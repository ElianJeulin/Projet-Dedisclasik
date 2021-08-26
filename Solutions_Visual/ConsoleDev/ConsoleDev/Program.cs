using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleDev
{
    class Program
    {
        private static bool valide;
        private static int idAbo;
        private static string mdpAdmin = "123";
        static MusiquePT2_CEntities baseMusique;
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            baseMusique = new MusiquePT2_CEntities();
            Console.WriteLine("Bienvenue !");
            while (true)
            {
                choixRole();
            }
                
        }

        #region Menus
        /// <summary>
        /// méthode permettant à l'utilisateur de choisir son rôle en entrant le numéro correspondant, ce qui va l'amener 
        /// jusqu'à une connexion ou une inscription au service demandé.
        /// </summary>
        public static void choixRole()
        {
            valide = false;
            string rep = null;
            Console.Clear();
            Console.WriteLine("Êtes vous : \n 1- Un administrateur \n 2- Un abonné \n 3- Un futur client");
            do
            {
                rep = Console.ReadLine();
                switch (rep.Trim())
                {
                    case "1":
                        connexionAdmin();
                        valide = true;
                        menuAdmin();
                        break;
                    case "2":
                        connexionAbo();
                        valide = true;
                        menuAbonné();
                        break;
                    case "3":
                        inscriptionAbonné(informationAbonné());
                        valide = true;
                        break;
                    default:
                        Console.WriteLine("Erreur lors du choix d'utilisateur");
                        break;
                }
            } while (!valide);
        }

        /// <summary>
        /// méthode permettant à l'utilisateur d'effectuer des taches d'administrateur en entrant le numéro correspondant à l'action 
        /// qu'il souhaite entreprendre, il peut aussi revenir au menu principal
        /// </summary> 
        public static void menuAdmin()
        {
            valide = false;
            Console.WriteLine("Menu Administrateur");
            do
            {
                Console.Clear();
                Console.WriteLine("Que voulez vous faire ? \n 1- Voir la liste des emprunts prolongés \n 2- Voir la liste des emprunts non rapportés (10 jours) \n 3- Purger les abonnés inactifs \n 4- Voir les albums les plus empruntés \n 5- Voir quels albums n'ont pas été empruntés depuis un an ou plus \n 6- Lister tous les abonnés \n 7- Déconnexion");
                string rep = Console.ReadLine();
                switch (rep.Trim())
                {
                    case "1":
                        listeEmpruntsProlonge();
                        valide = true;
                        break;
                    case "2":
                        listeRetards();
                        valide = true;
                        break;
                    case "3":
                        purge();
                        valide = true;
                        break;
                    case "4":
                        topAlbums(true);
                        valide = true;
                        break;
                    case "5":
                        listeAlbumNonEmprunte();
                        valide = true;
                        break;
                    case "6":
                        listerAbo();
                        valide = true;
                        break;
                    case "7":
                        choixRole();
                        valide = true;
                        break;
                    default:
                        Console.WriteLine("Erreur lors du choix");
                        break;
                }
                rep = Console.ReadLine();
                menuAdmin();
            }
            while (!valide);
        }

        /// <summary>
        /// méthode permettant à l'utilisateur d'effectuer des taches qu'un abonné peut faire en entrant le numéro correspondant à l'action 
        /// qu'il souhaite entreprendre, il peut aussi revenir au menu principal
        /// </summary>
        public static void menuAbonné()
        {
            valide = false;
            Console.WriteLine("Menu Abonné");
            do
            {
                Console.Clear();
                Console.WriteLine("Que voulez vous faire ? \n 1- Consulter mes emprunts \n 2- Prolonger un emprunt \n 3- Prolonger tous mes emprunts \n 4- Voir des suggestions \n 5- Emprunter un vinyle  \n 6- Rendre un vinyle \n 7- Déconnexion");
                string rep = Console.ReadLine();
                switch (rep)
                {
                    case "1":
                        forEachlistEmprunts(listEmprunts());
                        valide = true;
                        break;
                    case "2":
                        prolongerEmprunt(demandeUtilisateur("Veuillez entrer le nom de l'album à prolonger"));
                        valide = true;
                        break;
                    case "3":
                        prolongerTousEmprunts();
                        valide = true;
                        break;
                    case "4":
                        suggérerAlbum();
                        valide = true;
                        break;
                    case "5":
                        emprunterVinyle(demandeUtilisateur("Quel Album voulez vous emprunter ? "));
                        baseMusique.SaveChanges();
                        valide = true;    
                        break;
                    case "6":
                        rendreVinyle(demandeUtilisateur("Quel album voulez-vous rendre ?"));
                        valide = true;
                        break;
                    case "7":
                        choixRole();
                        valide = true;
                        break;
                   
                    default:
                        Console.WriteLine("Erreur lors du choix");
                        break;
                }
                rep = Console.ReadLine();
                menuAbonné();
            }
            while (!valide);
        }
        #endregion

        #region Abonné
        /// <summary>
        /// méthode permettant à un abonné de se connecter, il doit entrer un login et un mot de passe enregistrés au préalable, il accède au menu abonné si les informations correspondent.
        /// dans la base de donnée grâce à une inscription
        /// </summary>
        public static void connexionAbo()
        {
            bool loginExist = false;
            bool mdpCorrect = false;
            ABONNÉS abonne = null;


            while (!loginExist)
            {
                Console.WriteLine("Entrez votre login :");
                string login = Console.ReadLine();
                var re1 = from abo in baseMusique.ABONNÉS
                          where abo.LOGIN_ABONNÉ == login
                          select abo;
                if (re1.Any())
                {
                    loginExist = true;
                    abonne = re1.First();
                }
                else
                {
                    Console.WriteLine("Login invalide");
                }
            }
            string truemdp = abonne.PASSWORD_ABONNÉ.Trim();
            while (!mdpCorrect)
            {
                Console.WriteLine("Entrez votre Mot de passe :");
                string mdp = null;
                while (true)
                {
                    var key = System.Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter)
                        break;
                    mdp += key.KeyChar;
                }

                if (mdp.Equals(truemdp))
                {
                    mdpCorrect = true;
                }
                else
                {
                    Console.WriteLine("Mot de passe incorrect !");
                }
            }
            idAbo = abonne.CODE_ABONNÉ;
        }

        /// <summary>
        /// méthode permettant à un abonné de voir la liste complète des albums qu'il a emprunté mais pas encore rendu.
        /// </summary>
        public static List<string> listEmprunts()
        {
            var emprunts = from album in baseMusique.ALBUMS
                           join emprunt in baseMusique.EMPRUNTER on album.CODE_ALBUM equals emprunt.CODE_ALBUM
                           join abonné in baseMusique.ABONNÉS on emprunt.CODE_ABONNÉ equals abonné.CODE_ABONNÉ
                           where abonné.CODE_ABONNÉ == idAbo
                           select album.TITRE_ALBUM;
            return emprunts.ToList();
        }
        /// <summary>
        /// Méthode qui permet l'affichage des albums
        /// </summary>
        /// <param name="listeAffichage"> albums à afficher</param>
        public static void forEachlistEmprunts(List<string> listeAffichage) 
        {
            foreach (string album in listeAffichage)
            {
                affichage(album);
            }
        }
        /// <summary>
        /// Méthode d'affichage des albums
        /// </summary>
        /// <param name="album">albums à afficher</param>
        public static void affichage(string album)
        {
            Console.WriteLine(album.ToString());
        }



        /// <summary>
        /// méthode permettant à l'administrateur de lister les abonnés 
        /// </summary>
        public static void listerAbo()
        {
            var req = from abonné in baseMusique.ABONNÉS
                      select abonné;
            foreach (ABONNÉS abonné in req)
            {
                    Console.WriteLine( abonné.NOM_ABONNÉ.Trim() + " "+ abonné.PRÉNOM_ABONNÉ);
            }
        }

        public static List<string> listAbo()
        {
            List<string> listeDesAbos = new List<string>();
            var emprunts = from album in baseMusique.ALBUMS
                           join emprunt in baseMusique.EMPRUNTER on album.CODE_ALBUM equals emprunt.CODE_ALBUM
                           join abonné in baseMusique.ABONNÉS on emprunt.CODE_ABONNÉ equals abonné.CODE_ABONNÉ
                           where abonné.CODE_ABONNÉ == idAbo
                           select album.TITRE_ALBUM;
            return emprunts.ToList();
        }



        public static string demandeUtilisateur(string message)
        {
            Console.WriteLine(message);
            string entrée = Console.ReadLine();
            return entrée;
        }


        /// <summary>
        /// méthode permettant à un abonné d'emprunter un vinyle.
        /// </summary>
        public static void emprunterVinyle(string entree)
        {     
            bool memeVinyle;

            var req = from album in baseMusique.ALBUMS
                      select album;

            var mesEmprunts = from abonne in baseMusique.ABONNÉS
                      join emprunt in baseMusique.EMPRUNTER on abonne.CODE_ABONNÉ equals emprunt.CODE_ABONNÉ
                      join album in baseMusique.ALBUMS on emprunt.CODE_ALBUM equals album.CODE_ALBUM
                      where abonne.CODE_ABONNÉ == idAbo
                      select album;

            foreach (ALBUMS album in req)
            {
                memeVinyle = false;

                foreach (ALBUMS emprunt in mesEmprunts)
                {
                    if (emprunt.TITRE_ALBUM.Equals(album.TITRE_ALBUM))
                    {
                        memeVinyle = true;
                    }
                }

                if (album.TITRE_ALBUM.Contains(entree) && !memeVinyle)
                {
                    if (Confirmation("Voulez-vous emprunter: " + album.TITRE_ALBUM.Trim() + "? (y/n)"))
                    {
                        var req2 = from genre in baseMusique.GENRES
                                   join alb in baseMusique.ALBUMS on genre.CODE_GENRE equals album.CODE_GENRE
                                   where alb.CODE_ALBUM == album.CODE_ALBUM
                                   select genre;

                        EMPRUNTER emprunt = new EMPRUNTER
                        {
                            CODE_ABONNÉ = idAbo,
                            CODE_ALBUM = album.CODE_ALBUM,
                            DATE_EMPRUNT = System.DateTime.Now,
                            DATE_RETOUR_ATTENDUE = System.DateTime.Now.AddDays(req2.First().DÉLAI),
                            DATE_RETOUR = null
                        };
                        baseMusique.EMPRUNTER.Add(emprunt);
                        Console.WriteLine("L'album : " + album.TITRE_ALBUM.Trim() + " a bien été emprunté.");
                        Console.Read();
                        return;
                    }
                }
            }
        }

        public List<ALBUMS> GetAllAlbum()
        {
            var req = from album in baseMusique.ALBUMS
                      select album;

            return req.ToList();
        }

        public ALBUMS GetByCodeAlbum(int id)
        {
            var req = from album in baseMusique.ALBUMS
                      where album.CODE_ALBUM == id
                      select album;

            return req.FirstOrDefault();
        }

        /// <summary>
        /// Méthode permettant à un abonné de rendre un vinyle.
        /// </summary>
        public static void rendreVinyle(string retour)
        {
            EMPRUNTER albumARendre = null;
            var empruntRetour = from emprunt2 in baseMusique.EMPRUNTER
                                join abonné in baseMusique.ABONNÉS on emprunt2.CODE_ABONNÉ equals abonné.CODE_ABONNÉ
                                join album2 in baseMusique.ALBUMS on emprunt2.CODE_ALBUM equals album2.CODE_ALBUM
                                join genre in baseMusique.GENRES on album2.CODE_GENRE equals genre.CODE_GENRE
                                where abonné.CODE_ABONNÉ == idAbo && album2.TITRE_ALBUM.Contains(retour)
                                select emprunt2;

            foreach (EMPRUNTER mesEmprunts in empruntRetour)
            {
                if (Confirmation("Voulez-vous rendre cet album: " + mesEmprunts.ALBUMS.TITRE_ALBUM.Trim() + "? (y/n)"))
                {
                    albumARendre = mesEmprunts;
                    break;
                }
            }
            if (albumARendre != null)
            {
                if (albumARendre.DATE_RETOUR != null)
                {
                    Console.WriteLine("Cet album a déjà été rendu");
                }
                else
                {
                    albumARendre.DATE_RETOUR = System.DateTime.Now;
                    Console.WriteLine("Votre emprunt a bien été rendu");
                }
                baseMusique.SaveChanges();
            }

        }

        /// <summary>
        /// méthode permettant de confirmer un message.
        /// </summary>
        public static bool Confirmation(string message)
        {
            Console.WriteLine(message);
            string reponse = Console.ReadLine().ToUpper();
            if (reponse.Equals("Y"))
                return true;
            return false;
        }

        /// <summary>
        /// méthode permettant à un abonné de prolonger l'emprunt d'un album, il ne peut effectuer cette action que si l'album n'a pas déjà été prolongé par cet abonné.
        /// </summary>
        public static void prolongerEmprunt(string rep)
        {
            forEachlistEmprunts(listEmprunts());
            EMPRUNTER albumAProlonger = null;
            

            var dateRetour = from emprunt in baseMusique.EMPRUNTER
                             join abonné in baseMusique.ABONNÉS on emprunt.CODE_ABONNÉ equals abonné.CODE_ABONNÉ
                             join album in baseMusique.ALBUMS on emprunt.CODE_ALBUM equals album.CODE_ALBUM
                             join genre in baseMusique.GENRES on album.CODE_GENRE equals genre.CODE_GENRE
                             where abonné.CODE_ABONNÉ == idAbo && album.TITRE_ALBUM.Contains(rep)
                             select emprunt;

            foreach (EMPRUNTER emprunter in dateRetour)
            {
                if (Confirmation("Voulez-vous prolonger cet album: " + emprunter.ALBUMS.TITRE_ALBUM.Trim() + "? (y/n)"))
                {
                    albumAProlonger = emprunter;
                    break;
                }
            }

            var delai = from album in baseMusique.ALBUMS
                        join genre in baseMusique.GENRES on album.CODE_GENRE equals genre.CODE_GENRE
                        where album.TITRE_ALBUM.Equals(albumAProlonger.ALBUMS.TITRE_ALBUM)
                        select genre.DÉLAI;

            if (albumAProlonger != null)
            {
                if (albumAProlonger.DATE_RETOUR_ATTENDUE > albumAProlonger.DATE_EMPRUNT.AddDays(delai.First()))
                {
                    Console.WriteLine("Vous avez déjà prolongé la location. Action impossible.");
                }
                else
                {
                    int mois = albumAProlonger.prolongementMois();
                    if (mois == 1)
                    {
                        albumAProlonger.DATE_RETOUR_ATTENDUE = new DateTime(albumAProlonger.prolongementAnnée(),
                                                                    albumAProlonger.prolongementMois(),
                                                                    albumAProlonger.DATE_RETOUR_ATTENDUE.Day,
                                                                    albumAProlonger.DATE_RETOUR_ATTENDUE.Hour,
                                                                    albumAProlonger.DATE_RETOUR_ATTENDUE.Minute,
                                                                    albumAProlonger.DATE_RETOUR_ATTENDUE.Second);
                    }
                    else
                    {
                        albumAProlonger.DATE_RETOUR_ATTENDUE = new DateTime(albumAProlonger.DATE_RETOUR_ATTENDUE.Year,
                                                    albumAProlonger.prolongementMois(),
                                                    albumAProlonger.DATE_RETOUR_ATTENDUE.Day,
                                                    albumAProlonger.DATE_RETOUR_ATTENDUE.Hour,
                                                    albumAProlonger.DATE_RETOUR_ATTENDUE.Minute,
                                                    albumAProlonger.DATE_RETOUR_ATTENDUE.Second);
                    }
                }
                Console.WriteLine("Votre emprunt à bien était prolongé sur l'album " + albumAProlonger.ALBUMS.TITRE_ALBUM);
                baseMusique.SaveChanges();
            }
        }


        /// <summary>
        /// Méthode permettant à un abonné de prolonger l'emprunt de tout ses albums empruntés.
        /// </summary>
        public static void prolongerTousEmprunts()
        {
            var req1 = from emprunt in baseMusique.EMPRUNTER
                       where emprunt.CODE_ABONNÉ == idAbo
                       select emprunt;

            foreach (var emprunts in req1)
            {
                var delai = from album in baseMusique.ALBUMS
                            join genre in baseMusique.GENRES on album.CODE_GENRE equals genre.CODE_GENRE
                            where album.TITRE_ALBUM.Equals(emprunts.ALBUMS.TITRE_ALBUM)
                            select genre.DÉLAI;
                try
                {
                    if (emprunts.DATE_RETOUR_ATTENDUE > emprunts.DATE_EMPRUNT.AddDays(delai.First()))
                    {
                        Console.WriteLine("Vous avez déjà prolongé la location " + emprunts.ALBUMS.TITRE_ALBUM.Trim() +". Action impossible.");
                    }
                    else
                    {
                        int mois = emprunts.prolongementMois();
                        if (mois == 1)
                        {
                            emprunts.DATE_RETOUR_ATTENDUE = new DateTime(emprunts.prolongementAnnée(),
                                                                        emprunts.prolongementMois(),
                                                                        emprunts.DATE_RETOUR_ATTENDUE.Day,
                                                                        emprunts.DATE_RETOUR_ATTENDUE.Hour,
                                                                        emprunts.DATE_RETOUR_ATTENDUE.Minute,
                                                                        emprunts.DATE_RETOUR_ATTENDUE.Second);
                        }
                        else
                        {
                            emprunts.DATE_RETOUR_ATTENDUE = new DateTime(emprunts.DATE_RETOUR_ATTENDUE.Year,
                                                        emprunts.prolongementMois(),
                                                        emprunts.DATE_RETOUR_ATTENDUE.Day,
                                                        emprunts.DATE_RETOUR_ATTENDUE.Hour,
                                                        emprunts.DATE_RETOUR_ATTENDUE.Minute,
                                                        emprunts.DATE_RETOUR_ATTENDUE.Second);
                        }
                        Console.WriteLine(emprunts.ALBUMS.TITRE_ALBUM.Trim() + " a été prolongé d'un mois, sa nouvelle date de retour est : " + emprunts.DATE_RETOUR_ATTENDUE);
                    }
                }
                catch (System.InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            } 
            baseMusique.SaveChanges();  
        }

        public static string[] informationAbonné()
        {
            string[] listInfoDemande = new string[5];
            listInfoDemande[0] = "- Votre pays :";
            listInfoDemande[1] = "- Votre nom :";
            listInfoDemande[2] = "- Votre prénom :";
            listInfoDemande[3] = "- Votre login";
            listInfoDemande[4] = "- Votre mot de passe";
            string[] listInfo = new string[5];
            Console.WriteLine("Afin de créer votre compte, veuillez indiquer :");
            int index = 0;
            while (index < 5)
            {
                Console.WriteLine(listInfoDemande[index]);
                listInfo[index] = Console.ReadLine();
                if (listInfo[index].Length > 0)
                {
                    index++;
                }
                else
                {
                    Console.WriteLine("Veuillez rentrer une information");
                }
            }

            return listInfo;
        }

        /// <summary>
        /// Méthode permettant à un non-abonné de le devenir, il doit pour cela introduire ses informations et si son login ou 
        /// son mot de passe sont déjà inscrits alors l'action n'est pas validée et il doit les réinscrire
        /// </summary>
        public static void inscriptionAbonné(string[] listInfo)
        {
            ABONNÉS ord = new ABONNÉS
            {
                CODE_PAYS = Int32.Parse(listInfo[0]),
                NOM_ABONNÉ = listInfo[1],
                PRÉNOM_ABONNÉ = listInfo[2],
                LOGIN_ABONNÉ = listInfo[3],
                PASSWORD_ABONNÉ = listInfo[4]
            };
            var req = from abo in baseMusique.ABONNÉS
                      where abo.LOGIN_ABONNÉ == ord.LOGIN_ABONNÉ
                      select abo;
            
           if (req.Count() > 0)
            {
                Console.WriteLine("Nom d'utilisateur déjà existant");
            }
            else
            {
                Console.WriteLine("Compte bien créé !");
                baseMusique.ABONNÉS.Add(ord);
                baseMusique.SaveChanges();
            }
        }


        /// <summary>
        /// Méthode permettant à un abonné de voir les albums qui lui sont suggérés en fonction du genre d'albums qu'il a emprunté,
        /// on lui affiche la liste des albums les plus empruntés de l'année s'il n'a pas de genre préféré
        /// </summary>
        public static void suggérerAlbum()
        {
            bool memeVinyle;

            var req = from abonné in baseMusique.ABONNÉS
                      join emprunt in baseMusique.EMPRUNTER on abonné.CODE_ABONNÉ equals emprunt.CODE_ABONNÉ
                      join album in baseMusique.ALBUMS on emprunt.CODE_ALBUM equals album.CODE_ALBUM
                      join genre in baseMusique.GENRES on album.CODE_GENRE equals genre.CODE_GENRE
                      where abonné.CODE_ABONNÉ == idAbo
                      group genre by new { genre.CODE_GENRE } into genreAlbum
                      orderby genreAlbum.Count<GENRES>() descending
                      select new { genreAlbum, compteur = genreAlbum.Count<GENRES>() };

            if (req.Count() != 0)
            {
                var premierGenre = req.First();

                var req2 = from genre in baseMusique.GENRES
                           join album in baseMusique.ALBUMS on genre.CODE_GENRE equals album.CODE_GENRE
                           where genre.CODE_GENRE == premierGenre.genreAlbum.Key.CODE_GENRE
                           select album;

                var mesEmprunts = from abo in baseMusique.ABONNÉS
                                  join emprunt in baseMusique.EMPRUNTER on abo.CODE_ABONNÉ equals emprunt.CODE_ABONNÉ
                                  join alb in baseMusique.ALBUMS on emprunt.CODE_ALBUM equals alb.CODE_ALBUM
                                  where abo.CODE_ABONNÉ == idAbo
                                  select alb;

                List < ALBUMS > albumsAAfficher = new List<ALBUMS>();
                foreach (ALBUMS album in req2)
                {
                    memeVinyle = false;
                    foreach (ALBUMS alb in mesEmprunts)
                        if (alb.TITRE_ALBUM.Equals(album.TITRE_ALBUM))
                            memeVinyle = true;
                    if(!memeVinyle)
                        albumsAAfficher.Add(album);
                }
                    
                Random numAléatoire = new Random();
                for (int i = 1; i < 11; i++)
                {
                    int num = numAléatoire.Next(albumsAAfficher.Count());
                    Console.WriteLine(i + "." + albumsAAfficher[num].TITRE_ALBUM);
                }

            }
            else
            {
                topAlbums(false);
            }
        }
        #endregion

        #region Administrateur
        /// <summary>
        /// méthode permettant à l'utilisteur de se connecter à l'interface administrateur, il doit pour cela entrer un mot de passe défini à l'avance, 
        /// il accède au menu administrateur si le mot de passe correspond.
        /// </summary>
        public static void connexionAdmin()
        {
            while (true)
            {
                Console.WriteLine("Entrez votre Mot de passe :");
                string mdp = "";
                while (true)
                {
                    var key = System.Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter)
                        break;
                    mdp += key.KeyChar;
                }

                
                if (mdp.Equals(mdpAdmin))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Mot de passe incorrect");
                }
            }
        }

        /// <summary>
        /// méthode permettant à l'administrateur de voir les albums qui ont été prolongés.
        /// </summary>
        public static void listeEmpruntsProlonge()
        {
            List<int> listeDelais = new List<int>();
            var dateemprunt = from emprunt in baseMusique.EMPRUNTER
                              join album in baseMusique.ALBUMS on emprunt.CODE_ALBUM equals album.CODE_ALBUM
                              join genre in baseMusique.GENRES on album.CODE_GENRE equals genre.CODE_GENRE
                              select genre.DÉLAI;

            foreach (var delais in dateemprunt)
            {
                listeDelais.Add(delais);
            }

            var requete = from emprunt in baseMusique.EMPRUNTER
                          join album in baseMusique.ALBUMS on emprunt.CODE_ALBUM equals album.CODE_ALBUM
                          join genre in baseMusique.GENRES on album.CODE_GENRE equals genre.CODE_GENRE
                          select emprunt;
            int x = 0;
            foreach (EMPRUNTER emprunt in requete)
            {
                if (emprunt.DATE_RETOUR_ATTENDUE > emprunt.DATE_EMPRUNT.AddDays(listeDelais.ElementAt<int>(x)))
                    Console.WriteLine(emprunt.ALBUMS.TITRE_ALBUM.Trim() + " a été prolongé par l'abonné " + emprunt.ABONNÉS.NOM_ABONNÉ.Trim() + " " + emprunt.ABONNÉS.PRÉNOM_ABONNÉ.Trim() + " à la date du " + emprunt.DATE_RETOUR_ATTENDUE + ".");
                x++;
            }
        }

        /// <summary>
        /// Méthode permettant à l'administrateur de voir quel abonné est en retard sur la date de rendu d'un album.
        /// </summary>
        public static void listeRetards()
        {
            Console.WriteLine("Liste des abonnés en retard sur leur rendu :");
            DateTime dateActuelle = DateTime.Now;
            var req = from abonné in baseMusique.ABONNÉS
                      join emprunt in baseMusique.EMPRUNTER on abonné.CODE_ABONNÉ equals emprunt.CODE_ABONNÉ
                      where emprunt.DATE_RETOUR == null
                      select emprunt;

            foreach (EMPRUNTER emprunt in req)
            {
                if (dateActuelle > emprunt.DATE_RETOUR_ATTENDUE.AddDays(10))
                {
                    Console.WriteLine("Monsieur " + emprunt.ABONNÉS.NOM_ABONNÉ.Trim() + " " + emprunt.ABONNÉS.PRÉNOM_ABONNÉ.Trim() + " est en retard de plus de 10 jours pour le vinyle " + emprunt.ALBUMS.TITRE_ALBUM + ".");
                }
            }
        }

        /// <summary>
        /// Méthode permettant à l'administrateur de supprimer les abonnés qui n'ont pas emprunté de livre depuis plus d'un an.
        /// </summary>
        public static void purge()
        {
            DateTime dateActuelle = DateTime.Now;
            var req = from abonné in baseMusique.ABONNÉS
                      select abonné;

            foreach (ABONNÉS abo in req)
            {
                var req2 = from emprunt in baseMusique.EMPRUNTER
                           where emprunt.CODE_ABONNÉ == abo.CODE_ABONNÉ
                           orderby emprunt.DATE_EMPRUNT descending
                           select emprunt;

                if (req2.Any() && req2.First().DATE_EMPRUNT.AddYears(1) < dateActuelle)
                {
                    baseMusique.ABONNÉS.Remove(abo);
                }
            }
            Console.WriteLine("Les abonnés inactifs ont bien étés purgés.");
            baseMusique.SaveChanges();
        }

        /// <summary>
        /// Méthode permettant à l'administrateur de voir les 10 albums les plus empruntés cette année.
        /// </summary>
        public static void topAlbums(bool admin)
        {
            Console.WriteLine("Top 10 des albums les plus vendus de l'année :");
            var req = from topAlbum in baseMusique.EMPRUNTER
                      join album in baseMusique.ALBUMS on topAlbum.CODE_ALBUM equals album.CODE_ALBUM
                      group topAlbum by new { topAlbum.CODE_ALBUM, album.TITRE_ALBUM } into tAlbum
                      orderby tAlbum.Count<EMPRUNTER>() descending
                      select new { tAlbum, cnt = tAlbum.Count<EMPRUNTER>() };
            int index = 1;
            foreach (var alb in req.Take(10))
            {
                Console.WriteLine(index + "- " + alb.tAlbum.Key.TITRE_ALBUM.Trim() + " (emprunté " + alb.cnt + " fois)");
                index++;
            }

            Console.Read();
            if (admin)
            {
                menuAdmin();
            }else
            {
                menuAbonné();
            }

        }

        /// <summary>
        /// Méthode permettant à l'administrateur de voir quels albums n'ont pas été empruntés depuis plus d'un an.
        /// </summary>
        public static void listeAlbumNonEmprunte()
        {
            Console.WriteLine("Liste des albums non empruntés depuis plus d'un an :");
            DateTime dateActuelle = DateTime.Now;
            var req = from emprunt in baseMusique.EMPRUNTER
                      select emprunt;

            foreach (EMPRUNTER emprunt in req)
            {
                if (dateActuelle > emprunt.DATE_EMPRUNT.AddYears(1))
                {
                    var req2 = from album in baseMusique.ALBUMS
                               where album.CODE_ALBUM == emprunt.CODE_ALBUM
                               select album;

                    foreach (ALBUMS album in req2.Distinct())
                    {
                        Console.WriteLine("L'album " + album.TITRE_ALBUM.Trim() + " n'a pas été emprunté depuis plus d'un an.");
                    }
                }
            }
        }
        #endregion
    }
}
