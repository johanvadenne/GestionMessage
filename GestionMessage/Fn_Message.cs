using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace GestionMessage
{
    public partial class Fn_Message : Form
    {
        Cl_ConnexionBDD BDD_SQLlite = new Cl_ConnexionBDD();
        const string UPDATE = "UPDATE";
        const string INSERT = "INSERT";
        string typeModification = "";

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
            Cb_ChercheGroupeMessage.Items.Clear();

            string requeteSQL = "SELECT IdGroupeMessage, LabelGroupeMessage FROM T_GroupeMessage;";

            SQLiteCommand command = new SQLiteCommand(requeteSQL, BDD_SQLlite.connexion);

            BDD_SQLlite.connexion.Open();
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int IdGroupeMessage = reader.GetInt32(0);
                string LabelGroupeMessage = reader.GetString(1);

                Cl_GroupeMessage GroupeMessage = new Cl_GroupeMessage(IdGroupeMessage, LabelGroupeMessage);
                Cb_ChercheGroupeMessage.Items.Add(GroupeMessage);
                Cb_GroupeMessage.Items.Add(GroupeMessage);
            }
            reader.Close();
            BDD_SQLlite.connexion.Close();

            if (Cb_ChercheGroupeMessage.Items.Count == 0)
            {
                Cb_ChercheGroupeMessage.Items.Add("Aucun groupe message");
                Cb_ChercheGroupeMessage.Enabled = false;
                Btn_SupprimerGroupeMessage.Enabled = false;
                Btn_ModifierGroupeMessage.Enabled = false;
            }
            else
            {
                Btn_ModifierGroupeMessage.Enabled = true;
                Btn_SupprimerGroupeMessage.Enabled = true;
                Cb_ChercheGroupeMessage.Enabled = true;
            }

            Btn_EnregistrerGroupeMessage.Enabled = false;
            Btn_NouveauGroupeMessage.Enabled = true;


            Cb_ChercheGroupeMessage.SelectedIndex = 0;
        }

        private void Cb_ChercheGroupeMessage_SelectedIndexChanged(object sender, EventArgs e)
        {
            // mettre un 'try catch', attention à toi
            Cl_GroupeMessage GroupeMessageSelect = Cb_ChercheGroupeMessage.SelectedItem as Cl_GroupeMessage;
            if (typeModification != UPDATE && typeModification != INSERT)
            {
                Tb_LabelGroupeMessage.Text = GroupeMessageSelect.LabelGroupeMessage;
                Tb_LabelGroupeMessage.Enabled = false;
            }
        }

        private void Btn_NouveauGroupeMessage_Click(object sender, EventArgs e)
        {
            // Créez un nouvel objet Cl_GroupeMessage
            Cl_GroupeMessage nouveauGroupeMessage = new Cl_GroupeMessage(0, "Nouveau label groupe message");
            Cb_ChercheGroupeMessage.Items.Add(nouveauGroupeMessage);
            Cb_ChercheGroupeMessage.SelectedItem = nouveauGroupeMessage;
            Cb_ChercheGroupeMessage.Enabled = false;
            Tb_LabelGroupeMessage.Enabled = true;
            Btn_NouveauGroupeMessage.Enabled = false;
            Btn_EnregistrerGroupeMessage.Enabled = true;
            Btn_ModifierGroupeMessage.Enabled = false;

            typeModification = INSERT;
        }

        private void Btn_EnregistrerGroupeMessage_Click(object sender, EventArgs e)
        {
            Cl_GroupeMessage GroupeMessageSelect = Cb_ChercheGroupeMessage.SelectedItem as Cl_GroupeMessage;

            if (typeModification == UPDATE)
            {
                GroupeMessageSelect.update();
            }
            else if (typeModification == INSERT)
            {
                GroupeMessageSelect.insert();
            }
            else
            {
                // erreur
            }
            typeModification = "";
            remplieListeGroupeMessage();
        }

        private void Btn_SupprimerGroupeMessage_Click(object sender, EventArgs e)
        {
            Cl_GroupeMessage GroupeMessageSelect = Cb_ChercheGroupeMessage.SelectedItem as Cl_GroupeMessage;
            GroupeMessageSelect.delete();
            remplieListeGroupeMessage();
        }

        private void Tb_LabelGroupeMessage_TextChanged(object sender, EventArgs e)
        {
            if (typeModification == UPDATE)
            {
                Cb_ChercheGroupeMessage.Items.RemoveAt(Cb_ChercheGroupeMessage.SelectedIndex);

                Cl_GroupeMessage nouveauGroupeMessage = new Cl_GroupeMessage(0, Tb_LabelGroupeMessage.Text);
                Cb_ChercheGroupeMessage.Items.Add(nouveauGroupeMessage);
                Cb_ChercheGroupeMessage.SelectedItem = nouveauGroupeMessage;
            }
            else if(typeModification == INSERT)
            {
                Cl_GroupeMessage GroupeMessageSelect = Cb_ChercheGroupeMessage.SelectedItem as Cl_GroupeMessage;
                Cb_ChercheGroupeMessage.Items.RemoveAt(Cb_ChercheGroupeMessage.SelectedIndex);

                Cb_ChercheGroupeMessage.Items.Add(GroupeMessageSelect);
                Cb_ChercheGroupeMessage.SelectedItem = GroupeMessageSelect;
            }
        }

        private void Btn_ModifierGroupeMessage_Click(object sender, EventArgs e)
        {
            typeModification = UPDATE;
            Cb_ChercheGroupeMessage.Enabled = false;
            Tb_LabelGroupeMessage.Enabled = true;
            Btn_NouveauGroupeMessage.Enabled = false;
            Btn_EnregistrerGroupeMessage.Enabled = true;
            Btn_ModifierGroupeMessage.Enabled = false;
        }
    }
}
