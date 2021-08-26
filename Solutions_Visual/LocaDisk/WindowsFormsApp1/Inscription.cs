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
    public partial class Inscription : Form
    {
        Bitmap mdpVisible = WindowsFormsApp1.Properties.Resources.open_eye_icon;
        Bitmap mdpNonVisible = WindowsFormsApp1.Properties.Resources.close_eye_logo;
        bool étatMdp = false;
        bool étatConfirmation = false;
        public Inscription()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            listePays.Items.AddRange(Requêtes.ListePays());
        }

        #region Gestion des cliques 

        /// <summary>
        /// Méthode gérant le bouton d'inscription
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inscriptionButton_Click(object sender, EventArgs e)
        {
            List<String> infos = new List<string>();

            infos.Add(nomTextBox.Text);
            infos.Add(prenomTextBox.Text);
            infos.Add(loginTextBox.Text);
            infos.Add(passTextBox.Text);

            if (RemplissageChamps(infos))
            {
                MessageBox.Show("Veuillez remplir tous les champs !");
            }
            else
            {
                ABONNÉS ord = TestInformations(infos);
                Requêtes.NouvelAbonné(ord);
                this.DialogResult = DialogResult.OK;
            }
        }
        #endregion

        #region Vérification des informations 


        /// <summary>
        /// Méthode qui vérifie le remplissage des champs lors de l'inscription
        /// </summary>
        /// <returns> Retourne vrai si les champs d'inscription sont correctement remplis</returns>
        public bool RemplissageChamps(List<string> infos)
        {
            return (infos[0].Trim() == "" || infos[1].Trim() == "" || infos[2].Trim() == "" || infos[3].Trim() == "");
        }


        /// <summary>
        /// Méthode qui crée un abonné en fonction des informations qui lui sont donnés 
        /// </summary>
        /// <returns> L'abonné crée</returns>
        public ABONNÉS TestInformations(List<string> infos)
        {
            ABONNÉS ord = null;
            if (listePays.SelectedItem != null)
            {
                int codePays = Requêtes.CodePays(listePays.SelectedItem.ToString());
                ord = new ABONNÉS
                {
                    CODE_PAYS = codePays,
                    NOM_ABONNÉ = infos[0],
                    PRÉNOM_ABONNÉ = infos[1],
                    LOGIN_ABONNÉ = infos[2],
                    PASSWORD_ABONNÉ = infos[3]
                };
            }
            else
            {
                ord = new ABONNÉS
                {
                    CODE_PAYS = null,
                    NOM_ABONNÉ = infos[0],
                    PRÉNOM_ABONNÉ = infos[1],
                    LOGIN_ABONNÉ = infos[2],
                    PASSWORD_ABONNÉ = infos[3]
                };
            }
            return ord;
        }
        #endregion

        #region Connexion 

        /// <summary>
        /// Méthode qui gère la connexion 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loginTextBox_Leave(object sender, EventArgs e)
        {
            if (!Requêtes.VerifLogin(loginTextBox.Text))
            {
                verifLoginLabel.Visible = true;
                inscriptionButton.Enabled = false;
            }
            else
            {
                verifLoginLabel.Visible = false;
                inscriptionButton.Enabled = true;
            }
        }

        private void confirmTextBox_Leave(object sender, EventArgs e)
        {
            labelPass.Visible = passTextBox.Text != confirmTextBox.Text;
            if(inscriptionButton.Enabled) inscriptionButton.Enabled = passTextBox.Text == confirmTextBox.Text;
        }

        private void voirMdp_CheckedChanged(object sender, EventArgs e)
        {
            étatMdp = !étatMdp;
            if (étatMdp)
            {
                voirMdp.BackgroundImage = mdpVisible;
                passTextBox.UseSystemPasswordChar = false;

            }
            else
            {
                voirMdp.BackgroundImage = mdpNonVisible;
                passTextBox.UseSystemPasswordChar = true;
            }
        }

        private void voirConfirmation_CheckedChanged(object sender, EventArgs e)
        {
            étatConfirmation = !étatConfirmation;
            if (étatConfirmation)
            {
                voirConfirmation.BackgroundImage = mdpVisible;
                confirmTextBox.UseSystemPasswordChar = false;
            }
            else
            {
                voirConfirmation.BackgroundImage = mdpNonVisible;
                confirmTextBox.UseSystemPasswordChar = true;
            }
        }
        #endregion

        
    }
}
