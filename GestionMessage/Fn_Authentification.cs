using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionMessage
{
    public partial class Fn_Authentification : Form
    {
        Cl_Utilisateur Utilisateur;
        WindowsIdentity identiteWindows;
        bool connexionUtilisateur = false;
        public string MessageResult { get; private set; }

        public Fn_Authentification()
        {
            InitializeComponent();
            Utilisateur = new Cl_Utilisateur("", "");
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Si la fenêtre est fermée par l'utilisateur sans interaction
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Définir la valeur de MessageResult avant de fermer la fenêtre
                MessageResult = connexionUtilisateur.ToString();
            }
        }

        private void Fn_Authentification_Load(object sender, EventArgs e)
        {
        }

        private void Btn_Connexion_Click(object sender, EventArgs e)
        {
            if (!Utilisateur.valeurCorrect()) { return; }

            connexionUtilisateur = Utilisateur.utilisateurConnexion();

            if (connexionUtilisateur)
            {
                this.Close();
            }
            else
            {
                Cl_AfficheMessageBox.MessageAlerte("Accees refuser!");
            }
        }
    }
}
