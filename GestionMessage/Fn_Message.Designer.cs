namespace GestionMessage
{
    partial class Fn_Message
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Cb_GroupeMessage = new ComboBox();
            Tb_CodeMessage = new TextBox();
            Tb_Message = new TextBox();
            Btn_Nouveau = new Button();
            Btn_Modifier = new Button();
            Btn_Supprimer = new Button();
            Btn_Enregistrer = new Button();
            Lb_Groupe = new Label();
            Lb_Code = new Label();
            Lb_Message = new Label();
            TP_GestionMessage = new TabControl();
            TP_Message = new TabPage();
            Cb_Code = new ComboBox();
            Lb_ChercheCode = new Label();
            TP_GroupeMessage = new TabPage();
            Lb_Indicateur = new Label();
            Cb_ChercheGroupeMessage = new ComboBox();
            Lb_ChercheGroupeMessage = new Label();
            Btn_EnregistrerGroupeMessage = new Button();
            Btn_NouveauGroupeMessage = new Button();
            Btn_SupprimerGroupeMessage = new Button();
            Btn_ModifierGroupeMessage = new Button();
            Lb_LabelGroupeMessage = new Label();
            Tb_LabelGroupeMessage = new TextBox();
            TP_GestionMessage.SuspendLayout();
            TP_Message.SuspendLayout();
            TP_GroupeMessage.SuspendLayout();
            SuspendLayout();
            // 
            // Cb_GroupeMessage
            // 
            Cb_GroupeMessage.FormattingEnabled = true;
            Cb_GroupeMessage.Location = new Point(65, 17);
            Cb_GroupeMessage.Name = "Cb_GroupeMessage";
            Cb_GroupeMessage.Size = new Size(121, 23);
            Cb_GroupeMessage.TabIndex = 0;
            // 
            // Tb_CodeMessage
            // 
            Tb_CodeMessage.Location = new Point(67, 47);
            Tb_CodeMessage.Name = "Tb_CodeMessage";
            Tb_CodeMessage.Size = new Size(39, 23);
            Tb_CodeMessage.TabIndex = 1;
            // 
            // Tb_Message
            // 
            Tb_Message.Location = new Point(65, 78);
            Tb_Message.Multiline = true;
            Tb_Message.Name = "Tb_Message";
            Tb_Message.Size = new Size(327, 92);
            Tb_Message.TabIndex = 2;
            // 
            // Btn_Nouveau
            // 
            Btn_Nouveau.Location = new Point(128, 176);
            Btn_Nouveau.Name = "Btn_Nouveau";
            Btn_Nouveau.Size = new Size(75, 23);
            Btn_Nouveau.TabIndex = 3;
            Btn_Nouveau.Text = "Nouveau";
            Btn_Nouveau.UseVisualStyleBackColor = true;
            // 
            // Btn_Modifier
            // 
            Btn_Modifier.Location = new Point(128, 205);
            Btn_Modifier.Name = "Btn_Modifier";
            Btn_Modifier.Size = new Size(75, 23);
            Btn_Modifier.TabIndex = 4;
            Btn_Modifier.Text = "Modifier";
            Btn_Modifier.UseVisualStyleBackColor = true;
            // 
            // Btn_Supprimer
            // 
            Btn_Supprimer.Location = new Point(209, 205);
            Btn_Supprimer.Name = "Btn_Supprimer";
            Btn_Supprimer.Size = new Size(75, 23);
            Btn_Supprimer.TabIndex = 5;
            Btn_Supprimer.Text = "Supprimer";
            Btn_Supprimer.UseVisualStyleBackColor = true;
            // 
            // Btn_Enregistrer
            // 
            Btn_Enregistrer.Location = new Point(209, 176);
            Btn_Enregistrer.Name = "Btn_Enregistrer";
            Btn_Enregistrer.Size = new Size(75, 23);
            Btn_Enregistrer.TabIndex = 6;
            Btn_Enregistrer.Text = "Enregistrer";
            Btn_Enregistrer.UseVisualStyleBackColor = true;
            // 
            // Lb_Groupe
            // 
            Lb_Groupe.AutoSize = true;
            Lb_Groupe.Location = new Point(6, 20);
            Lb_Groupe.Name = "Lb_Groupe";
            Lb_Groupe.Size = new Size(46, 15);
            Lb_Groupe.TabIndex = 7;
            Lb_Groupe.Text = "Groupe";
            // 
            // Lb_Code
            // 
            Lb_Code.AutoSize = true;
            Lb_Code.Location = new Point(8, 50);
            Lb_Code.Name = "Lb_Code";
            Lb_Code.Size = new Size(35, 15);
            Lb_Code.TabIndex = 8;
            Lb_Code.Text = "Code";
            // 
            // Lb_Message
            // 
            Lb_Message.AutoSize = true;
            Lb_Message.Location = new Point(6, 81);
            Lb_Message.Name = "Lb_Message";
            Lb_Message.Size = new Size(53, 15);
            Lb_Message.TabIndex = 9;
            Lb_Message.Text = "Message";
            // 
            // TP_GestionMessage
            // 
            TP_GestionMessage.Controls.Add(TP_Message);
            TP_GestionMessage.Controls.Add(TP_GroupeMessage);
            TP_GestionMessage.Location = new Point(0, -2);
            TP_GestionMessage.Name = "TP_GestionMessage";
            TP_GestionMessage.SelectedIndex = 0;
            TP_GestionMessage.Size = new Size(417, 263);
            TP_GestionMessage.TabIndex = 10;
            // 
            // TP_Message
            // 
            TP_Message.Controls.Add(Cb_Code);
            TP_Message.Controls.Add(Lb_ChercheCode);
            TP_Message.Controls.Add(Lb_Groupe);
            TP_Message.Controls.Add(Lb_Message);
            TP_Message.Controls.Add(Cb_GroupeMessage);
            TP_Message.Controls.Add(Lb_Code);
            TP_Message.Controls.Add(Tb_CodeMessage);
            TP_Message.Controls.Add(Tb_Message);
            TP_Message.Controls.Add(Btn_Enregistrer);
            TP_Message.Controls.Add(Btn_Nouveau);
            TP_Message.Controls.Add(Btn_Supprimer);
            TP_Message.Controls.Add(Btn_Modifier);
            TP_Message.Location = new Point(4, 24);
            TP_Message.Name = "TP_Message";
            TP_Message.Padding = new Padding(3);
            TP_Message.Size = new Size(409, 235);
            TP_Message.TabIndex = 0;
            TP_Message.Text = "Message";
            TP_Message.UseVisualStyleBackColor = true;
            // 
            // Cb_Code
            // 
            Cb_Code.FormattingEnabled = true;
            Cb_Code.Location = new Point(327, 17);
            Cb_Code.Name = "Cb_Code";
            Cb_Code.Size = new Size(76, 23);
            Cb_Code.TabIndex = 12;
            // 
            // Lb_ChercheCode
            // 
            Lb_ChercheCode.AutoSize = true;
            Lb_ChercheCode.Location = new Point(243, 20);
            Lb_ChercheCode.Name = "Lb_ChercheCode";
            Lb_ChercheCode.Size = new Size(78, 15);
            Lb_ChercheCode.TabIndex = 11;
            Lb_ChercheCode.Text = "cherche code";
            // 
            // TP_GroupeMessage
            // 
            TP_GroupeMessage.Controls.Add(Lb_Indicateur);
            TP_GroupeMessage.Controls.Add(Cb_ChercheGroupeMessage);
            TP_GroupeMessage.Controls.Add(Lb_ChercheGroupeMessage);
            TP_GroupeMessage.Controls.Add(Btn_EnregistrerGroupeMessage);
            TP_GroupeMessage.Controls.Add(Btn_NouveauGroupeMessage);
            TP_GroupeMessage.Controls.Add(Btn_SupprimerGroupeMessage);
            TP_GroupeMessage.Controls.Add(Btn_ModifierGroupeMessage);
            TP_GroupeMessage.Controls.Add(Lb_LabelGroupeMessage);
            TP_GroupeMessage.Controls.Add(Tb_LabelGroupeMessage);
            TP_GroupeMessage.Location = new Point(4, 24);
            TP_GroupeMessage.Name = "TP_GroupeMessage";
            TP_GroupeMessage.Padding = new Padding(3);
            TP_GroupeMessage.Size = new Size(409, 235);
            TP_GroupeMessage.TabIndex = 1;
            TP_GroupeMessage.Text = "Groupe message";
            TP_GroupeMessage.UseVisualStyleBackColor = true;
            // 
            // Lb_Indicateur
            // 
            Lb_Indicateur.AutoSize = true;
            Lb_Indicateur.ForeColor = Color.Red;
            Lb_Indicateur.Location = new Point(339, 108);
            Lb_Indicateur.Name = "Lb_Indicateur";
            Lb_Indicateur.Size = new Size(66, 15);
            Lb_Indicateur.TabIndex = 15;
            Lb_Indicateur.Text = ">100 mots!";
            // 
            // Cb_ChercheGroupeMessage
            // 
            Cb_ChercheGroupeMessage.FormattingEnabled = true;
            Cb_ChercheGroupeMessage.Location = new Point(67, 44);
            Cb_ChercheGroupeMessage.Name = "Cb_ChercheGroupeMessage";
            Cb_ChercheGroupeMessage.Size = new Size(266, 23);
            Cb_ChercheGroupeMessage.TabIndex = 14;
            Cb_ChercheGroupeMessage.SelectedIndexChanged += Cb_ChercheGroupeMessage_SelectedIndexChanged;
            // 
            // Lb_ChercheGroupeMessage
            // 
            Lb_ChercheGroupeMessage.AutoSize = true;
            Lb_ChercheGroupeMessage.Location = new Point(67, 26);
            Lb_ChercheGroupeMessage.Name = "Lb_ChercheGroupeMessage";
            Lb_ChercheGroupeMessage.Size = new Size(139, 15);
            Lb_ChercheGroupeMessage.TabIndex = 13;
            Lb_ChercheGroupeMessage.Text = "cherche groupe message";
            // 
            // Btn_EnregistrerGroupeMessage
            // 
            Btn_EnregistrerGroupeMessage.Location = new Point(215, 148);
            Btn_EnregistrerGroupeMessage.Name = "Btn_EnregistrerGroupeMessage";
            Btn_EnregistrerGroupeMessage.Size = new Size(75, 23);
            Btn_EnregistrerGroupeMessage.TabIndex = 10;
            Btn_EnregistrerGroupeMessage.Text = "Enregistrer";
            Btn_EnregistrerGroupeMessage.UseVisualStyleBackColor = true;
            Btn_EnregistrerGroupeMessage.Click += Btn_EnregistrerGroupeMessage_Click;
            // 
            // Btn_NouveauGroupeMessage
            // 
            Btn_NouveauGroupeMessage.Location = new Point(134, 148);
            Btn_NouveauGroupeMessage.Name = "Btn_NouveauGroupeMessage";
            Btn_NouveauGroupeMessage.Size = new Size(75, 23);
            Btn_NouveauGroupeMessage.TabIndex = 7;
            Btn_NouveauGroupeMessage.Text = "Nouveau";
            Btn_NouveauGroupeMessage.UseVisualStyleBackColor = true;
            Btn_NouveauGroupeMessage.Click += Btn_NouveauGroupeMessage_Click;
            // 
            // Btn_SupprimerGroupeMessage
            // 
            Btn_SupprimerGroupeMessage.Location = new Point(215, 177);
            Btn_SupprimerGroupeMessage.Name = "Btn_SupprimerGroupeMessage";
            Btn_SupprimerGroupeMessage.Size = new Size(75, 23);
            Btn_SupprimerGroupeMessage.TabIndex = 9;
            Btn_SupprimerGroupeMessage.Text = "Supprimer";
            Btn_SupprimerGroupeMessage.UseVisualStyleBackColor = true;
            Btn_SupprimerGroupeMessage.Click += Btn_SupprimerGroupeMessage_Click;
            // 
            // Btn_ModifierGroupeMessage
            // 
            Btn_ModifierGroupeMessage.Location = new Point(134, 177);
            Btn_ModifierGroupeMessage.Name = "Btn_ModifierGroupeMessage";
            Btn_ModifierGroupeMessage.Size = new Size(75, 23);
            Btn_ModifierGroupeMessage.TabIndex = 8;
            Btn_ModifierGroupeMessage.Text = "Modifier";
            Btn_ModifierGroupeMessage.UseVisualStyleBackColor = true;
            Btn_ModifierGroupeMessage.Click += Btn_ModifierGroupeMessage_Click;
            // 
            // Lb_LabelGroupeMessage
            // 
            Lb_LabelGroupeMessage.AutoSize = true;
            Lb_LabelGroupeMessage.Location = new Point(67, 87);
            Lb_LabelGroupeMessage.Name = "Lb_LabelGroupeMessage";
            Lb_LabelGroupeMessage.Size = new Size(125, 15);
            Lb_LabelGroupeMessage.TabIndex = 1;
            Lb_LabelGroupeMessage.Text = "Label groupe message";
            // 
            // Tb_LabelGroupeMessage
            // 
            Tb_LabelGroupeMessage.Location = new Point(67, 105);
            Tb_LabelGroupeMessage.Name = "Tb_LabelGroupeMessage";
            Tb_LabelGroupeMessage.Size = new Size(266, 23);
            Tb_LabelGroupeMessage.TabIndex = 0;
            Tb_LabelGroupeMessage.TextChanged += Tb_LabelGroupeMessage_TextChanged;
            // 
            // Fn_Message
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(416, 259);
            Controls.Add(TP_GestionMessage);
            Name = "Fn_Message";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Message";
            Load += Fn_Message_Load;
            TP_GestionMessage.ResumeLayout(false);
            TP_Message.ResumeLayout(false);
            TP_Message.PerformLayout();
            TP_GroupeMessage.ResumeLayout(false);
            TP_GroupeMessage.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox Cb_GroupeMessage;
        private TextBox Tb_CodeMessage;
        private TextBox Tb_Message;
        private Button Btn_Nouveau;
        private Button Btn_Modifier;
        private Button Btn_Supprimer;
        private Button Btn_Enregistrer;
        private Label Lb_Groupe;
        private Label Lb_Code;
        private Label Lb_Message;
        private TabControl TP_GestionMessage;
        private TabPage TP_Message;
        private TabPage TP_GroupeMessage;
        private TextBox Tb_LabelGroupeMessage;
        private ComboBox Cb_Code;
        private Label Lb_ChercheCode;
        private ComboBox Cb_ChercheGroupeMessage;
        private Label Lb_ChercheGroupeMessage;
        private Button Btn_EnregistrerGroupeMessage;
        private Button Btn_NouveauGroupeMessage;
        private Button Btn_SupprimerGroupeMessage;
        private Button Btn_ModifierGroupeMessage;
        private Label Lb_LabelGroupeMessage;
        private Label Lb_Indicateur;
    }
}
