using System.Data.SQLite;

namespace GestionMessage
{
    public class Cl_Message : Cl_BDD
    {
        //
        // variables
        //
        private int _IdMessage;
        private string _CodeMessage;
        private string _Message;
        private Cl_GroupeMessage _GroupeMessage;
        private Cl_TypeMessage _TypeMessage;
        //
        // constructeur
        //
        public Cl_Message(int IdMessageRecu, Cl_GroupeMessage GroupeMessageRecu, Cl_TypeMessage TypeMessageRecu, string CodeMessageRecu, string MessageRecu)
        {
            _IdMessage = IdMessageRecu;
            GroupeMessage = GroupeMessageRecu;
            TypeMessage = TypeMessageRecu;
            CodeMessage = CodeMessageRecu;
            Message = MessageRecu;
        }
        //
        // IdMessage
        //
        public int IdMessage
        {
            get { return _IdMessage; }
        }
        //
        // IdGroupeMessage
        //
        public int IdGroupeMessage
        {
            get { return _GroupeMessage.IdGroupeMessage; }
        }
        //
        // TypeMessage
        //
        public int IdTypeMessage
        {
            get { return _TypeMessage.IdTypeMessage; }
        }
        //
        // CodeMessage
        //
        public string CodeMessage
        {
            get { return _CodeMessage; }
            set
            {
                if (value.Length > 4)
                {
                    Cl_AfficheMessageBox.MessageInformation("Le code ne peut comporter plus de 4 caractères!");
                }
                else
                {
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
                    Cl_AfficheMessageBox.MessageInformation("Le code ne peut comporter plus de 255 caractères!");
                }
                else
                {
                    _Message = value;
                }
            }
        }
        //
        // GroupeMessage
        //
        public Cl_GroupeMessage GroupeMessage
        {
            get { return _GroupeMessage; }
            set { _GroupeMessage = value; }
        }
        //
        // TypeMessage
        //
        public Cl_TypeMessage TypeMessage
        {
            get { return _TypeMessage; }
            set { _TypeMessage = value; }
        }
        //
        // Vérifie si toutes les données sont bien normées
        //
        public override bool ValeurCorrecte()
        {
            if (CodeMessage.Length > 4) // vérifie la taille de LabelGroupeMessage
            {
                Cl_AfficheMessageBox.MessageAlerte("Le code ne peut comporter plus de 4 caractères!");
                return false;
            }
            else if (CodeMessage == "XXXX")
            {
                Cl_AfficheMessageBox.MessageAlerte("Le code XXXX est un mot réservé au logiciel!");
                return false;
            }
            else if (Message.Length > 255)
            {
                Cl_AfficheMessageBox.MessageAlerte("Le code ne peut comporter plus de 255 caractères!");
                return false;
            }
            else if (IdGroupeMessage <= 0)
            {
                Cl_AfficheMessageBox.MessageAlerte("Le groupe de message n'est pas définie!");
                return false;
            }
            else if (IdTypeMessage <= 0)
            {
                Cl_AfficheMessageBox.MessageAlerte("Le type de message n'est pas définie!");
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
        public override void Insert()
        {
            try
            {
                if (!ValeurCorrecte()) { return; }

                // création de la requête INSERT
                string RequeteSQL = """
                    INSERT INTO T_Message (IdGroupeMessage,IdTypeMessage,CodeMessage,Message)
                    VALUES(@IdGroupeMessage,@IdTypeMessage,@CodeMessage,@Message);
                    """;

                SQLiteCommand CommandSQLite = new SQLiteCommand(RequeteSQL, this.MaConnexion); // création de la commande SQLite

                // Ajout des paramètres a la requête préparer
                CommandSQLite.Parameters.AddWithValue("@IdGroupeMessage", IdGroupeMessage);
                CommandSQLite.Parameters.AddWithValue("@IdTypeMessage", IdTypeMessage);
                CommandSQLite.Parameters.AddWithValue("@CodeMessage", CodeMessage);
                CommandSQLite.Parameters.AddWithValue("@Message", Message);

                this.MaConnexion.Open(); // ouvre la connexion à la base de données
                CommandSQLite.ExecuteNonQuery(); // Exécute la commande INSERT
                this.MaConnexion.Close(); // ferme la connexion à la base de données

            }
            catch
            {
                Cl_AfficheMessageBox.MessageAlerte("Une erreur s'est produite. Veuillez contacter les développeurs.\nCode erreur 009");
            }
        }
        //
        // override update
        //
        public override void Update()
        {
            try
            {
                if (!ValeurCorrecte()) { return; } // Vérifie si toutes les données sont bien normées
                else if (IdMessage <= 0)
                {
                    Cl_AfficheMessageBox.MessageAlerte("Il n'y a aucun message selectionner");
                    return;
                }

                // création de la requête UPDATE
                string RequeteSQL = """
                    UPDATE T_Message 
                    SET 
                        IdGroupeMessage=@IdGroupeMessage,
                        IdTypeMessage=@IdTypeMessage,
                        CodeMessage=@CodeMessage,
                        Message=@Message
                    WHERE 
                        IdMessage = @IdMessage;
                    """;

                SQLiteCommand CommandSQLite = new SQLiteCommand(RequeteSQL, this.MaConnexion); // création de la commande SQLite

                // Ajout des paramètres a la requête préparer
                CommandSQLite.Parameters.AddWithValue("@IdGroupeMessage", IdGroupeMessage);
                CommandSQLite.Parameters.AddWithValue("@IdTypeMessage", IdTypeMessage);
                CommandSQLite.Parameters.AddWithValue("@CodeMessage", CodeMessage);
                CommandSQLite.Parameters.AddWithValue("@Message", Message);
                CommandSQLite.Parameters.AddWithValue("@IdMessage", IdMessage);

                this.MaConnexion.Open(); // ouvre la connexion à la base de données
                CommandSQLite.ExecuteNonQuery(); // Exécute la commande UPDATE
                this.MaConnexion.Close(); // ferme la connexion à la base de données
            }
            catch
            {
                Cl_AfficheMessageBox.MessageAlerte("Une erreur s'est produite. Veuillez contacter les développeurs.\nCode erreur 010");
            }
        }
        //
        // override delete
        //
        public override void Delete()
        {
            try
            {
                if (IdMessage <= 0)
                {
                    Cl_AfficheMessageBox.MessageAlerte("Il n'y a aucun message sélectionné!");
                    return;
                }

                // création de la requête DELETE
                string RequeteSQL = """
                    DELETE FROM T_Message
                    WHERE IdMessage = @IdMessage;
                    """;

                SQLiteCommand CommandSQLite = new SQLiteCommand(RequeteSQL, this.MaConnexion); // création de la commande SQLite

                // Ajout des paramètres a la requête préparer
                CommandSQLite.Parameters.AddWithValue("@IdMessage", IdMessage);

                this.MaConnexion.Open(); // ouvre la connexion à la base de données
                CommandSQLite.ExecuteNonQuery(); // Exécute la commande DELETE
                this.MaConnexion.Close(); // ferme la connexion à la base de données
            }
            catch
            {
                Cl_AfficheMessageBox.MessageAlerte("Une erreur s'est produite. Veuillez contacter les développeurs.\nCode erreur 011");
            }
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
