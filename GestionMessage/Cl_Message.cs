using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GestionMessage
{
    public class Cl_Message
    {
        private int _IdGroupeMessage = 0;
        private int _IdMessage = 0;
        private string _CodeMessage = "";
        private string _TypeMessage = "";
        private string _Message = "";

        public Cl_Message()
        {
            _IdGroupeMessage = 0;
            _IdMessage = 0;
            _CodeMessage = "";
            _TypeMessage = "";
            _Message = "";
        }

        public int IdGroupeMessage 
        {
            get { return IdGroupeMessage; }
        }

        public int IdMessage
        {
            get { return _IdMessage; }
        }

        public string CodeMessage
        {
            get { return _CodeMessage; }
            set { 
                if(value.Length <= 3) {
                    _CodeMessage = value;
                }
                else {
                    Cl_AfficheMessage.MessageErreur("Le code ne peux comporter plus de 4 charactères");
                }
            }
        }

        public string TypeMessage
        {
            get { return _TypeMessage; }
            set
            {
                if (value.Length <= 20)
                {
                    _TypeMessage = value;
                }
                else
                {
                    Cl_AfficheMessage.MessageErreur("Le code ne peux comporter plus de 20 charactères");
                }
            }
        }

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
                    Cl_AfficheMessage.MessageErreur("Le code ne peux comporter plus de 255 charactères");
                }
            }
        }

        // CodeMessage VARCHAR(4) NOT NULL,
        // TypeMessage VARCHAR(50) NOT NULL,
        // Message VARCHAR(255) NOT NULL,
    }
}
