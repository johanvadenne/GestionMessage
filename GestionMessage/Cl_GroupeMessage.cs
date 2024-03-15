using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Data.Entity.Infrastructure;

namespace GestionMessage
{
    public class Cl_GroupeMessage : Cl_BDD
    {
        //
        // variables
        //
        private int _IdGroupeMessage;
        private string _LabelGroupeMessage;
        //
        // constructeur
        //
        public Cl_GroupeMessage(int IdGroupeMessageRecu, string LabelGroupeMessageRecu)
        {
            _IdGroupeMessage = IdGroupeMessageRecu;
            LabelGroupeMessage = LabelGroupeMessageRecu;
        }
        //
        // IdGroupeMessage
        //
        public int IdGroupeMessage
        {
            get {return _IdGroupeMessage;}
        }
        //
        // LabelGroupeMessage
        //
        public string LabelGroupeMessage
        {
            get { return _LabelGroupeMessage; }
            set {
                if (value.Length <= 100) // vérifie la taille de value
                {
                    _LabelGroupeMessage = value;
                }
                else
                {
                    Cl_AfficheMessageBox.MessageAlerte("Le label groupe message ne peux comporter plus de 100 charactères");
                }
            }
        }
        //
        // savoir si l'on peux enrigistrer
        //
        public override bool ValeurCorrecte()
        {
            if (LabelGroupeMessage.Length > 100)
            {
                Cl_AfficheMessageBox.MessageAlerte("Le label groupe message ne peux comporter plus de 100 charactères");
                return false;
            }

            return true;
        }
        //
        // override insert
        //
        public override void Insert()
        {
            if (ValeurCorrecte()) // vérifie la taille de LabelGroupeMessage
            {
                // création de la requete
                string requete =
                    "INSERT INTO T_GroupeMessage " +
                    "(LabelGroupeMessage) VALUES(@LabelGroupeMessage);";

                SQLiteCommand command = new SQLiteCommand(requete, this.MaConnexion); // créer la commande

                command.Parameters.AddWithValue("@LabelGroupeMessage", LabelGroupeMessage); // Ajouter des paramètres à la commande

                this.MaConnexion.Open(); // ouvre la connexion à la base de données
                command.ExecuteNonQuery(); // execute la requête
                this.MaConnexion.Close(); // ferme la connexion à la base de données
            }
        }
        //
        // override update
        //
        public override void Update()
        {
            if (ValeurCorrecte()) // vérifie la taille de LabelGroupeMessage
            {
                // création de la requete
                string requete =
                    "UPDATE T_GroupeMessage " +
                    " SET LabelGroupeMessage = @LabelGroupeMessage" +
                    " WHERE IdGroupeMessage = @IdGroupeMessage;";

                SQLiteCommand command = new SQLiteCommand(requete, this.MaConnexion);  // créer la commande

                // Ajouter des paramètres à la commande
                command.Parameters.AddWithValue("@LabelGroupeMessage", LabelGroupeMessage);
                command.Parameters.AddWithValue("@IdGroupeMessage", IdGroupeMessage);

                this.MaConnexion.Open(); // ouvre la connexion à la base de données
                command.ExecuteNonQuery(); // execute la requête
                this.MaConnexion.Close(); // ferme la connexion à la base de données
            }
}
        //
        // override delete
        //
        public override void Delete()
        {
            // création de la requete
            string requete =
                "DELETE FROM T_GroupeMessage " +
                " WHERE IdGroupeMessage = @IdGroupeMessage;";
            
            SQLiteCommand command = new SQLiteCommand(requete, this.MaConnexion); // créer la commande

            command.Parameters.AddWithValue("@IdGroupeMessage", IdGroupeMessage); // Ajouter des paramètres à la commande

            this.MaConnexion.Open(); // ouvre la connexion à la base de données
            command.ExecuteNonQuery(); // execute la requête
            this.MaConnexion.Close(); // ferme la connexion à la base de données
        }
        //
        // override ToString
        //
        public override string ToString()
        {
            return IdGroupeMessage.ToString() + " - " + LabelGroupeMessage;
        }
    }
}
