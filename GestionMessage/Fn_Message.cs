using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Data.SQLite;

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
        string typeModification = "";
        //
        // initialisation affichage
        //
        public Fn_Message()
        {
            InitializeComponent();
        }
        //
        // chargement de la fen�tre
        //
        private void Fn_Message_Load(object sender, EventArgs e)
        {
            remplieListeGroupeMessage();
        }
        //
        // Remplie la liste de groupe message
        //
        private void remplieListeGroupeMessage()
        {
            try
            {
                Cb_ChercheGroupeMessage.Items.Clear(); // supprime la liste

                string requeteSQL = "SELECT IdGroupeMessage, LabelGroupeMessage FROM T_GroupeMessage;"; // Requete SQL
                SQLiteCommand command = new SQLiteCommand(requeteSQL, BDD_SQLlite.connexion); // cr�er la commande

                BDD_SQLlite.connexion.Open(); // Ouvre la connexion � la base
                SQLiteDataReader reader = command.ExecuteReader(); // execute la commande en mode lecture

                while (reader.Read()) // tant qu'il y a encore des donn�es � lire
                {
                    int IdGroupeMessage = reader.GetInt32(0); // r�cup�re la 1er colonne
                    string LabelGroupeMessage = reader.GetString(1); // r�cup�re la 2eme colonne

                    Cl_GroupeMessage GroupeMessage = new Cl_GroupeMessage(IdGroupeMessage, LabelGroupeMessage); // j'instancie un nouveau Cl_GroupeMessage
                    Cb_ChercheGroupeMessage.Items.Add(GroupeMessage); // ajoute l'instance dans la liste
                    Cb_GroupeMessage.Items.Add(GroupeMessage); // ajoute l'instance dans la liste
                }
                reader.Close(); // ferme la lecture
                BDD_SQLlite.connexion.Close(); // ferme la connexion � la base de donn�es

                // si je n'ai aucun �l�ment
                if (Cb_ChercheGroupeMessage.Items.Count == 0)
                {
                    Cb_ChercheGroupeMessage.Items.Add("Aucun groupe message");
                    AucunGroupeMessage(true); // affichage des �l�ment
                }
                else
                {
                    AucunGroupeMessage(false); // affichage des �l�ment
                }

                Cb_ChercheGroupeMessage.SelectedIndex = 0; // selectionne le premier �l�ment par d�faut
            }
            catch
            {
                Cl_AfficheMessage.MessageErreur("La liste n'a pas �t� charger corectement");
            }

        }
        //
        // evenement lors de la selection d'un �l�ment de la liste
        //
        private void Cb_ChercheGroupeMessage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // r�cup�re l'instance selectionner dans la liste
                Cl_GroupeMessage GroupeMessageSelect = Cb_ChercheGroupeMessage.SelectedItem as Cl_GroupeMessage;

                // si la valeur selectionner n'est pas une classe Cl_GroupeMessage
                if (GroupeMessageSelect == null)
                {
                    Tb_LabelGroupeMessage.Enabled = false;
                    return;
                }

                // si c'est un nouveau ou une modification
                if (typeModification == UPDATE || typeModification == INSERT)
                {
                    Tb_LabelGroupeMessage.Enabled = true; // rendre le champ �ditable
                }
                else
                {
                    Tb_LabelGroupeMessage.Enabled = false; // rendre le champ inactif
                    Tb_LabelGroupeMessage.Text = GroupeMessageSelect.LabelGroupeMessage;
                }
            }
            catch
            {
                Cl_AfficheMessage.MessageErreur("Imposible de selectionner un �l�ment");
            }

        }
        //
        // evenement bouton "nouveau groupe message"
        //
        private void Btn_NouveauGroupeMessage_Click(object sender, EventArgs e)
        {
            try
            {
                Cl_GroupeMessage nouveauGroupeMessage = new Cl_GroupeMessage(0, "Nouveau label groupe message"); // Cr�ez un nouvel objet Cl_GroupeMessage
                Cb_ChercheGroupeMessage.Items.Add(nouveauGroupeMessage); // ajout dans la liste
                Cb_ChercheGroupeMessage.SelectedItem = nouveauGroupeMessage; // selectionne la nouvelle valeur ajouter
                Tb_LabelGroupeMessage.Text = "Nouveau label groupe message";

                editeGroupeMessage(); // affichage des �l�ment
                typeModification = INSERT; // rep�re pour savoir que fait l'utilisateur
            }
            catch
            {
                Cl_AfficheMessage.MessageErreur("La cr�ation d'un nouveau groupe message � cr�er une erreur");
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

                if (GroupeMessageSelect == null) // si la valeur selectionner n'est pas une classe Cl_GroupeMessage
                {
                    throw new InvalidOperationException(""); // lever une exeption
                }

                // v�rifie qu'il n'y a pas un autre �l�ment qui a le m�me label 
                foreach (Cl_GroupeMessage elementGroupeMessage in Cb_ChercheGroupeMessage.Items)
                {
                    if (elementGroupeMessage != null)
                    {
                        if (elementGroupeMessage.LabelGroupeMessage == GroupeMessageSelect.LabelGroupeMessage && GroupeMessageSelect != elementGroupeMessage)
                        {
                            Cl_AfficheMessage.MessageAlerte("Il ne peux pas y avoir 2 m�me label groupe message");
                            return;
                        }
                    }
                }

                if (typeModification == UPDATE) // si c'est une mise � jour
                {
                    GroupeMessageSelect.update();
                }
                else if (typeModification == INSERT) // si c'est une nouvelle valeurs
                {
                    GroupeMessageSelect.insert();
                }
                else
                {
                    Cl_AfficheMessage.MessageErreur("Il n'y a aucun enregistrement � effectuer");
                }
                typeModification = ""; // plus de modification en cours
                remplieListeGroupeMessage(); // initialise la liste
            }
            catch
            {
                Cl_AfficheMessage.MessageErreur("L'enregistrement � provoquer une erreur");
            }
        }
        //
        // evenement bouton "supprimer groupe message"
        //
        private void Btn_SupprimerGroupeMessage_Click(object sender, EventArgs e)
        {
            try
            {
                if (typeModification == "")
                {
                    typeModification = "";  // plus de modification en cours
                    Cl_GroupeMessage GroupeMessageSelect = Cb_ChercheGroupeMessage.SelectedItem as Cl_GroupeMessage; // r�cup�re l'instance selectionner dans la liste
                    if (GroupeMessageSelect == null) // si la valeur selectionner n'est pas une classe Cl_GroupeMessage
                    {
                        throw new InvalidOperationException(""); // lever une exeption
                    }
                    else
                    {
                        GroupeMessageSelect.delete(); // supprsion de l'�l�ment
                        remplieListeGroupeMessage(); // initialise la liste
                    }
                }
                else
                {
                    typeModification = "";  // plus de modification en cours
                    remplieListeGroupeMessage(); // initialise la liste
                }
            }
            catch
            {
                Cl_AfficheMessage.MessageErreur("La suppression de l'�l�ment � g�n�rer une erreur");
            }
        }
        //
        // evenement bouton "modifier groupe message"
        //
        private void Btn_ModifierGroupeMessage_Click(object sender, EventArgs e)
        {
            typeModification = UPDATE;
            editeGroupeMessage();
        }
        //
        // a chaque modification de se champ, une synchronisation est effectu� avec la liste de groupe message
        //
        private void Tb_LabelGroupeMessage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Tb_LabelGroupeMessage.Text.Length > 100)
                {
                    Lb_Indicateur.Text = ">100 mots!";
                    Btn_EnregistrerGroupeMessage.Enabled = false;
                }
                else
                {
                    Lb_Indicateur.Text = "";
                    Btn_EnregistrerGroupeMessage.Enabled = true;
                }

                if (typeModification == INSERT) // si une modification
                {
                    Cb_ChercheGroupeMessage.Items.RemoveAt(Cb_ChercheGroupeMessage.SelectedIndex); // je supprime l'�l�ment

                    // j'instancie un nouveau groupe message avec le nouveau texte
                    Cl_GroupeMessage nouveauGroupeMessage = new Cl_GroupeMessage(0, Tb_LabelGroupeMessage.Text);
                    Cb_ChercheGroupeMessage.Items.Add(nouveauGroupeMessage); // je l'ajoute dans la liste
                    Cb_ChercheGroupeMessage.SelectedItem = nouveauGroupeMessage; // je selectionne l'�l�ment qui vien d'etre ajouter
                }
                else if (typeModification == UPDATE)
                {
                    Cl_GroupeMessage GroupeMessageSelect = Cb_ChercheGroupeMessage.SelectedItem as Cl_GroupeMessage; // r�cup�re l'instance selectionner dans la liste
                    Cb_ChercheGroupeMessage.Items.RemoveAt(Cb_ChercheGroupeMessage.SelectedIndex); // je supprime l'�l�ment
                    GroupeMessageSelect.LabelGroupeMessage = Tb_LabelGroupeMessage.Text; // modifie le label
                    Cb_ChercheGroupeMessage.Items.Add(GroupeMessageSelect); // je l'ajoute dans la liste
                    Cb_ChercheGroupeMessage.SelectedItem = GroupeMessageSelect; // je selectionne l'�l�ment qui vien d'etre ajou
                    Cb_ChercheGroupeMessage.SelectedItem = GroupeMessageSelect; // je selectionne l'�l�ment qui vien d'etre ajouter
                }
            }
            catch
            {
                Cl_AfficheMessage.MessageErreur("Une erreur dans l'�dition du texte � provoquer une erreur");
            }
        }
    }
}
