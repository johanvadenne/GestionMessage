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
        //
        // variables
        //
        private int _IdGroupeMessage;
        private int _IdMessage;
        private string _CodeMessage;
        private string _TypeMessage;
        private string _Message;
        //
        // constructeur
        //
        public Cl_Message()
        {
            _IdGroupeMessage = 0;
            _IdMessage = 0;
            _CodeMessage = "";
            _TypeMessage = "";
            _Message = "";
        }
        //
        // IdGroupeMessage
        //
        public int IdGroupeMessage 
        {
            get { return IdGroupeMessage; }
        }
        //
        // IdMessage
        //
        public int IdMessage
        {
            get { return _IdMessage; }
        }
        //
        // CodeMessage
        //
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
        //
        // TypeMessage
        //
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
        //
        // Message
        //
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
    }
}
