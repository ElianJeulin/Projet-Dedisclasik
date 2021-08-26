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
    public partial class ChoixRendreProlonger : Form
    {
        public ChoixRendreProlonger(string titre)
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            labelTitre.Text = "Souhaitez-vous prolonger ou rendre " + titre.Trim() + " ?";
        }

        private void ChoixRendreProlonger_Load(object sender, EventArgs e)
        {

        }
    }
}
