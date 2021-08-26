using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Requêtes
    {
        public static MusiquePT2_CEntities baseMusique = new MusiquePT2_CEntities();

        #region Requête Inscription abonné
        /// <summary>
        /// Requête permettant de tester la connexion d'un abonné en prenant en paramètre ses entrées pour le mot de passe et le login
        /// <paramref name="login"/ le login>
        /// <paramref name="mdp"/ le mot de passe>
        /// return un boolean permettant de savoir si la connexion est refusée ou non
        /// </summary>
        public static bool Connexion(string login, string mdp)
        {
            var connexionRequest = from abonné in baseMusique.ABONNÉS
                                   where abonné.LOGIN_ABONNÉ == login && abonné.PASSWORD_ABONNÉ == mdp
                                   select abonné;
            bool valide = false;
            foreach (ABONNÉS abo in connexionRequest)
            {
                if (abo.LOGIN_ABONNÉ.Trim().Equals(login) && abo.PASSWORD_ABONNÉ.Trim().Equals(mdp))
                {
                    valide = true;
                }
            }
            return valide;
        }

        /// <summary>
        /// Requête permettant de récupérer l'ID d'un abonné en fonction de son mot de passe et son login
        /// <paramref name="login"/ le login>
        /// <paramref name="mdp"/ le mot de passe>
        /// return un int correspondant à son code abonné
        /// </summary>
        public static int RecupIdAbo(string login, string mdp)
        {
            var reqRecup = from abonné in baseMusique.ABONNÉS
                           where abonné.LOGIN_ABONNÉ == login && abonné.PASSWORD_ABONNÉ == mdp
                           select abonné.CODE_ABONNÉ;

            return reqRecup.FirstOrDefault();
        }

        /// <summary>
        /// Requête permettant d'avoir tout les noms des pays de la base dans un tableau de string
        /// return tout les noms des pays dans un tableau
        /// </summary>
        public static string[] ListePays()
        {
            var nomPays = from pays in baseMusique.PAYS
                          select pays.NOM_PAYS;
            return nomPays.ToArray();
        }

        /// <summary>
        /// Requête permettant de trouvé le code pays associé au nom du pays
        /// <paramref name="paysChoisis"/ le nom du pays>
        /// return un int correspondant au numéro du pays
        /// </summary>
        public static int CodePays(string paysChoisis)
        {
            var reqPays = from pays in baseMusique.PAYS
                          where pays.NOM_PAYS.Trim() == paysChoisis.Trim()
                          select pays.CODE_PAYS;

            return reqPays.FirstOrDefault();
        }

        /// <summary>
        /// Requête permettant de vérifier si le login choisi n'est pas déjà présent dans la base
        /// <paramref name="loginDemandé"/ le login en question>
        /// return un boolean permettant de savoir si le login demandé est déjà dans la base ou non
        /// </summary>
        public static bool VerifLogin(string loginDemandé)
        {
            var reqVerif = from abonné in baseMusique.ABONNÉS
                           where abonné.LOGIN_ABONNÉ.Trim() == loginDemandé
                           select abonné.LOGIN_ABONNÉ.Trim();

            bool valide = true;
            foreach (string login in reqVerif)
            {
                if (login.Equals(loginDemandé)) {
                    valide = false;
                }
            }
            return valide;
        }

        /// <summary>
        /// Requête permettant d'ajouté un abonné à la base
        /// <paramref name="abonne"/ l'abonné que l'on veut ajouter>
        /// </summary>
        public static void NouvelAbonné(ABONNÉS abonne)
        {
            Inscription ins = new Inscription();
            List<String> infos = new List<string>();
            infos.Add(abonne.NOM_ABONNÉ); infos.Add(abonne.PRÉNOM_ABONNÉ); infos.Add(abonne.LOGIN_ABONNÉ); infos.Add(abonne.PASSWORD_ABONNÉ);

            if (Requêtes.VerifLogin(abonne.LOGIN_ABONNÉ) && !ins.RemplissageChamps(infos))
            {
                baseMusique.ABONNÉS.Add(abonne);
                baseMusique.SaveChanges();
            }      
        }
        #endregion

        #region Requête pour les Albums
        /// <summary>
        /// Requête permettant de charger le top dix des albums présent dans la base dans l'année
        /// return un tableau de string avec les 10 albums les plus emprentés
        /// </summary>
        public static ALBUMS[] ChargerTopAlbums()
        {
            var req = (from topAlbum in baseMusique.EMPRUNTER
                      join album in baseMusique.ALBUMS on topAlbum.CODE_ALBUM equals album.CODE_ALBUM
                      group topAlbum by new { topAlbum.CODE_ALBUM, album.TITRE_ALBUM } into tAlbum
                      orderby tAlbum.Count<EMPRUNTER>() descending
                      select tAlbum.Key.TITRE_ALBUM).Take(10);
            List<string> listeTitreAlbums = req.ToList();

            var req2 = from album in baseMusique.ALBUMS
                       join titreAlbum in listeTitreAlbums on album.TITRE_ALBUM equals titreAlbum
                       select album;

            return req2.ToArray();
        }

        /// <summary>
        /// Requête permettant de lister tout les abonnés
        /// return un tableau d'abonné
        /// </summary>
        public static ABONNÉS[] ListeToutAbonné()
        {
            var req = from abonné in baseMusique.ABONNÉS
                      orderby abonné.NOM_ABONNÉ
                      select abonné;
            return req.ToArray();
        }        

        /// <summary>
        /// Requête permettant de lister les albums par genre
        /// <paramref name="codePremierGenre"/ un genre>
        /// return un tableau de string correspondant au code genre entré en paramètres
        /// </summary>
        public static ALBUMS[] ListeAlbumParGenre(int codePremierGenre)
        {
            var req = from genre in baseMusique.GENRES
                      join album in baseMusique.ALBUMS on genre.CODE_GENRE equals album.CODE_GENRE
                      where genre.CODE_GENRE == codePremierGenre
                      select album;

            return req.ToArray();
        }

        /// <summary>
        /// Requête permettant de trouver tout les albums par rapport à son titre
        /// <paramref name="titre"/ le titre de l'album>
        /// return un tableau d'album correspondant au titre rentré en paramètre
        /// </summary>
        public static ALBUMS[] RechercheAlbum(string titre)
        {
            var reqRecherche = from album in baseMusique.ALBUMS
                               where album.TITRE_ALBUM.Contains(titre)
                               select album;

            return reqRecherche.ToArray();
        }

        /// <summary>
        /// Requête permettant de trouver un album par rapport à son titre
        /// </summary>
        /// <param name="titre"></param>
        /// <returns></returns>
        public static ALBUMS emprunterAlbumTitre(string titre)
        {
            var reqRecherche = from album in baseMusique.ALBUMS
                               where album.TITRE_ALBUM.Contains(titre)
                               select album;

            return reqRecherche.FirstOrDefault();
        }

        /// <summary>
        /// Requête permettant de de lister tout les albums non empruntés
        /// </summary>
        /// <returns>un tableau d'album</returns>
        public static ALBUMS[] listeAlbumNonEmprunte()
        {
            int compteur = 0;
            DateTime dateActuelle = DateTime.Now;
            var req = from emprunt in baseMusique.EMPRUNTER
                      select emprunt;

            List<ALBUMS> titres = new List<ALBUMS>();
            foreach (EMPRUNTER emprunt in req)
            {
                if (dateActuelle > emprunt.DATE_EMPRUNT.AddYears(1))
                {
                    var req2 = from album in baseMusique.ALBUMS
                               where album.CODE_ALBUM == emprunt.CODE_ALBUM
                               select album;

                    foreach (ALBUMS album in req2.Distinct())
                    {
                        titres.Add(album);
                        compteur++;
                    }
                }
            }
            return titres.ToArray();
        }

        /// <summary>
        /// Requête permettant d'emprunter un album
        /// </summary>
        /// <param name="alb">l'album en question</param>
        /// <param name="idAbo">l'ID de l'abonné</param>
        /// <returns></returns>
        private static EMPRUNTER EmprunterAlbum(ALBUMS alb, int idAbo)
        {
            GENRES genre = Requêtes.GenreAlbum(alb);

            EMPRUNTER emprunt = new EMPRUNTER
            {
                CODE_ABONNÉ = idAbo,
                CODE_ALBUM = alb.CODE_ALBUM,
                DATE_EMPRUNT = DateTime.Now,
                DATE_RETOUR_ATTENDUE = DateTime.Now.AddDays(genre.DÉLAI),
                DATE_RETOUR = null
            };

            return emprunt;
        }
        #endregion

        #region Requête Genre Album
        /// <summary>
        /// Requête permettant de trouver le genre préféré d'un abonné
        /// <paramref name="idAbo"/ l'ID de l'abonné>
        /// return un int correspondant au code du genre en question
        /// </summary>
        public static int GenrePréféré(int idAbo)
        {
            var req = from abonné in baseMusique.ABONNÉS
                      join emprunt in baseMusique.EMPRUNTER on abonné.CODE_ABONNÉ equals emprunt.CODE_ABONNÉ
                      join album in baseMusique.ALBUMS on emprunt.CODE_ALBUM equals album.CODE_ALBUM
                      join genre in baseMusique.GENRES on album.CODE_GENRE equals genre.CODE_GENRE
                      where abonné.CODE_ABONNÉ == idAbo
                      group genre by new { genre.CODE_GENRE } into genreAlbum
                      orderby genreAlbum.Count<GENRES>() descending
                      select genreAlbum.Key.CODE_GENRE;

            return req.FirstOrDefault();
        }

        /// <summary>
        /// Requête permettant de trouver le genre d'un album
        /// <paramref name="album"/ l'album dont on veut savoir le genre>
        /// return le genre de l'album
        /// </summary>
        public static GENRES GenreAlbum(ALBUMS album)
        {
            var req = from genre in baseMusique.GENRES
                      join alb in baseMusique.ALBUMS on genre.CODE_GENRE equals album.CODE_GENRE
                      where alb.CODE_ALBUM == album.CODE_ALBUM
                      select genre;
            return req.FirstOrDefault();
        }
        #endregion

        #region Requête Emprunt
        /// <summary>
        /// Requête permettant de voir tout les emprunts d'un abonné
        /// <paramref name="idAbo"/ l'ID de l'abonné>
        /// return un tableau de string correspondant à tout les titres des albums empruntés par l'abonné
        /// </summary>
        public static ALBUMS[] ChargerEmprunts(int idAbo)
        {
            var reqEmprunts = from album in baseMusique.ALBUMS
                              join emprunt in baseMusique.EMPRUNTER on album.CODE_ALBUM equals emprunt.CODE_ALBUM
                              join abonné in baseMusique.ABONNÉS on emprunt.CODE_ABONNÉ equals abonné.CODE_ABONNÉ
                              where abonné.CODE_ABONNÉ == idAbo
                              orderby emprunt.DATE_EMPRUNT descending
                              select album;

            return reqEmprunts.ToArray();
        }

        /// <summary>
        /// Requête permettant d'emprunter un vinyle
        /// </summary>
        /// <param name="album"> L'album en question </param>
        /// <param name="idAbo"> l'ID de l'abonné</param>
        public static void EmprunterVinyle(ALBUMS album, int idAbo)
        {
            EMPRUNTER emprunt = EmprunterAlbum(album, idAbo);
            EMPRUNTER emprunté = TrouverEmprunts(album.TITRE_ALBUM, idAbo);
            
            if (emprunté == null)
            {
                baseMusique.EMPRUNTER.Add(emprunt);
                baseMusique.SaveChanges();
            }
            else
            {
                baseMusique.EMPRUNTER.Remove(emprunté);
                baseMusique.SaveChanges();
                emprunt.DATE_EMPRUNT = DateTime.Now;
                GENRES delai = album.GENRES;
                emprunt.DATE_RETOUR_ATTENDUE = DateTime.Now.AddDays(delai.DÉLAI);
                emprunt.DATE_RETOUR = null;
                baseMusique.EMPRUNTER.Add(emprunt);
                baseMusique.SaveChanges();
            }
            
        }
        
        /// <summary>
        /// Requête permettant de rendre un emprunt
        /// </summary>
        /// <param name="emprunt">L'emprunt en question</param>
        public static void RendreEmprunt(EMPRUNTER emprunt)
        {
            LocaDisk acc = new LocaDisk();
            if (!acc.DejaRendu(emprunt))
                emprunt.DATE_RETOUR = DateTime.Now;
            Requêtes.baseMusique.SaveChanges();
        }

        /// <summary>
        /// Requête permettant de charger une image
        /// <paramref name="titres"/ le nom des albums avec lesquelles il faut charger la pochette>
        /// return une list de bytes
        /// </summary>
        public static List<byte[]> ChargerImages(string[] titres)
        {
            List<byte[]> pochettes = new List<byte[]>();

            foreach (string titre in titres)
            {
                var req = from album in baseMusique.ALBUMS
                          where album.TITRE_ALBUM.Trim() == titre && album.POCHETTE != null
                          select album.POCHETTE;

                pochettes.Add(req.FirstOrDefault());
            }
            return pochettes;
        }

        /// <summary>
        /// Requête permettant de lister tout les emprunts de chaque abonné
        /// return un tableau d'emprunt
        /// </summary>
        public static EMPRUNTER[] ListeToutEmprunt()
        {
            var requete = from emprunt in baseMusique.EMPRUNTER
                          join album in baseMusique.ALBUMS on emprunt.CODE_ALBUM equals album.CODE_ALBUM
                          join genre in baseMusique.GENRES on album.CODE_GENRE equals genre.CODE_GENRE
                          select emprunt;

            return requete.ToArray();
        }

        /// <summary>
        /// Requette permettant de récupérer les emprunts en fonction d'un casier 
        /// </summary>
        /// <param name="numeroCasier">numéro du casier</param>
        /// <returns>Un tableau d'emprunts</returns>
        public static EMPRUNTER[] ListeEmpruntParCasier(int numeroCasier)
        {
            var requete = from emprunt in baseMusique.EMPRUNTER
                          join album in baseMusique.ALBUMS on emprunt.CODE_ALBUM equals album.CODE_ALBUM
                          where album.CASIER_ALBUM == numeroCasier
                          select emprunt;

            return requete.ToArray();
        }

        /// <summary>
        /// Requête permettant de lister les emprunts non rendus
        /// return un tableau d'emprunt
        /// </summary>
        public static EMPRUNTER[] ListeEmpruntNonRendu()
        {
            var req = from abonné in baseMusique.ABONNÉS
                      join emprunt in baseMusique.EMPRUNTER on abonné.CODE_ABONNÉ equals emprunt.CODE_ABONNÉ
                      where emprunt.DATE_RETOUR == null
                      select emprunt;

            return req.ToArray();
        }

        /// <summary>
        /// Requête permettant de lister tout les emprunts rendus
        /// <paramref name="idAbo"/ l'ID de l'abonné>
        /// return un tableau d'emprunt
        /// </summary>
        public static EMPRUNTER[] ListeEmpruntRendu(int idAbo)
        {
            var req = from abonné in baseMusique.ABONNÉS
                      join emprunt in baseMusique.EMPRUNTER on abonné.CODE_ABONNÉ equals emprunt.CODE_ABONNÉ
                      where emprunt.DATE_RETOUR != null && emprunt.CODE_ABONNÉ == idAbo
                      select emprunt;

            return req.ToArray();
        }

       
        /// <summary>
        /// Requête permettant de vérifier si un prolongement est possible
        /// <paramref name="titre"/ le titre de l'album>
        /// <paramref name="idAbo"/ l'ID de l'abonné>
        /// return un boolean permettant de savoir si le prolongement d'un emprunt est possible ou non
        /// </summary>
        public static bool VerificationProlongementPossible(string titre, int idAbo)
        {
            var dateRetour = from emprunt in baseMusique.EMPRUNTER
                             join abonné in baseMusique.ABONNÉS on emprunt.CODE_ABONNÉ equals abonné.CODE_ABONNÉ
                             join album in baseMusique.ALBUMS on emprunt.CODE_ALBUM equals album.CODE_ALBUM
                             join genre in baseMusique.GENRES on album.CODE_GENRE equals genre.CODE_GENRE
                             where abonné.CODE_ABONNÉ == idAbo && album.TITRE_ALBUM.Trim().Contains(titre.Trim())
                             select emprunt;
            EMPRUNTER empruntAProlonger = dateRetour.First();

            return empruntAProlonger.DATE_RETOUR_ATTENDUE == empruntAProlonger.DATE_EMPRUNT.AddDays(empruntAProlonger.ALBUMS.GENRES.DÉLAI);
        }

        /// <summary>
        /// Requête permettant de trouver un album précis dans les emprunts d'un abonné
        /// <paramref name="titre"/ le titre de l'album>
        /// <paramref name="idAbo"/ l'ID de l'abonné>
        /// return un emprunt correspondant au titre donné et l'abonné voulu
        /// </summary>
        public static EMPRUNTER TrouverDansMesEmprunts(string titre, int idAbo)
        {
            var reqEmprunt = from emprunt in baseMusique.EMPRUNTER
                             join abonné in baseMusique.ABONNÉS on emprunt.CODE_ABONNÉ equals abonné.CODE_ABONNÉ
                             join album in baseMusique.ALBUMS on emprunt.CODE_ALBUM equals album.CODE_ALBUM
                             join genre in baseMusique.GENRES on album.CODE_GENRE equals genre.CODE_GENRE
                             where abonné.CODE_ABONNÉ == idAbo && album.TITRE_ALBUM.Trim().Contains(titre.Trim()) && emprunt.DATE_RETOUR == null
                             select emprunt;

            return reqEmprunt.FirstOrDefault();
        }

        /// <summary>
        /// Requête permettant de trouver un album précis dans les emprunts d'un abonné
        /// <paramref name="titre"/ le titre de l'album>
        /// <paramref name="idAbo"/ l'ID de l'abonné>
        /// return un emprunt correspondant au titre donné et l'abonné voulu
        /// </summary>
        public static EMPRUNTER TrouverEmprunts(string titre, int idAbo)
        {
            var reqEmprunt = from emprunt in baseMusique.EMPRUNTER
                             join abonné in baseMusique.ABONNÉS on emprunt.CODE_ABONNÉ equals abonné.CODE_ABONNÉ
                             join album in baseMusique.ALBUMS on emprunt.CODE_ALBUM equals album.CODE_ALBUM
                             join genre in baseMusique.GENRES on album.CODE_GENRE equals genre.CODE_GENRE
                             where abonné.CODE_ABONNÉ == idAbo && album.TITRE_ALBUM.Trim().Contains(titre.Trim()) 
                             select emprunt;

            return reqEmprunt.FirstOrDefault();
        }

        /// <summary>
        /// Requête permettant de selectionner un vinyle
        /// <paramref name="idAbo"/ l'ID de l'abonné>
        /// <paramref name="titre"/ titre de l'album>
        /// return un emprunt correspondant au titre du vinyle
        /// </summary>
        public static EMPRUNTER VinyleSelectionné(string titre, int idAbo)
        {
            var empruntRetour = from emprunt in baseMusique.EMPRUNTER
                                join abonné in baseMusique.ABONNÉS on emprunt.CODE_ABONNÉ equals abonné.CODE_ABONNÉ
                                join album in baseMusique.ALBUMS on emprunt.CODE_ALBUM equals album.CODE_ALBUM
                                where abonné.CODE_ABONNÉ == idAbo && album.TITRE_ALBUM.Contains(titre)
                                select emprunt;

            return empruntRetour.FirstOrDefault();
        }
        #endregion

        #region Requête Abonné
        /// <summary>
        /// Requête permettant de purger tout les abonnées n'ayant pas emprunté depuis plus d'un an
        /// return le nombre d'abonné ayant été purgé
        /// </summary>
        public static int Purge()
        {
            int count = 0;
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
                    count++;
                }
            }
            baseMusique.SaveChanges();
            return count;
        }
        #endregion

    }
}
