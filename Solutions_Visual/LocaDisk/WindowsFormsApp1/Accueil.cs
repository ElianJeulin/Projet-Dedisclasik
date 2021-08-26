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
    public partial class LocaDisk : Form
    {
        public static int idAbo = -1;
        public static bool deco = false;
        private int indexEmpruntsPage = 0;
        private int tailleEmprunt;
        private string[] titresEmprunts;
        private ImageList imagesEmprunts;
        private List<byte[]> pochettesEmprunts;
        private Color backListView = ColorTranslator.FromHtml("#8BE4DB");
        private Color backColor = ColorTranslator.FromHtml("#CBF3F0");
        private Color rendu = ColorTranslator.FromHtml("#5C6D70");
        private Color boutonColor = ColorTranslator.FromHtml("#8BE4DB");
        private Color textColor = ColorTranslator.FromHtml("#2FC6B7");
        

        public LocaDisk()
        {
            deco = false;
            StartPosition = FormStartPosition.CenterScreen;
            chargerEmprunts();
            InitializeComponent();
            //Gestion couleur
            this.BackColor = backColor;
            labelEmprunts.ForeColor = textColor;
            labelEspacePerso.ForeColor = textColor;
            labelTopAlbum.ForeColor = textColor;
            TopAlbums.BackColor = backListView;
            Emprunts.BackColor = backListView;
            //gestion style bouton
            boutonEmprunt.BackColor = boutonColor;
            boutonProlonger.BackColor = boutonColor;
            pagePrécédente.BackColor = boutonColor;
            pageSuivante.BackColor = boutonColor;
            buttonDéconnexion.BackColor = boutonColor;
            boutonChangerMdp.Visible = false;

        }
        #region Affichages et chargements 
        /// <summary>
        /// Méthode qui appelle la méthode d'affichage du top 10 ou des suggestions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LocaDisk_Load(object sender, EventArgs e)
        {
            if (titresEmprunts.Length == 0)
            {
                affichageTop10();
            }
            else
            {
                affichageSuggestion();
            }
            affichageEmprunts();
            gestionBoutonPages();
        }
        #endregion

        #region listViews
        /// <summary>
        /// Méthode d'affichage du top 10
        /// </summary>
        protected void affichageTop10()
        {
            labelTopAlbum.Text = "Top 10 des vinyles loués";
            TopAlbums.Clear();
            ALBUMS[] topAlbum = Requêtes.ChargerTopAlbums();
            ImageList imagesTopAlbum = new ImageList();
            imagesTopAlbum.ImageSize = new Size(75, 75);

            Utilitaire.afficherAlbumsListView10(TopAlbums, topAlbum, imagesTopAlbum, 0, 10);
        }

        /// <summary>
        /// Méthode d'affichage des suggestions 
        /// </summary>
        private void affichageSuggestion()
        {
            labelTopAlbum.Text = "Suggestions";
            TopAlbums.Clear();
            TopAlbums.Scrollable = false;
            ALBUMS[] ablumParGenre = Requêtes.ListeAlbumParGenre(Requêtes.GenrePréféré(idAbo));
            List<ALBUMS> listSuggestion = new List<ALBUMS>();
            bool verif;
            foreach (ALBUMS album in ablumParGenre)
            {
                verif = false;
                foreach(string dejaEmprunté in titresEmprunts)
                {
                    if (dejaEmprunté.Trim().Equals(album.TITRE_ALBUM.Trim())) {
                        verif = true;
                    }

                }
                if (!verif)
                {
                    listSuggestion.Add(album);
                }
            }
            ALBUMS[] toutesSuggestions = listSuggestion.ToArray();
            int max = toutesSuggestions.Length;
            if (max >= 10) max = 10;
            ALBUMS[] suggestions = new ALBUMS[max];
            int index = 0;
            Random random = new Random();
            while (index < max)
            {
                ALBUMS suggestion = toutesSuggestions[random.Next(0, toutesSuggestions.Length)];
                verif = false;
                foreach(ALBUMS suggéré in suggestions)
                {
                    if(suggestion.Equals(suggéré)){
                        verif = true;
                    }
                }
                if (!verif)
                {
                    suggestions[index] = suggestion;
                    index++;
                }
            }

            ImageList imagesTopAlbum = new ImageList();
            imagesTopAlbum.ImageSize = new Size(75, 75);
            Utilitaire.afficherAlbumsListView10(TopAlbums, suggestions, imagesTopAlbum, 0, 10);
        }

        /// <summary>
        /// Mééthode qui gère l'affichage des emprunts
        /// </summary>
        private void affichageEmprunts()
        {
            int indexEmprunts = 0;
            EMPRUNTER[] listeEmpruntsRendu = Requêtes.ListeEmpruntRendu(idAbo);
            ALBUMS[] listeAlbumEmprunté = Requêtes.ChargerEmprunts(idAbo);
            List<ALBUMS> albumEmprunté = new List<ALBUMS>();
            foreach(ALBUMS album in listeAlbumEmprunté)
            {
                albumEmprunté.Add(album);
            }
            foreach(EMPRUNTER emprunt in listeEmpruntsRendu)
            {
                albumEmprunté.Add(emprunt.ALBUMS);
            }
            albumEmprunté.Reverse();
            IEnumerable<ALBUMS> albums = albumEmprunté.Distinct();
            albumEmprunté = albums.Reverse().ToList();

            //Création de la liste d'image des Emprunts
            foreach (byte[] pochette in pochettesEmprunts)
            {
                imagesEmprunts.Images.Add(titresEmprunts[indexEmprunts], decrypteImage(pochette));
                indexEmprunts++;
            }
            ALBUMS[] albumsAAfficher = albumEmprunté.ToArray();

            Emprunts.LargeImageList = imagesEmprunts;

            Utilitaire.afficherAlbumsListView10(Emprunts, albumsAAfficher, imagesEmprunts, indexEmpruntsPage, 12);
            
        }

        /// <summary>
        /// M&thode qui permet de charger les emprunts
        /// </summary>
        private void chargerEmprunts()
        {
            List<ALBUMS> emprunté = Requêtes.ChargerEmprunts(idAbo).ToList();
            tailleEmprunt = emprunté.Count();
            titresEmprunts = new string[tailleEmprunt];
            foreach(ALBUMS album in emprunté)
            {
                titresEmprunts[emprunté.IndexOf(album)] = album.TITRE_ALBUM;
            }
            imagesEmprunts = new ImageList();
            imagesEmprunts.ImageSize = new Size(75, 75);
            pochettesEmprunts = Requêtes.ChargerImages(titresEmprunts);
        }

        /// <summary>
        /// Méthode de gestion de l'affichage des pochettes d'album
        /// </summary>
        /// <param name="valeurHex">Tableau d'images</param>
        /// <returns> le vinyle</returns>
        public static Image decrypteImage(byte[] valeurHex)
        {
            if(valeurHex != null)
            {
                using (var ms = new MemoryStream(valeurHex))
                {
                    return Image.FromStream(ms);
                }
            }
            Image vinyle = new Bitmap(WindowsFormsApp1.Properties.Resources.vinyle_icon);
            return vinyle;
        }
        #endregion

        #region boutonsPages

        /// <summary>
        /// Méthode de gestion du bouton de déconnexion 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDéconnexion_Click(object sender, EventArgs e)
        {
            deco = true;
            this.Close();
        }

        /// <summary>
        /// Méthode permettant de passer à la page suivante
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pageSuivante_Click(object sender, EventArgs e)
        {
            indexEmpruntsPage+=12;
            Emprunts.Clear();
            affichageEmprunts();
            gestionBoutonPages();
        }

        /// <summary>
        /// M&thode permettant de revenir à la page précédente 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pagePrécédente_Click(object sender, EventArgs e)
        {
            indexEmpruntsPage-=12;
            Emprunts.Clear();
            affichageEmprunts();
            gestionBoutonPages();
        }

        /// <summary>
        /// Méthode permettant de gérer les boutons sur les pages (suivant / précédent)
        /// </summary>
        private void gestionBoutonPages()
        {
            pageSuivante.Enabled = !((indexEmpruntsPage + 1) * 12 >= tailleEmprunt);
            pagePrécédente.Enabled = indexEmpruntsPage != 0;
        }

        /// <summary>
        /// Mthode qui gère le bouton de prolongement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void boutonProlonger_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Etes-vous sûr de vouloir prolonger tous vos emprunts ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                List<ALBUMS> emprunté = Requêtes.ChargerEmprunts(idAbo).ToList();
                string[] emprunts = new string[emprunté.Count()];
                foreach (ALBUMS album in emprunté)
                {
                    emprunts[emprunté.IndexOf(album)] = album.TITRE_ALBUM;
                }
                int compte = 0;
                foreach (string titre in emprunts)
                {
                    if (Requêtes.VerificationProlongementPossible(titre, idAbo))
                    {
                        EMPRUNTER emprunt = Requêtes.TrouverDansMesEmprunts(titre, idAbo);
                        if (emprunt != null)
                        {
                            emprunt.DATE_RETOUR_ATTENDUE = emprunt.DATE_RETOUR_ATTENDUE.AddMonths(1);
                            compte++;
                        }
                        Requêtes.baseMusique.SaveChanges();
                    }
                }
                Requêtes.baseMusique.SaveChanges();

                if (compte != 0)
                {
                    MessageBox.Show("Vous avez prolongés " + compte + " emprunts");
                }
                else
                {
                    MessageBox.Show("Aucun emprunts ne peut être prolongé");
                }

            }
        }

        /// <summary>
        /// Méthode qui gère le bouton d'emprunt 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void boutonEmprunt_Click(object sender, EventArgs e)
        {
            Emprunt emprunt = new Emprunt();
            if (emprunt.ShowDialog() == DialogResult.OK)
            {
                affichageSuggestion();
                chargerEmprunts();
                affichageEmprunts();
                gestionBoutonPages();
            }
        }
        #endregion

        #region Gestion de l'emprunt 
        /// <summary>
        /// Méthode permettant de gérer le prolongement d'un album
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Emprunts_ItemActivate(object sender, EventArgs e)
        {
            string titre = Emprunts.FocusedItem.Text;
            if (titre.Trim() != "")
            {
                ChoixRendreProlonger choix = new ChoixRendreProlonger(titre);
                EMPRUNTER emprunt = Requêtes.VinyleSelectionné(titre, idAbo);
                ALBUMS album = emprunt.ALBUMS;
                bool dejaRendu = DejaRendu(emprunt);
            
                if (!dejaRendu)
                {
                    DialogResult retour = choix.ShowDialog();
                    if (retour == DialogResult.Yes)
                    {
                        ProlongerEmprunts prolongerEmprunts = new ProlongerEmprunts(Requêtes.VerificationProlongementPossible(titre, idAbo), titre);
                        if (prolongerEmprunts.ShowDialog() == DialogResult.Yes)
                        {
                            emprunt = Requêtes.TrouverDansMesEmprunts(titre, idAbo);
                            emprunt.DATE_RETOUR_ATTENDUE = emprunt.DATE_RETOUR_ATTENDUE.AddMonths(1);
                            Requêtes.baseMusique.SaveChanges();
                            MessageBox.Show("Votre emprunt a bien été prolongé");
                        }
                    }
                    else if (retour == DialogResult.No)
                    {
                        Requêtes.RendreEmprunt(emprunt);
                        MessageBox.Show("Vous avez rendu " + titre.Trim() + ".");
                        affichageEmprunts();
                    }
                }
                else
                {
                    if (MessageBox.Show("Voulez-vous ré-emprunter "+ titre.Trim() +" ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Requêtes.baseMusique.EMPRUNTER.Remove(emprunt);
                        Requêtes.baseMusique.SaveChanges();
                        emprunt.DATE_EMPRUNT = DateTime.Now;
                        GENRES delai = album.GENRES;
                        emprunt.DATE_RETOUR_ATTENDUE = DateTime.Now.AddDays(delai.DÉLAI);
                        emprunt.DATE_RETOUR = null;
                        Requêtes.baseMusique.EMPRUNTER.Add(emprunt);
                        Requêtes.baseMusique.SaveChanges();
                        MessageBox.Show("Vous avez ré-emprunter " + titre.Trim() + " ?");
                        affichageEmprunts();
                    }
                }
            }
        }

        /// <summary>
        /// Fonction qui vérifie si un emprunt a bien été rendu
        /// </summary>
        /// <param name="emprunt">l'emprunt concerné</param>
        /// <returns>vrai si l'emprunt a été rendu</returns>
        public bool DejaRendu(EMPRUNTER emprunt)
        {
            bool dejaRendu = false;

            EMPRUNTER[] listeRendu = Requêtes.ListeEmpruntRendu(idAbo);
            foreach (EMPRUNTER rendu in listeRendu)
            {
                if (rendu.CODE_ALBUM == emprunt.CODE_ALBUM)
                {
                    dejaRendu = true;
                }
            }
            return dejaRendu;
        }



        /// <summary>
        /// Méthode de gestion de l'emprunt dans le top 10 albums et les connections
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TopAlbums_ItemActivate(object sender, EventArgs e)
        {
            if (TopAlbums.FocusedItem != null)
            {
                string texte = TopAlbums.FocusedItem.Text.Trim();
                if (texte.Trim() != "")
                {
                    DialogResult dialog = MessageBox.Show("Souhaitez-vous emprunter " + texte + " ?", "emprunt", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        ALBUMS albumAEmprunter = Requêtes.emprunterAlbumTitre(texte);
                        GENRES genre = Requêtes.GenreAlbum(albumAEmprunter);

                        EMPRUNTER emprunt = new EMPRUNTER
                        {
                            CODE_ABONNÉ = LocaDisk.idAbo,
                            CODE_ALBUM = albumAEmprunter.CODE_ALBUM,
                            DATE_EMPRUNT = DateTime.Now,
                            DATE_RETOUR_ATTENDUE = DateTime.Now.AddDays(genre.DÉLAI),
                            DATE_RETOUR = null
                        };
                        Requêtes.baseMusique.EMPRUNTER.Add(emprunt);
                        Requêtes.baseMusique.SaveChanges();
                        MessageBox.Show(albumAEmprunter.ToString().Trim() + " a bien été emprunté");
                        affichageSuggestion();
                        chargerEmprunts();
                        affichageEmprunts();
                        gestionBoutonPages();

                    }
                }
            }
        }
        #endregion

        private void boutonChangerMdp_Click(object sender, EventArgs e)
        {

        }
    }
}
