namespace GestionMessage
{
    public partial class Fn_Message : Form
    {
        public Fn_Message()
        {
            InitializeComponent();
        }

        private void Fn_Message_Load(object sender, EventArgs e)
        {

        }

        private void Btn_NouveauGroupeMessage_Click(object sender, EventArgs e)
        {
            Tb_LabelGroupeMessage.PlaceholderText = "Nouveau label groupe message";
        }

        private void Btn_EnregistrerGroupeMessage_Click(object sender, EventArgs e)
        {
            Cl_GroupeMessage test = new Cl_GroupeMessage();
            test.LabelGroupeMessage = Tb_LabelGroupeMessage.Text;
            test.insert();
        }
    }
}
