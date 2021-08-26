using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Utilitaire
    {
        /// <summary>
        /// Méthode pour afficher les albums dans une list view
        /// </summary>
        /// <param name="listView">La liste view en question</param>
        /// <param name="albums">La liste des albums à afficher</param>
        /// <param name="imageList">La liste des images des albums</param>
        /// <param name="indexPage">L'index de la page actuel</param>
        /// <param name="tailleListe">Le nombre d'album à afficher par page</param>
        public static void afficherAlbumsListView10(ListView listView, ALBUMS[] albums, ImageList imageList, int indexPage, int tailleListe)
        {
            listView.Clear();
            string[] titresAAficher = new string[tailleListe];

            int index = 0;

            while (index < tailleListe && indexPage < albums.Length)
            {
                titresAAficher[index] = albums[indexPage].TITRE_ALBUM.Trim();
                Image buff = LocaDisk.decrypteImage(albums[indexPage].POCHETTE);
                imageList.Images.Add(titresAAficher[index], buff);
                index++;
                indexPage++;
            }
            listView.LargeImageList = imageList;

            foreach (string titre in titresAAficher)
            {
                var listViewItem = listView.Items.Add(titre);
                listViewItem.ImageKey = (titre);
            }
        }
    }
}
