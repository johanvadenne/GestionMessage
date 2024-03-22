namespace GestionMessage
{
    public partial class Fn_Authentification : Form
    {
        //
        // Variables
        //
        Cl_Utilisateur Utilisateur;
        public bool ConnexionUtilisateur { get; private set; }
        //
        // constructeur
        //
        public Fn_Authentification()
        {
            try
            {
                InitializeComponent();
                Utilisateur = new Cl_Utilisateur("", "");
            }
            catch
            {
                Cl_AfficheMessageBox.MessageErreur("Une erreur s'est produite. Veuillez contacter les développeurs.\nCode erreur 012");
            }
        }
        //
        // Lorsque l'utilisateur tente une connexion
        //
        private void Btn_Connexion_Click(object sender, EventArgs e)
        {
            try
            {
                // si les champs utilisateur et mot de passe ne sont pas remplis ne pas essayer la connexion
                if (!Utilisateur.ValeurCorrecte()) { return; }

                // tentative de connexion
                ConnexionUtilisateur = Utilisateur.utilisateurConnexion();

                // si la connexion de l'utilisateur est réussie on ferme la fenêtre
                if (ConnexionUtilisateur)
                {
                    this.Close();
                }
                // Sinon on affiche un message refusé
                else
                {
                    Cl_AfficheMessageBox.MessageAlerte("Accès refusé!");
                }
            }
            catch
            {
                Cl_AfficheMessageBox.MessageErreur("Une erreur s'est produite. Veuillez contacter les développeurs.\nCode erreur 013");
            }
        }
        //
        // à chaque modification du champ utilisateur
        //
        private void Tb_Utilisateur_TextChanged(object sender, EventArgs e)
        {
            Utilisateur.NomUtilisateur = Tb_Utilisateur.Text;
        }
        //
        // à chaque modification du champ mot de passe
        //
        private void Tb_MotDePasse_TextChanged(object sender, EventArgs e)
        {
            Utilisateur.MotDePasse = Tb_MotDePasse.Text;
        }
    }
}
