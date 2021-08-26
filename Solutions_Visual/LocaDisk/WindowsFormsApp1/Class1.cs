using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Test18
    {
        public  MusiquePT2_CEntities baseMusique = new MusiquePT2_CEntities();
        public  bool verifLogin(string loginDemandé)
        {
            var reqVerif = from abonné in baseMusique.ABONNÉS
                           where abonné.LOGIN_ABONNÉ.Trim() == loginDemandé
                           select abonné.LOGIN_ABONNÉ.Trim();

            bool valide = true;
            foreach (string login in reqVerif)
            {
                if (login.Equals(loginDemandé))
                {
                    valide = false;
                }
            }

            return valide;
        }

    }
}
