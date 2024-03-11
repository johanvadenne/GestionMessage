using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMessage
{
    public partial class Cl_AfficheMessageBox
    {
        //
        // Erreur
        public static void MessageErreur(string message)
        {
            MessageBox.Show(message, "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }

        public static void MessageAlerte(string message)
        {
            MessageBox.Show(message, "ALERTE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
