use MusiquePT2_C



DELETE FROM EMPRUNTER
DELETE FROM ABONNÉS



INSERT INTO ABONNÉS Values(1,'test1','test1','test1', 'test1')
INSERT INTO ABONNÉS Values(1,'test2','test2','test2', 'test2')
INSERT INTO ABONNÉS Values(1,'test3','test3','test3', 'test3')
INSERT INTO ABONNÉS Values(1,'test4','test4','test4', 'test4')
INSERT INTO ABONNÉS Values(1,'test5','test5','test5', 'test5')
INSERT INTO ABONNÉS Values(1,'test6','test6','test6', 'test6')
INSERT INTO ABONNÉS Values(1,'test7','test7','test7', 'test7')
INSERT INTO ABONNÉS Values(1,'test8','test8','test8', 'test8')
INSERT INTO ABONNÉS Values(1,'test9','test9','test9', 'test9')
INSERT INTO ABONNÉS Values(1,'test10','test10','test10', 'test10')



/* Abonné qui a emprunté plusieurs livres (pas de retard) */
insert into EMPRUNTER values ((select CODE_ABONNÉ from ABONNÉS where LOGIN_ABONNÉ = 'test1'), 1, '07/06/2021','27/06/2021', null)
insert into EMPRUNTER values ((select CODE_ABONNÉ from ABONNÉS where LOGIN_ABONNÉ = 'test1'), 2, '09/06/2021','27/06/2021', null)
insert into EMPRUNTER values ((select CODE_ABONNÉ from ABONNÉS where LOGIN_ABONNÉ = 'test1'), 3, '10/05/2021','06/06/2021','06/06/2021')

/* Abonné qui emprunte plusieurs livres depuis plusieurs années (au moins 1 par an)*/
insert into EMPRUNTER values ((select CODE_ABONNÉ from ABONNÉS where LOGIN_ABONNÉ = 'test2'), 5, '10/05/2019','30/06/2019','30/06/2019')
insert into EMPRUNTER values ((select CODE_ABONNÉ from ABONNÉS where LOGIN_ABONNÉ = 'test2'), 6, '08/05/2020','27/06/2020','27/06/2020')
insert into EMPRUNTER values ((select CODE_ABONNÉ from ABONNÉS where LOGIN_ABONNÉ = 'test2'), 7, '07/05/2021','25/06/2021','25/06/2021')
insert into EMPRUNTER values ((select CODE_ABONNÉ from ABONNÉS where LOGIN_ABONNÉ = 'test2'), 3, '05/04/2021','06/05/2021',null)

/* Abonné qui n'a pas emprunté depuis plus d'un an */ 
insert into EMPRUNTER values ((select CODE_ABONNÉ from ABONNÉS where LOGIN_ABONNÉ = 'test3'), 8, '10/05/2019','30/06/2019','30/06/2019')

/* Abonné qui a un retard > 10 jours */
insert into EMPRUNTER values ((select CODE_ABONNÉ from ABONNÉS where LOGIN_ABONNÉ = 'test4'), 9, '08/05/2020','27/06/2020', null)

/* Un livre emprunté plusieurs fois sur 2 périodes différentes */
insert into EMPRUNTER values ((select CODE_ABONNÉ from ABONNÉS where LOGIN_ABONNÉ = 'test5'), 10, '08/05/2020','27/06/2020', '27/06/2020')
insert into EMPRUNTER values ((select CODE_ABONNÉ from ABONNÉS where LOGIN_ABONNÉ = 'test5'), 11, '08/05/2021','27/06/2021', null)

