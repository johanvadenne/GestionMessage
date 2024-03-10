using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace GestionMessage
{
    internal class Cl_ConnexionBDD : Cl_BDD
    {
        public SQLiteConnection connexion
        {
            get {  return this.maConnexion; }
        }

        public override void insert() {}
        public override void update() {}
        public override void delete() {}
        public override string ToString() { return ""; }
    }
}
