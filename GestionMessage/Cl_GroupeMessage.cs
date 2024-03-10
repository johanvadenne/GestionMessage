using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

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
        private string colonne = "LabelGroupeMessage";
        //
        // constructeur
        //
        public Cl_GroupeMessage()
        {
            _IdGroupeMessage = 0;
            _LabelGroupeMessage = "";
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
        // LabelGroupeMessage
        //
        public string insertValeur()
        {
            return "'" + LabelGroupeMessage + "'";
        }
        //
        // override insert
        //
        public override void insert()
        {
            string reqSQL = "INSERT INTO " + Table + " (" + colonne + ") VALUES(" + insertValeur() + ");";
            this.connexionBDD();
            SQLiteCommand commande = new SQLiteCommand(reqSQL, this.maConnexion);
            commande.ExecuteNonQuery();
        }
    }
}
