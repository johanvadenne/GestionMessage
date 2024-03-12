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
            Btn_NouveauMessage = new Button();
            Btn_ModifierMessage = new Button();
            Btn_SupprimerMessage = new Button();
            Btn_EnregistrerMessage = new Button();
            Lb_Groupe = new Label();
            Lb_Code = new Label();
            Lb_Message = new Label();
            TP_GestionMessage = new TabControl();
            TP_Message = new TabPage();
            Cb_TypeMessage = new ComboBox();
            Lb_Type = new Label();
            Cb_CodeMessage = new ComboBox();
            Lb_ChercheCode = new Label();
            TP_GroupeMessage = new TabPage();
            Cb_ChercheGroupeMessage = new ComboBox();
            Lb_ChercheGroupeMessage = new Label();
            Btn_EnregistrerGroupeMessage = new Button();
            Btn_NouveauGroupeMessage = new Button();
            Btn_SupprimerGroupeMessage = new Button();
            Btn_ModifierGroupeMessage = new Button();
            Lb_LabelGroupeMessage = new Label();
            Tb_LabelGroupeMessage = new TextBox();
            TB_TypeMessage = new TabPage();
            Cb_ChercheTypeMessage = new ComboBox();
            Lb_ChercheTypeMessage = new Label();
            Btn_EnregistrerTypeMessage = new Button();
            Btn_NouveauTypeMessage = new Button();
            Btn_SupprimerTypeMessage = new Button();
            Btn_ModifierTypeMessage = new Button();
            Lb_LabelTypeMessage = new Label();
            Tb_LabelTypeMessage = new TextBox();
            TP_GestionMessage.SuspendLayout();
            TP_Message.SuspendLayout();
            TP_GroupeMessage.SuspendLayout();
            TB_TypeMessage.SuspendLayout();
            SuspendLayout();
            // 
            // Cb_GroupeMessage
            // 
            Cb_GroupeMessage.DropDownStyle = ComboBoxStyle.DropDownList;
            Cb_GroupeMessage.FormattingEnabled = true;
            Cb_GroupeMessage.Location = new Point(187, 47);
            Cb_GroupeMessage.Name = "Cb_GroupeMessage";
            Cb_GroupeMessage.Size = new Size(205, 23);
            Cb_GroupeMessage.TabIndex = 0;
            // 
            // Tb_CodeMessage
            // 
            Tb_CodeMessage.Location = new Point(67, 47);
            Tb_CodeMessage.MaxLength = 4;
            Tb_CodeMessage.Name = "Tb_CodeMessage";
            Tb_CodeMessage.Size = new Size(39, 23);
            Tb_CodeMessage.TabIndex = 1;
            Tb_CodeMessage.TextChanged += Tb_CodeMessage_TextChanged;
            // 
            // Tb_Message
            // 
            Tb_Message.Location = new Point(65, 78);
            Tb_Message.MaxLength = 255;
            Tb_Message.Multiline = true;
            Tb_Message.Name = "Tb_Message";
            Tb_Message.Size = new Size(327, 92);
            Tb_Message.TabIndex = 2;
            // 
            // Btn_NouveauMessage
            // 
            Btn_NouveauMessage.Location = new Point(128, 176);
            Btn_NouveauMessage.Name = "Btn_NouveauMessage";
            Btn_NouveauMessage.Size = new Size(75, 23);
            Btn_NouveauMessage.TabIndex = 3;
            Btn_NouveauMessage.Text = "Nouveau";
            Btn_NouveauMessage.UseVisualStyleBackColor = true;
            Btn_NouveauMessage.Click += Btn_NouveauMessage_Click;
            // 
            // Btn_ModifierMessage
            // 
            Btn_ModifierMessage.Location = new Point(128, 205);
            Btn_ModifierMessage.Name = "Btn_ModifierMessage";
            Btn_ModifierMessage.Size = new Size(75, 23);
            Btn_ModifierMessage.TabIndex = 4;
            Btn_ModifierMessage.Text = "Modifier";
            Btn_ModifierMessage.UseVisualStyleBackColor = true;
            Btn_ModifierMessage.Click += Btn_ModifierMessage_Click;
            // 
            // Btn_SupprimerMessage
            // 
            Btn_SupprimerMessage.Location = new Point(209, 205);
            Btn_SupprimerMessage.Name = "Btn_SupprimerMessage";
            Btn_SupprimerMessage.Size = new Size(75, 23);
            Btn_SupprimerMessage.TabIndex = 5;
            Btn_SupprimerMessage.Text = "Supprimer";
            Btn_SupprimerMessage.UseVisualStyleBackColor = true;
            Btn_SupprimerMessage.Click += Btn_SupprimerMessage_Click;
            // 
            // Btn_EnregistrerMessage
            // 
            Btn_EnregistrerMessage.Location = new Point(209, 176);
            Btn_EnregistrerMessage.Name = "Btn_EnregistrerMessage";
            Btn_EnregistrerMessage.Size = new Size(75, 23);
            Btn_EnregistrerMessage.TabIndex = 6;
            Btn_EnregistrerMessage.Text = "Enregistrer";
            Btn_EnregistrerMessage.UseVisualStyleBackColor = true;
            Btn_EnregistrerMessage.Click += Btn_EnregistrerMessage_Click;
            // 
            // Lb_Groupe
            // 
            Lb_Groupe.AutoSize = true;
            Lb_Groupe.Location = new Point(128, 50);
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
            TP_GestionMessage.Controls.Add(TB_TypeMessage);
            TP_GestionMessage.Location = new Point(0, -2);
            TP_GestionMessage.Name = "TP_GestionMessage";
            TP_GestionMessage.SelectedIndex = 0;
            TP_GestionMessage.Size = new Size(417, 263);
            TP_GestionMessage.TabIndex = 10;
            // 
            // TP_Message
            // 
            TP_Message.Controls.Add(Cb_TypeMessage);
            TP_Message.Controls.Add(Lb_Type);
            TP_Message.Controls.Add(Cb_CodeMessage);
            TP_Message.Controls.Add(Lb_ChercheCode);
            TP_Message.Controls.Add(Lb_Groupe);
            TP_Message.Controls.Add(Lb_Message);
            TP_Message.Controls.Add(Cb_GroupeMessage);
            TP_Message.Controls.Add(Lb_Code);
            TP_Message.Controls.Add(Tb_CodeMessage);
            TP_Message.Controls.Add(Tb_Message);
            TP_Message.Controls.Add(Btn_EnregistrerMessage);
            TP_Message.Controls.Add(Btn_NouveauMessage);
            TP_Message.Controls.Add(Btn_SupprimerMessage);
            TP_Message.Controls.Add(Btn_ModifierMessage);
            TP_Message.Location = new Point(4, 24);
            TP_Message.Name = "TP_Message";
            TP_Message.Padding = new Padding(3);
            TP_Message.Size = new Size(409, 235);
            TP_Message.TabIndex = 0;
            TP_Message.Text = "Message";
            TP_Message.UseVisualStyleBackColor = true;
            // 
            // Cb_TypeMessage
            // 
            Cb_TypeMessage.DropDownStyle = ComboBoxStyle.DropDownList;
            Cb_TypeMessage.FormattingEnabled = true;
            Cb_TypeMessage.Location = new Point(224, 18);
            Cb_TypeMessage.Name = "Cb_TypeMessage";
            Cb_TypeMessage.Size = new Size(168, 23);
            Cb_TypeMessage.TabIndex = 14;
            // 
            // Lb_Type
            // 
            Lb_Type.AutoSize = true;
            Lb_Type.Location = new Point(187, 21);
            Lb_Type.Name = "Lb_Type";
            Lb_Type.Size = new Size(31, 15);
            Lb_Type.TabIndex = 13;
            Lb_Type.Text = "Type";
            // 
            // Cb_CodeMessage
            // 
            Cb_CodeMessage.DropDownStyle = ComboBoxStyle.DropDownList;
            Cb_CodeMessage.FormattingEnabled = true;
            Cb_CodeMessage.Location = new Point(93, 18);
            Cb_CodeMessage.Name = "Cb_CodeMessage";
            Cb_CodeMessage.Size = new Size(88, 23);
            Cb_CodeMessage.TabIndex = 12;
            Cb_CodeMessage.SelectedIndexChanged += Cb_CodeMessage_SelectedIndexChanged;
            // 
            // Lb_ChercheCode
            // 
            Lb_ChercheCode.AutoSize = true;
            Lb_ChercheCode.Location = new Point(9, 21);
            Lb_ChercheCode.Name = "Lb_ChercheCode";
            Lb_ChercheCode.Size = new Size(78, 15);
            Lb_ChercheCode.TabIndex = 11;
            Lb_ChercheCode.Text = "cherche code";
            // 
            // TP_GroupeMessage
            // 
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
            // Cb_ChercheGroupeMessage
            // 
            Cb_ChercheGroupeMessage.DropDownStyle = ComboBoxStyle.DropDownList;
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
            Btn_EnregistrerGroupeMessage.Location = new Point(196, 154);
            Btn_EnregistrerGroupeMessage.Name = "Btn_EnregistrerGroupeMessage";
            Btn_EnregistrerGroupeMessage.Size = new Size(75, 23);
            Btn_EnregistrerGroupeMessage.TabIndex = 10;
            Btn_EnregistrerGroupeMessage.Text = "Enregistrer";
            Btn_EnregistrerGroupeMessage.UseVisualStyleBackColor = true;
            Btn_EnregistrerGroupeMessage.Click += Btn_EnregistrerGroupeMessage_Click;
            // 
            // Btn_NouveauGroupeMessage
            // 
            Btn_NouveauGroupeMessage.Location = new Point(115, 154);
            Btn_NouveauGroupeMessage.Name = "Btn_NouveauGroupeMessage";
            Btn_NouveauGroupeMessage.Size = new Size(75, 23);
            Btn_NouveauGroupeMessage.TabIndex = 7;
            Btn_NouveauGroupeMessage.Text = "Nouveau";
            Btn_NouveauGroupeMessage.UseVisualStyleBackColor = true;
            Btn_NouveauGroupeMessage.Click += Btn_NouveauGroupeMessage_Click;
            // 
            // Btn_SupprimerGroupeMessage
            // 
            Btn_SupprimerGroupeMessage.Location = new Point(196, 183);
            Btn_SupprimerGroupeMessage.Name = "Btn_SupprimerGroupeMessage";
            Btn_SupprimerGroupeMessage.Size = new Size(75, 23);
            Btn_SupprimerGroupeMessage.TabIndex = 9;
            Btn_SupprimerGroupeMessage.Text = "Supprimer";
            Btn_SupprimerGroupeMessage.UseVisualStyleBackColor = true;
            Btn_SupprimerGroupeMessage.Click += Btn_SupprimerGroupeMessage_Click;
            // 
            // Btn_ModifierGroupeMessage
            // 
            Btn_ModifierGroupeMessage.Location = new Point(115, 183);
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
            Tb_LabelGroupeMessage.MaxLength = 100;
            Tb_LabelGroupeMessage.Name = "Tb_LabelGroupeMessage";
            Tb_LabelGroupeMessage.Size = new Size(266, 23);
            Tb_LabelGroupeMessage.TabIndex = 0;
            Tb_LabelGroupeMessage.TextChanged += Tb_LabelGroupeMessage_TextChanged;
            // 
            // TB_TypeMessage
            // 
            TB_TypeMessage.Controls.Add(Cb_ChercheTypeMessage);
            TB_TypeMessage.Controls.Add(Lb_ChercheTypeMessage);
            TB_TypeMessage.Controls.Add(Btn_EnregistrerTypeMessage);
            TB_TypeMessage.Controls.Add(Btn_NouveauTypeMessage);
            TB_TypeMessage.Controls.Add(Btn_SupprimerTypeMessage);
            TB_TypeMessage.Controls.Add(Btn_ModifierTypeMessage);
            TB_TypeMessage.Controls.Add(Lb_LabelTypeMessage);
            TB_TypeMessage.Controls.Add(Tb_LabelTypeMessage);
            TB_TypeMessage.Location = new Point(4, 24);
            TB_TypeMessage.Name = "TB_TypeMessage";
            TB_TypeMessage.Padding = new Padding(3);
            TB_TypeMessage.Size = new Size(409, 235);
            TB_TypeMessage.TabIndex = 2;
            TB_TypeMessage.Text = "Type message";
            TB_TypeMessage.UseVisualStyleBackColor = true;
            // 
            // Cb_ChercheTypeMessage
            // 
            Cb_ChercheTypeMessage.DropDownStyle = ComboBoxStyle.DropDownList;
            Cb_ChercheTypeMessage.FormattingEnabled = true;
            Cb_ChercheTypeMessage.Location = new Point(95, 48);
            Cb_ChercheTypeMessage.Name = "Cb_ChercheTypeMessage";
            Cb_ChercheTypeMessage.Size = new Size(217, 23);
            Cb_ChercheTypeMessage.TabIndex = 22;
            Cb_ChercheTypeMessage.SelectedIndexChanged += Cb_ChercheTypeMessage_SelectedIndexChanged;
            // 
            // Lb_ChercheTypeMessage
            // 
            Lb_ChercheTypeMessage.AutoSize = true;
            Lb_ChercheTypeMessage.Location = new Point(95, 30);
            Lb_ChercheTypeMessage.Name = "Lb_ChercheTypeMessage";
            Lb_ChercheTypeMessage.Size = new Size(124, 15);
            Lb_ChercheTypeMessage.TabIndex = 21;
            Lb_ChercheTypeMessage.Text = "cherche type message";
            // 
            // Btn_EnregistrerTypeMessage
            // 
            Btn_EnregistrerTypeMessage.Location = new Point(204, 152);
            Btn_EnregistrerTypeMessage.Name = "Btn_EnregistrerTypeMessage";
            Btn_EnregistrerTypeMessage.Size = new Size(75, 23);
            Btn_EnregistrerTypeMessage.TabIndex = 20;
            Btn_EnregistrerTypeMessage.Text = "Enregistrer";
            Btn_EnregistrerTypeMessage.UseVisualStyleBackColor = true;
            Btn_EnregistrerTypeMessage.Click += Btn_EnregistrerTypeMessage_Click;
            // 
            // Btn_NouveauTypeMessage
            // 
            Btn_NouveauTypeMessage.Location = new Point(123, 152);
            Btn_NouveauTypeMessage.Name = "Btn_NouveauTypeMessage";
            Btn_NouveauTypeMessage.Size = new Size(75, 23);
            Btn_NouveauTypeMessage.TabIndex = 17;
            Btn_NouveauTypeMessage.Text = "Nouveau";
            Btn_NouveauTypeMessage.UseVisualStyleBackColor = true;
            Btn_NouveauTypeMessage.Click += Btn_NouveauTypeMessage_Click;
            // 
            // Btn_SupprimerTypeMessage
            // 
            Btn_SupprimerTypeMessage.Location = new Point(204, 181);
            Btn_SupprimerTypeMessage.Name = "Btn_SupprimerTypeMessage";
            Btn_SupprimerTypeMessage.Size = new Size(75, 23);
            Btn_SupprimerTypeMessage.TabIndex = 19;
            Btn_SupprimerTypeMessage.Text = "Supprimer";
            Btn_SupprimerTypeMessage.UseVisualStyleBackColor = true;
            Btn_SupprimerTypeMessage.Click += Btn_SupprimerTypeMessage_Click;
            // 
            // Btn_ModifierTypeMessage
            // 
            Btn_ModifierTypeMessage.Location = new Point(123, 181);
            Btn_ModifierTypeMessage.Name = "Btn_ModifierTypeMessage";
            Btn_ModifierTypeMessage.Size = new Size(75, 23);
            Btn_ModifierTypeMessage.TabIndex = 18;
            Btn_ModifierTypeMessage.Text = "Modifier";
            Btn_ModifierTypeMessage.UseVisualStyleBackColor = true;
            Btn_ModifierTypeMessage.Click += Btn_ModifierTypeMessage_Click;
            // 
            // Lb_LabelTypeMessage
            // 
            Lb_LabelTypeMessage.AutoSize = true;
            Lb_LabelTypeMessage.Location = new Point(95, 91);
            Lb_LabelTypeMessage.Name = "Lb_LabelTypeMessage";
            Lb_LabelTypeMessage.Size = new Size(110, 15);
            Lb_LabelTypeMessage.TabIndex = 16;
            Lb_LabelTypeMessage.Text = "Label type message";
            // 
            // Tb_LabelTypeMessage
            // 
            Tb_LabelTypeMessage.Location = new Point(95, 109);
            Tb_LabelTypeMessage.MaxLength = 20;
            Tb_LabelTypeMessage.Name = "Tb_LabelTypeMessage";
            Tb_LabelTypeMessage.Size = new Size(217, 23);
            Tb_LabelTypeMessage.TabIndex = 15;
            Tb_LabelTypeMessage.TextChanged += Tb_LabelTypeMessage_TextChanged;
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
            TB_TypeMessage.ResumeLayout(false);
            TB_TypeMessage.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox Cb_GroupeMessage;
        private TextBox Tb_CodeMessage;
        private TextBox Tb_Message;
        private Button Btn_NouveauMessage;
        private Button Btn_ModifierMessage;
        private Button Btn_SupprimerMessage;
        private Button Btn_EnregistrerMessage;
        private Label Lb_Groupe;
        private Label Lb_Code;
        private Label Lb_Message;
        private TabControl TP_GestionMessage;
        private TabPage TP_Message;
        private TabPage TP_GroupeMessage;
        private TextBox Tb_LabelGroupeMessage;
        private ComboBox Cb_CodeMessage;
        private Label Lb_ChercheCode;
        private ComboBox Cb_ChercheGroupeMessage;
        private Label Lb_ChercheGroupeMessage;
        private Button Btn_EnregistrerGroupeMessage;
        private Button Btn_NouveauGroupeMessage;
        private Button Btn_SupprimerGroupeMessage;
        private Button Btn_ModifierGroupeMessage;
        private Label Lb_LabelGroupeMessage;
        private TabPage TB_TypeMessage;
        private ComboBox Cb_ChercheTypeMessage;
        private Label Lb_ChercheTypeMessage;
        private Button Btn_EnregistrerTypeMessage;
        private Button Btn_NouveauTypeMessage;
        private Button Btn_SupprimerTypeMessage;
        private Button Btn_ModifierTypeMessage;
        private Label Lb_LabelTypeMessage;
        private TextBox Tb_LabelTypeMessage;
        private Label Lb_Type;
        private ComboBox Cb_TypeMessage;
    }
}
