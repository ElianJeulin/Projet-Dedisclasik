using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Admin : Form
    {
        private ALBUMS[] empruntsProlongés;
        private ALBUMS[] topAlbum;
        private ALBUMS[] albumsNonEmpruntes;
        private ImageList imagesAlbumsNonEmpruntes;
        private ImageList imagesTopAlbum;
        private ImageList imagesEmpruntsProlongés;
        private int indexAlbumNonEmpruntes = 0;
        private int indexEmpruntsProlongés = 0;
        private int tailleAlbumsNonEmpruntes;
        private int tailleEmpruntsProlongés;
        private Color backListView = ColorTranslator.FromHtml("#8BE4DB");
        private Color backColor = ColorTranslator.FromHtml("#CBF3F0");
        private Color boutonColor = ColorTranslator.FromHtml("#8BE4DB");
        private Color textColor = ColorTranslator.FromHtml("#2FC6B7");
        public Admin()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

            //Gestion des couleurs
            labelAbonné.ForeColor = textColor;
            labelAlbumsManquants.ForeColor = textColor;
            labelAlbumsNonEmpruntés.ForeColor = textColor;
            labelCasier.ForeColor = textColor;
            labelEmpruntsProlongés.ForeColor = textColor;
            labelTopAlbum.ForeColor = textColor;
            this.BackColor = backColor;
            numericUpDownCasier.BackColor = backListView;
            listViewTopAlbum.BackColor = backListView;
            listViewAlbumsNonEmpuntés.BackColor = backListView;
            listViewCasier.BackColor = backListView;
            listViewEmpruntsProlongés.BackColor = backListView;
            pagePrécédente.BackColor = boutonColor;
            boutonDéconnexion.BackColor = boutonColor;
            boutonPurge.BackColor = boutonColor;
            boutonRetard.BackColor = boutonColor;
            pageSuivante.BackColor = boutonColor;
            pagePrécédente.BackColor = boutonColor;
            pageSuivante.BackColor = boutonColor;
            suivantEmprunts.BackColor = boutonColor;
            précédentEmprunts.BackColor = boutonColor;
        }

        #region Chargement page admin
        /// <summary>
        /// Méthode d'affichage fixe de admin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Admin_Load(object sender, EventArgs e)
        {
            chargerAlbumsNonEmpruntes();
            chargerEmpruntsProlongés();
            chargerTopAlbum();
            affichageAbonnés();
            //Affichage des listViews
            Utilitaire.afficherAlbumsListView10(listViewTopAlbum, topAlbum, imagesTopAlbum, 0, 10);
            Utilitaire.afficherAlbumsListView10(listViewAlbumsNonEmpuntés, albumsNonEmpruntes, imagesAlbumsNonEmpruntes, indexAlbumNonEmpruntes, 10);
            Utilitaire.afficherAlbumsListView10(listViewEmpruntsProlongés, empruntsProlongés, imagesEmpruntsProlongés, indexEmpruntsProlongés, 10);
            gestionBoutonPages();
        }
        #endregion

        #region Méthode de gestion des boutons


        /// <summary>
        /// Méthode de gestion du bouton de page précédente 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pagePrécédente_Click(object sender, EventArgs e)
        {
            indexAlbumNonEmpruntes -= 10;
            listViewAlbumsNonEmpuntés.Clear();
            Utilitaire.afficherAlbumsListView10(listViewAlbumsNonEmpuntés, albumsNonEmpruntes, imagesAlbumsNonEmpruntes, indexAlbumNonEmpruntes, 10);
            gestionBoutonPages();
        }

        /// <summary>
        /// Méthode de gestion du bouton de connexion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDéconnexion_Click(object sender, EventArgs e)
        {
            LocaDisk.deco = true;
            this.Close();
        }

        /// <summary>
        /// Méthode de gestion de la page suivante 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pageSuivante_Click(object sender, EventArgs e)
        {
            indexAlbumNonEmpruntes += 10;
            listViewAlbumsNonEmpuntés.Clear();
            Utilitaire.afficherAlbumsListView10(listViewAlbumsNonEmpuntés, albumsNonEmpruntes, imagesAlbumsNonEmpruntes, indexAlbumNonEmpruntes, 10);
            gestionBoutonPages();
        }

        /// <summary>
        /// Méthode de gestion du click du bouton précédent des emprunts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void précédentEmprunts_Click(object sender, EventArgs e)
        {
            indexEmpruntsProlongés -= 10;
            listViewEmpruntsProlongés.Clear();
            Utilitaire.afficherAlbumsListView10(listViewEmpruntsProlongés, empruntsProlongés, imagesEmpruntsProlongés, indexEmpruntsProlongés, 10);
            gestionBoutonPages();
        }

        /// <summary>
        /// Méthode de gestion du click du bouton suivant des emprunts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void suivantEmprunts_Click(object sender, EventArgs e)
        {
            indexEmpruntsProlongés += 10;
            listViewEmpruntsProlongés.Clear();
            Utilitaire.afficherAlbumsListView10(listViewEmpruntsProlongés, empruntsProlongés, imagesEmpruntsProlongés, indexEmpruntsProlongés, 10);
            gestionBoutonPages();
        }

        /// <summary>
        /// Méthode de gestion du click du bouton retard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRetard_Click(object sender, EventArgs e)
        {
            DateTime dateActuelle = DateTime.Now;
            EMPRUNTER[] empruntsTab = Requêtes.ListeEmpruntNonRendu();
            string aboRetard = "";

            foreach (EMPRUNTER emprunt in empruntsTab)
            {
                if (dateActuelle > emprunt.DATE_RETOUR_ATTENDUE.AddDays(10))
                {
                    string[] infos = emprunt.ABONNÉS.ToString().Split('/');
                    aboRetard += "-" + infos[0] + " " + infos[1] + " a cet emprunt en retard: " + emprunt.ALBUMS.TITRE_ALBUM.Trim() + "\n";
                }
            }
            MessageBox.Show("Voici la liste des retards:\n" + aboRetard);
        }

        /// <summary>
        /// Méthode de gestion du numericUpDown pour le numéro du casier
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDownCasier_ValueChanged(object sender, EventArgs e)
        {
            AffichageAlbumManquantCasier();
        }

        #endregion

        #region Affichages des éléments

        /// <summary>
        /// Méthode permettant d'afficher la liste des abonnés 
        /// </summary>
        private void affichageAbonnés()
        {
            dataGridViewAbonné.Columns.Clear();
            dataGridViewAbonné.Rows.Clear();

            ABONNÉS[] abonnés = Requêtes.ListeToutAbonné();
            dataGridViewAbonné.Columns.Add("Nom", "Nom");
            dataGridViewAbonné.Columns.Add("Prénom", "Prénom");
            dataGridViewAbonné.Columns.Add("Login", "Login");
            foreach (ABONNÉS abo in abonnés)
            {
                string[] infos = abo.ToString().Split('/');
                dataGridViewAbonné.Rows.Add(infos[0], infos[1], infos[2]);
            }
        }

        /// <summary>
        /// Méthode d'affichage des albums manquant par casier 
        /// </summary>
        private void AffichageAlbumManquantCasier()
        {
            listViewCasier.Items.Clear();
            int numeroCasier = (int)numericUpDownCasier.Value;

            EMPRUNTER[] emprunts = Requêtes.ListeEmpruntParCasier(numeroCasier);

            foreach (EMPRUNTER emprunt in emprunts)
            {
                listViewCasier.Items.Add(emprunt.ALBUMS.TITRE_ALBUM);
            }
        }

        #endregion

        #region Chargement données 


        /// <summary>
        /// Méthode de chargement du topAlbum
        /// </summary>
        private void chargerTopAlbum()
        {
            topAlbum = Requêtes.ChargerTopAlbums();
            imagesTopAlbum = new ImageList();
            imagesTopAlbum.ImageSize = new Size(50, 50);
        }

        /// <summary>
        /// Méthode de gestion du bouton de purge 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void boutonPurge_Click(object sender, EventArgs e)
        {
            int nbPurgés = Requêtes.Purge();
            MessageBox.Show("Vous avez purgé " + nbPurgés + " abonnés.");
            affichageAbonnés();
        }

        /// <summary>
        /// Méthode de chargement des albums non empruntés
        /// </summary>
        private void chargerAlbumsNonEmpruntes()
        {
            albumsNonEmpruntes = Requêtes.listeAlbumNonEmprunte();
            imagesAlbumsNonEmpruntes = new ImageList();
            imagesAlbumsNonEmpruntes.ImageSize = new Size(50, 50);
            tailleAlbumsNonEmpruntes = albumsNonEmpruntes.Length;
        }

        private void chargerEmpruntsProlongés()
        {
            List<EMPRUNTER> buffEmprunts = new List<EMPRUNTER>();
            List<ALBUMS> buffAlbums = new List<ALBUMS>();

            int index = 0;
            foreach (EMPRUNTER emprunt in Requêtes.ListeToutEmprunt())
            {
                if (emprunt.DATE_RETOUR_ATTENDUE > emprunt.DATE_EMPRUNT.AddDays(emprunt.ALBUMS.GENRES.DÉLAI))
                {
                    buffEmprunts.Add(emprunt);
                }
                index++;
            }

            foreach (EMPRUNTER emprunt in buffEmprunts)
            {
                var req = from albums in Requêtes.baseMusique.ALBUMS
                          join emprunts in Requêtes.baseMusique.EMPRUNTER on albums.CODE_ALBUM equals emprunt.CODE_ALBUM
                          where emprunt.CODE_ALBUM == albums.CODE_ALBUM
                          select albums;
                buffAlbums.Add(req.FirstOrDefault());
            }
            empruntsProlongés = buffAlbums.ToArray();
            imagesEmpruntsProlongés = new ImageList();
            imagesEmpruntsProlongés.ImageSize = new Size(50, 50);
            tailleEmpruntsProlongés = empruntsProlongés.Length;
        }



        /// <summary>
        /// Méthode de gestion des boutons de changement de page 
        /// </summary>
        private void gestionBoutonPages()
        {
            pageSuivante.Enabled = !((indexAlbumNonEmpruntes + 1) * 10 >= tailleAlbumsNonEmpruntes);
            pagePrécédente.Enabled = indexAlbumNonEmpruntes != 0;

            suivantEmprunts.Enabled = !((indexEmpruntsProlongés + 1) * 10 >= tailleEmpruntsProlongés);
            précédentEmprunts.Enabled = indexEmpruntsProlongés != 0;
        }
        #endregion
    }
}
