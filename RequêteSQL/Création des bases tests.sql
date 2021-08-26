use MusiquePT2_C



DELETE FROM EMPRUNTER
DELETE FROM ABONN�S



INSERT INTO ABONN�S Values(1,'test1','test1','test1', 'test1')
INSERT INTO ABONN�S Values(1,'test2','test2','test2', 'test2')
INSERT INTO ABONN�S Values(1,'test3','test3','test3', 'test3')
INSERT INTO ABONN�S Values(1,'test4','test4','test4', 'test4')
INSERT INTO ABONN�S Values(1,'test5','test5','test5', 'test5')
INSERT INTO ABONN�S Values(1,'test6','test6','test6', 'test6')
INSERT INTO ABONN�S Values(1,'test7','test7','test7', 'test7')
INSERT INTO ABONN�S Values(1,'test8','test8','test8', 'test8')
INSERT INTO ABONN�S Values(1,'test9','test9','test9', 'test9')
INSERT INTO ABONN�S Values(1,'test10','test10','test10', 'test10')



/* Abonn� qui a emprunt� plusieurs livres (pas de retard) */
insert into EMPRUNTER values ((select CODE_ABONN� from ABONN�S where LOGIN_ABONN� = 'test1'), 1, '07/06/2021','27/06/2021', null)
insert into EMPRUNTER values ((select CODE_ABONN� from ABONN�S where LOGIN_ABONN� = 'test1'), 2, '09/06/2021','27/06/2021', null)
insert into EMPRUNTER values ((select CODE_ABONN� from ABONN�S where LOGIN_ABONN� = 'test1'), 3, '10/05/2021','06/06/2021','06/06/2021')

/* Abonn� qui emprunte plusieurs livres depuis plusieurs ann�es (au moins 1 par an)*/
insert into EMPRUNTER values ((select CODE_ABONN� from ABONN�S where LOGIN_ABONN� = 'test2'), 5, '10/05/2019','30/06/2019','30/06/2019')
insert into EMPRUNTER values ((select CODE_ABONN� from ABONN�S where LOGIN_ABONN� = 'test2'), 6, '08/05/2020','27/06/2020','27/06/2020')
insert into EMPRUNTER values ((select CODE_ABONN� from ABONN�S where LOGIN_ABONN� = 'test2'), 7, '07/05/2021','25/06/2021','25/06/2021')
insert into EMPRUNTER values ((select CODE_ABONN� from ABONN�S where LOGIN_ABONN� = 'test2'), 3, '05/04/2021','06/05/2021',null)

/* Abonn� qui n'a pas emprunt� depuis plus d'un an */ 
insert into EMPRUNTER values ((select CODE_ABONN� from ABONN�S where LOGIN_ABONN� = 'test3'), 8, '10/05/2019','30/06/2019','30/06/2019')

/* Abonn� qui a un retard > 10 jours */
insert into EMPRUNTER values ((select CODE_ABONN� from ABONN�S where LOGIN_ABONN� = 'test4'), 9, '08/05/2020','27/06/2020', null)

/* Un livre emprunt� plusieurs fois sur 2 p�riodes diff�rentes */
insert into EMPRUNTER values ((select CODE_ABONN� from ABONN�S where LOGIN_ABONN� = 'test5'), 10, '08/05/2020','27/06/2020', '27/06/2020')
insert into EMPRUNTER values ((select CODE_ABONN� from ABONN�S where LOGIN_ABONN� = 'test5'), 11, '08/05/2021','27/06/2021', null)

