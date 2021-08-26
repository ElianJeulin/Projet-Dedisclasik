
namespace WindowsFormsApp1
{
    partial class ProlongerEmprunts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProlongerEmprunts));
            this.label1 = new System.Windows.Forms.Label();
            this.boutonOui = new System.Windows.Forms.Button();
            this.boutonOK = new System.Windows.Forms.Button();
            this.boutonNon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.MaximumSize = new System.Drawing.Size(300, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // boutonOui
            // 
            this.boutonOui.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.boutonOui.Location = new System.Drawing.Point(37, 78);
            this.boutonOui.Name = "boutonOui";
            this.boutonOui.Size = new System.Drawing.Size(75, 23);
            this.boutonOui.TabIndex = 1;
            this.boutonOui.Text = "Oui";
            this.boutonOui.UseVisualStyleBackColor = true;
            // 
            // boutonOK
            // 
            this.boutonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.boutonOK.Location = new System.Drawing.Point(118, 78);
            this.boutonOK.Name = "boutonOK";
            this.boutonOK.Size = new System.Drawing.Size(75, 23);
            this.boutonOK.TabIndex = 2;
            this.boutonOK.Text = "OK";
            this.boutonOK.UseVisualStyleBackColor = true;
            // 
            // boutonNon
            // 
            this.boutonNon.DialogResult = System.Windows.Forms.DialogResult.No;
            this.boutonNon.Location = new System.Drawing.Point(199, 78);
            this.boutonNon.Name = "boutonNon";
            this.boutonNon.Size = new System.Drawing.Size(75, 23);
            this.boutonNon.TabIndex = 3;
            this.boutonNon.Text = "Non";
            this.boutonNon.UseVisualStyleBackColor = true;
            // 
            // ProlongerEmprunts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 120);
            this.Controls.Add(this.boutonNon);
            this.Controls.Add(this.boutonOK);
            this.Controls.Add(this.boutonOui);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ProlongerEmprunts";
            this.Text = "TrouverDansMesEmprunts d\'un emprunt";
            this.Load += new System.EventHandler(this.ProlongerEmprunts_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button boutonOui;
        private System.Windows.Forms.Button boutonOK;
        private System.Windows.Forms.Button boutonNon;
    }
}