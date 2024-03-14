using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data.SQLite;
using System.Text.RegularExpressions;

namespace GestionMessage
{
    public class Cl_Utilisateur: Cl_BDD
    {
        private string _NomUtilisateur;
        private string _MotDePasse;
        private string _TypeAuthentification;

        
        public Cl_Utilisateur(string nomUtilisateur, string motDePasse, string typeAuthentification)
        {
            _NomUtilisateur = nomUtilisateur;
            _MotDePasse = motDePasse;
            _TypeAuthentification = typeAuthentification;
        }

        public string NomUtilisateur
        {
            get { return _NomUtilisateur; }
            set { _NomUtilisateur = value;}
        }

        public string TypeAuthentification
        {
            get { return _TypeAuthentification; }
            set { _TypeAuthentification = value;}
        }

        public string WINDOWS
        {
            get { return "WINDOWS"; }
        }

        public string MANUELLE
        {
            get { return "MANUELLE"; }
        }

        public override string ToString() { return _NomUtilisateur; }
        public override void delete()
        {
            throw new NotImplementedException();
        }
        public override void insert()
        {
            throw new NotImplementedException();
        }
        public override void update()
        {
            throw new NotImplementedException();
        }
        public override bool valeurCorrect()
        {
            if (_TypeAuthentification == MANUELLE && !motDePasseCorrect())
            {
                Cl_AfficheMessageBox.MessageAlerte("Le mot de passe dois comporter au moins:\n- 12 charactères\n- 1 majuscule\n- 1 minuscule\n- 1 chiffre\n- 1 charactère spéciale");
                return false;
            }

            return true;
        }
        public bool motDePasseCorrect()
        {
            Regex regex = new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{12,}$");
            return regex.IsMatch(_MotDePasse);
        }

        public string hachSHA256(string chaine)
        {
            // Convertir la chaîne en tableau de bytes
            byte[] bytesTexteOriginal = Encoding.UTF8.GetBytes(chaine);

            // Créer un objet de l'algorithme de hachage SHA256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Calculer le hachage
                byte[] bytesHache = sha256Hash.ComputeHash(bytesTexteOriginal);

                // Convertir le tableau de bytes en une chaîne hexadécimale
                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < bytesHache.Length; i++)
                {
                    strBuilder.Append(bytesHache[i].ToString("x2"));
                }

                return strBuilder.ToString();
            }
        }

        public bool utilisateurConnexion()
        {
            if (!valeurCorrect()) { return false; }

            string requete;
            if (_TypeAuthentification == WINDOWS) 
            { 
                requete = """
                    SELECT 
                        IdUtilisateur 
                    FROM 
                        T_Utilisateur
                    WHERE
                        NomUtilisateur = @NomUtilisateur;
                    """;
            }
            else if (_TypeAuthentification == MANUELLE)
            {
                requete = """
                    SELECT 
                        IdUtilisateur 
                    FROM 
                        T_Utilisateur
                    WHERE
                        NomUtilisateur = @NomUtilisateur
                        AND MotDePasse = @MotDePasse;
                    """;
            }
            else
            {
                Cl_AfficheMessageBox.MessageAlerte("Le type d'authentification n'est pas définie!");
                return false;
            }

            SQLiteCommand command = new SQLiteCommand(requete, this.maConnexion); // créer la commande

            if (_TypeAuthentification == WINDOWS)
            {
                command.Parameters.AddWithValue("@NomUtilisateur", hachSHA256(_NomUtilisateur)); // Ajouter des paramètres à la commande
            }
            else if (_TypeAuthentification == MANUELLE)
            {
                command.Parameters.AddWithValue("@NomUtilisateur", hachSHA256(_NomUtilisateur)); // Ajouter des paramètres à la commande
                command.Parameters.AddWithValue("@MotDePasse", hachSHA256(_MotDePasse)); // Ajouter des paramètres à la commande
            }
            else
            {
                Cl_AfficheMessageBox.MessageAlerte("Le type d'authentification n'est pas définie!");
                return false;
            }


            this.maConnexion.Open(); // ouvre la connexion à la base de données

            SQLiteDataReader reader = command.ExecuteReader(); // execute la commande en mode lecture

            int IdUtilisateurLu = 0;

            while (reader.Read())
            {
                IdUtilisateurLu = reader.GetInt32(0);
            }
            reader.Close();
            this.maConnexion.Close(); // ferme la connexion à la base de données

            if (IdUtilisateurLu > 0)
            {
                return true;
            }
            else 
            { 
                return false; 
            }
        }
    }
}
