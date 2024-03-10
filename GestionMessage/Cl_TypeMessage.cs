using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionMessage
{
    public class Cl_TypeMessage
    {
        //
        // variables
        //
        private int _IdTypeMessage;
        private string _LabelTypeMessage;
        //
        // constructeur
        //
        public Cl_TypeMessage()
        {
            _IdTypeMessage = 0;
            _LabelTypeMessage = "";
        }
        //
        // IdTypeMessage
        //
        public int IdTypeMessage
        {
            get {return _IdTypeMessage; }
        }
        //
        // LabelTypeMessage
        //
        public string LabelTypeMessage
        {
            get { return _LabelTypeMessage; }
            set {
                if (value.Length <= 20)
                {
                    _LabelTypeMessage = value;
                }
                else
                {
                    Cl_AfficheMessage.MessageErreur("Le label groupe message ne peux comporter plus de 20 charactères");
                }
            }
        }
    }
}
