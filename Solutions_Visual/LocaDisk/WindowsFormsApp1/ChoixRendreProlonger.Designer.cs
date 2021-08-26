
namespace WindowsFormsApp1
{
    partial class ChoixRendreProlonger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChoixRendreProlonger));
            this.boutonRendre = new System.Windows.Forms.Button();
            this.boutonProlonger = new System.Windows.Forms.Button();
            this.labelTitre = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // boutonRendre
            // 
            this.boutonRendre.DialogResult = System.Windows.Forms.DialogResult.No;
            this.boutonRendre.Location = new System.Drawing.Point(199, 78);
            this.boutonRendre.Name = "boutonRendre";
            this.boutonRendre.Size = new System.Drawing.Size(75, 23);
            this.boutonRendre.TabIndex = 7;
            this.boutonRendre.Text = "Rendre";
            this.boutonRendre.UseVisualStyleBackColor = true;
            // 
            // boutonProlonger
            // 
            this.boutonProlonger.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.boutonProlonger.Location = new System.Drawing.Point(37, 78);
            this.boutonProlonger.Name = "boutonProlonger";
            this.boutonProlonger.Size = new System.Drawing.Size(75, 23);
            this.boutonProlonger.TabIndex = 5;
            this.boutonProlonger.Text = "Prolonger";
            this.boutonProlonger.UseVisualStyleBackColor = true;
            // 
            // labelTitre
            // 
            this.labelTitre.AutoEllipsis = true;
            this.labelTitre.AutoSize = true;
            this.labelTitre.Location = new System.Drawing.Point(12, 30);
            this.labelTitre.MaximumSize = new System.Drawing.Size(300, 39);
            this.labelTitre.Name = "labelTitre";
            this.labelTitre.Size = new System.Drawing.Size(35, 13);
            this.labelTitre.TabIndex = 4;
            this.labelTitre.Text = "label1";
            // 
            // ChoixRendreProlonger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 120);
            this.Controls.Add(this.boutonRendre);
            this.Controls.Add(this.boutonProlonger);
            this.Controls.Add(this.labelTitre);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChoixRendreProlonger";
            this.Text = "ChoixRendreProlonger";
            this.Load += new System.EventHandler(this.ChoixRendreProlonger_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button boutonRendre;
        private System.Windows.Forms.Button boutonProlonger;
        private System.Windows.Forms.Label labelTitre;
    }
}