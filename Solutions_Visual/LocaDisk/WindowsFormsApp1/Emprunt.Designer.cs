
namespace WindowsFormsApp1
{
    partial class Emprunt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Emprunt));
            this.textBoxRecherche = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox = new System.Windows.Forms.ListBox();
            this.boutonEmprunter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxRecherche
            // 
            this.textBoxRecherche.Location = new System.Drawing.Point(78, 38);
            this.textBoxRecherche.Name = "textBoxRecherche";
            this.textBoxRecherche.Size = new System.Drawing.Size(285, 20);
            this.textBoxRecherche.TabIndex = 0;
            this.textBoxRecherche.TextChanged += new System.EventHandler(this.textBoxRecherche_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Recherche";
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(13, 80);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(350, 225);
            this.listBox.TabIndex = 2;
            // 
            // boutonEmprunter
            // 
            this.boutonEmprunter.Location = new System.Drawing.Point(461, 139);
            this.boutonEmprunter.Name = "boutonEmprunter";
            this.boutonEmprunter.Size = new System.Drawing.Size(75, 58);
            this.boutonEmprunter.TabIndex = 3;
            this.boutonEmprunter.Text = "Emprunter";
            this.boutonEmprunter.UseVisualStyleBackColor = true;
            this.boutonEmprunter.Click += new System.EventHandler(this.boutonEmprunter_Click);
            // 
            // Emprunt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 333);
            this.Controls.Add(this.boutonEmprunter);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxRecherche);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Emprunt";
            this.Text = "Emprunt";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Emprunt_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxRecherche;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button boutonEmprunter;
    }
}