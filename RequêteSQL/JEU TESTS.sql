DELETE FROM EMPRUNTER
DELETE FROM ABONN?S

INSERT INTO ABONN?S Values(1,'test1','test1','test1', 'test1')
INSERT INTO ABONN?S Values(1,'test2','test2','test2', 'test2')
INSERT INTO ABONN?S Values(1,'test3','test3','test3', 'test3')
INSERT INTO ABONN?S Values(1,'test4','test4','test4', 'test4')
INSERT INTO ABONN?S Values(1,'test5','test5','test5', 'test5')
INSERT INTO ABONN?S Values(1,'test6','test6','test6', 'test6')
INSERT INTO ABONN?S Values(1,'test7','test7','test7', 'test7')
INSERT INTO ABONN?S Values(1,'test8','test8','test8', 'test8')
INSERT INTO ABONN?S Values(1,'test9','test9','test9', 'test9')
INSERT INTO ABONN?S Values(1,'test10','test10','test10', 'test10')

INSERT INTO EMPRUNTER Values((SELECT CODE_ABONN? from ABONN?S WHERE LOGIN_ABONN? = 'test1'), 1, GETDATE(), GETDATE()+10, null)
INSERT INTO EMPRUNTER Values((SELECT CODE_ABONN? from ABONN?S WHERE LOGIN_ABONN? = 'test1'), 2, GETDATE(), GETDATE()+10, null)
INSERT INTO EMPRUNTER Values((SELECT CODE_ABONN? from ABONN?S WHERE LOGIN_ABONN? = 'test1'), 3, GETDATE(), GETDATE()+10, null)
INSERT INTO EMPRUNTER Values((SELECT CODE_ABONN? from ABONN?S WHERE LOGIN_ABONN? = 'test1'), 4, GETDATE(), GETDATE()+10, null)
INSERT INTO EMPRUNTER Values((SELECT CODE_ABONN? from ABONN?S WHERE LOGIN_ABONN? = 'test1'), 5, GETDATE(), GETDATE()+10, null)
INSERT INTO EMPRUNTER Values((SELECT CODE_ABONN? from ABONN?S WHERE LOGIN_ABONN? = 'test2'), 25, '18/11/2001', '30/11/2001', null)
INSERT INTO EMPRUNTER Values((SELECT CODE_ABONN? from ABONN?S WHERE LOGIN_ABONN? = 'test1'), 10, GETDATE(), GETDATE()+10, null)
INSERT INTO EMPRUNTER Values((SELECT CODE_ABONN? from ABONN?S WHERE LOGIN_ABONN? = 'test4'), 11, GETDATE(), GETDATE()+10, null)
INSERT INTO EMPRUNTER Values((SELECT CODE_ABONN? from ABONN?S WHERE LOGIN_ABONN? = 'test3'), 385, '18/11/2001', '30/11/2001', null)
INSERT INTO EMPRUNTER Values((SELECT CODE_ABONN? from ABONN?S WHERE LOGIN_ABONN? = 'test4'), 99, GETDATE(), GETDATE()+11, GETDATE()+12)
INSERT INTO EMPRUNTER Values((SELECT CODE_ABONN? from ABONN?S WHERE LOGIN_ABONN? = 'test5'), 70, '18/11/2001', '30/11/2001', GETDATE())
INSERT INTO EMPRUNTER Values((SELECT CODE_ABONN? from ABONN?S WHERE LOGIN_ABONN? = 'test6'), 200, '18/11/2001', '30/11/2001', null)




