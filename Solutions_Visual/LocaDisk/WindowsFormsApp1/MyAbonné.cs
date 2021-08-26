using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public partial class ABONNÉS
    {
        public override string ToString()
        {
            return NOM_ABONNÉ.Trim() + "/" + PRÉNOM_ABONNÉ.Trim() + "/" + LOGIN_ABONNÉ.Trim();
        }
    }
}
