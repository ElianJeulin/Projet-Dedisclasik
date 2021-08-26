
namespace WindowsFormsApp1
{
    partial class Connexion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Connexion));
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.passTextBox = new System.Windows.Forms.TextBox();
            this.connexionButton = new System.Windows.Forms.Button();
            this.inscriptionBouton = new System.Windows.Forms.Button();
            this.voirMdp = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // loginTextBox
            // 
            this.loginTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginTextBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.loginTextBox.Location = new System.Drawing.Point(116, 28);
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(149, 31);
            this.loginTextBox.TabIndex = 1;
            this.loginTextBox.Text = "Login";
            this.loginTextBox.Enter += new System.EventHandler(this.loginTextBox_Enter);
            this.loginTextBox.Leave += new System.EventHandler(this.loginTextBox_Leave);
            // 
            // passTextBox
            // 
            this.passTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passTextBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.passTextBox.Location = new System.Drawing.Point(116, 74);
            this.passTextBox.Name = "passTextBox";
            this.passTextBox.Size = new System.Drawing.Size(149, 31);
            this.passTextBox.TabIndex = 2;
            this.passTextBox.Text = "Mot de passe";
            this.passTextBox.Enter += new System.EventHandler(this.passTextBox_Enter);
            this.passTextBox.Leave += new System.EventHandler(this.passTextBox_Leave);
            // 
            // connexionButton
            // 
            this.connexionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connexionButton.Location = new System.Drawing.Point(127, 111);
            this.connexionButton.Name = "connexionButton";
            this.connexionButton.Size = new System.Drawing.Size(127, 35);
            this.connexionButton.TabIndex = 4;
            this.connexionButton.Text = "Connexion";
            this.connexionButton.UseVisualStyleBackColor = true;
            this.connexionButton.Click += new System.EventHandler(this.connexionButton_Click);
            // 
            // inscriptionBouton
            // 
            this.inscriptionBouton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inscriptionBouton.Location = new System.Drawing.Point(127, 152);
            this.inscriptionBouton.Name = "inscriptionBouton";
            this.inscriptionBouton.Size = new System.Drawing.Size(127, 35);
            this.inscriptionBouton.TabIndex = 5;
            this.inscriptionBouton.Text = "S\'inscrire";
            this.inscriptionBouton.UseVisualStyleBackColor = true;
            this.inscriptionBouton.Click += new System.EventHandler(this.inscriptionBouton_Click);
            // 
            // voirMdp
            // 
            this.voirMdp.Appearance = System.Windows.Forms.Appearance.Button;
            this.voirMdp.BackColor = System.Drawing.Color.Transparent;
            this.voirMdp.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.close_eye_logo;
            this.voirMdp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.voirMdp.FlatAppearance.BorderSize = 0;
            this.voirMdp.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.voirMdp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.voirMdp.Location = new System.Drawing.Point(271, 74);
            this.voirMdp.Name = "voirMdp";
            this.voirMdp.Size = new System.Drawing.Size(31, 31);
            this.voirMdp.TabIndex = 3;
            this.voirMdp.UseVisualStyleBackColor = false;
            this.voirMdp.CheckedChanged += new System.EventHandler(this.voirMdp_CheckedChanged);
            // 
            // Connexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 199);
            this.Controls.Add(this.voirMdp);
            this.Controls.Add(this.inscriptionBouton);
            this.Controls.Add(this.connexionButton);
            this.Controls.Add(this.passTextBox);
            this.Controls.Add(this.loginTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Connexion";
            this.Text = "Connexion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.TextBox passTextBox;
        private System.Windows.Forms.Button connexionButton;
        private System.Windows.Forms.Button inscriptionBouton;
        private System.Windows.Forms.CheckBox voirMdp;
    }
}