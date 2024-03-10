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
        public void connexionBDD()
        {
            string cheminBDD = "C:\\VADIT\\VADIT.db";
            char version = '3';
            string chaineDeConnexion = "Data Source=" + cheminBDD + ";Version=" + version + ";";

            maConnexion = new SQLiteConnection(chaineDeConnexion);
            maConnexion.Open();
        }
        //
        // insert
        //
        public abstract void insert();
        //
        // update
        //
        public abstract void update();
        //
        // delete
        //
        public abstract void delete();
    }
}
