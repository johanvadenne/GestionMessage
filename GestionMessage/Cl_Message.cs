﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Data.SQLite;

namespace GestionMessage
{
    public class Cl_Message : Cl_BDD
    {
        //
        // variables
        //
        private int _IdGroupeMessage;
        private int _IdMessage;
        private int _IdTypeMessage;
        private string _CodeMessage;
        private string _Message;
        //
        // constructeur
        //
        public Cl_Message(int IdMessageRecu, int IdGroupeMessageRecu, int IdTypeMessageRecu, string CodeMessageRecu, string MessageRecu)
        {
            _IdGroupeMessage = IdGroupeMessageRecu;
            _IdMessage = IdMessageRecu;
            _IdTypeMessage = IdTypeMessageRecu;
            CodeMessage = CodeMessageRecu;
            _Message = MessageRecu;

            if (CodeMessage.Length > 4)
            {
                Cl_AfficheMessageBox.MessageAlerte("Le code message fait plus de 4 charactères");
            }
            else if (Message.Length > 255)
            {
                Cl_AfficheMessageBox.MessageAlerte("Le message fait plus de 255 charactères");
            }
        }
        //
        // IdGroupeMessage
        //
        public int IdGroupeMessage 
        {
            get { return _IdGroupeMessage; }
            set { _IdGroupeMessage = value;}
        }
        //
        // IdMessage
        //
        public int IdMessage
        {
            get { return _IdMessage; }
        }
        //
        // TypeMessage
        //
        public int IdTypeMessage
        {
            get { return _IdTypeMessage; }
            set { _IdTypeMessage = value;}
        }
        //
        // CodeMessage
        //
        public string CodeMessage
        {
            get { return _CodeMessage; }
            set { 
                if(value.Length > 4) {
                    Cl_AfficheMessageBox.MessageAlerte("Le code ne peux comporter plus de 4 charactères");
                }
                else {
                    _CodeMessage = value.PadLeft(4, '0');
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
                if (value.Length > 255)
                {
                    Cl_AfficheMessageBox.MessageAlerte("Le code ne peux comporter plus de 255 charactères");
                }
                else
                {
                    _Message = value;
                }
            }
        }
        //
        // vérifie si les valeurs sont valide
        //
        private bool enregistrer()
        {
            if (CodeMessage.Length > 4) // vérifie la taille de LabelGroupeMessage
            {
                Cl_AfficheMessageBox.MessageAlerte("Le code ne peux comporter plus de 4 charactères");
                return false;
            }
            else if (Message.Length > 255)
            {
                Cl_AfficheMessageBox.MessageAlerte("Le code ne peux comporter plus de 255 charactères");
                return false;
            }
            else if (IdGroupeMessage <= 0)
            {
                Cl_AfficheMessageBox.MessageAlerte("Le groupe de message n'ai pas définie");
                return false;
            }
            else if (IdTypeMessage <= 0)
            {
                Cl_AfficheMessageBox.MessageAlerte("Le type de message n'ai pas définie");
                return false;
            }
            else
            {
                return true;
            }
        }
        //
        // override insert
        //
        public override void insert()
        {
            if (!enregistrer()) { return; }
            
            // création de la requete
            string requete = """
                INSERT INTO T_Message (IdGroupeMessage,IdTypeMessage,CodeMessage,Message)
                VALUES(@IdGroupeMessage,@IdTypeMessage,@CodeMessage,@Message);
                """;

            SQLiteCommand command = new SQLiteCommand(requete, this.maConnexion); // créer la commande

            // Ajouter des paramètres à la commande
            command.Parameters.AddWithValue("@IdGroupeMessage", IdGroupeMessage);
            command.Parameters.AddWithValue("@IdTypeMessage", IdTypeMessage);
            command.Parameters.AddWithValue("@CodeMessage", CodeMessage);
            command.Parameters.AddWithValue("@Message", Message);

            this.maConnexion.Open(); // ouvre la connexion à la base de données
            command.ExecuteNonQuery(); // execute la requête
            this.maConnexion.Close(); // ferme la connexion à la base de données
        }
        //
        // override update
        //
        public override void update()
        {
            if (!enregistrer()) { return; }

            // création de la requete
            string requete = """
                UPDATE T_Message 
                SET 
                    IdGroupeMessage=@IdGroupeMessage,
                    IdTypeMessage=@IdTypeMessage,
                    CodeMessage=@CodeMessage,
                    Message=@Message
                WHERE 
                    IdMessage = @IdMessage;
                """;

            SQLiteCommand command = new SQLiteCommand(requete, this.maConnexion); // créer la commande

            // Ajouter des paramètres à la commande
            command.Parameters.AddWithValue("@IdGroupeMessage", IdGroupeMessage);
            command.Parameters.AddWithValue("@IdTypeMessage", IdTypeMessage);
            command.Parameters.AddWithValue("@CodeMessage", CodeMessage);
            command.Parameters.AddWithValue("@Message", Message);
            command.Parameters.AddWithValue("@IdMessage", IdMessage);

            this.maConnexion.Open(); // ouvre la connexion à la base de données
            command.ExecuteNonQuery(); // execute la requête
            this.maConnexion.Close(); // ferme la connexion à la base de données
        }
        //
        // override delete
        //
        public override void delete()
        {
            // création de la requete
            string requete = """
                DELETE FROM T_Message
                WHERE IdMessage = @IdMessage;
                """;

            SQLiteCommand command = new SQLiteCommand(requete, this.maConnexion); // créer la commande

            command.Parameters.AddWithValue("@IdMessage", IdMessage); // Ajouter des paramètres à la commande

            this.maConnexion.Open(); // ouvre la connexion à la base de données
            command.ExecuteNonQuery(); // execute la requête
            this.maConnexion.Close(); // ferme la connexion à la base de données
        }
        //
        // override ToString
        //
        public override string ToString()
        {
            return "code: " + CodeMessage;
        }
    }
}
