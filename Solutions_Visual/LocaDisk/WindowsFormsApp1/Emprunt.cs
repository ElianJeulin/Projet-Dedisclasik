using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Emprunt : Form
    {
        public Emprunt()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        #region Gestion des boutons 
        /// <summary>
        /// Méthode de gestion du bouton d'emprunt 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void boutonEmprunter_Click(object sender, EventArgs e)
        {
            if(listBox.SelectedItem != null)
            {
                ALBUMS albumAEmprunter = (ALBUMS)listBox.SelectedItem;
                Requêtes.EmprunterVinyle(albumAEmprunter, LocaDisk.idAbo);
                MessageBox.Show(albumAEmprunter.ToString().Trim() + " a bien été emprunté");
                textBoxRecherche_TextChanged(sender, e);
            } else
            {
                MessageBox.Show("Vous n'avez séléctionné aucun vinyle.");
            }

        }

        /// <summary>
        /// Méthode qui gère la fermeture de la boite de dialogue d'emprunt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Emprunt_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        #endregion

        #region Recherche
        /// <summary>
        /// Méthode de gestion de la textBox de recherche 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxRecherche_TextChanged(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            ALBUMS[] albums = Requêtes.RechercheAlbum(textBoxRecherche.Text);
            ALBUMS[] albumsEmpruntés = Requêtes.ChargerEmprunts(LocaDisk.idAbo);

            foreach (ALBUMS album in albums)
            {
                if (!albumsEmpruntés.ToString().Contains(album.TITRE_ALBUM))
                {
                    listBox.Items.Add(album);
                }
            }
        }
        #endregion

    }
}
