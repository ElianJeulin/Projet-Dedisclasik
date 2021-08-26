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
    public partial class Connexion : Form
    {
        public bool admin = false;
        Bitmap mdpVisible = WindowsFormsApp1.Properties.Resources.open_eye_icon;
        Bitmap mdpNonVisible = WindowsFormsApp1.Properties.Resources.close_eye_logo;
        bool étatMdp = false;
        bool vide = true;
        MusiquePT2_CEntities baseMusique;
        public Connexion()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            baseMusique = new MusiquePT2_CEntities();
        }

        #region TextsBoxs
        /// <summary>
        /// Méthode permettant de gérer la textBox du login du menu connexion lorsque l'utilisateur tape des informations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loginTextBox_Enter(object sender, EventArgs e)
        {
            if (loginTextBox.Text == "Login")
            {
                loginTextBox.ForeColor = Color.Black;
                loginTextBox.Text = "";
            }
        }

        /// <summary>
        /// Méthode permettant de gérer la textBox du login du menu connexion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loginTextBox_Leave(object sender, EventArgs e)
        {
            if (loginTextBox.Text.Length == 0)
            {
                loginTextBox.ForeColor = Color.Gray;
                loginTextBox.Text = "Login";
            }
        }

        /// <summary>
        /// Méthode permettant de gérer la textBox du mot de passe du menu connexion lorsque l'utilisateur tape des informations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void passTextBox_Enter(object sender, EventArgs e)
        {
            if (passTextBox.Text == "Mot de passe" && vide)
            {
                passTextBox.ForeColor = Color.Black;
                passTextBox.Text = "";
                passTextBox.UseSystemPasswordChar = !étatMdp;
                vide = false;
            }
        }
        /// <summary>
        /// Méthode permettant de gérer la textBox du login du menu connexion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void passTextBox_Leave(object sender, EventArgs e)
        {
            if (passTextBox.Text.Length == 0)
            {
                passTextBox.ForeColor = Color.Gray;
                passTextBox.Text = "Mot de passe";
                passTextBox.UseSystemPasswordChar = false;
                vide = true;
            }
        }
        #endregion

        #region Buttons
        private void connexionButton_Click(object sender, EventArgs e)
        {
            string login = loginTextBox.Text;
            string mdp = passTextBox.Text;

            if(Requêtes.Connexion(login, mdp))
            {
                if (loginTextBox.Text.Equals("admin"))
                {
                    admin = true;
                } else
                {
                    LocaDisk.idAbo = Requêtes.RecupIdAbo(login, mdp);
                    this.DialogResult = DialogResult.OK;
                    LocaDisk.idAbo = Requêtes.RecupIdAbo(login, mdp);
                }
                this.DialogResult = DialogResult.OK;
            } else
            {
                MessageBox.Show("Combinaison login/mdp invalide !");
            }
        }

        private void inscriptionBouton_Click(object sender, EventArgs e)
        {
            Inscription inscription = new Inscription();
            if(inscription.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Votre compte a bien été créé !");
            }
        }
        #endregion

        private void voirMdp_CheckedChanged(object sender, EventArgs e)
        {
            étatMdp = !étatMdp;
            if (étatMdp)
            {
                voirMdp.BackgroundImage = mdpVisible;
                if(!vide) passTextBox.UseSystemPasswordChar = false;

            }
            else
            {
                voirMdp.BackgroundImage = mdpNonVisible;
                if (!vide) passTextBox.UseSystemPasswordChar = true;
            }
        }
    }
}
