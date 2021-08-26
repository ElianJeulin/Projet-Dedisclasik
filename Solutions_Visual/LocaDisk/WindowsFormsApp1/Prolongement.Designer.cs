
namespace WindowsFormsApp1
{
    partial class Prolongement
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
            this.message = new System.Windows.Forms.Label();
            this.boutonOui = new System.Windows.Forms.Button();
            this.buttonNon = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // message
            // 
            this.message.AutoSize = true;
            this.message.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.message.Location = new System.Drawing.Point(190, 57);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(51, 20);
            this.message.TabIndex = 0;
            this.message.Text = "label1";
            // 
            // boutonOui
            // 
            this.boutonOui.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.boutonOui.Location = new System.Drawing.Point(74, 132);
            this.boutonOui.Name = "boutonOui";
            this.boutonOui.Size = new System.Drawing.Size(80, 24);
            this.boutonOui.TabIndex = 1;
            this.boutonOui.Text = "Oui";
            this.boutonOui.UseVisualStyleBackColor = true;
            // 
            // buttonNon
            // 
            this.buttonNon.DialogResult = System.Windows.Forms.DialogResult.No;
            this.buttonNon.Location = new System.Drawing.Point(283, 132);
            this.buttonNon.Name = "buttonNon";
            this.buttonNon.Size = new System.Drawing.Size(80, 24);
            this.buttonNon.TabIndex = 2;
            this.buttonNon.Text = "Non";
            this.buttonNon.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(177, 132);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(80, 24);
            this.buttonOk.TabIndex = 3;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // Prolongement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 196);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonNon);
            this.Controls.Add(this.boutonOui);
            this.Controls.Add(this.message);
            this.Name = "Prolongement";
            this.Text = "Prolongement";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label message;
        private System.Windows.Forms.Button boutonOui;
        private System.Windows.Forms.Button buttonNon;
        private System.Windows.Forms.Button buttonOk;
    }
}