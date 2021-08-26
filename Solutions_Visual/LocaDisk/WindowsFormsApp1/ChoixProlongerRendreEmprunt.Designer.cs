
namespace WindowsFormsApp1
{
    partial class ChoixProlongerRendreEmprunt
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
            this.boutonRendre = new System.Windows.Forms.Button();
            this.boutonProlonger = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // boutonRendre
            // 
            this.boutonRendre.DialogResult = System.Windows.Forms.DialogResult.No;
            this.boutonRendre.Location = new System.Drawing.Point(194, 60);
            this.boutonRendre.Name = "boutonRendre";
            this.boutonRendre.Size = new System.Drawing.Size(75, 23);
            this.boutonRendre.TabIndex = 7;
            this.boutonRendre.Text = "Rendre";
            this.boutonRendre.UseVisualStyleBackColor = true;
            // 
            // boutonProlonger
            // 
            this.boutonProlonger.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.boutonProlonger.Location = new System.Drawing.Point(32, 60);
            this.boutonProlonger.Name = "boutonProlonger";
            this.boutonProlonger.Size = new System.Drawing.Size(75, 23);
            this.boutonProlonger.TabIndex = 5;
            this.boutonProlonger.Text = "Prolonger";
            this.boutonProlonger.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 12);
            this.label1.MaximumSize = new System.Drawing.Size(300, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // ChoixProlongerRendreEmprunt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 120);
            this.Controls.Add(this.boutonRendre);
            this.Controls.Add(this.boutonProlonger);
            this.Controls.Add(this.label1);
            this.Name = "ChoixProlongerRendreEmprunt";
            this.Text = "ChoixProlongerRendreEmprunt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button boutonRendre;
        private System.Windows.Forms.Button boutonProlonger;
        private System.Windows.Forms.Label label1;
    }
}