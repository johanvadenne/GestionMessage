using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace GestionMessage
{
    public class Cl_TypeMessage : Cl_BDD
    {
        //
        // variables
        //
        private int _IdTypeMessage;
        private string _LabelTypeMessage;
        //
        // constructeur
        //
        public Cl_TypeMessage(int IdTypeMessageRecu, string LabelTypeMessageRecu)
        {
            _IdTypeMessage = IdTypeMessageRecu;
            LabelTypeMessage = LabelTypeMessageRecu;
        }
        //
        // IdTypeMessage
        //
        public int IdTypeMessage
        {
            get { return _IdTypeMessage; }
        }
        //
        // LabelTypeMessage
        //
        public string LabelTypeMessage
        {
            get { return _LabelTypeMessage; }
            set
            {
                if (value.Length <= 20) // vérifie la taille de value
                {
                    _LabelTypeMessage = value;
                }
                else
                {
                    Cl_AfficheMessageBox.MessageInformation("Le label type message ne peux comporter plus de 20 charactères");
                }
            }
        }
        //
        // Vérifie si toutes les données sont bien normées
        //
        public override bool ValeurCorrecte()
        {
            if (LabelTypeMessage.Length > 20) // vérifie la taille
            {
                Cl_AfficheMessageBox.MessageAlerte("Le label type message ne peux comporter plus de 20 charactères");
                return false;
            }

            return true;
        }
        //
        // override insert
        //
        public override void Insert()
        {
            try
            {
                if (ValeurCorrecte()) // Vérifie si toutes les données sont bien normées
                {
                    // création de la requête INSERT
                    string RequeteSQL = """
                        INSERT INTO T_TypeMessage
                        (LabelTypeMessage) VALUES(@LabelTypeMessage);
                        """;

                    SQLiteCommand CommandSQLite = new SQLiteCommand(RequeteSQL, this.MaConnexion); // création de la commande SQLite

                    // Ajout des paramètres a la requête préparer
                    CommandSQLite.Parameters.AddWithValue("@LabelTypeMessage", LabelTypeMessage);

                    this.MaConnexion.Open(); // ouvre la connexion à la base de données
                    CommandSQLite.ExecuteNonQuery(); // Exécute la commande INSERT
                    this.MaConnexion.Close(); // ferme la connexion à la base de données
                }
            }
            catch
            {
                Cl_AfficheMessageBox.MessageAlerte("Une erreur s'est produite. Veuillez contacter les développeurs.\nCode erreur 006");
            }
        }
        //
        // override update
        //
        public override void Update()
        {
            try
            {
                if (ValeurCorrecte()) // Vérifie si toutes les données sont bien normées
                {
                    // création de la requête UPDATE
                    string RequeteSQL = """
                        UPDATE T_TypeMessage
                        SET LabelTypeMessage = @LabelTypeMessage
                        WHERE IdTypeMessage = @IdTypeMessage;
                    """;

                    SQLiteCommand CommandSQLite = new SQLiteCommand(RequeteSQL, this.MaConnexion);  // création de la commande SQLite

                    // Ajout des paramètres a la requête préparer
                    CommandSQLite.Parameters.AddWithValue("@LabelTypeMessage", LabelTypeMessage);
                    CommandSQLite.Parameters.AddWithValue("@IdTypeMessage", IdTypeMessage);

                    this.MaConnexion.Open(); // ouvre la connexion à la base de données
                    CommandSQLite.ExecuteNonQuery(); // Exécute la commande UPDATE
                    this.MaConnexion.Close(); // ferme la connexion à la base de données
                }
            }
            catch
            {
                Cl_AfficheMessageBox.MessageAlerte("Une erreur s'est produite. Veuillez contacter les développeurs.\nCode erreur 007");
            }
        }
        //
        // override delete
        //
        public override void Delete()
        {
            try
            {
                if (IdTypeMessage <= 0)
                {
                    Cl_AfficheMessageBox.MessageAlerte("Il n'y a aucun type message sélectionné!");
                    return;
                }

                // création de la requête DELETE
                string RequeteSQL = """
                    DELETE FROM T_TypeMessage
                    WHERE IdTypeMessage = @IdTypeMessage;
                    """;

                SQLiteCommand CommandSQLite = new SQLiteCommand(RequeteSQL, this.MaConnexion); // création de la commande SQLite

                // Ajout des paramètres a la requête préparer
                CommandSQLite.Parameters.AddWithValue("@IdTypeMessage", IdTypeMessage);

                this.MaConnexion.Open(); // ouvre la connexion à la base de données
                CommandSQLite.ExecuteNonQuery(); // Exécute la commande DELETE
                this.MaConnexion.Close(); // ferme la connexion à la base de données
            }
            catch
            {
                Cl_AfficheMessageBox.MessageAlerte("Une erreur s'est produite. Veuillez contacter les développeurs.\nCode erreur 008");
            }
}
        //
        // override ToString
        //
        public override string ToString()
        {
            return IdTypeMessage.ToString() + " - " + LabelTypeMessage;
        }
    }
}
