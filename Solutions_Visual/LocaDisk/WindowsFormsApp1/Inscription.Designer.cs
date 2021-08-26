
namespace WindowsFormsApp1
{
    partial class Inscription
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inscription));
            this.nomTextBox = new System.Windows.Forms.TextBox();
            this.prenomTextBox = new System.Windows.Forms.TextBox();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.passTextBox = new System.Windows.Forms.TextBox();
            this.listePays = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.inscriptionButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.verifLoginLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.confirmTextBox = new System.Windows.Forms.TextBox();
            this.labelPass = new System.Windows.Forms.Label();
            this.voirMdp = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.voirConfirmation = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // nomTextBox
            // 
            this.nomTextBox.Location = new System.Drawing.Point(118, 96);
            this.nomTextBox.MaxLength = 32;
            this.nomTextBox.Name = "nomTextBox";
            this.nomTextBox.Size = new System.Drawing.Size(121, 20);
            this.nomTextBox.TabIndex = 1;
            // 
            // prenomTextBox
            // 
            this.prenomTextBox.Location = new System.Drawing.Point(118, 49);
            this.prenomTextBox.MaxLength = 32;
            this.prenomTextBox.Name = "prenomTextBox";
            this.prenomTextBox.Size = new System.Drawing.Size(121, 20);
            this.prenomTextBox.TabIndex = 0;
            // 
            // loginTextBox
            // 
            this.loginTextBox.Location = new System.Drawing.Point(118, 146);
            this.loginTextBox.MaxLength = 32;
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(121, 20);
            this.loginTextBox.TabIndex = 2;
            this.loginTextBox.Leave += new System.EventHandler(this.loginTextBox_Leave);
            // 
            // passTextBox
            // 
            this.passTextBox.Location = new System.Drawing.Point(118, 193);
            this.passTextBox.MaxLength = 32;
            this.passTextBox.Name = "passTextBox";
            this.passTextBox.Size = new System.Drawing.Size(121, 20);
            this.passTextBox.TabIndex = 3;
            this.passTextBox.UseSystemPasswordChar = true;
            // 
            // listePays
            // 
            this.listePays.FormattingEnabled = true;
            this.listePays.Location = new System.Drawing.Point(118, 280);
            this.listePays.Name = "listePays";
            this.listePays.Size = new System.Drawing.Size(121, 21);
            this.listePays.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(82, 283);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Pays";
            // 
            // inscriptionButton
            // 
            this.inscriptionButton.Location = new System.Drawing.Point(308, 206);
            this.inscriptionButton.Name = "inscriptionButton";
            this.inscriptionButton.Size = new System.Drawing.Size(150, 54);
            this.inscriptionButton.TabIndex = 8;
            this.inscriptionButton.Text = "Inscription";
            this.inscriptionButton.UseVisualStyleBackColor = true;
            this.inscriptionButton.Click += new System.EventHandler(this.inscriptionButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Prénom";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Nom";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Login";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Mot de passe";
            // 
            // verifLoginLabel
            // 
            this.verifLoginLabel.AutoSize = true;
            this.verifLoginLabel.ForeColor = System.Drawing.Color.Red;
            this.verifLoginLabel.Location = new System.Drawing.Point(123, 169);
            this.verifLoginLabel.Name = "verifLoginLabel";
            this.verifLoginLabel.Size = new System.Drawing.Size(110, 13);
            this.verifLoginLabel.TabIndex = 15;
            this.verifLoginLabel.Text = "Ce login est déjà pris !";
            this.verifLoginLabel.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 243);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Confirmation";
            // 
            // confirmTextBox
            // 
            this.confirmTextBox.Location = new System.Drawing.Point(118, 240);
            this.confirmTextBox.MaxLength = 32;
            this.confirmTextBox.Name = "confirmTextBox";
            this.confirmTextBox.Size = new System.Drawing.Size(121, 20);
            this.confirmTextBox.TabIndex = 5;
            this.confirmTextBox.UseSystemPasswordChar = true;
            this.confirmTextBox.Leave += new System.EventHandler(this.confirmTextBox_Leave);
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.ForeColor = System.Drawing.Color.Red;
            this.labelPass.Location = new System.Drawing.Point(97, 224);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(175, 13);
            this.labelPass.TabIndex = 19;
            this.labelPass.Text = "Les mots de passes sont différents !\r\n";
            this.labelPass.Visible = false;
            // 
            // voirMdp
            // 
            this.voirMdp.Appearance = System.Windows.Forms.Appearance.Button;
            this.voirMdp.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.close_eye_logo;
            this.voirMdp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.voirMdp.FlatAppearance.BorderSize = 0;
            this.voirMdp.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.voirMdp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.voirMdp.Location = new System.Drawing.Point(245, 193);
            this.voirMdp.Name = "voirMdp";
            this.voirMdp.Size = new System.Drawing.Size(20, 20);
            this.voirMdp.TabIndex = 4;
            this.voirMdp.UseVisualStyleBackColor = true;
            this.voirMdp.CheckedChanged += new System.EventHandler(this.voirMdp_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(308, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // voirConfirmation
            // 
            this.voirConfirmation.Appearance = System.Windows.Forms.Appearance.Button;
            this.voirConfirmation.BackColor = System.Drawing.Color.Transparent;
            this.voirConfirmation.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.close_eye_logo;
            this.voirConfirmation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.voirConfirmation.FlatAppearance.BorderSize = 0;
            this.voirConfirmation.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.voirConfirmation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.voirConfirmation.Location = new System.Drawing.Point(245, 240);
            this.voirConfirmation.Name = "voirConfirmation";
            this.voirConfirmation.Size = new System.Drawing.Size(20, 20);
            this.voirConfirmation.TabIndex = 6;
            this.voirConfirmation.UseVisualStyleBackColor = false;
            this.voirConfirmation.CheckedChanged += new System.EventHandler(this.voirConfirmation_CheckedChanged);
            // 
            // Inscription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 313);
            this.Controls.Add(this.voirConfirmation);
            this.Controls.Add(this.voirMdp);
            this.Controls.Add(this.labelPass);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.confirmTextBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.verifLoginLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inscriptionButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listePays);
            this.Controls.Add(this.loginTextBox);
            this.Controls.Add(this.passTextBox);
            this.Controls.Add(this.prenomTextBox);
            this.Controls.Add(this.nomTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Inscription";
            this.Text = "Inscription";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nomTextBox;
        private System.Windows.Forms.TextBox prenomTextBox;
        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.TextBox passTextBox;
        private System.Windows.Forms.ComboBox listePays;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button inscriptionButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label verifLoginLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox confirmTextBox;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.CheckBox voirMdp;
        private System.Windows.Forms.CheckBox voirConfirmation;
    }
}