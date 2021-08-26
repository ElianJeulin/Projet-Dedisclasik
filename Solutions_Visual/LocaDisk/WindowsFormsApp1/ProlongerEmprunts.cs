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
    public partial class ProlongerEmprunts : Form
    {
        public bool empruntPossible { get; set; }
        public string titre { get; set; }

        #region Emprunts

        /// <summary>
        /// Méthode de prolongement d'un emprunt 
        /// </summary>
        /// <param name="possible"></param>
        /// <param name="titreAlbum"></param>
        public ProlongerEmprunts(bool possible, string titreAlbum)
        {
            this.empruntPossible = possible;
            StartPosition = FormStartPosition.CenterScreen;
            this.titre = titreAlbum;
            InitializeComponent();
            if (empruntPossible)
            {
                boutonOui.Visible = true;
                boutonNon.Visible = true;
                boutonOK.Visible = false;
                label1.Text = "Voulez vous prolonger l'emprunt de " + titre.Trim() + " ?";
            }
            else
            {
                boutonOui.Visible = false;
                boutonNon.Visible = false;
                boutonOK.Visible = true;
                label1.Text = "Vous avez déjà prolonger l'emprunt de " + titre.Trim() + ".";
            }

        }

        #endregion

        private void ProlongerEmprunts_Load(object sender, EventArgs e)
        {

        }
    }
}
