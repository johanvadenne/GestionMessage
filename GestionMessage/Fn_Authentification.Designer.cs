namespace GestionMessage
{
    partial class Fn_Authentification
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Tb_Utilisateur = new TextBox();
            Tb_MotDePasse = new TextBox();
            Btn_Connexion = new Button();
            SuspendLayout();
            // 
            // Tb_Utilisateur
            // 
            Tb_Utilisateur.Location = new Point(30, 56);
            Tb_Utilisateur.MaxLength = 512;
            Tb_Utilisateur.Name = "Tb_Utilisateur";
            Tb_Utilisateur.PlaceholderText = "Utilisateur";
            Tb_Utilisateur.Size = new Size(239, 23);
            Tb_Utilisateur.TabIndex = 2;
            Tb_Utilisateur.TextChanged += Tb_Utilisateur_TextChanged;
            // 
            // Tb_MotDePasse
            // 
            Tb_MotDePasse.Location = new Point(30, 85);
            Tb_MotDePasse.MaxLength = 512;
            Tb_MotDePasse.Name = "Tb_MotDePasse";
            Tb_MotDePasse.PasswordChar = '●';
            Tb_MotDePasse.PlaceholderText = "Mot de passe";
            Tb_MotDePasse.Size = new Size(239, 23);
            Tb_MotDePasse.TabIndex = 3;
            Tb_MotDePasse.TextChanged += Tb_MotDePasse_TextChanged;
            // 
            // Btn_Connexion
            // 
            Btn_Connexion.Location = new Point(112, 114);
            Btn_Connexion.Name = "Btn_Connexion";
            Btn_Connexion.Size = new Size(75, 23);
            Btn_Connexion.TabIndex = 4;
            Btn_Connexion.Text = "Connexion";
            Btn_Connexion.UseVisualStyleBackColor = true;
            Btn_Connexion.Click += Btn_Connexion_Click;
            // 
            // Fn_Authentification
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(304, 181);
            Controls.Add(Btn_Connexion);
            Controls.Add(Tb_MotDePasse);
            Controls.Add(Tb_Utilisateur);
            Name = "Fn_Authentification";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Fn_Authentification";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox Tb_Utilisateur;
        private TextBox Tb_MotDePasse;
        private Button Btn_Connexion;
    }
}