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
            Cb_TypeAuthentification = new ComboBox();
            Tb_Utilisateur = new TextBox();
            Tb_MotDePasse = new TextBox();
            Btn_Connexion = new Button();
            SuspendLayout();
            // 
            // Cb_TypeAuthentification
            // 
            Cb_TypeAuthentification.DropDownStyle = ComboBoxStyle.DropDownList;
            Cb_TypeAuthentification.FormattingEnabled = true;
            Cb_TypeAuthentification.Items.AddRange(new object[] { "Authentification Windows", "Authentification manuelle" });
            Cb_TypeAuthentification.Location = new Point(86, 54);
            Cb_TypeAuthentification.Name = "Cb_TypeAuthentification";
            Cb_TypeAuthentification.Size = new Size(177, 23);
            Cb_TypeAuthentification.TabIndex = 0;
            Cb_TypeAuthentification.SelectedIndexChanged += Cb_TypeAuthentification_SelectedIndexChanged;
            // 
            // Tb_Utilisateur
            // 
            Tb_Utilisateur.Location = new Point(55, 83);
            Tb_Utilisateur.MaxLength = 4;
            Tb_Utilisateur.Name = "Tb_Utilisateur";
            Tb_Utilisateur.PlaceholderText = "Utilisateur";
            Tb_Utilisateur.Size = new Size(239, 23);
            Tb_Utilisateur.TabIndex = 2;
            // 
            // Tb_MotDePasse
            // 
            Tb_MotDePasse.Location = new Point(55, 112);
            Tb_MotDePasse.MaxLength = 4;
            Tb_MotDePasse.Name = "Tb_MotDePasse";
            Tb_MotDePasse.PasswordChar = '●';
            Tb_MotDePasse.PlaceholderText = "Mot de passe";
            Tb_MotDePasse.Size = new Size(239, 23);
            Tb_MotDePasse.TabIndex = 3;
            // 
            // Btn_Connexion
            // 
            Btn_Connexion.Location = new Point(137, 141);
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
            ClientSize = new Size(352, 228);
            Controls.Add(Btn_Connexion);
            Controls.Add(Tb_MotDePasse);
            Controls.Add(Tb_Utilisateur);
            Controls.Add(Cb_TypeAuthentification);
            Name = "Fn_Authentification";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Fn_Authentification";
            Load += Fn_Authentification_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox Cb_TypeAuthentification;
        private TextBox Tb_Utilisateur;
        private TextBox Tb_MotDePasse;
        private Button Btn_Connexion;
    }
}