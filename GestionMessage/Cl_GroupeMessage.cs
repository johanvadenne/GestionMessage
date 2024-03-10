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
                if (value.Length <= 100)
                {
                    _LabelGroupeMessage = value;
                }
                else
                {
                    Cl_AfficheMessage.MessageErreur("Le label groupe message ne peux comporter plus de 100 charactères");
                }
            }
        }
        //
        // override insert
        //
        public override void insert()
        {
            // création de la requete
            string requete = 
                "INSERT INTO " + Table + 
                " (LabelGroupeMessage) VALUES(@LabelGroupeMessage);";

            SQLiteCommand command = new SQLiteCommand(requete, this.maConnexion);
            
            // Ajouter des paramètres à la commande
            command.Parameters.AddWithValue("@LabelGroupeMessage", LabelGroupeMessage);

            this.maConnexion.Open();
            command.ExecuteNonQuery();
            this.maConnexion.Close();
        }
        //
        // override update
        //
        public override void update()
        {

        }
        //
        // override delete
        //
        public override void delete()
        {
            // création de la requete
            string requete =
                "DELETE FROM " + Table +
                " WHERE IdGroupeMessage = " + IdGroupeMessage + ";";
            
            SQLiteCommand command = new SQLiteCommand(requete, this.maConnexion);
            
            this.maConnexion.Open();
            command.ExecuteNonQuery();
            this.maConnexion.Close();
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
