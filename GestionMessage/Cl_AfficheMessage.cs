using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMessage
{
    public partial class Cl_AfficheMessage
    {
        public static void MessageErreur(string message)
        {
            MessageBox.Show(message, "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
