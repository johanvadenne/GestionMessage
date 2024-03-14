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
                    Cl_AfficheMessageBox.MessageAlerte("Le label type message ne peux comporter plus de 20 charactères");
                }
            }
        }
        //
        // savoir si l'on peux enrigistrer
        //
        public override bool valeurCorrect()
        {
            if (LabelTypeMessage.Length > 20)
            {
                Cl_AfficheMessageBox.MessageAlerte("Le label type message ne peux comporter plus de 20 charactères");
                return false;
            }

            return true;
        }
        //
        // override insert
        //
        public override void insert()
        {
            if (valeurCorrect()) // vérifie la taille de LabelGroupeMessage
            {
                // création de la requete
                string requete = """
                    INSERT INTO T_TypeMessage
                    (LabelTypeMessage) VALUES(@LabelTypeMessage);
                    """;

                SQLiteCommand command = new SQLiteCommand(requete, this.maConnexion); // créer la commande

                command.Parameters.AddWithValue("@LabelTypeMessage", LabelTypeMessage); // Ajouter des paramètres à la commande

                this.maConnexion.Open(); // ouvre la connexion à la base de données
                command.ExecuteNonQuery(); // execute la requête
                this.maConnexion.Close(); // ferme la connexion à la base de données
            }
        }
        //
        // override update
        //
        public override void update()
        {
            if (valeurCorrect()) // vérifie la taille de LabelGroupeMessage
            {
                // création de la requete
                string requete =
                    "UPDATE T_TypeMessage " +
                    " SET LabelTypeMessage = @LabelTypeMessage" +
                    " WHERE IdTypeMessage = @IdTypeMessage;";

                SQLiteCommand command = new SQLiteCommand(requete, this.maConnexion);  // créer la commande

                // Ajouter des paramètres à la commande
                command.Parameters.AddWithValue("@LabelTypeMessage", LabelTypeMessage);
                command.Parameters.AddWithValue("@IdTypeMessage", IdTypeMessage);

                this.maConnexion.Open(); // ouvre la connexion à la base de données
                command.ExecuteNonQuery(); // execute la requête
                this.maConnexion.Close(); // ferme la connexion à la base de données
            }
        }
        //
        // override delete
        //
        public override void delete()
        {
            // création de la requete
            string requete =
                "DELETE FROM T_TypeMessage " +
                " WHERE IdTypeMessage = @IdTypeMessage;";

            SQLiteCommand command = new SQLiteCommand(requete, this.maConnexion); // créer la commande

            command.Parameters.AddWithValue("@IdTypeMessage", IdTypeMessage); // Ajouter des paramètres à la commande

            this.maConnexion.Open(); // ouvre la connexion à la base de données
            command.ExecuteNonQuery(); // execute la requête
            this.maConnexion.Close(); // ferme la connexion à la base de données
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
