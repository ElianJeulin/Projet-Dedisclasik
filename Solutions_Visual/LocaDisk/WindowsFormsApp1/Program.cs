using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool connexionRéussie = false;

            Connexion connexion = new Connexion();
            do
            {
                do
                {
                    if (connexion.ShowDialog() == DialogResult.OK)
                    {
                        if (connexion.admin)
                        {
                            Application.Run(new Admin());
                            connexionRéussie = true;
                            connexion.admin = false;
                        }
                        else
                        {
                            Application.Run(new LocaDisk());
                            connexionRéussie = true;
                        }
                    } else
                    {
                        return;
                    }
                } while (!connexionRéussie);
            } while (LocaDisk.deco);
        }
    }
}
