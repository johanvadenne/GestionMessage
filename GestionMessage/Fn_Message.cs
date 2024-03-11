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
        // chargement de la fenêtre
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
                SQLiteCommand command = new SQLiteCommand(requeteSQL, BDD_SQLlite.connexion); // créer la commande

                BDD_SQLlite.connexion.Open(); // Ouvre la connexion à la base
                SQLiteDataReader reader = command.ExecuteReader(); // execute la commande en mode lecture

                while (reader.Read()) // tant qu'il y a encore des données à lire
                {
                    int IdGroupeMessage = reader.GetInt32(0); // récupère la 1er colonne
                    string LabelGroupeMessage = reader.GetString(1); // récupère la 2eme colonne

                    Cl_GroupeMessage GroupeMessage = new Cl_GroupeMessage(IdGroupeMessage, LabelGroupeMessage); // j'instancie un nouveau Cl_GroupeMessage
                    Cb_ChercheGroupeMessage.Items.Add(GroupeMessage); // ajoute l'instance dans la liste
                    Cb_GroupeMessage.Items.Add(GroupeMessage); // ajoute l'instance dans la liste
                }
                reader.Close(); // ferme la lecture
                BDD_SQLlite.connexion.Close(); // ferme la connexion à la base de données

                // si je n'ai aucun élément
                if (Cb_ChercheGroupeMessage.Items.Count == 0)
                {
                    Cb_ChercheGroupeMessage.Items.Add("Aucun groupe message");
                    AucunGroupeMessage(true); // affichage des élément
                }
                else
                {
                    AucunGroupeMessage(false); // affichage des élément
                }

                Cb_ChercheGroupeMessage.SelectedIndex = 0; // selectionne le premier élément par défaut
            }
            catch
            {
                Cl_AfficheMessage.MessageErreur("La liste n'a pas été charger corectement");
            }

        }
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
                if (typeModification == UPDATE || typeModification == INSERT)
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
                Cl_AfficheMessage.MessageErreur("Imposible de selectionner un élément");
            }

        }
        //
        // evenement bouton "nouveau groupe message"
        //
        private void Btn_NouveauGroupeMessage_Click(object sender, EventArgs e)
        {
            try
            {
                Cl_GroupeMessage nouveauGroupeMessage = new Cl_GroupeMessage(0, "Nouveau label groupe message"); // Créez un nouvel objet Cl_GroupeMessage
                Cb_ChercheGroupeMessage.Items.Add(nouveauGroupeMessage); // ajout dans la liste
                Cb_ChercheGroupeMessage.SelectedItem = nouveauGroupeMessage; // selectionne la nouvelle valeur ajouter
                Tb_LabelGroupeMessage.Text = "Nouveau label groupe message";

                editeGroupeMessage(); // affichage des élément
                typeModification = INSERT; // repère pour savoir que fait l'utilisateur
            }
            catch
            {
                Cl_AfficheMessage.MessageErreur("La création d'un nouveau groupe message à créer une erreur");
            }
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

                // vérifie qu'il n'y a pas un autre élément qui a le même label 
                foreach (Cl_GroupeMessage elementGroupeMessage in Cb_ChercheGroupeMessage.Items)
                {
                    if (elementGroupeMessage != null)
                    {
                        if (elementGroupeMessage.LabelGroupeMessage == GroupeMessageSelect.LabelGroupeMessage && GroupeMessageSelect != elementGroupeMessage)
                        {
                            Cl_AfficheMessage.MessageAlerte("Il ne peux pas y avoir 2 même label groupe message");
                            return;
                        }
                    }
                }

                if (typeModification == UPDATE) // si c'est une mise à jour
                {
                    GroupeMessageSelect.update();
                }
                else if (typeModification == INSERT) // si c'est une nouvelle valeurs
                {
                    GroupeMessageSelect.insert();
                }
                else
                {
                    Cl_AfficheMessage.MessageErreur("Il n'y a aucun enregistrement à effectuer");
                }
                typeModification = ""; // plus de modification en cours
                remplieListeGroupeMessage(); // initialise la liste
            }
            catch
            {
                Cl_AfficheMessage.MessageErreur("L'enregistrement à provoquer une erreur");
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
                    Cl_GroupeMessage GroupeMessageSelect = Cb_ChercheGroupeMessage.SelectedItem as Cl_GroupeMessage; // récupère l'instance selectionner dans la liste
                    if (GroupeMessageSelect == null) // si la valeur selectionner n'est pas une classe Cl_GroupeMessage
                    {
                        throw new InvalidOperationException(""); // lever une exeption
                    }
                    else
                    {
                        GroupeMessageSelect.delete(); // supprsion de l'élément
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
                Cl_AfficheMessage.MessageErreur("La suppression de l'élément à générer une erreur");
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
        // a chaque modification de se champ, une synchronisation est effectué avec la liste de groupe message
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
                    Cb_ChercheGroupeMessage.Items.RemoveAt(Cb_ChercheGroupeMessage.SelectedIndex); // je supprime l'élément

                    // j'instancie un nouveau groupe message avec le nouveau texte
                    Cl_GroupeMessage nouveauGroupeMessage = new Cl_GroupeMessage(0, Tb_LabelGroupeMessage.Text);
                    Cb_ChercheGroupeMessage.Items.Add(nouveauGroupeMessage); // je l'ajoute dans la liste
                    Cb_ChercheGroupeMessage.SelectedItem = nouveauGroupeMessage; // je selectionne l'élément qui vien d'etre ajouter
                }
                else if (typeModification == UPDATE)
                {
                    Cl_GroupeMessage GroupeMessageSelect = Cb_ChercheGroupeMessage.SelectedItem as Cl_GroupeMessage; // récupère l'instance selectionner dans la liste
                    Cb_ChercheGroupeMessage.Items.RemoveAt(Cb_ChercheGroupeMessage.SelectedIndex); // je supprime l'élément
                    GroupeMessageSelect.LabelGroupeMessage = Tb_LabelGroupeMessage.Text; // modifie le label
                    Cb_ChercheGroupeMessage.Items.Add(GroupeMessageSelect); // je l'ajoute dans la liste
                    Cb_ChercheGroupeMessage.SelectedItem = GroupeMessageSelect; // je selectionne l'élément qui vien d'etre ajou
                    Cb_ChercheGroupeMessage.SelectedItem = GroupeMessageSelect; // je selectionne l'élément qui vien d'etre ajouter
                }
            }
            catch
            {
                Cl_AfficheMessage.MessageErreur("Une erreur dans l'édition du texte à provoquer une erreur");
            }
        }
    }
}
