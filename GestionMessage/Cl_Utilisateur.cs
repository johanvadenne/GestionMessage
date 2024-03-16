using System.Text;
using System.Security.Cryptography;
using System.Data.SQLite;

namespace GestionMessage
{
    public class Cl_Utilisateur: Cl_BDD
    {
        //
        // Variables
        //
        private string NomUtilisateur;
        private string MotDePasse;
        //
        // constructeur
        //
        public Cl_Utilisateur(string NomUtilisateurRecu, string MotDePasseRecu)
        {
            NomUtilisateur = NomUtilisateurRecu;
            MotDePasse = MotDePasseRecu;
        }
        //
        // Permet de hacher une chaine en sha256
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
                CommandSQLite.Parameters.AddWithValue("@NomUtilisateur", HachSHA256(NomUtilisateur)); 
                CommandSQLite.Parameters.AddWithValue("@MotDePasse", HachSHA256(MotDePasse));
                
                this.MaConnexion.Open(); // ouvre la connexion à la base de données
                SQLiteDataReader LectureRequete = CommandSQLite.ExecuteReader(); // execute la commande en mode lecture

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
        // fonction et procédure abstraite non utilisée
        //
        public override string ToString() { return NomUtilisateur; }
        public override void Delete() { }
        public override void Insert() { }
        public override void Update() { }
        public override bool ValeurCorrecte() { return false; }
    }
}
