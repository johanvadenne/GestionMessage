﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace GestionMessage
{
    internal class Cl_ConnexionBDD : Cl_BDD
    {
        public SQLiteConnection Connexion
        {
            get {  return this.MaConnexion; }
        }

        public override bool ValeurCorrecte() { return false; }
        public override void Insert() {}
        public override void Update() {}
        public override void Delete() {}
        public override string ToString() { return ""; }
    }
}
