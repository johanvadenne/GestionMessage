using System.Data.SQLite;

namespace GestionMessage
{
    public abstract class Cl_BDD
    {
        //
        // variable
        //
        public SQLiteConnection MaConnexion = null;
        //
        // Connexion à la base de données
        //
        public Cl_BDD()
        {
            string CheminBDD = "..\\..\\..\\VADIT.db";
            char Version = '3';
            string ChaineDeConnexion = "Data Source=" + CheminBDD + ";Version=" + Version + ";";
            
            // test de connexion à la base de données
            try
            {
                MaConnexion = new SQLiteConnection(ChaineDeConnexion);
                SQLiteCommand CommandSQLite = new SQLiteCommand("SELECT * FROM T_TypeMessage;", MaConnexion);
                MaConnexion.Open();
                CommandSQLite.ExecuteNonQuery();
                MaConnexion.Close();    
            }
            // Si une erreur est survenue alors afficher l'erreur et fermer l'application
            catch
            {
                Cl_AfficheMessageBox.MessageErreur("La connexion à la base de données à échouée!");
            }
        }
        //
        // fonction abstraite insert, update, delete
        //
        public abstract void Insert();
        public abstract void Update();
        public abstract void Delete();
        //
        // Cette procédure abstraite affiche la valeur incorrecte liée aux données de la classe
        //
        public abstract bool ValeurCorrecte();
        //
        // ToString
        //
        public override abstract string ToString();
    }
}
