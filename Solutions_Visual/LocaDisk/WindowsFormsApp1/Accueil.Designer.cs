
namespace WindowsFormsApp1
{
    partial class LocaDisk
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocaDisk));
            this.TopAlbums = new System.Windows.Forms.ListView();
            this.labelEspacePerso = new System.Windows.Forms.Label();
            this.Emprunts = new System.Windows.Forms.ListView();
            this.labelTopAlbum = new System.Windows.Forms.Label();
            this.labelEmprunts = new System.Windows.Forms.Label();
            this.boutonEmprunt = new System.Windows.Forms.Button();
            this.buttonDéconnexion = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pageSuivante = new System.Windows.Forms.Button();
            this.pagePrécédente = new System.Windows.Forms.Button();
            this.boutonProlonger = new System.Windows.Forms.Button();
            this.boutonChangerMdp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TopAlbums
            // 
            this.TopAlbums.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.TopAlbums.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TopAlbums.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TopAlbums.HideSelection = false;
            this.TopAlbums.Location = new System.Drawing.Point(12, 148);
            this.TopAlbums.Name = "TopAlbums";
            this.TopAlbums.Size = new System.Drawing.Size(568, 376);
            this.TopAlbums.TabIndex = 0;
            this.TopAlbums.UseCompatibleStateImageBehavior = false;
            this.TopAlbums.ItemActivate += new System.EventHandler(this.TopAlbums_ItemActivate);
            // 
            // labelEspacePerso
            // 
            this.labelEspacePerso.AutoSize = true;
            this.labelEspacePerso.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEspacePerso.Location = new System.Drawing.Point(426, 9);
            this.labelEspacePerso.Name = "labelEspacePerso";
            this.labelEspacePerso.Size = new System.Drawing.Size(410, 55);
            this.labelEspacePerso.TabIndex = 1;
            this.labelEspacePerso.Text = "Espace personnel";
            // 
            // Emprunts
            // 
            this.Emprunts.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.Emprunts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Emprunts.HideSelection = false;
            this.Emprunts.Location = new System.Drawing.Point(646, 148);
            this.Emprunts.Name = "Emprunts";
            this.Emprunts.Size = new System.Drawing.Size(568, 376);
            this.Emprunts.TabIndex = 2;
            this.Emprunts.UseCompatibleStateImageBehavior = false;
            this.Emprunts.ItemActivate += new System.EventHandler(this.Emprunts_ItemActivate);
            // 
            // labelTopAlbum
            // 
            this.labelTopAlbum.AutoSize = true;
            this.labelTopAlbum.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTopAlbum.Location = new System.Drawing.Point(12, 108);
            this.labelTopAlbum.Name = "labelTopAlbum";
            this.labelTopAlbum.Size = new System.Drawing.Size(365, 37);
            this.labelTopAlbum.TabIndex = 3;
            this.labelTopAlbum.Text = "Top 10 des vinyles loués";
            // 
            // labelEmprunts
            // 
            this.labelEmprunts.AutoSize = true;
            this.labelEmprunts.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmprunts.Location = new System.Drawing.Point(638, 108);
            this.labelEmprunts.Name = "labelEmprunts";
            this.labelEmprunts.Size = new System.Drawing.Size(216, 37);
            this.labelEmprunts.TabIndex = 4;
            this.labelEmprunts.Text = "Vos emprunts";
            // 
            // boutonEmprunt
            // 
            this.boutonEmprunt.FlatAppearance.BorderSize = 0;
            this.boutonEmprunt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.boutonEmprunt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boutonEmprunt.Location = new System.Drawing.Point(58, 614);
            this.boutonEmprunt.Name = "boutonEmprunt";
            this.boutonEmprunt.Size = new System.Drawing.Size(117, 55);
            this.boutonEmprunt.TabIndex = 5;
            this.boutonEmprunt.Text = "Emprunter un livre";
            this.boutonEmprunt.UseVisualStyleBackColor = true;
            this.boutonEmprunt.Click += new System.EventHandler(this.boutonEmprunt_Click);
            // 
            // buttonDéconnexion
            // 
            this.buttonDéconnexion.FlatAppearance.BorderSize = 0;
            this.buttonDéconnexion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDéconnexion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDéconnexion.Location = new System.Drawing.Point(1032, 614);
            this.buttonDéconnexion.Name = "buttonDéconnexion";
            this.buttonDéconnexion.Size = new System.Drawing.Size(117, 55);
            this.buttonDéconnexion.TabIndex = 6;
            this.buttonDéconnexion.Text = "Déconnexion";
            this.buttonDéconnexion.UseVisualStyleBackColor = true;
            this.buttonDéconnexion.Click += new System.EventHandler(this.buttonDéconnexion_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1083, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // pageSuivante
            // 
            this.pageSuivante.FlatAppearance.BorderSize = 0;
            this.pageSuivante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pageSuivante.Location = new System.Drawing.Point(1108, 530);
            this.pageSuivante.Name = "pageSuivante";
            this.pageSuivante.Size = new System.Drawing.Size(106, 23);
            this.pageSuivante.TabIndex = 8;
            this.pageSuivante.Text = "Page suivante";
            this.pageSuivante.UseVisualStyleBackColor = true;
            this.pageSuivante.Click += new System.EventHandler(this.pageSuivante_Click);
            // 
            // pagePrécédente
            // 
            this.pagePrécédente.FlatAppearance.BorderSize = 0;
            this.pagePrécédente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pagePrécédente.Location = new System.Drawing.Point(996, 530);
            this.pagePrécédente.Name = "pagePrécédente";
            this.pagePrécédente.Size = new System.Drawing.Size(106, 23);
            this.pagePrécédente.TabIndex = 9;
            this.pagePrécédente.Text = "Page précédente";
            this.pagePrécédente.UseVisualStyleBackColor = true;
            this.pagePrécédente.Click += new System.EventHandler(this.pagePrécédente_Click);
            // 
            // boutonProlonger
            // 
            this.boutonProlonger.FlatAppearance.BorderSize = 0;
            this.boutonProlonger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.boutonProlonger.Location = new System.Drawing.Point(646, 530);
            this.boutonProlonger.Name = "boutonProlonger";
            this.boutonProlonger.Size = new System.Drawing.Size(75, 48);
            this.boutonProlonger.TabIndex = 10;
            this.boutonProlonger.Text = "Prolonger tous mes emprunts";
            this.boutonProlonger.UseVisualStyleBackColor = true;
            this.boutonProlonger.Click += new System.EventHandler(this.boutonProlonger_Click);
            // 
            // boutonChangerMdp
            // 
            this.boutonChangerMdp.FlatAppearance.BorderSize = 0;
            this.boutonChangerMdp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.boutonChangerMdp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boutonChangerMdp.Location = new System.Drawing.Point(12, 9);
            this.boutonChangerMdp.Name = "boutonChangerMdp";
            this.boutonChangerMdp.Size = new System.Drawing.Size(117, 55);
            this.boutonChangerMdp.TabIndex = 11;
            this.boutonChangerMdp.Text = "Changer mon mot de passe";
            this.boutonChangerMdp.UseVisualStyleBackColor = true;
            this.boutonChangerMdp.Click += new System.EventHandler(this.boutonChangerMdp_Click);
            // 
            // LocaDisk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 681);
            this.Controls.Add(this.boutonChangerMdp);
            this.Controls.Add(this.boutonProlonger);
            this.Controls.Add(this.pagePrécédente);
            this.Controls.Add(this.pageSuivante);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonDéconnexion);
            this.Controls.Add(this.boutonEmprunt);
            this.Controls.Add(this.labelEmprunts);
            this.Controls.Add(this.labelTopAlbum);
            this.Controls.Add(this.Emprunts);
            this.Controls.Add(this.labelEspacePerso);
            this.Controls.Add(this.TopAlbums);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LocaDisk";
            this.Text = "Dédisclasik";
            this.Load += new System.EventHandler(this.LocaDisk_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView TopAlbums;
        private System.Windows.Forms.Label labelEspacePerso;
        private System.Windows.Forms.ListView Emprunts;
        private System.Windows.Forms.Label labelTopAlbum;
        private System.Windows.Forms.Label labelEmprunts;
        private System.Windows.Forms.Button boutonEmprunt;
        private System.Windows.Forms.Button buttonDéconnexion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button pageSuivante;
        private System.Windows.Forms.Button pagePrécédente;
        private System.Windows.Forms.Button boutonProlonger;
        private System.Windows.Forms.Button boutonChangerMdp;
    }
}

