using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Diagnostics.CodeAnalysis;


namespace GestionMessage
{
    public partial class Fn_Message : Form
    {
        //
        // variable
        //
        Cl_ConnexionBDD BDD_SQLlite = new Cl_ConnexionBDD();
        const string UPDATE = "UPDATE";
        const string INSERT = "INSERT";

        const string GROUPE_MESSAGE = "GROUPE MESSAGE";
        const string TYPE_MESSAGE = "TYPE MESSAGE";
        const string MESSAGE = "MESSAGE";
        
        string typeModificationMessage = "";
        string typeModificationGroupeMessage = "";
        string typeModificationTypeMessage = "";

        delegate void AffichageChamp(bool valeur);
        //
        // initialisation affichage
        //
        public Fn_Message()
        {
            InitializeComponent();
        }
        //
        // chargement de la fenêtre
        //
        private void Fn_Message_Load(object sender, EventArgs e)
        {
            initialisationListes();
        }

        // ############################################## //
        // ############### ONGLET MESSAGE ############### //
        // ############################################## //

        //
        // A la selection d'un code message
        //
        private void Cb_CodeMessage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (typeModificationMessage == INSERT) { return; }

            Cl_Message messageSelect = Cb_CodeMessage.SelectedItem as Cl_Message;

            if(messageSelect.IdMessage == 0) { return; }

            if (messageSelect == null) { return; }
            
            Tb_CodeMessage.Text = messageSelect.CodeMessage;
            Tb_Message.Text = messageSelect.Message;

            Cl_GroupeMessage GroupeMessageSelect = null;
            Cl_TypeMessage TypeMessageSelect = null;

            foreach (Cl_GroupeMessage GroupeMessage in Cb_GroupeMessage.Items)
            {
                if (GroupeMessage.IdGroupeMessage == messageSelect.IdGroupeMessage)
                {
                    GroupeMessageSelect = GroupeMessage;
                    Cb_GroupeMessage.SelectedItem = GroupeMessage;
                    break;
                }
            }

            foreach (Cl_TypeMessage TypeMessage in Cb_TypeMessage.Items)
            {
                if (TypeMessage.IdTypeMessage == messageSelect.IdTypeMessage)
                {
                    TypeMessageSelect = TypeMessage;
                    Cb_TypeMessage.SelectedItem = TypeMessage;
                    break;
                }
            }

            if (GroupeMessageSelect == null) { Cl_AfficheMessageBox.MessageErreur("Le groupe message n'a pas été trouver"); }
            if (TypeMessageSelect == null) { Cl_AfficheMessageBox.MessageErreur("Le type message n'a pas été trouver"); }
        }
        //
        // a chaque modification de se champ, une synchronisation est effectué avec la liste de code message
        //
        private void Tb_CodeMessage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (typeModificationMessage == INSERT) // si une modification
                {
                    Cb_CodeMessage.Items.RemoveAt(Cb_CodeMessage.SelectedIndex); // je supprime l'élément
                    Cl_GroupeMessage groupeMessageSelectionner = Cb_GroupeMessage.SelectedItem as Cl_GroupeMessage;
                    Cl_TypeMessage typeMessageSelectionner = Cb_TypeMessage.SelectedItem as Cl_TypeMessage;

                    // j'instancie un nouveau message avec le nouveau texte
                    Cl_Message nouveauMessage = new Cl_Message(0, groupeMessageSelectionner, typeMessageSelectionner, Tb_CodeMessage.Text, Tb_Message.Text);
                    Cb_CodeMessage.Items.Add(nouveauMessage); // je l'ajoute dans la liste
                    Cb_CodeMessage.SelectedItem = nouveauMessage; // je selectionne l'élément qui vient d'etre ajouter
                }
                else if (typeModificationMessage == UPDATE)
                {
                    Cl_Message MessageSelect = Cb_CodeMessage.SelectedItem as Cl_Message; // récupère l'instance selectionner dans la liste

                    Cb_CodeMessage.Items.RemoveAt(Cb_CodeMessage.SelectedIndex); // je supprime l'élément
                    MessageSelect.CodeMessage = Tb_CodeMessage.Text; // modifie le label
                    Cb_CodeMessage.Items.Add(MessageSelect); // je l'ajoute dans la liste
                    Cb_CodeMessage.SelectedItem = typeModificationMessage; // je selectionne l'élément qui vien d'etre ajouter
                }
            }
            catch
            {
                Cl_AfficheMessageBox.MessageErreur("Une erreur dans l'édition du texte à provoquer une erreur");
            }
        }
        //
        // evenement bouton "nouveau message"
        //
        private void Btn_NouveauMessage_Click(object sender, EventArgs e)
        {
            Cl_GroupeMessage nouveauGroupeMessage = new Cl_GroupeMessage(0, "Nouveau label groupe message");
            Cl_TypeMessage nouveauTypeMessage = new Cl_TypeMessage(0, "Nouveau type message");
            typeModificationMessage = INSERT; // repère pour savoir que fait l'utilisateur

            Cl_Message nouveauMessage = new Cl_Message(0, nouveauGroupeMessage, nouveauTypeMessage, "XXXX", "Aucun message"); // Créez un nouvel objet Cl_Message
            Cb_CodeMessage.Items.Add(nouveauMessage); // ajout dans la liste
            Cb_CodeMessage.SelectedItem = nouveauMessage; // selectionne la nouvelle valeur ajouter
            Tb_Message.Text = nouveauMessage.Message;
            Tb_CodeMessage.Text = nouveauMessage.CodeMessage;

            Cb_GroupeMessage.SelectedIndex = 0;
            Cb_TypeMessage.SelectedIndex = 0;
            editeMessage();
        }
        //
        // evenement bouton "enregistrer message"
        //
        private void Btn_EnregistrerMessage_Click(object sender, EventArgs e)
        {
            Cl_Message MessageSelect = Cb_CodeMessage.SelectedItem as Cl_Message; // récupère l'instance selectionner dans la liste
            Cl_GroupeMessage GroupeMessageSelect = Cb_GroupeMessage.SelectedItem as Cl_GroupeMessage; // récupère l'instance selectionner dans la liste
            Cl_TypeMessage TypeMessageSelect = Cb_TypeMessage.SelectedItem as Cl_TypeMessage; // récupère l'instance selectionner dans la liste

            int IdGroupMessageSelect = 0;
            int IdTypeMessageSelect = 0;
            if (MessageSelect.valeurCorrect() == false) { return; }

            foreach (Cl_Message messageParcouru in Cb_CodeMessage.Items)
            {
                if (messageParcouru.CodeMessage == MessageSelect.CodeMessage && messageParcouru != MessageSelect)
                {
                    Cl_AfficheMessageBox.MessageAlerte("Le code " + messageParcouru.CodeMessage + " existe déjà.");
                    return;
                }

            }

            if (typeModificationMessage == INSERT)
            {
                if (MessageSelect != null)
                {
                    MessageSelect.GroupeMessage = GroupeMessageSelect;
                    MessageSelect.TypeMessage = TypeMessageSelect;
                    MessageSelect.CodeMessage = Tb_CodeMessage.Text;
                    MessageSelect.Message = Tb_Message.Text;
                    MessageSelect.insert();
                }
                else
                {
                    Cl_AfficheMessageBox.MessageAlerte("Une erreur d'enregistrement c'est produite");
                }
            }
            else if ( typeModificationMessage == UPDATE )
            {
                if (MessageSelect != null)
                {
                    MessageSelect.GroupeMessage = GroupeMessageSelect;
                    MessageSelect.TypeMessage = TypeMessageSelect;
                    MessageSelect.CodeMessage = Tb_CodeMessage.Text;
                    MessageSelect.Message = Tb_Message.Text;
                    MessageSelect.update();
                }
                else
                {
                    Cl_AfficheMessageBox.MessageAlerte("Une erreur d'enregistrement c'est produite");
                }
            }

            typeModificationMessage = "";
            initialisationListes();
        }
        //
        // evenement bouton "modifier message"
        //
        private void Btn_ModifierMessage_Click(object sender, EventArgs e)
        {
            typeModificationMessage = UPDATE;
            editeMessage();
        }
        //
        // evenement bouton "supprimer message"
        //
        private void Btn_SupprimerMessage_Click(object sender, EventArgs e)
        {
            if (Cb_CodeMessage.SelectedItem != null && typeModificationMessage == "")
            {
                Cl_Message elementMessage = Cb_CodeMessage.SelectedItem as Cl_Message;
                elementMessage.delete();
            }
            typeModificationMessage = "";
            initialisationListes();
        }

        // ##################################################### //
        // ############### ONGLET GROUPE MESSAGE ############### //
        // ##################################################### //

        //
        // evenement lors de la selection d'un élément de la liste
        //
        private void Cb_ChercheGroupeMessage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // récupère l'instance selectionner dans la liste
                Cl_GroupeMessage GroupeMessageSelect = Cb_ChercheGroupeMessage.SelectedItem as Cl_GroupeMessage;

                // si la valeur selectionner n'est pas une classe Cl_GroupeMessage
                if (GroupeMessageSelect == null)
                {
                    Tb_LabelGroupeMessage.Enabled = false;
                    return;
                }

                // si c'est un nouveau ou une modification
                if (typeModificationGroupeMessage == UPDATE || typeModificationGroupeMessage == INSERT)
                {
                    Tb_LabelGroupeMessage.Enabled = true; // rendre le champ éditable
                }
                else
                {
                    Tb_LabelGroupeMessage.Enabled = false; // rendre le champ inactif
                    Tb_LabelGroupeMessage.Text = GroupeMessageSelect.LabelGroupeMessage;
                }
            }
            catch
            {
                Cl_AfficheMessageBox.MessageErreur("Imposible de selectionner un élément");
            }
        }
        //
        // a chaque modification de se champ, une synchronisation est effectué avec la liste de groupe message
        //
        private void Tb_LabelGroupeMessage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (typeModificationGroupeMessage == INSERT) // si une modification
                {
                    Cb_ChercheGroupeMessage.Items.RemoveAt(Cb_ChercheGroupeMessage.SelectedIndex); // je supprime l'élément

                    // j'instancie un nouveau groupe message avec le nouveau texte
                    Cl_GroupeMessage nouveauGroupeMessage = new Cl_GroupeMessage(0, Tb_LabelGroupeMessage.Text);
                    Cb_ChercheGroupeMessage.Items.Add(nouveauGroupeMessage); // je l'ajoute dans la liste
                    Cb_ChercheGroupeMessage.SelectedItem = nouveauGroupeMessage; // je selectionne l'élément qui vien d'etre ajouter
                }
                else if (typeModificationGroupeMessage == UPDATE)
                {
                    Cl_GroupeMessage GroupeMessageSelect = Cb_ChercheGroupeMessage.SelectedItem as Cl_GroupeMessage; // récupère l'instance selectionner dans la liste
                    Cb_ChercheGroupeMessage.Items.RemoveAt(Cb_ChercheGroupeMessage.SelectedIndex); // je supprime l'élément
                    GroupeMessageSelect.LabelGroupeMessage = Tb_LabelGroupeMessage.Text; // modifie le label
                    Cb_ChercheGroupeMessage.Items.Add(GroupeMessageSelect); // je l'ajoute dans la liste
                    Cb_ChercheGroupeMessage.SelectedItem = GroupeMessageSelect; // je selectionne l'élément qui vien d'etre ajou
                    Cb_ChercheGroupeMessage.SelectedItem = typeModificationGroupeMessage; // je selectionne l'élément qui vien d'etre ajouter
                }
            }
            catch
            {
                Cl_AfficheMessageBox.MessageErreur("Une erreur dans l'édition du texte à provoquer une erreur");
            }
        }
        //
        // evenement bouton "nouveau groupe message"
        //
        private void Btn_NouveauGroupeMessage_Click(object sender, EventArgs e)
        {
            Cl_GroupeMessage nouveauGroupeMessage = new Cl_GroupeMessage(0, "Nouveau label groupe message");
            Cb_ChercheGroupeMessage.Items.Add(nouveauGroupeMessage); // ajout dans la liste
            Cb_ChercheGroupeMessage.SelectedItem = nouveauGroupeMessage; // selectionne la nouvelle valeur ajouter
            Tb_LabelGroupeMessage.Text = "Nouveau label groupe message";

            typeModificationGroupeMessage = INSERT; // repère pour savoir que fait l'utilisateur
            editeGroupeMessage();
        }
        //
        // evenement bouton "enregistrer groupe message"
        //
        private void Btn_EnregistrerGroupeMessage_Click(object sender, EventArgs e)
        {
            try
            {
                Cl_GroupeMessage GroupeMessageSelect = Cb_ChercheGroupeMessage.SelectedItem as Cl_GroupeMessage; // récupère l'instance selectionner dans la liste

                if (GroupeMessageSelect == null) // si la valeur selectionner n'est pas une classe Cl_GroupeMessage
                {
                    throw new InvalidOperationException(""); // lever une exeption
                }

                if (GroupeMessageSelect.valeurCorrect() == false) { return; }

                // vérifie qu'il n'y a pas un autre élément qui a le même label 
                foreach (Cl_GroupeMessage elementGroupeMessage in Cb_ChercheGroupeMessage.Items)
                {
                    if (elementGroupeMessage != null)
                    {
                        if (elementGroupeMessage.LabelGroupeMessage == GroupeMessageSelect.LabelGroupeMessage && GroupeMessageSelect != elementGroupeMessage)
                        {
                            Cl_AfficheMessageBox.MessageAlerte("Il ne peux pas y avoir 2 même label groupe message");
                            return;
                        }
                    }
                }

                if (typeModificationGroupeMessage == UPDATE) // si c'est une mise à jour
                {
                    GroupeMessageSelect.update();
                }
                else if (typeModificationGroupeMessage == INSERT) // si c'est une nouvelle valeurs
                {
                    GroupeMessageSelect.insert();
                }
                else
                {
                    Cl_AfficheMessageBox.MessageErreur("Il n'y a aucun enregistrement à effectuer");
                }
                typeModificationGroupeMessage = ""; // plus de modification en cours
                initialisationListes();
            }
            catch
            {
                Cl_AfficheMessageBox.MessageErreur("L'enregistrement à provoquer une erreur");
            }
        }
        //
        // evenement bouton "supprimer groupe message"
        //
        private void Btn_SupprimerGroupeMessage_Click(object sender, EventArgs e)
        {
            if (Cb_ChercheGroupeMessage.SelectedItem != null && typeModificationGroupeMessage == "")
            {
                Cl_GroupeMessage elementGroupeMessage = Cb_ChercheGroupeMessage.SelectedItem as Cl_GroupeMessage;
                string code = "";
                foreach (Cl_Message messageSelect in Cb_CodeMessage.Items)
                {
                    if (messageSelect.GroupeMessage == elementGroupeMessage)
                    {
                        code += messageSelect.CodeMessage + ", ";
                    }
                    
                }
                if (code != "")
                {
                    Cl_AfficheMessageBox.MessageAlerte("Le groupe message est utiliser dans le(s) message(s) " + code + "Il ne peux donc pas être supprimer.");
                    return;
                }
                
                elementGroupeMessage.delete();
            }
            typeModificationGroupeMessage = "";
            initialisationListes();
        }
        //
        // evenement bouton "modifier groupe message"
        //
        private void Btn_ModifierGroupeMessage_Click(object sender, EventArgs e)
        {
            typeModificationGroupeMessage = UPDATE;
            editeGroupeMessage();
        }

        // ################################################### //
        // ############### ONGLET TYPE MESSAGE ############### //
        // ################################################### //

        //
        // evenement lors de la selection d'un élément de la liste
        //
        private void Cb_ChercheTypeMessage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // récupère l'instance selectionner dans la liste
                Cl_TypeMessage TypeMessageSelect = Cb_ChercheTypeMessage.SelectedItem as Cl_TypeMessage;

                // si la valeur selectionner n'est pas une classe Cl_TypeMessage
                if (TypeMessageSelect == null)
                {
                    Tb_LabelTypeMessage.Enabled = false;
                    return;
                }

                // si c'est un nouveau ou une modification
                if (typeModificationTypeMessage == UPDATE || typeModificationTypeMessage == INSERT)
                {
                    Tb_LabelTypeMessage.Enabled = true; // rendre le champ éditable
                }
                else
                {
                    Tb_LabelTypeMessage.Enabled = false; // rendre le champ inactif
                    Tb_LabelTypeMessage.Text = TypeMessageSelect.LabelTypeMessage;
                }
            }
            catch
            {
                Cl_AfficheMessageBox.MessageErreur("Imposible de selectionner un élément");
            }
        }
        //
        // a chaque modification de se champ, une synchronisation est effectué avec la liste de type message
        //
        private void Tb_LabelTypeMessage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (typeModificationTypeMessage == INSERT) // si une modification
                {
                    Cb_ChercheTypeMessage.Items.RemoveAt(Cb_ChercheTypeMessage.SelectedIndex); // je supprime l'élément

                    // j'instancie un nouveau Type message avec le nouveau texte
                    Cl_TypeMessage nouveauTypeMessage = new Cl_TypeMessage(0, Tb_LabelTypeMessage.Text);
                    Cb_ChercheTypeMessage.Items.Add(nouveauTypeMessage); // je l'ajoute dans la liste
                    Cb_ChercheTypeMessage.SelectedItem = nouveauTypeMessage; // je selectionne l'élément qui vien d'etre ajouter
                }
                else if (typeModificationTypeMessage == UPDATE)
                {
                    Cl_TypeMessage TypeMessageSelect = Cb_ChercheTypeMessage.SelectedItem as Cl_TypeMessage; // récupère l'instance selectionner dans la liste
                    Cb_ChercheTypeMessage.Items.RemoveAt(Cb_ChercheTypeMessage.SelectedIndex); // je supprime l'élément
                    TypeMessageSelect.LabelTypeMessage = Tb_LabelTypeMessage.Text; // modifie le label
                    Cb_ChercheTypeMessage.Items.Add(TypeMessageSelect); // je l'ajoute dans la liste
                    Cb_ChercheTypeMessage.SelectedItem = TypeMessageSelect; // je selectionne l'élément qui vien d'etre ajou
                    Cb_ChercheTypeMessage.SelectedItem = typeModificationTypeMessage; // je selectionne l'élément qui vien d'etre ajouter
                }
            }
            catch
            {
                Cl_AfficheMessageBox.MessageErreur("Une erreur dans l'édition du texte à provoquer une erreur");
            }
        }
        //
        // evenement bouton "nouveau type message"
        //
        private void Btn_NouveauTypeMessage_Click(object sender, EventArgs e)
        {
            Cl_TypeMessage nouveauTypeMessage = new Cl_TypeMessage(0, "Nouveau type message");
            Cb_ChercheTypeMessage.Items.Add(nouveauTypeMessage); // ajout dans la liste
            Cb_ChercheTypeMessage.SelectedItem = nouveauTypeMessage; // selectionne la nouvelle valeur ajouter
            Tb_LabelTypeMessage.Text = "Nouveau type message";

            typeModificationTypeMessage = INSERT; // repère pour savoir que fait l'utilisateur
            editeTypeMessage();
        }
        //
        // evenement bouton "enregistrer type message"
        //
        private void Btn_EnregistrerTypeMessage_Click(object sender, EventArgs e)
        {
            try
            {
                Cl_TypeMessage TypeMessageSelect = Cb_ChercheTypeMessage.SelectedItem as Cl_TypeMessage; // récupère l'instance selectionner dans la liste

                if (TypeMessageSelect.valeurCorrect() == false) { return; }

                if (TypeMessageSelect == null) // si la valeur selectionner n'est pas une classe Cl_TypeMessage
                {
                    throw new InvalidOperationException(""); // lever une exeption
                }

                // vérifie qu'il n'y a pas un autre élément qui a le même label 
                foreach (Cl_TypeMessage elementTypeMessage in Cb_ChercheTypeMessage.Items)
                {
                    if (elementTypeMessage != null)
                    {
                        if (elementTypeMessage.LabelTypeMessage == TypeMessageSelect.LabelTypeMessage && TypeMessageSelect != elementTypeMessage)
                        {
                            Cl_AfficheMessageBox.MessageAlerte("Il ne peux pas y avoir 2 même label type message");
                            return;
                        }
                    }
                }

                if (typeModificationTypeMessage == UPDATE) // si c'est une mise à jour
                {
                    TypeMessageSelect.update();
                }
                else if (typeModificationTypeMessage == INSERT) // si c'est une nouvelle valeurs
                {
                    TypeMessageSelect.insert();
                }
                else
                {
                    Cl_AfficheMessageBox.MessageErreur("Il n'y a aucun enregistrement à effectuer");
                }
                typeModificationTypeMessage = ""; // plus de modification en cours
                initialisationListes(); // initialise la liste
            }
            catch
            {
                Cl_AfficheMessageBox.MessageErreur("L'enregistrement à provoquer une erreur");
            }
        }
        //
        // evenement bouton "modifier type message"
        //
        private void Btn_ModifierTypeMessage_Click(object sender, EventArgs e)
        {
            typeModificationTypeMessage = UPDATE;
            editeTypeMessage();
        }
        //
        // evenement bouton "supprimer type message"
        //
        private void Btn_SupprimerTypeMessage_Click(object sender, EventArgs e)
        {
            if (Cb_ChercheTypeMessage.SelectedItem != null && typeModificationTypeMessage == "")
            {
                Cl_TypeMessage elementTypeMessage = Cb_ChercheTypeMessage.SelectedItem as Cl_TypeMessage;

                string code = "";
                foreach (Cl_Message messageSelect in Cb_CodeMessage.Items)
                {
                    if (messageSelect.TypeMessage == elementTypeMessage)
                    {
                        code += messageSelect.CodeMessage + ", ";
                    }

                }
                if (code != "")
                {
                    Cl_AfficheMessageBox.MessageAlerte("Le groupe message est utiliser dans le(s) message(s) " + code + "Il ne peux donc pas être supprimer.");
                    return;
                }

                elementTypeMessage.delete();
            }
            typeModificationTypeMessage = "";
            initialisationListes();
        }

        // #################################################### //
        // ############### Affichage des champs ############### //
        // #################################################### //

        //
        // initialisation liste
        //
        private void initialisationListes()
        {
            remplieListe(TYPE_MESSAGE);
            remplieListe(GROUPE_MESSAGE);
            remplieListe(MESSAGE);
        }
        //
        // Remplie les listes
        //
        private void remplieListe(string nomListe)
        {
            ComboBox CB_OngletEdition;
            ComboBox CB_OngletPrincipale;
            string requeteSQL;
            AffichageChamp affichageChamp;

            switch (nomListe)
            {
                case GROUPE_MESSAGE:
                    CB_OngletEdition = Cb_ChercheGroupeMessage;
                    CB_OngletPrincipale = Cb_GroupeMessage;
                    requeteSQL = "SELECT IdGroupeMessage, LabelGroupeMessage FROM T_GroupeMessage;"; // Requete SQL
                    affichageChamp = AucunGroupeMessage;
                    break;
                case TYPE_MESSAGE:
                    CB_OngletEdition = Cb_ChercheTypeMessage;
                    CB_OngletPrincipale = Cb_TypeMessage;
                    requeteSQL = "SELECT IdTypeMessage, LabelTypeMessage FROM T_TypeMessage;"; // Requete SQL
                    affichageChamp = AucunTypeMessage;
                    break;
                case MESSAGE:
                    CB_OngletEdition = Cb_CodeMessage;
                    CB_OngletPrincipale = new ComboBox(); // évite l'erreur
                    requeteSQL = """
                        SELECT 
                            IdMessage, 
                            IdGroupeMessage, 
                            IdTypeMessage, 
                            CodeMessage, 
                            Message
                        FROM 
                            T_Message;
                        """; // Requete SQL
                    affichageChamp = AucunMessage;
                    break;
                default:
                    Cl_AfficheMessageBox.MessageErreur("Une erreur de developpement c'est produite 1");
                    return;
            }

            CB_OngletEdition.Items.Clear();
            CB_OngletPrincipale.Items.Clear();

            SQLiteCommand command = new SQLiteCommand(requeteSQL, BDD_SQLlite.connexion); // créer la commande

            BDD_SQLlite.connexion.Open(); // Ouvre la connexion à la base
            SQLiteDataReader reader = command.ExecuteReader(); // execute la commande en mode lecture

            while (reader.Read()) // tant qu'il y a encore des données à lire
            {
                if (nomListe == MESSAGE)
                {
                    int IdMessageLu = reader.GetInt32(0); // récupère la 1er colonne
                    int IdGroupeMessageLu = reader.GetInt32(1); // récupère la 2eme colonne
                    int IdTypeMessageLu = reader.GetInt32(2); // récupère la 2eme colonne
                    string CodeLu = reader.GetString(3); // récupère la 2eme colonne
                    string MessageLu = reader.GetString(4); // récupère la 2eme colonne

                    Cl_GroupeMessage groupeMessageLu = null;
                    Cl_TypeMessage typeMessageLu = null;

                    foreach (Cl_GroupeMessage groupeMessageTrouver in Cb_ChercheGroupeMessage.Items)
                    {
                        if (groupeMessageTrouver.IdGroupeMessage == IdGroupeMessageLu) { groupeMessageLu = groupeMessageTrouver; }
                    }
                    foreach (Cl_TypeMessage typeMessageTrouver in Cb_ChercheTypeMessage.Items)
                    {
                        if (typeMessageTrouver.IdTypeMessage == IdTypeMessageLu) { typeMessageLu = typeMessageTrouver; }
                    }

                    if (groupeMessageLu == null)
                    {
                        Cl_AfficheMessageBox.MessageAlerte("Le message " + CodeLu + " n'est pas lié à de groupe message\ncontacté les développeurs.");
                        return;
                    }
                    else if (typeMessageLu == null)
                    {
                        Cl_AfficheMessageBox.MessageAlerte("Le message " + CodeLu + " n'est pas lié à de type message\ncontacté les développeurs.");
                        return;
                    }

                    Cl_Message valeurRajouter = new Cl_Message(IdMessageLu, groupeMessageLu, typeMessageLu, CodeLu, MessageLu);
                    CB_OngletEdition.Items.Add(valeurRajouter); // ajoute l'instance dans la liste
                    CB_OngletPrincipale.Items.Add(valeurRajouter); // ajoute l'instance dans la liste
                }
                else
                {
                    int IdLu = reader.GetInt32(0); // récupère la 1er colonne
                    string LabelLu = reader.GetString(1); // récupère la 2eme colonne

                    if (nomListe == GROUPE_MESSAGE)
                    {
                        Cl_GroupeMessage valeurRajouter = new Cl_GroupeMessage(IdLu, LabelLu);
                        CB_OngletEdition.Items.Add(valeurRajouter); // ajoute l'instance dans la liste
                        CB_OngletPrincipale.Items.Add(valeurRajouter); // ajoute l'instance dans la liste
                    }
                    else if (nomListe == TYPE_MESSAGE)
                    {
                        Cl_TypeMessage valeurRajouter = new Cl_TypeMessage(IdLu, LabelLu);
                        CB_OngletEdition.Items.Add(valeurRajouter); // ajoute l'instance dans la liste
                        CB_OngletPrincipale.Items.Add(valeurRajouter); // ajoute l'instance dans la liste
                    }
                    else { Cl_AfficheMessageBox.MessageErreur("Une erreur de developpement c'est produite 2"); }
                }
            }
            reader.Close(); // ferme la lecture
            BDD_SQLlite.connexion.Close(); // ferme la connexion à la base de données

            // si je n'ai aucun élément
            if (CB_OngletEdition.Items.Count == 0)
            {
                Cl_GroupeMessage valeurGroupeMessageRajouter = new Cl_GroupeMessage(0, "Aucun groupe message");
                Cl_TypeMessage valeurTypeMessageRajouter = new Cl_TypeMessage(0, "Aucun type message");
                if (nomListe == GROUPE_MESSAGE)
                {
                    CB_OngletEdition.Items.Add(valeurGroupeMessageRajouter); // ajoute l'instance dans la liste
                    CB_OngletPrincipale.Items.Add(valeurGroupeMessageRajouter); // ajoute l'instance dans la liste
                }
                else if (nomListe == TYPE_MESSAGE)
                {
                    CB_OngletEdition.Items.Add(valeurTypeMessageRajouter); // ajoute l'instance dans la liste
                    CB_OngletPrincipale.Items.Add(valeurTypeMessageRajouter); // ajoute l'instance dans la liste
                }
                else if (nomListe == MESSAGE)
                {
                    Cl_Message valeurRajouter = new Cl_Message(0, valeurGroupeMessageRajouter, valeurTypeMessageRajouter, "XXXX", "Aucun message");
                    CB_OngletEdition.Items.Add(valeurRajouter); // ajoute l'instance dans la liste
                    CB_OngletPrincipale.Items.Add(valeurRajouter); // ajoute l'instance dans la liste
                }
                else { Cl_AfficheMessageBox.MessageErreur("Une erreur de developpement c'est produite 3"); }

                affichageChamp(true); // affichage des élément
            }
            else
            {
                affichageChamp(false); // affichage des élément
            }

            CB_OngletEdition.SelectedIndex = 0; // selectionne le premier élément par défaut
            CB_OngletPrincipale.SelectedIndex = 0; // selectionne le premier élément par défaut
        }
        //
        // affichage d'un message
        //
        private void AucunMessage(bool valeur)
        {
            if (valeur)
            {
                // champ
                Cb_CodeMessage.Enabled = false;
                Cb_GroupeMessage.Enabled = false;
                Cb_TypeMessage.Enabled = false;
                Tb_CodeMessage.Enabled = false;
                Tb_Message.Enabled = false;
                // bouton
                Btn_EnregistrerMessage.Enabled = false;
                Btn_ModifierMessage.Enabled = false;
                Btn_SupprimerMessage.Enabled = false;
                Btn_NouveauMessage.Enabled = true;
            }
            else
            {
                // champ
                Cb_CodeMessage.Enabled = true;
                Cb_GroupeMessage.Enabled = false;
                Cb_TypeMessage.Enabled = false;
                Tb_CodeMessage.Enabled = false;
                Tb_Message.Enabled = false;
                // bouton
                Btn_EnregistrerMessage.Enabled = false;
                Btn_ModifierMessage.Enabled = true;
                Btn_SupprimerMessage.Enabled = true;
                Btn_NouveauMessage.Enabled = true;
            }
            Btn_SupprimerMessage.Text = "Supprimer";
        }
        //
        // affichage d'un message
        //
        private void editeMessage()
        {
            // champ
            Cb_CodeMessage.Enabled = false;
            Cb_GroupeMessage.Enabled = true;
            Cb_TypeMessage.Enabled = true;
            Tb_CodeMessage.Enabled = true;
            Tb_Message.Enabled = true;
            // bouton
            Btn_EnregistrerMessage.Enabled = true;
            Btn_ModifierMessage.Enabled = false;
            Btn_SupprimerMessage.Enabled = true;
            Btn_NouveauMessage.Enabled = false;
            Btn_SupprimerMessage.Text = "Annuler";
        }
        //
        // affichage d'un groupe message
        //
        private void AucunGroupeMessage(bool valeur)
        {
            if (valeur)
            {
                // champ
                Cb_ChercheGroupeMessage.Enabled = false;
                Tb_LabelGroupeMessage.Enabled = false;
                // Bouton
                Btn_EnregistrerGroupeMessage.Enabled = false;
                Btn_ModifierGroupeMessage.Enabled = false;
                Btn_SupprimerGroupeMessage.Enabled = false;
                Btn_NouveauGroupeMessage.Enabled = true;
            }
            else
            {
                // champ
                Cb_ChercheGroupeMessage.Enabled = true;
                Tb_LabelGroupeMessage.Enabled = true;
                // Bouton
                Btn_EnregistrerGroupeMessage.Enabled = false;
                Btn_ModifierGroupeMessage.Enabled = true;
                Btn_SupprimerGroupeMessage.Enabled = true;
                Btn_NouveauGroupeMessage.Enabled = true;
            }
            Btn_SupprimerGroupeMessage.Text = "Supprimer";
        }
        //
        // edition d'un groupe message
        //
        private void editeGroupeMessage()
        {
            // champ
            Cb_ChercheGroupeMessage.Enabled = false;
            Tb_LabelGroupeMessage.Enabled = true;
            // Bouton
            Btn_NouveauGroupeMessage.Enabled = false;
            Btn_EnregistrerGroupeMessage.Enabled = true;
            Btn_ModifierGroupeMessage.Enabled = false;
            Btn_SupprimerGroupeMessage.Enabled = true;
            Btn_SupprimerGroupeMessage.Text = "Annuler";
        }
        //
        // affichage d'un type message
        //
        private void AucunTypeMessage(bool valeur)
        {
            if (valeur)
            {
                // champ
                Cb_ChercheTypeMessage.Enabled = false;
                Tb_LabelTypeMessage.Enabled = false;
                // Bouton
                Btn_EnregistrerTypeMessage.Enabled = false;
                Btn_ModifierTypeMessage.Enabled = false;
                Btn_SupprimerTypeMessage.Enabled = false;
                Btn_NouveauTypeMessage.Enabled = true;
            }
            else
            {
                // champ
                Cb_ChercheTypeMessage.Enabled = true;
                Tb_LabelTypeMessage.Enabled = true;
                // Bouton
                Btn_EnregistrerTypeMessage.Enabled = false;
                Btn_ModifierTypeMessage.Enabled = true;
                Btn_SupprimerTypeMessage.Enabled = true;
                Btn_NouveauTypeMessage.Enabled = true;
            }
            Btn_SupprimerTypeMessage.Text = "Supprimer";
        }
        //
        // edition d'un type message
        //
        private void editeTypeMessage()
        {
            // champ
            Cb_ChercheTypeMessage.Enabled = false;
            Tb_LabelTypeMessage.Enabled = true;
            // Bouton
            Btn_NouveauTypeMessage.Enabled = false;
            Btn_EnregistrerTypeMessage.Enabled = true;
            Btn_ModifierTypeMessage.Enabled = false;
            Btn_SupprimerTypeMessage.Enabled = true;
            Btn_SupprimerTypeMessage.Text = "Annuler";
        }
    }
}
