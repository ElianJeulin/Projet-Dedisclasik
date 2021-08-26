using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDev
{
    public partial class EMPRUNTER
    {
        public int prolongementMois()
        {
            DateTime date = DATE_RETOUR_ATTENDUE.AddMonths(1);

            return date.Month;
        }

        public int prolongementAnnée()
        {
            DateTime date = DATE_RETOUR_ATTENDUE.AddYears(1);

            return date.Year;
        }
    }
}
