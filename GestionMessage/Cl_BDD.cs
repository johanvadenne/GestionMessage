using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace GestionMessage
{
    public abstract class Cl_BDD
    {
        //
        // variable
        //
        public SQLiteConnection maConnexion;
        //
        // connexionBDD
        //
        public Cl_BDD()
        {
            string cheminBDD = "C:\\VADIT\\VADIT.db";
            char version = '3';
            string chaineDeConnexion = "Data Source=" + cheminBDD + ";Version=" + version + ";";

            maConnexion = new SQLiteConnection(chaineDeConnexion);
        }
        //
        // fonction abstraite insert,update,delete
        //
        public abstract void insert();
        public abstract void update();
        public abstract void delete();
        //
        // savoir si on peux enregistrer
        //
        public abstract bool valeurCorrect();
        //
        // ToString
        //
        public override abstract string ToString();
    }
}
