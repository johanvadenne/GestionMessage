using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Data.SQLite;

namespace GestionMessage
{
    public class Cl_Message : Cl_BDD
    {
        //
        // variables
        //
        private int _IdGroupeMessage;
        private int _IdMessage;
        private string _CodeMessage;
        private string _IdTypeMessage;
        private string _Message;
        //
        // constructeur
        //
        public Cl_Message(int IdGroupeMessage, int IdMessage, string CodeMessage, string TypeMessage, string Message)
        {
            _IdGroupeMessage = IdGroupeMessage;
            _IdMessage = IdMessage;
            _CodeMessage = CodeMessage;
            _IdTypeMessage = TypeMessage;
            _Message = Message;
        }
        //
        // IdGroupeMessage
        //
        public int IdGroupeMessage 
        {
            get { return IdGroupeMessage; }
            set { _IdGroupeMessage = value;}
        }
        //
        // IdMessage
        //
        public int IdMessage
        {
            get { return _IdMessage; }
        }
        //
        // CodeMessage
        //
        public string CodeMessage
        {
            get { return _CodeMessage; }
            set { 
                if(value.Length <= 3) {
                    _CodeMessage = value;
                }
                else {
                    Cl_AfficheMessageBox.MessageAlerte("Le code ne peux comporter plus de 4 charactères");
                }
            }
        }
        //
        // TypeMessage
        //
        public string IdTypeMessage
        {
            get { return _IdTypeMessage; }
            set { _IdTypeMessage = value;}
        }
        //
        // Message
        //
        public string Message
        {
            get { return _Message; }
            set
            {
                if (value.Length <= 255)
                {
                    _Message = value;
                }
                else
                {
                    Cl_AfficheMessageBox.MessageAlerte("Le code ne peux comporter plus de 255 charactères");
                }
            }
        }
        //
        // si l'enregistrement est possible
        //
        private bool enregistrer()
        {
            if (CodeMessage.Length > 4) // vérifie la taille de LabelGroupeMessage
            {
                Cl_AfficheMessageBox.MessageAlerte("Le code ne peux comporter plus de 4 charactères");
                return false;
            }
            else if (Message.Length > 255)
            {
                Cl_AfficheMessageBox.MessageAlerte("Le code ne peux comporter plus de 255 charactères");
                return false;
            }
            else
            {
                return true;
            }
        }
        //
        // override insert
        //
        public override void insert()
        {
            if (!enregistrer()) { return; }
        }
        //
        // override update
        //
        public override void update()
        {
            if (!enregistrer()) { return; }
        }
        //
        // override delete
        //
        public override void delete()
        {
            // création de la requete
            string requete =
                "DELETE FROM T_Message " +
                " WHERE IdMessage = @IdMessage;";

            SQLiteCommand command = new SQLiteCommand(requete, this.maConnexion); // créer la commande

            command.Parameters.AddWithValue("@IdMessage", IdMessage); // Ajouter des paramètres à la commande

            this.maConnexion.Open(); // ouvre la connexion à la base de données
            command.ExecuteNonQuery(); // execute la requête
            this.maConnexion.Close(); // ferme la connexion à la base de données
        }
        //
        // override ToString
        //
        public override string ToString()
        {
            return "code: " + CodeMessage;
        }
    }
}
