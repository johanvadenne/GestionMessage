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
            Utilisateur = new Cl_Utilisateur("", "", "");
            identiteWindows = WindowsIdentity.GetCurrent();
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
            Cb_TypeAuthentification.SelectedIndex = 0;
        }

        private void Cb_TypeAuthentification_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cb_TypeAuthentification.SelectedIndex == 0)
            {
                if (identiteWindows == null)
                {
                    Cl_AfficheMessageBox.MessageAlerte("L'authentifications windows n'est pas possible!");
                    Cb_TypeAuthentification.SelectedIndex = 1;
                    return;
                }

                Utilisateur.NomUtilisateur = identiteWindows.Name;
                Utilisateur.TypeAuthentification = Utilisateur.WINDOWS;
                Tb_Utilisateur.Enabled = false;
                Tb_MotDePasse.Enabled = false;
            }
            else if (Cb_TypeAuthentification.SelectedIndex == 1)
            {
                Utilisateur.TypeAuthentification = Utilisateur.MANUELLE;
                Tb_Utilisateur.Enabled = true;
                Tb_MotDePasse.Enabled = true;
            }
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
