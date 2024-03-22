using System.Data.SQLite;
using System.Security.Cryptography;
using System.Text;

namespace GestionMessage
{
    public class Cl_Utilisateur : Cl_BDD
    {
        //
        // Variables
        //
        private string _NomUtilisateur;
        private string _MotDePasse;
        //
        // constructeur
        //
        public Cl_Utilisateur(string NomUtilisateurRecu, string MotDePasseRecu)
        {
            _NomUtilisateur = NomUtilisateurRecu;
            _MotDePasse = MotDePasseRecu;
        }
        //
        // NomUtilisateur
        //
        public string NomUtilisateur
        {
            get { return _NomUtilisateur; }
            set { _NomUtilisateur = value; }
        }
        //
        // NomUtilisateur
        //
        public string MotDePasse
        {
            private get { return _MotDePasse; }
            set { _MotDePasse = value; }
        }
        //
        // Permets de hacher une chaine en sha256
        //
        public string HachSHA256(string Chaine)
        {
            try
            {
                // Convertir la chaîne en tableau de bytes
                byte[] BytesChaine = Encoding.UTF8.GetBytes(Chaine);

                // Créer un objet de l'algorithme de hachage SHA256
                SHA256 Sha256Hash = SHA256.Create();

                // Calculer le hachage
                byte[] BytesHache = Sha256Hash.ComputeHash(BytesChaine);

                // Convertir le tableau de bytes en une chaîne hexadécimale
                StringBuilder StrBuilder = new StringBuilder();
                for (int i = 0; i < BytesHache.Length; i++)
                {
                    StrBuilder.Append(BytesHache[i].ToString("x2"));
                }

                return StrBuilder.ToString();
            }
            catch
            {
                Cl_AfficheMessageBox.MessageAlerte("Une erreur s'est produite. Veuillez contacter les développeurs.\nCode erreur 001");
                return "";
            }
        }
        //
        // Retourne vrai au faux si l'utilisateur est existant
        //
        public bool utilisateurConnexion()
        {
            try
            {
                if (!ValeurCorrecte()) { return false; }

                // Création de la requette SQL
                string RequeteSQL = """
                    SELECT 
                        IdUtilisateur 
                    FROM 
                        T_Utilisateur
                    WHERE
                        NomUtilisateur = @NomUtilisateur
                        AND MotDePasse = @MotDePasse;
                    """;

                SQLiteCommand CommandSQLite = new SQLiteCommand(RequeteSQL, this.MaConnexion); // création de la commande SQLite

                // Ajout des paramètres a la requête préparer
                CommandSQLite.Parameters.AddWithValue("@NomUtilisateur", HachSHA256(_NomUtilisateur));
                CommandSQLite.Parameters.AddWithValue("@MotDePasse", HachSHA256(_MotDePasse));


                this.MaConnexion.Open(); // ouvre la connexion à la base de données
                SQLiteDataReader LectureRequete = CommandSQLite.ExecuteReader(); // Exécute la commande en mode lecture

                int IdUtilisateurLu = 0;

                // récupère l'IdUtilisateur
                while (LectureRequete.Read())
                {
                    IdUtilisateurLu = LectureRequete.GetInt32(0);
                }
                LectureRequete.Close(); // ferme la lecture de la requête
                this.MaConnexion.Close(); // ferme la connexion à la base de données

                // si l'utilisateur existe on retourn vrai, sinon faux
                if (IdUtilisateurLu > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                Cl_AfficheMessageBox.MessageAlerte("Une erreur s'est produite. Veuillez contacter les développeurs.\nCode erreur 002");
                return false;
            }
        }
        //
        // Vérifie si toutes les données sont bien normées
        //
        public override bool ValeurCorrecte()
        {
            if (NomUtilisateur == "")
            {
                Cl_AfficheMessageBox.MessageAlerte("Vous devez rentrer un nom utilisateur!");
                return false;
            }
            else if (MotDePasse == "")
            {
                Cl_AfficheMessageBox.MessageAlerte("Vous devez rentrer un mot de passe!");
                return false;
            }
            return true;
        }
        //
        // fonction et procédure abstraite non utilisée
        //
        public override string ToString() { return NomUtilisateur; }
        public override void Delete() { }
        public override void Insert() { }
        public override void Update() { }
    }
}
