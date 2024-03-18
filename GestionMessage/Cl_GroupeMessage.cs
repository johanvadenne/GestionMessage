﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;

namespace GestionMessage
{
    public class Cl_GroupeMessage : Cl_BDD
    {
        //
        // variables
        //
        private int _IdGroupeMessage;
        private string _LabelGroupeMessage;
        //
        // constructeur
        //
        public Cl_GroupeMessage(int IdGroupeMessageRecu, string LabelGroupeMessageRecu)
        {
            _IdGroupeMessage = IdGroupeMessageRecu;
            LabelGroupeMessage = LabelGroupeMessageRecu;
        }
        //
        // IdGroupeMessage
        //
        public int IdGroupeMessage
        {
            get {return _IdGroupeMessage;}
        }
        //
        // LabelGroupeMessage
        //
        public string LabelGroupeMessage
        {
            get { return _LabelGroupeMessage; }
            set {
                if (value.Length <= 100) // vérifie la taille de value
                {
                    _LabelGroupeMessage = value;
                }
                else
                {
                    Cl_AfficheMessageBox.MessageInformation("Le label groupe message ne peut comporter plus de 100 caractères!");
                }
            }
        }
        //
        // Vérifie si toutes les données sont bien normées
        //
        public override bool ValeurCorrecte()
        {
            if (LabelGroupeMessage.Length > 100) // vérifie la taille de value
            {
                Cl_AfficheMessageBox.MessageAlerte("Le label groupe message ne peut comporter plus de 100 caractères!");
                return false;
            }

            return true;
        }
        //
        // override insert
        //
        public override void Insert()
        {
            if (ValeurCorrecte()) // Vérifie si toutes les données sont bien normées
            {
                // création de la requête INSERT
                string RequeteSQL = """
                    INSERT INTO T_GroupeMessage
                    (LabelGroupeMessage) VALUES(@LabelGroupeMessage);
                    """;

                SQLiteCommand CommandSQLite = new SQLiteCommand(RequeteSQL, this.MaConnexion); // création de la commande SQLite

                // Ajout des paramètres a la requête préparer
                CommandSQLite.Parameters.AddWithValue("@LabelGroupeMessage", LabelGroupeMessage);

                this.MaConnexion.Open(); // ouvre la connexion à la base de données
                CommandSQLite.ExecuteNonQuery(); // Exécute la commande INSERT
                this.MaConnexion.Close(); // ferme la connexion à la base de données
            }
        }
        //
        // override update
        //
        public override void Update()
        {
            if (ValeurCorrecte()) // Vérifie si toutes les données sont bien normées
            {
                // création de la requête UPDATE
                string RequeteSQL = """
                    UPDATE T_GroupeMessage
                    SET LabelGroupeMessage = @LabelGroupeMessage
                    WHERE IdGroupeMessage = @IdGroupeMessage;
                """;

                SQLiteCommand CommandSQLite = new SQLiteCommand(RequeteSQL, this.MaConnexion);  // création de la commande SQLite

                // Ajout des paramètres a la requête préparer
                CommandSQLite.Parameters.AddWithValue("@LabelGroupeMessage", LabelGroupeMessage);
                CommandSQLite.Parameters.AddWithValue("@IdGroupeMessage", IdGroupeMessage);

                this.MaConnexion.Open(); // ouvre la connexion à la base de données
                CommandSQLite.ExecuteNonQuery(); // Exécute la commande UPDATE
                this.MaConnexion.Close(); // ferme la connexion à la base de données
            }
}
        //
        // override delete
        //
        public override void Delete()
        {
            // création de la requête DELETE
            string RequeteSQL =
                "DELETE FROM T_GroupeMessage " +
                " WHERE IdGroupeMessage = @IdGroupeMessage;";
            
            SQLiteCommand CommandSQLite = new SQLiteCommand(RequeteSQL, this.MaConnexion); // création de la commande SQLite

            // Ajout des paramètres a la requête préparer
            CommandSQLite.Parameters.AddWithValue("@IdGroupeMessage", IdGroupeMessage);

            this.MaConnexion.Open(); // ouvre la connexion à la base de données
            CommandSQLite.ExecuteNonQuery(); // Exécute la commande DELETE
            this.MaConnexion.Close(); // ferme la connexion à la base de données
        }
        //
        // override ToString
        //
        public override string ToString()
        {
            return IdGroupeMessage.ToString() + " - " + LabelGroupeMessage;
        }
    }
}
