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
        private string Table = "T_GroupeMessage";
        //
        // constructeur
        //
        public Cl_GroupeMessage(int IdGroupeMessageRecu, string LabelGroupeMessageRecu)
        {
            _IdGroupeMessage = IdGroupeMessageRecu;
            _LabelGroupeMessage = LabelGroupeMessageRecu;

            if (_LabelGroupeMessage.Length > 100) // vérifie la taille de _LabelGroupeMessageRecu
            {
                Cl_AfficheMessage.MessageAlerte("Le label groupe message ne peux comporter plus de 100 charactères");
            }
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
                    Cl_AfficheMessage.MessageAlerte("Le label groupe message ne peux comporter plus de 100 charactères");
                }
            }
        }
        //
        // override insert
        //
        public override void insert()
        {
            if (LabelGroupeMessage.Length <= 100) // vérifie la taille de LabelGroupeMessage
            {
                // création de la requete
                string requete =
                    "INSERT INTO " + Table +
                    " (LabelGroupeMessage) VALUES(@LabelGroupeMessage);";

                SQLiteCommand command = new SQLiteCommand(requete, this.maConnexion); // créer la commande

                command.Parameters.AddWithValue("@LabelGroupeMessage", LabelGroupeMessage); // Ajouter des paramètres à la commande

                this.maConnexion.Open(); // ouvre la connexion à la base de données
                command.ExecuteNonQuery(); // execute la requête
                this.maConnexion.Close(); // ferme la connexion à la base de données
            }
            else
            {
                Cl_AfficheMessage.MessageAlerte("Le label groupe message ne peux comporter plus de 100 charactères");
            }
        }
        //
        // override update
        //
        public override void update()
        {
            if (LabelGroupeMessage.Length <= 100) // vérifie la taille de LabelGroupeMessage
            {
                // création de la requete
                string requete =
                    "UPDATE " + Table +
                    " SET LabelGroupeMessage = @LabelGroupeMessage" +
                    " WHERE IdGroupeMessage = @IdGroupeMessage;";

                SQLiteCommand command = new SQLiteCommand(requete, this.maConnexion);  // créer la commande

                // Ajouter des paramètres à la commande
                command.Parameters.AddWithValue("@LabelGroupeMessage", LabelGroupeMessage);
                command.Parameters.AddWithValue("@IdGroupeMessage", IdGroupeMessage);

                this.maConnexion.Open(); // ouvre la connexion à la base de données
                command.ExecuteNonQuery(); // execute la requête
                this.maConnexion.Close(); // ferme la connexion à la base de données
            }
            else
            {
                Cl_AfficheMessage.MessageAlerte("Le label groupe message ne peux comporter plus de 100 charactères");
            }
}
        //
        // override delete
        //
        public override void delete()
        {
            // création de la requete
            string requete =
                "DELETE FROM " + Table +
                " WHERE IdGroupeMessage = @IdGroupeMessage;";
            
            SQLiteCommand command = new SQLiteCommand(requete, this.maConnexion); // créer la commande

            command.Parameters.AddWithValue("@IdGroupeMessage", IdGroupeMessage); // Ajouter des paramètres à la commande

            this.maConnexion.Open(); // ouvre la connexion à la base de données
            command.ExecuteNonQuery(); // execute la requête
            this.maConnexion.Close(); // ferme la connexion à la base de données
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
