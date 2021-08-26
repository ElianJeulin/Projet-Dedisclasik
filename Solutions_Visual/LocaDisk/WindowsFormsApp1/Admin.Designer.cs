
namespace WindowsFormsApp1
{
    partial class Admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            this.labelTopAlbum = new System.Windows.Forms.Label();
            this.listViewTopAlbum = new System.Windows.Forms.ListView();
            this.labelAbonné = new System.Windows.Forms.Label();
            this.boutonPurge = new System.Windows.Forms.Button();
            this.listViewAlbumsNonEmpuntés = new System.Windows.Forms.ListView();
            this.labelAlbumsNonEmpruntés = new System.Windows.Forms.Label();
            this.pagePrécédente = new System.Windows.Forms.Button();
            this.pageSuivante = new System.Windows.Forms.Button();
            this.dataGridViewAbonné = new System.Windows.Forms.DataGridView();
            this.boutonDéconnexion = new System.Windows.Forms.Button();
            this.numericUpDownCasier = new System.Windows.Forms.NumericUpDown();
            this.labelCasier = new System.Windows.Forms.Label();
            this.listViewCasier = new System.Windows.Forms.ListView();
            this.listViewEmpruntsProlongés = new System.Windows.Forms.ListView();
            this.précédentEmprunts = new System.Windows.Forms.Button();
            this.suivantEmprunts = new System.Windows.Forms.Button();
            this.labelEmpruntsProlongés = new System.Windows.Forms.Label();
            this.labelAlbumsManquants = new System.Windows.Forms.Label();
            this.boutonRetard = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAbonné)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCasier)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTopAlbum
            // 
            this.labelTopAlbum.AutoSize = true;
            this.labelTopAlbum.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTopAlbum.Location = new System.Drawing.Point(12, 9);
            this.labelTopAlbum.Name = "labelTopAlbum";
            this.labelTopAlbum.Size = new System.Drawing.Size(365, 37);
            this.labelTopAlbum.TabIndex = 4;
            this.labelTopAlbum.Text = "Top 10 des vinyles loués";
            // 
            // listViewTopAlbum
            // 
            this.listViewTopAlbum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewTopAlbum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewTopAlbum.HideSelection = false;
            this.listViewTopAlbum.Location = new System.Drawing.Point(12, 49);
            this.listViewTopAlbum.Name = "listViewTopAlbum";
            this.listViewTopAlbum.Size = new System.Drawing.Size(578, 221);
            this.listViewTopAlbum.TabIndex = 5;
            this.listViewTopAlbum.UseCompatibleStateImageBehavior = false;
            // 
            // labelAbonné
            // 
            this.labelAbonné.AutoSize = true;
            this.labelAbonné.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAbonné.Location = new System.Drawing.Point(607, 9);
            this.labelAbonné.Name = "labelAbonné";
            this.labelAbonné.Size = new System.Drawing.Size(220, 37);
            this.labelAbonné.TabIndex = 7;
            this.labelAbonné.Text = "Liste Abonnés";
            // 
            // boutonPurge
            // 
            this.boutonPurge.Location = new System.Drawing.Point(940, 49);
            this.boutonPurge.Name = "boutonPurge";
            this.boutonPurge.Size = new System.Drawing.Size(88, 49);
            this.boutonPurge.TabIndex = 9;
            this.boutonPurge.Text = "Purge";
            this.boutonPurge.UseVisualStyleBackColor = true;
            this.boutonPurge.Click += new System.EventHandler(this.boutonPurge_Click);
            // 
            // listViewAlbumsNonEmpuntés
            // 
            this.listViewAlbumsNonEmpuntés.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewAlbumsNonEmpuntés.HideSelection = false;
            this.listViewAlbumsNonEmpuntés.Location = new System.Drawing.Point(12, 315);
            this.listViewAlbumsNonEmpuntés.Name = "listViewAlbumsNonEmpuntés";
            this.listViewAlbumsNonEmpuntés.Size = new System.Drawing.Size(578, 214);
            this.listViewAlbumsNonEmpuntés.TabIndex = 10;
            this.listViewAlbumsNonEmpuntés.UseCompatibleStateImageBehavior = false;
            // 
            // labelAlbumsNonEmpruntés
            // 
            this.labelAlbumsNonEmpruntés.AutoSize = true;
            this.labelAlbumsNonEmpruntés.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAlbumsNonEmpruntés.Location = new System.Drawing.Point(5, 275);
            this.labelAlbumsNonEmpruntés.Name = "labelAlbumsNonEmpruntés";
            this.labelAlbumsNonEmpruntés.Size = new System.Drawing.Size(462, 37);
            this.labelAlbumsNonEmpruntés.TabIndex = 11;
            this.labelAlbumsNonEmpruntés.Text = "Albums non empruntés en 1 an";
            // 
            // pagePrécédente
            // 
            this.pagePrécédente.Location = new System.Drawing.Point(372, 535);
            this.pagePrécédente.Name = "pagePrécédente";
            this.pagePrécédente.Size = new System.Drawing.Size(106, 23);
            this.pagePrécédente.TabIndex = 13;
            this.pagePrécédente.Text = "Page précédente";
            this.pagePrécédente.UseVisualStyleBackColor = true;
            this.pagePrécédente.Click += new System.EventHandler(this.pagePrécédente_Click);
            // 
            // pageSuivante
            // 
            this.pageSuivante.Location = new System.Drawing.Point(484, 535);
            this.pageSuivante.Name = "pageSuivante";
            this.pageSuivante.Size = new System.Drawing.Size(106, 23);
            this.pageSuivante.TabIndex = 12;
            this.pageSuivante.Text = "Page suivante";
            this.pageSuivante.UseVisualStyleBackColor = true;
            this.pageSuivante.Click += new System.EventHandler(this.pageSuivante_Click);
            // 
            // dataGridViewAbonné
            // 
            this.dataGridViewAbonné.AllowUserToAddRows = false;
            this.dataGridViewAbonné.AllowUserToDeleteRows = false;
            this.dataGridViewAbonné.AllowUserToResizeColumns = false;
            this.dataGridViewAbonné.AllowUserToResizeRows = false;
            this.dataGridViewAbonné.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAbonné.Location = new System.Drawing.Point(614, 49);
            this.dataGridViewAbonné.Name = "dataGridViewAbonné";
            this.dataGridViewAbonné.ReadOnly = true;
            this.dataGridViewAbonné.RowHeadersVisible = false;
            this.dataGridViewAbonné.Size = new System.Drawing.Size(320, 221);
            this.dataGridViewAbonné.TabIndex = 14;
            // 
            // boutonDéconnexion
            // 
            this.boutonDéconnexion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boutonDéconnexion.Location = new System.Drawing.Point(1246, 592);
            this.boutonDéconnexion.Name = "boutonDéconnexion";
            this.boutonDéconnexion.Size = new System.Drawing.Size(117, 55);
            this.boutonDéconnexion.TabIndex = 15;
            this.boutonDéconnexion.Text = "Déconnexion";
            this.boutonDéconnexion.UseVisualStyleBackColor = true;
            this.boutonDéconnexion.Click += new System.EventHandler(this.buttonDéconnexion_Click);
            // 
            // numericUpDownCasier
            // 
            this.numericUpDownCasier.Location = new System.Drawing.Point(1268, 276);
            this.numericUpDownCasier.Name = "numericUpDownCasier";
            this.numericUpDownCasier.Size = new System.Drawing.Size(95, 20);
            this.numericUpDownCasier.TabIndex = 16;
            this.numericUpDownCasier.ValueChanged += new System.EventHandler(this.numericUpDownCasier_ValueChanged);
            // 
            // labelCasier
            // 
            this.labelCasier.AutoSize = true;
            this.labelCasier.Location = new System.Drawing.Point(1211, 278);
            this.labelCasier.Name = "labelCasier";
            this.labelCasier.Size = new System.Drawing.Size(51, 13);
            this.labelCasier.TabIndex = 17;
            this.labelCasier.Text = "N° Casier";
            // 
            // listViewCasier
            // 
            this.listViewCasier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewCasier.HideSelection = false;
            this.listViewCasier.Location = new System.Drawing.Point(1129, 56);
            this.listViewCasier.Name = "listViewCasier";
            this.listViewCasier.Size = new System.Drawing.Size(234, 214);
            this.listViewCasier.TabIndex = 18;
            this.listViewCasier.UseCompatibleStateImageBehavior = false;
            // 
            // listViewEmpruntsProlongés
            // 
            this.listViewEmpruntsProlongés.HideSelection = false;
            this.listViewEmpruntsProlongés.Location = new System.Drawing.Point(614, 315);
            this.listViewEmpruntsProlongés.Name = "listViewEmpruntsProlongés";
            this.listViewEmpruntsProlongés.Size = new System.Drawing.Size(578, 214);
            this.listViewEmpruntsProlongés.TabIndex = 19;
            this.listViewEmpruntsProlongés.UseCompatibleStateImageBehavior = false;
            // 
            // précédentEmprunts
            // 
            this.précédentEmprunts.Location = new System.Drawing.Point(974, 535);
            this.précédentEmprunts.Name = "précédentEmprunts";
            this.précédentEmprunts.Size = new System.Drawing.Size(106, 23);
            this.précédentEmprunts.TabIndex = 21;
            this.précédentEmprunts.Text = "Page précédente";
            this.précédentEmprunts.UseVisualStyleBackColor = true;
            this.précédentEmprunts.Click += new System.EventHandler(this.précédentEmprunts_Click);
            // 
            // suivantEmprunts
            // 
            this.suivantEmprunts.Location = new System.Drawing.Point(1086, 535);
            this.suivantEmprunts.Name = "suivantEmprunts";
            this.suivantEmprunts.Size = new System.Drawing.Size(106, 23);
            this.suivantEmprunts.TabIndex = 20;
            this.suivantEmprunts.Text = "Page suivante";
            this.suivantEmprunts.UseVisualStyleBackColor = true;
            this.suivantEmprunts.Click += new System.EventHandler(this.suivantEmprunts_Click);
            // 
            // labelEmpruntsProlongés
            // 
            this.labelEmpruntsProlongés.AutoSize = true;
            this.labelEmpruntsProlongés.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmpruntsProlongés.Location = new System.Drawing.Point(607, 275);
            this.labelEmpruntsProlongés.Name = "labelEmpruntsProlongés";
            this.labelEmpruntsProlongés.Size = new System.Drawing.Size(305, 37);
            this.labelEmpruntsProlongés.TabIndex = 22;
            this.labelEmpruntsProlongés.Text = "Emprunts prolongés";
            // 
            // labelAlbumsManquants
            // 
            this.labelAlbumsManquants.AutoSize = true;
            this.labelAlbumsManquants.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAlbumsManquants.Location = new System.Drawing.Point(1069, 16);
            this.labelAlbumsManquants.Name = "labelAlbumsManquants";
            this.labelAlbumsManquants.Size = new System.Drawing.Size(294, 37);
            this.labelAlbumsManquants.TabIndex = 23;
            this.labelAlbumsManquants.Text = "Albums manquants";
            // 
            // boutonRetard
            // 
            this.boutonRetard.Location = new System.Drawing.Point(940, 104);
            this.boutonRetard.Name = "boutonRetard";
            this.boutonRetard.Size = new System.Drawing.Size(88, 49);
            this.boutonRetard.TabIndex = 24;
            this.boutonRetard.Text = "Liste retards";
            this.boutonRetard.UseVisualStyleBackColor = true;
            this.boutonRetard.Click += new System.EventHandler(this.buttonRetard_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1392, 659);
            this.Controls.Add(this.boutonRetard);
            this.Controls.Add(this.labelAlbumsManquants);
            this.Controls.Add(this.labelEmpruntsProlongés);
            this.Controls.Add(this.précédentEmprunts);
            this.Controls.Add(this.suivantEmprunts);
            this.Controls.Add(this.listViewEmpruntsProlongés);
            this.Controls.Add(this.listViewCasier);
            this.Controls.Add(this.labelCasier);
            this.Controls.Add(this.numericUpDownCasier);
            this.Controls.Add(this.boutonDéconnexion);
            this.Controls.Add(this.dataGridViewAbonné);
            this.Controls.Add(this.pagePrécédente);
            this.Controls.Add(this.pageSuivante);
            this.Controls.Add(this.labelAlbumsNonEmpruntés);
            this.Controls.Add(this.listViewAlbumsNonEmpuntés);
            this.Controls.Add(this.boutonPurge);
            this.Controls.Add(this.labelAbonné);
            this.Controls.Add(this.listViewTopAlbum);
            this.Controls.Add(this.labelTopAlbum);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Admin";
            this.Text = "Admin";
            this.Load += new System.EventHandler(this.Admin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAbonné)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCasier)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTopAlbum;
        private System.Windows.Forms.ListView listViewTopAlbum;
        private System.Windows.Forms.Label labelAbonné;
        private System.Windows.Forms.Button boutonPurge;
        private System.Windows.Forms.ListView listViewAlbumsNonEmpuntés;
        private System.Windows.Forms.Label labelAlbumsNonEmpruntés;
        private System.Windows.Forms.Button pagePrécédente;
        private System.Windows.Forms.Button pageSuivante;
        private System.Windows.Forms.DataGridView dataGridViewAbonné;
        private System.Windows.Forms.Button boutonDéconnexion;
        private System.Windows.Forms.NumericUpDown numericUpDownCasier;
        private System.Windows.Forms.Label labelCasier;
        private System.Windows.Forms.ListView listViewCasier;
        private System.Windows.Forms.ListView listViewEmpruntsProlongés;
        private System.Windows.Forms.Button précédentEmprunts;
        private System.Windows.Forms.Button suivantEmprunts;
        private System.Windows.Forms.Label labelEmpruntsProlongés;
        private System.Windows.Forms.Label labelAlbumsManquants;
        private System.Windows.Forms.Button boutonRetard;
    }
}