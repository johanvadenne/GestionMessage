using System.Data.SQLite;


namespace GestionMessage
{
    public partial class Fn_Message : Form
    {
        //
        // variables
        //
        Cl_ConnexionBDD BDD_SQLlite = new Cl_ConnexionBDD();
        const string UPDATE = "UPDATE";
        const string INSERT = "INSERT";

        // Indicateurs du type de modification
        string TypeModificationMessage = "";
        string TypeModificationGroupeMessage = "";
        string TypeModificationTypeMessage = "";

        const string GROUPE_MESSAGE = "GROUPE MESSAGE";
        const string TYPE_MESSAGE = "TYPE MESSAGE";
        const string MESSAGE = "MESSAGE";

        delegate void AffichageChamp(bool valeur);
        //
        // constructeur
        //
        public Fn_Message()
        {
            try
            {
                // page authentification
                Fn_Authentification FenetreAuthentification = new Fn_Authentification();
                FenetreAuthentification.ShowDialog();

                bool UtilisateurConnecte = FenetreAuthentification.ConnexionUtilisateur;

                if (UtilisateurConnecte == false)
                {
                    this.Close();
                }

                InitializeComponent();
            }
            catch
            {
                Cl_AfficheMessageBox.MessageErreur("Une erreur s'est produite. Veuillez contacter les d�veloppeurs.\nCode erreur 014");
            }
        }
        //
        // au chargement de la fen�tre
        //
        private void Fn_Message_Load(object sender, EventArgs e)
        {
            InitialisationListes();
        }

        // ############################################## //
        // ############### ONGLET MESSAGE ############### //
        // ############################################## //

        //
        // � la s�lection d'un code message
        //
        private void Cb_CodeMessage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // r�cup�re le message s�lectionn�
                Cl_Message MessageSelect = Cb_CodeMessage.SelectedItem as Cl_Message;

                // v�rifie si les valeurs MessageSelect est correcte 
                if (MessageSelect == null) { return; }
                if (MessageSelect.IdMessage == 0) { return; }

                // Remplit les champs
                Tb_CodeMessage.Text = MessageSelect.CodeMessage;
                Tb_Message.Text = MessageSelect.Message;

                // init
                Cl_GroupeMessage GroupeMessageSelect = null;
                Cl_TypeMessage TypeMessageSelect = null;

                // Selectionne la valeur du groupe message dans la liste
                foreach (Cl_GroupeMessage GroupeMessage in Cb_GroupeMessage.Items)
                {
                    if (GroupeMessage.IdGroupeMessage == MessageSelect.IdGroupeMessage)
                    {
                        GroupeMessageSelect = GroupeMessage;
                        Cb_GroupeMessage.SelectedItem = GroupeMessage;
                        break;
                    }
                }

                // Selectionne la valeur du type message dans la liste
                foreach (Cl_TypeMessage TypeMessage in Cb_TypeMessage.Items)
                {
                    if (TypeMessage.IdTypeMessage == MessageSelect.IdTypeMessage)
                    {
                        TypeMessageSelect = TypeMessage;
                        Cb_TypeMessage.SelectedItem = TypeMessage;
                        break;
                    }
                }

                // v�rifie si les valeurs sont bien existantes
                if (GroupeMessageSelect == null) { Cl_AfficheMessageBox.MessageErreur("Le groupe message n'a pas �t� trouver, Veuillez contacter les d�veloppeurs.\nCode erreur 016"); }
                if (TypeMessageSelect == null) { Cl_AfficheMessageBox.MessageErreur("Le type message n'a pas �t� trouver, Veuillez contacter les d�veloppeurs.\nCode erreur 017"); }
            }
            catch
            {
                Cl_AfficheMessageBox.MessageAlerte("Une erreur s'est produite. Veuillez contacter les d�veloppeurs.\nCode erreur 015");
                InitialisationListes();
            }
        }
        //
        // � chaque modification de ce champ, une synchronisation est effectu�e avec la liste de codes message
        //
        private void Tb_CodeMessage_TextChanged(object sender, EventArgs e)
        {
            // � chaque modification du code message mettre � jour l'affichage et la donn�e code message
            // l'�l�ment est supprim� puis rajouter pour pouvoir mettre � jour l'affichage
            try
            {
                if (TypeModificationMessage == INSERT) // si une modification
                {
                    Cl_Message MessageSelect = Cb_CodeMessage.SelectedItem as Cl_Message; // r�cup�re l'instance s�lectionn�e dans la liste

                    if (MessageSelect == null)
                    {
                        Cl_AfficheMessageBox.MessageAlerte("Une erreur est survenue, Veuillez contacter les d�veloppeurs.\nCode erreur 019");
                        InitialisationListes();
                        return;
                    }

                    // Je r�cup�re le type et groupe message associ� au message
                    Cl_GroupeMessage GroupeMessageSelectionner = MessageSelect.GroupeMessage;
                    Cl_TypeMessage TypeMessageSelectionner = MessageSelect.TypeMessage;

                    // V�rifie que les valeurs type et groupe message existent
                    if (GroupeMessageSelectionner == null) { Cl_AfficheMessageBox.MessageErreur("Le groupe message n'a pas �t� trouver, Veuillez contacter les d�veloppeurs.\nCode erreur 016"); }
                    if (TypeMessageSelectionner == null) { Cl_AfficheMessageBox.MessageErreur("Le type message n'a pas �t� trouver, Veuillez contacter les d�veloppeurs.\nCode erreur 017"); }

                    Cb_CodeMessage.Items.RemoveAt(Cb_CodeMessage.SelectedIndex); // je supprime l'�l�ment de la liste

                    // j'instancie un nouveau message avec le nouveau code
                    Cl_Message NouveauMessage = new Cl_Message(0, GroupeMessageSelectionner, TypeMessageSelectionner, Tb_CodeMessage.Text, Tb_Message.Text);
                    Cb_CodeMessage.Items.Add(NouveauMessage); // je l'ajoute dans la liste
                    Cb_CodeMessage.SelectedItem = NouveauMessage; // je s�lectionne l'�l�ment qui vient d'�tre ajout�
                }
                else if (TypeModificationMessage == UPDATE)
                {
                    Cl_Message MessageSelect = Cb_CodeMessage.SelectedItem as Cl_Message; // r�cup�re l'instance s�lectionn�e dans la liste

                    if (MessageSelect == null)
                    {
                        Cl_AfficheMessageBox.MessageAlerte("Une erreur est survenue, Veuillez contacter les d�veloppeurs.\nCode erreur 019");
                        InitialisationListes();
                        return;
                    }

                    Cb_CodeMessage.Items.RemoveAt(Cb_CodeMessage.SelectedIndex); // je supprime l'�l�ment
                    MessageSelect.CodeMessage = Tb_CodeMessage.Text; // r�cup�re le nouveau code message
                    Cb_CodeMessage.Items.Add(MessageSelect); // je l'ajoute dans la liste
                    Cb_CodeMessage.SelectedItem = TypeModificationMessage; // je s�lectionne l'�l�ment qui vient d'�tre ajout�
                }
            }
            catch
            {
                Cl_AfficheMessageBox.MessageAlerte("Une erreur s'est produite. Veuillez contacter les d�veloppeurs.\nCode erreur 018");
            }
        }
        //
        // selection d'un type message
        //
        private void Cb_TypeMessage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // si je suis en modification
                if (TypeModificationMessage != "")
                {
                    Cl_Message MessageSelect = Cb_CodeMessage.SelectedItem as Cl_Message;
                    Cl_TypeMessage TypeMessageSelect = Cb_TypeMessage.SelectedItem as Cl_TypeMessage;
                    MessageSelect.TypeMessage = TypeMessageSelect;
                }
            }
            catch
            {
                Cl_AfficheMessageBox.MessageErreur("Une erreur est survenue, Veuillez contacter les d�veloppeurs.\nCode erreur 025");
            }
        }
        //
        // selection d'un groupe message
        //
        private void Cb_GroupeMessage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // si je suis en modification
                if (TypeModificationMessage != "")
                {
                    Cl_Message MessageSelect = Cb_CodeMessage.SelectedItem as Cl_Message;
                    Cl_GroupeMessage GroupeMessageSelect = Cb_GroupeMessage.SelectedItem as Cl_GroupeMessage;
                    MessageSelect.GroupeMessage = GroupeMessageSelect;
                }
            }
            catch
            {
                Cl_AfficheMessageBox.MessageErreur("Une erreur est survenue, Veuillez contacter les d�veloppeurs.\nCode erreur 026");
            }
        }
        //
        // Modification du label message
        //
        private void Tb_Message_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // si je suis en modification
                if (TypeModificationMessage != "")
                {
                    Cl_Message MessageSelect = Cb_CodeMessage.SelectedItem as Cl_Message;
                    MessageSelect.Message = Tb_Message.Text;
                }
            }
            catch
            {
                Cl_AfficheMessageBox.MessageErreur("Une erreur est survenue, Veuillez contacter les d�veloppeurs.\nCode erreur 027");
            }
        }
        //
        // �v�nement bouton "nouveau message"
        //
        private void Btn_NouveauMessage_Click(object sender, EventArgs e)
        {
            try
            {
                // j'instancie un type et un groupe message qui sera temporaire au message
                Cl_GroupeMessage NouveauGroupeMessage = new Cl_GroupeMessage(0, "Nouveau label groupe message");
                Cl_TypeMessage NouveauTypeMessage = new Cl_TypeMessage(0, "Nouveau type message");

                TypeModificationMessage = INSERT; // On indique que le message est en mode INSERT

                Cl_Message NouveauMessage = new Cl_Message(0, NouveauGroupeMessage, NouveauTypeMessage, "XXXX", "Aucun message"); // Cr�e un nouvel objet Cl_Message
                Cb_CodeMessage.Items.Add(NouveauMessage); // ajout dans la liste
                Cb_CodeMessage.SelectedItem = NouveauMessage; // s�lectionne la nouvelle valeur ajout�e

                // init la valeur des champs par d�faut
                Tb_Message.Text = NouveauMessage.Message;
                Tb_CodeMessage.Text = NouveauMessage.CodeMessage;

                // valeur par d�faut des listes
                Cb_GroupeMessage.Items.Add(NouveauGroupeMessage); // ajout dans la liste
                Cb_GroupeMessage.SelectedItem = NouveauGroupeMessage; // s�lectionne la nouvelle valeur ajout�e
                Cb_TypeMessage.Items.Add(NouveauTypeMessage); // ajout dans la liste
                Cb_TypeMessage.SelectedItem = NouveauTypeMessage; // s�lectionne la nouvelle valeur ajout�e

                ModeAffichageEditeMessage();
            }
            catch
            {
                Cl_AfficheMessageBox.MessageAlerte("Une erreur est survenue, Veuillez contacter les d�veloppeurs.\nCode erreur 020");
                InitialisationListes();
            }
        }
        //
        // evenement bouton "enregistrer message"
        //
        private void Btn_EnregistrerMessage_Click(object sender, EventArgs e)
        {
            try
            {
                Cl_Message MessageSelect = Cb_CodeMessage.SelectedItem as Cl_Message; // r�cup�re l'instance selectionner dans la liste

                // v�rifie si la valeur n'est pas � null
                if (MessageSelect == null)
                {
                    Cl_AfficheMessageBox.MessageAlerte("Une erreur est survenue, Veuillez contacter les d�veloppeurs.\nCode erreur 021");
                    InitialisationListes();
                    return;
                }

                // v�rifie si les valeurs li�es au message sont correctes
                if (MessageSelect.ValeurCorrecte() == false) { return; }

                // v�rifie si le code n'existe pas
                foreach (Cl_Message MessageParcouru in Cb_CodeMessage.Items)
                {
                    if (MessageParcouru.CodeMessage == MessageSelect.CodeMessage && MessageParcouru != MessageSelect)
                    {
                        Cl_AfficheMessageBox.MessageAlerte("Le code " + MessageParcouru.CodeMessage + " existe d�j�.");
                        return;
                    }
                }

                // enregistrement
                if (TypeModificationMessage == INSERT)
                {
                    MessageSelect.Insert();
                }
                else if (TypeModificationMessage == UPDATE)
                {
                    MessageSelect.Update();
                }

                // initialisation
                TypeModificationMessage = "";
                InitialisationListes();
            }
            catch
            {
                Cl_AfficheMessageBox.MessageAlerte("Une erreur est survenue, Veuillez contacter les d�veloppeurs.\nCode erreur 022");
                InitialisationListes();
            }
        }
        //
        // evenement bouton "modifier message"
        //
        private void Btn_ModifierMessage_Click(object sender, EventArgs e)
        {
            TypeModificationMessage = UPDATE;
            ModeAffichageEditeMessage();
        }
        //
        // evenement bouton "supprimer message"
        //
        private void Btn_SupprimerMessage_Click(object sender, EventArgs e)
        {
            try
            {
                if (TypeModificationMessage == "")
                {
                    Cl_Message MessageSelect = Cb_CodeMessage.SelectedItem as Cl_Message; // r�cup�re l'instance selectionner dans la liste

                    // v�rifie si la valeur n'est pas � null
                    if (MessageSelect == null)
                    {
                        Cl_AfficheMessageBox.MessageAlerte("Une erreur est survenue, Veuillez contacter les d�veloppeurs.\nCode erreur 023");
                        InitialisationListes();
                        return;
                    }

                    MessageSelect.Delete();
                }

                // initialisation
                TypeModificationMessage = "";
                InitialisationListes();
            }
            catch
            {
                Cl_AfficheMessageBox.MessageAlerte("Une erreur est survenue, Veuillez contacter les d�veloppeurs.\nCode erreur 024");
                InitialisationListes();
            }
        }

        // ##################################################### //
        // ############### ONGLET GROUPE MESSAGE ############### //
        // ##################################################### //

        //
        // �v�nement lors de la s�lection d'un �l�ment de la liste groupe message
        //
        private void Cb_ChercheGroupeMessage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // r�cup�re l'instance groupe message s�lectionner dans la liste
                Cl_GroupeMessage GroupeMessageSelect = Cb_ChercheGroupeMessage.SelectedItem as Cl_GroupeMessage;

                // si la valeur s�lectionn�e est � null
                if (GroupeMessageSelect == null)
                {
                    Cl_AfficheMessageBox.MessageErreur("Une erreur est survenue, Veuillez contacter les d�veloppeurs.\nCode erreur 028");
                    return;
                }
                
                Tb_LabelGroupeMessage.Text = GroupeMessageSelect.LabelGroupeMessage; // Synchronise le labelle champ texte avec la liste
            }
            catch
            {
                Cl_AfficheMessageBox.MessageErreur("Une erreur est survenue, Veuillez contacter les d�veloppeurs.\nCode erreur 029");
            }
        }
        //
        // a chaque modification de se champ, une synchronisation est effectu� avec la liste de groupe message
        //
        private void Tb_LabelGroupeMessage_TextChanged(object sender, EventArgs e)
        {
            // � chaque modification du label groupe message, mettre � jour l'affichage de la liste
            // l'�l�ment est supprim� puis rajouter pour pouvoir mettre � jour l'affichage
            try
            {
                if (TypeModificationGroupeMessage == INSERT) // si une modification
                {
                    Cb_ChercheGroupeMessage.Items.RemoveAt(Cb_ChercheGroupeMessage.SelectedIndex); // je supprime l'�l�ment

                    // j'instancie un nouveau groupe message avec le nouveau texte
                    Cl_GroupeMessage NouveauGroupeMessage = new Cl_GroupeMessage(0, Tb_LabelGroupeMessage.Text);
                    Cb_ChercheGroupeMessage.Items.Add(NouveauGroupeMessage); // je l'ajoute dans la liste
                    Cb_ChercheGroupeMessage.SelectedItem = NouveauGroupeMessage; // je s�lectionne l'�l�ment qui vient d'�tre ajout�
                }
                else if (TypeModificationGroupeMessage == UPDATE)
                {
                    Cl_GroupeMessage GroupeMessageSelect = Cb_ChercheGroupeMessage.SelectedItem as Cl_GroupeMessage; // r�cup�re l'instance selectionner dans la liste

                    if (GroupeMessageSelect == null)
                    {
                        Cl_AfficheMessageBox.MessageAlerte("Une erreur est survenue, Veuillez contacter les d�veloppeurs.\nCode erreur 030");
                        InitialisationListes();
                        return;
                    }

                    Cb_ChercheGroupeMessage.Items.RemoveAt(Cb_ChercheGroupeMessage.SelectedIndex); // je supprime l'�l�ment

                    GroupeMessageSelect.LabelGroupeMessage = Tb_LabelGroupeMessage.Text; // modifie le label
                    Cb_ChercheGroupeMessage.Items.Add(GroupeMessageSelect); // je l'ajoute dans la liste
                    Cb_ChercheGroupeMessage.SelectedItem = GroupeMessageSelect; // je s�lectionne l'�l�ment qui vient d'�tre ajout
                    Cb_ChercheGroupeMessage.SelectedItem = TypeModificationGroupeMessage; // je s�lectionne l'�l�ment qui vient d'�tre ajout�
                }
            }
            catch
            {
                Cl_AfficheMessageBox.MessageErreur("Une erreur est survenue, Veuillez contacter les d�veloppeurs.\nCode erreur 031");
            }
        }
        //
        // �v�nement bouton "nouveau groupe message"
        //
        private void Btn_NouveauGroupeMessage_Click(object sender, EventArgs e)
        {
            try
            {
                Cl_GroupeMessage nouveauGroupeMessage = new Cl_GroupeMessage(0, "Nouveau label groupe message"); // Instancie un nouveau groupe message
                Cb_ChercheGroupeMessage.Items.Add(nouveauGroupeMessage); // ajout dans la liste
                Cb_ChercheGroupeMessage.SelectedItem = nouveauGroupeMessage; // selectionne la nouvelle valeur ajouter
                Tb_LabelGroupeMessage.Text = "Nouveau label groupe message";
                
                TypeModificationGroupeMessage = INSERT; // On indique que le groupe message est en mode INSERT
                ModeAffichageEditeGroupeMessage();
            }
            catch
            {
                Cl_AfficheMessageBox.MessageErreur("Une erreur est survenue, Veuillez contacter les d�veloppeurs.\nCode erreur 032");
            }
        }
        //
        // evenement bouton "enregistrer groupe message"
        //
        private void Btn_EnregistrerGroupeMessage_Click(object sender, EventArgs e)
        {
            try
            {
                Cl_GroupeMessage GroupeMessageSelect = Cb_ChercheGroupeMessage.SelectedItem as Cl_GroupeMessage; // r�cup�re l'instance selectionner dans la liste

                if (GroupeMessageSelect == null) 
                {
                    Cl_AfficheMessageBox.MessageErreur("Une erreur est survenue, Veuillez contacter les d�veloppeurs.\nCode erreur 033");
                    return;
                }

                // v�rifie si les valeurs li�es au message sont correctes
                if (GroupeMessageSelect.ValeurCorrecte() == false) { return; }

                // v�rifie qu'il n'y a pas un autre �l�ment qui a le m�me label 
                foreach (Cl_GroupeMessage elementGroupeMessage in Cb_ChercheGroupeMessage.Items)
                {
                    if (elementGroupeMessage != null)
                    {
                        if (elementGroupeMessage.LabelGroupeMessage == GroupeMessageSelect.LabelGroupeMessage && GroupeMessageSelect != elementGroupeMessage)
                        {
                            Cl_AfficheMessageBox.MessageAlerte("Il ne peut pas y avoir 2 m�me label groupe message");
                            return;
                        }
                    }
                }

                if (TypeModificationGroupeMessage == UPDATE) // si c'est une mise � jour
                {
                    GroupeMessageSelect.Update();
                }
                else if (TypeModificationGroupeMessage == INSERT) // si c'est une nouvelle valeurs
                {
                    GroupeMessageSelect.Insert();
                }
                else
                {
                    Cl_AfficheMessageBox.MessageErreur("Il n'y a aucun enregistrement � effectuer, Veuillez contacter les d�veloppeurs.\nCode erreur 034");
                }

                TypeModificationGroupeMessage = ""; // plus de modification en cours
                InitialisationListes();
            }
            catch
            {
                Cl_AfficheMessageBox.MessageErreur("Une erreur est survenue, Veuillez contacter les d�veloppeurs.\nCode erreur 035");
            }
        }
        //
        // evenement bouton "supprimer groupe message"
        //
        private void Btn_SupprimerGroupeMessage_Click(object sender, EventArgs e)
        {
            try
            {
                // si aucune modification est en cours
                if (TypeModificationGroupeMessage == "")
                {
                    Cl_GroupeMessage ElementGroupeMessage = Cb_ChercheGroupeMessage.SelectedItem as Cl_GroupeMessage; // r�cup�re l'instance selectionner dans la liste

                    // v�rifie si la valeur n'est pas � null
                    if (ElementGroupeMessage == null)
                    {
                        Cl_AfficheMessageBox.MessageAlerte("Une erreur est survenue, Veuillez contacter les d�veloppeurs.\nCode erreur 036");
                        InitialisationListes();
                        return;
                    }

                    string Code = "";

                    // V�rifie que le groupe message n'est pas associ� � un message
                    foreach (Cl_Message MessageSelect in Cb_CodeMessage.Items)
                    {
                        if (MessageSelect.GroupeMessage == ElementGroupeMessage)
                        {
                            Code += MessageSelect.CodeMessage + ", ";
                        }

                    }
                    if (Code != "")
                    {
                        Cl_AfficheMessageBox.MessageAlerte("Le groupe message est utilis� dans le(s) message(s) " + Code + "il ne peut donc pas �tre supprim�.");
                        return;
                    }

                    ElementGroupeMessage.Delete(); // supprime l'�l�ment
                }
            }
            catch
            {
                Cl_AfficheMessageBox.MessageAlerte("Une erreur est survenue, Veuillez contacter les d�veloppeurs.\nCode erreur 041");
            }

            TypeModificationGroupeMessage = "";
            InitialisationListes();
        }
        //
        // �v�nement bouton "modifier groupe message"
        //
        private void Btn_ModifierGroupeMessage_Click(object sender, EventArgs e)
        {
            TypeModificationGroupeMessage = UPDATE;
            ModeAffichageEditeGroupeMessage();
        }

        // ################################################### //
        // ############### ONGLET TYPE MESSAGE ############### //
        // ################################################### //

        //
        // evenement lors de la selection d'un �l�ment de la liste
        //
        private void Cb_ChercheTypeMessage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // r�cup�re l'instance type message s�lectionner dans la liste
                Cl_TypeMessage TypeMessageSelect = Cb_ChercheTypeMessage.SelectedItem as Cl_TypeMessage;

                // si la valeur s�lectionn�e est � null
                if (TypeMessageSelect == null)
                {
                    Cl_AfficheMessageBox.MessageErreur("Une erreur est survenue, Veuillez contacter les d�veloppeurs.\nCode erreur 038");
                    return;
                }

                Tb_LabelTypeMessage.Text = TypeMessageSelect.LabelTypeMessage;
            }
            catch
            {
                Cl_AfficheMessageBox.MessageErreur("Une erreur est survenue, Veuillez contacter les d�veloppeurs.\nCode erreur 037");
            }
        }
        //
        // a chaque modification de se champ, une synchronisation est effectu� avec la liste de type message
        //
        private void Tb_LabelTypeMessage_TextChanged(object sender, EventArgs e)
        {
            // � chaque modification du label type message, mettre � jour l'affichage de la liste
            // l'�l�ment est supprim� puis rajouter pour pouvoir mettre � jour l'affichage
            try
            {
                if (TypeModificationTypeMessage == INSERT) // si une modification
                {
                    Cb_ChercheTypeMessage.Items.RemoveAt(Cb_ChercheTypeMessage.SelectedIndex); // je supprime l'�l�ment

                    // j'instancie un nouveau Type message avec le nouveau texte
                    Cl_TypeMessage nouveauTypeMessage = new Cl_TypeMessage(0, Tb_LabelTypeMessage.Text);
                    Cb_ChercheTypeMessage.Items.Add(nouveauTypeMessage); // je l'ajoute dans la liste
                    Cb_ChercheTypeMessage.SelectedItem = nouveauTypeMessage; // je s�lectionne l'�l�ment qui vient d'�tre ajout�
                }
                else if (TypeModificationTypeMessage == UPDATE)
                {
                    Cl_TypeMessage TypeMessageSelect = Cb_ChercheTypeMessage.SelectedItem as Cl_TypeMessage; // r�cup�re l'instance selectionner dans la liste
                    Cb_ChercheTypeMessage.Items.RemoveAt(Cb_ChercheTypeMessage.SelectedIndex); // je supprime l'�l�ment
                    TypeMessageSelect.LabelTypeMessage = Tb_LabelTypeMessage.Text; // modifie le label
                    Cb_ChercheTypeMessage.Items.Add(TypeMessageSelect); // je l'ajoute dans la liste
                    Cb_ChercheTypeMessage.SelectedItem = TypeMessageSelect; // je selectionne l'�l�ment qui vient d'etre ajou
                    Cb_ChercheTypeMessage.SelectedItem = TypeModificationTypeMessage; // je s�lectionne l'�l�ment qui vient d'�tre ajout�
                }
            }
            catch
            {
                Cl_AfficheMessageBox.MessageErreur("Une erreur est survenue, Veuillez contacter les d�veloppeurs.\nCode erreur 039");
            }
        }
        //
        // evenement bouton "nouveau type message"
        //
        private void Btn_NouveauTypeMessage_Click(object sender, EventArgs e)
        {
            try
            {
                Cl_TypeMessage nouveauTypeMessage = new Cl_TypeMessage(0, "Nouveau type message"); // Instancie un nouveau type message
                Cb_ChercheTypeMessage.Items.Add(nouveauTypeMessage); // ajout dans la liste
                Cb_ChercheTypeMessage.SelectedItem = nouveauTypeMessage; // selectionne la nouvelle valeur ajouter
                Tb_LabelTypeMessage.Text = "Nouveau type message";
            }
            catch
            {
                Cl_AfficheMessageBox.MessageErreur("Une erreur est survenue, Veuillez contacter les d�veloppeurs.\nCode erreur 042");
            }

            TypeModificationTypeMessage = INSERT; // On indique que le groupe message est en mode INSERT
            ModeAffichageEditeTypeMessage();
        }
        //
        // evenement bouton "enregistrer type message"
        //
        private void Btn_EnregistrerTypeMessage_Click(object sender, EventArgs e)
        {
            try
            {
                Cl_TypeMessage TypeMessageSelect = Cb_ChercheTypeMessage.SelectedItem as Cl_TypeMessage; // r�cup�re l'instance selectionner dans la liste

                if (TypeMessageSelect.ValeurCorrecte() == false) { return; }

                if (TypeMessageSelect == null)
                {
                    Cl_AfficheMessageBox.MessageErreur("Une erreur est survenue, Veuillez contacter les d�veloppeurs.\nCode erreur 045");
                    return;
                }

                // v�rifie qu'il n'y a pas un autre �l�ment qui a le m�me label 
                foreach (Cl_TypeMessage elementTypeMessage in Cb_ChercheTypeMessage.Items)
                {
                    if (elementTypeMessage != null)
                    {
                        if (elementTypeMessage.LabelTypeMessage == TypeMessageSelect.LabelTypeMessage && TypeMessageSelect != elementTypeMessage)
                        {
                            Cl_AfficheMessageBox.MessageAlerte("Il ne peut pas y avoir 2 m�me label type message");
                            return;
                        }
                    }
                }

                if (TypeModificationTypeMessage == UPDATE) // si c'est une mise � jour
                {
                    TypeMessageSelect.Update();
                }
                else if (TypeModificationTypeMessage == INSERT) // si c'est une nouvelle valeurs
                {
                    TypeMessageSelect.Insert();
                }
                else
                {
                    Cl_AfficheMessageBox.MessageErreur("Il n'y a aucun enregistrement � effectuer, Veuillez contacter les d�veloppeurs.\nCode erreur 043");
                }

                TypeModificationTypeMessage = ""; // plus de modification en cours
                InitialisationListes(); // initialise les listes
            }
            catch
            {
                Cl_AfficheMessageBox.MessageErreur("Une erreur est survenue, Veuillez contacter les d�veloppeurs.\nCode erreur 044");
            }
        }
        //
        // evenement bouton "modifier type message"
        //
        private void Btn_ModifierTypeMessage_Click(object sender, EventArgs e)
        {
            TypeModificationTypeMessage = UPDATE;
            ModeAffichageEditeTypeMessage();
        }
        //
        // evenement bouton "supprimer type message"
        //
        private void Btn_SupprimerTypeMessage_Click(object sender, EventArgs e)
        {
            try
            {
                if (TypeModificationTypeMessage == "")
                {
                    Cl_TypeMessage ElementTypeMessage = Cb_ChercheTypeMessage.SelectedItem as Cl_TypeMessage;

                    // v�rifie si la valeur n'est pas � null
                    if (ElementTypeMessage == null)
                    {
                        Cl_AfficheMessageBox.MessageAlerte("Une erreur est survenue, Veuillez contacter les d�veloppeurs.\nCode erreur 047");
                        InitialisationListes();
                        return;
                    }

                    string Code = "";

                    // V�rifie que le groupe message n'est pas associ� � un message
                    foreach (Cl_Message MessageSelect in Cb_CodeMessage.Items)
                    {
                        if (MessageSelect.TypeMessage == ElementTypeMessage)
                        {
                            Code += MessageSelect.CodeMessage + ", ";
                        }

                    }
                    if (Code != "")
                    {
                        Cl_AfficheMessageBox.MessageAlerte("Le groupe message est utilis� dans le(s) message(s) " + Code + "il ne peut donc pas �tre supprim�.");
                        return;
                    }

                    ElementTypeMessage.Delete(); // supprime l'�l�ment
                }
            }
            catch
            {
                Cl_AfficheMessageBox.MessageAlerte("Une erreur est survenue, Veuillez contacter les d�veloppeurs.\nCode erreur 046");
            }

            TypeModificationTypeMessage = "";
            InitialisationListes();
        }

        // #################################################### //
        // ############### Affichage des champs ############### //
        // #################################################### //

        //
        // Initialise toutes les listes de l'application
        //
        private void InitialisationListes()
        {
            remplieListe(TYPE_MESSAGE);
            remplieListe(GROUPE_MESSAGE);
            remplieListe(MESSAGE);
        }
        //
        // Remplie les listes
        //
        private void remplieListe(string NomListe)
        {
            try
            {
                ComboBox CB_OngletMessage;
                ComboBox CB_OngletEdition;
                string RequeteSQL;
                AffichageChamp AffichageChamp;

                switch (NomListe)
                {
                    case GROUPE_MESSAGE:
                        CB_OngletMessage = Cb_GroupeMessage; // Onglet Message
                        CB_OngletEdition = Cb_ChercheGroupeMessage; // Onglet Groupe Message
                        RequeteSQL = "SELECT IdGroupeMessage, LabelGroupeMessage FROM T_GroupeMessage;"; // Requete SQL
                        AffichageChamp = ModeAffichageAucunGroupeMessage; // fonction qui sera appel�e
                        break;
                    case TYPE_MESSAGE:
                        CB_OngletMessage = Cb_TypeMessage; // Onglet Message
                        CB_OngletEdition = Cb_ChercheTypeMessage; // Onglet Type Message
                        RequeteSQL = "SELECT IdTypeMessage, LabelTypeMessage FROM T_TypeMessage;"; // Requete SQL
                        AffichageChamp = ModeAffichageAucunTypeMessage; // fonction qui sera appel�e
                        break;
                    case MESSAGE:
                        CB_OngletEdition = Cb_CodeMessage; // Liste de l'onglet Message
                        CB_OngletMessage = new ComboBox(); // Liste zombie, pour �viter l'erreur
                        RequeteSQL = """
                            SELECT 
                                IdMessage, 
                                IdGroupeMessage, 
                                IdTypeMessage, 
                                CodeMessage, 
                                Message
                            FROM 
                                T_Message;
                            """; // Requete SQL
                        AffichageChamp = ModeAffichageAucunMessage; // fonction qui sera appel�e
                        break;
                    default:
                        Cl_AfficheMessageBox.MessageErreur("Une erreur est survenue, Veuillez contacter les d�veloppeurs.\nCode erreur 049");
                        return;
                }

                // vide les listes
                CB_OngletEdition.Items.Clear();
                CB_OngletMessage.Items.Clear();

                SQLiteCommand CommandSQLite = new SQLiteCommand(RequeteSQL, BDD_SQLlite.Connexion); // cr�e la commande SQLite

                BDD_SQLlite.Connexion.Open(); // Ouvre la connexion � la base
                SQLiteDataReader Reader = CommandSQLite.ExecuteReader(); // execute la commande en mode lecture

                while (Reader.Read()) // tant qu'il y a encore des donn�es � lire
                {
                    if (NomListe == MESSAGE) // Si les donn�es � aliment� sont des messages
                    {
                        int IdMessageLu = Reader.GetInt32(0); // r�cup�re la 1er colonne
                        int IdGroupeMessageLu = Reader.GetInt32(1); // r�cup�re la 2�me colonne
                        int IdTypeMessageLu = Reader.GetInt32(2); // r�cup�re la 3�me colonne
                        string CodeLu = Reader.GetString(3); // r�cup�re la 4�me colonne
                        string MessageLu = Reader.GetString(4); // r�cup�re la 5�me colonne

                        Cl_GroupeMessage GroupeMessageLu = null;
                        Cl_TypeMessage TypeMessageLu = null;

                        // r�cup�re la valeur type et groupe message li� au message en parcourant les listes "Cb_ChercheGroupeMessage" et "Cb_ChercheTypeMessage"
                        // ATTENTION: les listes "Cb_ChercheGroupeMessage" et "Cb_ChercheTypeMessage" doivent �tre remplies avant !!!
                        foreach (Cl_GroupeMessage groupeMessageTrouver in Cb_ChercheGroupeMessage.Items)
                        {
                            if (groupeMessageTrouver.IdGroupeMessage == IdGroupeMessageLu) { GroupeMessageLu = groupeMessageTrouver; }
                        }
                        foreach (Cl_TypeMessage typeMessageTrouver in Cb_ChercheTypeMessage.Items)
                        {
                            if (typeMessageTrouver.IdTypeMessage == IdTypeMessageLu) { TypeMessageLu = typeMessageTrouver; }
                        }

                        if (GroupeMessageLu == null)
                        {
                            Cl_AfficheMessageBox.MessageErreur("Le message " + CodeLu + " n'est pas li� � de groupe message.\nVeuillez contacter les d�veloppeurs.");
                            return;
                        }
                        else if (TypeMessageLu == null)
                        {
                            Cl_AfficheMessageBox.MessageErreur("Le message " + CodeLu + " n'est pas li� � de type message.\nVeuillez contacter les d�veloppeurs.");
                            return;
                        }

                        Cl_Message ValeurMessageRajouter = new Cl_Message(IdMessageLu, GroupeMessageLu, TypeMessageLu, CodeLu, MessageLu);
                        CB_OngletEdition.Items.Add(ValeurMessageRajouter); // ajoute l'instance dans la liste
                        CB_OngletMessage.Items.Add(ValeurMessageRajouter); // ajoute l'instance dans la liste
                    }
                    else // Les types de donn�es GROUPE_MESSAGE et TYPE_MESSAGE sont quasiment identiques
                    {
                        int IdLu = Reader.GetInt32(0); // r�cup�re la 1er colonne
                        string LabelLu = Reader.GetString(1); // r�cup�re la 2eme colonne

                        if (NomListe == GROUPE_MESSAGE)
                        {
                            Cl_GroupeMessage ValeurGroupeMessageRajouter = new Cl_GroupeMessage(IdLu, LabelLu);
                            CB_OngletMessage.Items.Add(ValeurGroupeMessageRajouter); // ajout dans la liste de l'onglet message
                            CB_OngletEdition.Items.Add(ValeurGroupeMessageRajouter); // ajout dans la liste de l'onglet groupe message
                        }
                        else if (NomListe == TYPE_MESSAGE)
                        {
                            Cl_TypeMessage ValeurTypeMessageRajouter = new Cl_TypeMessage(IdLu, LabelLu);
                            CB_OngletMessage.Items.Add(ValeurTypeMessageRajouter); // ajout dans la liste de l'onglet message
                            CB_OngletEdition.Items.Add(ValeurTypeMessageRajouter); // ajout dans la liste de l'onglet type message
                        }
                        else { Cl_AfficheMessageBox.MessageErreur("Une erreur est survenue, Veuillez contacter les d�veloppeurs.\nCode erreur 050"); }
                    }
                }

                Reader.Close(); // ferme la lecture
                BDD_SQLlite.Connexion.Close(); // ferme la connexion � la base de donn�es

                // si je n'ai aucun �l�ment, une valeur par d�faut est rajout�e pour indiquer qu'il n'y a aucune donn�e
                if (CB_OngletEdition.Items.Count == 0)
                {
                    Cl_GroupeMessage ValeurGroupeMessageRajouter = new Cl_GroupeMessage(0, "Aucun groupe message");
                    Cl_TypeMessage ValeurTypeMessageRajouter = new Cl_TypeMessage(0, "Aucun type message");
                    Cl_Message ValeurMessageRajouter = new Cl_Message(0, ValeurGroupeMessageRajouter, ValeurTypeMessageRajouter, "XXXX", "Aucun message");

                    if (NomListe == GROUPE_MESSAGE)
                    {
                        CB_OngletEdition.Items.Add(ValeurGroupeMessageRajouter); // ajoute l'instance dans la liste
                        CB_OngletMessage.Items.Add(ValeurGroupeMessageRajouter); // ajoute l'instance dans la liste
                    }
                    else if (NomListe == TYPE_MESSAGE)
                    {
                        CB_OngletEdition.Items.Add(ValeurTypeMessageRajouter); // ajoute l'instance dans la liste
                        CB_OngletMessage.Items.Add(ValeurTypeMessageRajouter); // ajoute l'instance dans la liste
                    }
                    else if (NomListe == MESSAGE)
                    {
                        CB_OngletEdition.Items.Add(ValeurMessageRajouter); // ajoute l'instance dans la liste
                        CB_OngletMessage.Items.Add(ValeurMessageRajouter); // ajoute l'instance dans la liste
                    }
                    else { Cl_AfficheMessageBox.MessageErreur("Une erreur est survenue, Veuillez contacter les d�veloppeurs.\nCode erreur 051"); }

                    AffichageChamp(true); // affichage des �l�ment
                }
                else
                {
                    AffichageChamp(false); // affichage des �l�ment
                }

                // selectionne le premier �l�ment par d�faut
                CB_OngletEdition.SelectedIndex = 0;
                CB_OngletMessage.SelectedIndex = 0;
            }
            catch 
            {
                Cl_AfficheMessageBox.MessageErreur("Une erreur est survenue, Veuillez contacter les d�veloppeurs.\nCode erreur 048");
            }
        }
        //
        // ModeAffichageAucunMessage
        //
        private void ModeAffichageAucunMessage(bool valeur)
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
        // ModeAffichageEditeMessage
        //
        private void ModeAffichageEditeMessage()
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
        // ModeAffichageAucunGroupeMessage
        //
        private void ModeAffichageAucunGroupeMessage(bool valeur)
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
        // ModeAffichageEditeGroupeMessage
        //
        private void ModeAffichageEditeGroupeMessage()
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
        // ModeAffichageAucunTypeMessage
        //
        private void ModeAffichageAucunTypeMessage(bool valeur)
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
                Tb_LabelTypeMessage.Enabled = false;
                // Bouton
                Btn_EnregistrerTypeMessage.Enabled = false;
                Btn_ModifierTypeMessage.Enabled = true;
                Btn_SupprimerTypeMessage.Enabled = true;
                Btn_NouveauTypeMessage.Enabled = true;
            }
            Btn_SupprimerTypeMessage.Text = "Supprimer";
        }
        //
        // ModeAffichageEditeTypeMessage
        //
        private void ModeAffichageEditeTypeMessage()
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
