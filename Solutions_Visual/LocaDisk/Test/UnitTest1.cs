using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WindowsFormsApp1;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        #region Test Requête Générale
        
        [TestMethod]
        public void TestConnexion()
        {
            Assert.IsTrue(Requêtes.Connexion("test1", "test1"));//Connexion avec un compte enregistré
            Assert.IsFalse(Requêtes.Connexion("test", "test"));//Connexion avec un compte non enregistré

        }

        [TestMethod]
        public void TestInscription()
        {
            Assert.IsTrue(Requêtes.VerifLogin("test")); // Ce login est disponible car il n'est pas déjà enregistré
            Assert.IsFalse(Requêtes.VerifLogin("test1")); // Ce login est indisponible car pas déjà enregistré
        }

        [TestMethod]
        public void TestTopAlbum()
        {
            ALBUMS[] test = Requêtes.ChargerTopAlbums();
            Assert.AreEqual(10, test.Length); // Le top album contient 10 albums
            Assert.AreEqual("Bach, CPE: Concertos pour violoncelle", test[0].TITRE_ALBUM.Trim()); // L'album numéro 1 du top album est bien celui là       
        }

        
        [TestMethod]
        public void TestEmprunt()
        {
            ALBUMS[] test = Requêtes.ChargerEmprunts(549);
            Assert.AreEqual(6, test.Length); 
            Assert.AreEqual("Mozart Verdi: Requiem", test[0].TITRE_ALBUM.Trim()); 
        }

        [TestMethod]
        public void NouvelAbo()
        {
            ABONNÉS abo1 = new ABONNÉS { CODE_PAYS = 1, NOM_ABONNÉ = "testAbo", PRÉNOM_ABONNÉ = "testAbo", LOGIN_ABONNÉ = "testAbo", PASSWORD_ABONNÉ = "testAbo" };
            var req1 = from abotest in Requêtes.baseMusique.ABONNÉS
                      where abotest.LOGIN_ABONNÉ == abo1.LOGIN_ABONNÉ
                      select abotest;

            Assert.AreEqual(req1.Count(), 0); // Test si aucun abonné de cette forme n'existe déjà

            ABONNÉS abo2 = new ABONNÉS { CODE_PAYS = 1,NOM_ABONNÉ= "testAbo", PRÉNOM_ABONNÉ="testAbo",LOGIN_ABONNÉ= "testAbo", PASSWORD_ABONNÉ ="testAbo" };
            Requêtes.NouvelAbonné(abo2);
            var req2 = from abotest in Requêtes.baseMusique.ABONNÉS
                      where abotest.LOGIN_ABONNÉ == abo2.LOGIN_ABONNÉ
                      select abotest;

            Assert.AreEqual(req2.Count(), 1); // Test l'insertion d'un abonné dans la base

            foreach (ABONNÉS abo in req2)
            {
                Requêtes.baseMusique.ABONNÉS.Remove(abo);
            }
            Requêtes.baseMusique.SaveChanges();
        }

        [TestMethod]
        public void TestRecupIdAbo()
        {
            Assert.AreEqual(Requêtes.RecupIdAbo("test1", "test1"), 549); //Test si la récuparation de l'ID d'un abo est fonctionnelle
        }

        [TestMethod]
        public void TestListePays()
        {
            string[] test = Requêtes.ListePays();
            Assert.AreEqual(67, test.Length); // Test si le nombre de pays retourné est bien égal à 67
            Assert.AreEqual("France", test[0].Trim()); // Test si le pays numéro 1 est bien la France
        }

        [TestMethod]
        public void TestToutEmprunt()
        {
            EMPRUNTER[] test = Requêtes.ListeToutEmprunt();
            Assert.AreEqual(12, test.Length); 
            Assert.AreEqual(549, test[0].CODE_ABONNÉ); 
            Assert.AreEqual("Bach J-C: Sinfonien", test[1].ALBUMS.TITRE_ALBUM.Trim()); 
        }

       [TestMethod]
        public void TestListeAbonné()
        {
            ABONNÉS[] test = Requêtes.ListeToutAbonné();
            Assert.AreEqual(10, test.Length); 
            Assert.AreEqual("test1", test[0].LOGIN_ABONNÉ.Trim()); 
        }

        [TestMethod]
        public void TestGenreAlbum()
        {
            var req = from album in Requêtes.baseMusique.ALBUMS
                      select album;
            ALBUMS[] albums = req.ToArray();

            GENRES genreTest = Requêtes.GenreAlbum(albums[1]);
            Assert.AreEqual(17, genreTest.DÉLAI);//Test si le genre de l'album 1 est bien Baroque
        }

        [TestMethod]
        public void TestRetourAlbum()
        {
            EMPRUNTER emprunttest2 = Requêtes.TrouverDansMesEmprunts("C", 549);
            Assert.AreEqual("Bach, CPE: Concertos pour violoncelle", emprunttest2.ALBUMS.TITRE_ALBUM.Trim());
        }

        [TestMethod]
        public void TestListeAlbumParGenre()
        {
            GENRES g = new GENRES { CODE_GENRE = 3, LIBELLÉ_GENRE = "Baroque", DÉLAI = 17 };
            ALBUMS[] genre = Requêtes.ListeAlbumParGenre(g.CODE_GENRE);
            Assert.AreEqual("Albinoni: 12 Concertos Op. 9", genre[0].TITRE_ALBUM.Trim());
        }

        [TestMethod]
        public void TestGenrePréféré()
        {
            int genre = Requêtes.GenrePréféré(549);
            Assert.AreEqual(3, genre);
            int genre2 = Requêtes.GenrePréféré(551);
            Assert.AreEqual(7, genre2);
        }

        [TestMethod]
        public void TestRechercheAlbum()
        {
            string nom = "Bach";
            ALBUMS[] albums = Requêtes.RechercheAlbum(nom);
            Assert.AreEqual("Bach, CPE: Concertos pour violoncelle", albums[0].TITRE_ALBUM.Trim());

            string nom2 = "Mozart";
            albums = Requêtes.RechercheAlbum(nom2);
            Assert.AreEqual("Mozart: Portraits", albums[0].TITRE_ALBUM.Trim());
        }

        [TestMethod]
        public void TestCodePays()
        {
            string nom = "France";
            string nom2 = "Chine";

            Assert.AreEqual(1, Requêtes.CodePays(nom));
            Assert.AreEqual(20, Requêtes.CodePays(nom2));
        }

        [TestMethod]
        public void TestVerificationProlongementPossible()
        {
            string nom = "Mozart Verdi: Requiem";
            string nom2 = "Bach, CPE: Concertos pour violoncelle";

            Assert.IsFalse(Requêtes.VerificationProlongementPossible(nom, 549)); // Vérifie si le prolongement est possible pour le livre
            Assert.IsFalse(Requêtes.VerificationProlongementPossible(nom2, 549)); // Vérifie si le prolongement est possible pour le livre
        }

        [TestMethod]
        public void TestEmprunterAlbumTitre()
        {
            string titre = "Bach";
            Assert.AreEqual("Bach, CPE: Concertos pour violoncelle", Requêtes.emprunterAlbumTitre(titre).TITRE_ALBUM.Trim());

            titre = "Albinoni: 12 Concertos Op. 9";
            Assert.AreEqual("Albinoni: 12 Concertos Op. 9", Requêtes.emprunterAlbumTitre(titre).TITRE_ALBUM.Trim());
        }

        [TestMethod]
        public void TestListeAlbumNonEmprunte()
        {
            ALBUMS[] album = Requêtes.listeAlbumNonEmprunte();
            Assert.AreEqual("Bach: The Well-Tempered Clavier Book 2", album[0].TITRE_ALBUM.Trim());
        }

        [TestMethod]
        public void TestListeEmpruntParCasier()
        {
            EMPRUNTER[] emprunts = Requêtes.ListeEmpruntParCasier(1);
            Assert.AreEqual(1, emprunts.Length);
            Assert.AreEqual("Penderecki: Concertos pour clarinette", emprunts[0].ALBUMS.TITRE_ALBUM.Trim());
        }

        [TestMethod]
        public void TestListeEmpruntNonRendu()
        {
            EMPRUNTER[] emprunts = Requêtes.ListeEmpruntNonRendu();
            Assert.AreEqual(10, emprunts.Length);
        }

        [TestMethod]
        public void TestListeEmpruntRendu()
        {
            EMPRUNTER[] emprunts = Requêtes.ListeEmpruntRendu(350);
            Assert.AreEqual(0, emprunts.Length);
        }

        [TestMethod]
        public void TestVinyleSelectionné()
        {
            EMPRUNTER emprunt = Requêtes.VinyleSelectionné("Mahler: Lieder", 549);
            Assert.IsNull(emprunt);
            emprunt = Requêtes.VinyleSelectionné("Mozart Verdi: Requiem", 549);
            Assert.AreEqual(emprunt.CODE_ALBUM, 302);
        }
        #endregion


        #region TU US1 à US2
        [TestMethod]
        public void US1() 
        {
            ABONNÉS abo1 = new ABONNÉS { CODE_PAYS = 1, NOM_ABONNÉ = "US1'", PRÉNOM_ABONNÉ = "US1'", LOGIN_ABONNÉ = "US1'", PASSWORD_ABONNÉ = "US1'" };
            
            for (int i = 0; i < 2; i++)
            {
                Requêtes.NouvelAbonné(abo1);
            }

            var req1 = from abotest in Requêtes.baseMusique.ABONNÉS
                       where abotest.LOGIN_ABONNÉ == abo1.LOGIN_ABONNÉ
                       select abotest;

            Assert.AreEqual(req1.Count(), 1); // Test si 1 seul abonné a bien été rajouté


            ABONNÉS abo2 = new ABONNÉS { CODE_PAYS = null, NOM_ABONNÉ = "US1'", PRÉNOM_ABONNÉ = "US1'", LOGIN_ABONNÉ = "     ", PASSWORD_ABONNÉ = "US1'" };
            Requêtes.NouvelAbonné(abo2);


            var req2 = from abotest2 in Requêtes.baseMusique.ABONNÉS
                       where abotest2.LOGIN_ABONNÉ == abo2.LOGIN_ABONNÉ
                       select abotest2;

            Assert.AreEqual(req2.Count(), 0); // Test si aucun abonné n'a pas été rajouté

            foreach (ABONNÉS abo in req1)
            {
                Requêtes.baseMusique.ABONNÉS.Remove(abo);
            }
            Requêtes.baseMusique.SaveChanges();
        }

        [TestMethod]
        public void TestUS1Bis()
        {
            
            ALBUMS album = new ALBUMS { CODE_ALBUM = 1, CODE_EDITEUR = 7, CODE_GENRE = 3, TITRE_ALBUM = "Albinoni: 12 Concertos Op. 9", ANNÉE_ALBUM = 1997, PRIX_ALBUM = 5.00M, ALLÉE_ALBUM = "G", CASIER_ALBUM = 3, POCHETTE = null };
            Requêtes.EmprunterVinyle(album, 550);

            var req2 = from emprunter in Requêtes.baseMusique.EMPRUNTER
                       where emprunter.CODE_ABONNÉ == 550 && emprunter.CODE_ALBUM == 1
                       select emprunter;

            Assert.AreEqual(req2.Count(), 1);

            Assert.AreEqual(req2.FirstOrDefault().DATE_RETOUR, null);
            Requêtes.RendreEmprunt(req2.FirstOrDefault());
            Assert.IsNotNull(req2.FirstOrDefault().DATE_RETOUR);
            Requêtes.RendreEmprunt(req2.FirstOrDefault());

            foreach (EMPRUNTER e in req2)
            {
                Requêtes.baseMusique.EMPRUNTER.Remove(e);
            }
            Requêtes.baseMusique.SaveChanges();
        }

        [TestMethod]
        public void US2()
        {
            ALBUMS[] test = Requêtes.ChargerEmprunts(213);
            Assert.AreEqual(0, test.Length); 

            ALBUMS[] test2 = Requêtes.ChargerEmprunts(549);
            Assert.AreEqual(6, test2.Length); 

            ALBUMS[] test3 = Requêtes.ChargerEmprunts(549);
            Assert.AreEqual("Mozart Verdi: Requiem", test3[0].TITRE_ALBUM.Trim()); 
            Assert.AreEqual("Bach: Cantates - Harnoncourt", test3[test3.Length - 1].TITRE_ALBUM.Trim()); 
        }
        #endregion
    }
}
