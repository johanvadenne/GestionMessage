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
        public bool connexionUtilisateur { get; private set; }

        public Fn_Authentification()
        {
            InitializeComponent();
            Utilisateur = new Cl_Utilisateur("", "");
        }

        private void Fn_Authentification_Load(object sender, EventArgs e)
        {
        }

        private void Btn_Connexion_Click(object sender, EventArgs e)
        {
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

        private void Tb_Utilisateur_TextChanged(object sender, EventArgs e)
        {
            Utilisateur.NomUtilisateur = Tb_Utilisateur.Text;
        }

        private void Tb_MotDePasse_TextChanged(object sender, EventArgs e)
        {
            Utilisateur.MotDePasse = Tb_MotDePasse.Text;
        }
    }
}
