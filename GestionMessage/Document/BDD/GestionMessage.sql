BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "T_GroupeMessage" (
	"IdGroupeMessage"	INTEGER NOT NULL UNIQUE,
	"LabelGroupeMessage"	TEXT(100) NOT NULL UNIQUE,
	UNIQUE("LabelGroupeMessage"),
	PRIMARY KEY("IdGroupeMessage" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "T_TypeMessage" (
	"IdTypeMessage"	INTEGER NOT NULL UNIQUE,
	"LabelTypeMessage"	TEXT(20) NOT NULL UNIQUE,
	UNIQUE("LabelTypeMessage"),
	PRIMARY KEY("IdTypeMessage" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "T_Message" (
	"IdMessage"	INTEGER NOT NULL UNIQUE,
	"IdGroupeMessage"	INTEGER NOT NULL,
	"IdTypeMessage"	INTEGER NOT NULL,
	"CodeMessage"	TEXT(4) NOT NULL UNIQUE,
	"Message"	TEXT(255) NOT NULL,
	UNIQUE("CodeMessage"),
	FOREIGN KEY("IdGroupeMessage") REFERENCES "T_GroupeMessage"("IdGroupeMessage"),
	FOREIGN KEY("IdTypeMessage") REFERENCES "T_TypeMessage"("IdTypeMessage"),
	PRIMARY KEY("IdMessage" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "T_Utilisateur" (
	"IdUtilisateur"	INTEGER NOT NULL UNIQUE,
	"NomUtilisateur"	TEXT(64) NOT NULL UNIQUE,
	"MotDePasse"	TEXT(64),
	PRIMARY KEY("IdUtilisateur" AUTOINCREMENT)
);
INSERT INTO "T_GroupeMessage" VALUES (9,'Base de données');
INSERT INTO "T_GroupeMessage" VALUES (10,'authentification');
INSERT INTO "T_GroupeMessage" VALUES (11,'évènement innatendu');
INSERT INTO "T_GroupeMessage" VALUES (12,'problème interne');
INSERT INTO "T_TypeMessage" VALUES (2,'ALERTES');
INSERT INTO "T_TypeMessage" VALUES (3,'INFORMATION');
INSERT INTO "T_TypeMessage" VALUES (9,'QUESTION');
INSERT INTO "T_TypeMessage" VALUES (10,'ERREUR');
INSERT INTO "T_TypeMessage" VALUES (11,'TRACE');
INSERT INTO "T_Message" VALUES (4,9,2,'0001','Connexion à la base de données échouée. Veuillez vérifier les paramètres de connexion et l''état du serveur');
INSERT INTO "T_Message" VALUES (5,9,3,'0002','La base de données a été sauvegardée avec succès à 03:00 AM.');
INSERT INTO "T_Message" VALUES (6,9,9,'0003','Le format de la base de données doit-il être mis à jour pour prendre en charge les nouvelles fonctionnalités ?');
INSERT INTO "T_Message" VALUES (7,9,10,'0004','Erreur lors de l''exécution de la requête SQL. Veuillez contacter l''administrateur du système pour assistance.');
INSERT INTO "T_Message" VALUES (8,10,2,'0005','Tentative de connexion avec des identifiants invalides. Veuillez vérifier vos informations d''identification.');
INSERT INTO "T_Message" VALUES (9,10,3,'0006','L''utilisateur ''JohnDoe'' s''est connecté avec succès à 14:30 PM.');
INSERT INTO "T_Message" VALUES (10,10,9,'0007','Les politiques de mot de passe doivent-elles être renforcées pour des raisons de sécurité ?');
INSERT INTO "T_Message" VALUES (11,10,10,'0008','Impossible de vérifier les informations d''identification. Veuillez réessayer ou réinitialiser votre mot de passe.');
INSERT INTO "T_Message" VALUES (12,11,2,'0009','Le serveur a subi une surcharge soudaine de trafic. Des mesures sont en cours pour stabiliser les performances.');
INSERT INTO "T_Message" VALUES (13,11,3,'0010','Le système de notification par e-mail est temporairement désactivé en raison d''une maintenance planifiée.');
INSERT INTO "T_Message" VALUES (14,11,9,'0011','Devrions-nous implémenter des sauvegardes automatiques pour prévenir les pertes de données en cas de panne imprévue du système ?');
INSERT INTO "T_Message" VALUES (15,11,10,'0012','Une erreur inattendue s''est produite. Veuillez réessayer ultérieurement ou contacter l''équipe de support pour assistance.');
INSERT INTO "T_Message" VALUES (16,9,9,'0013','Préférences de sauvegarde. Quelle fréquence de sauvegarde préférez-vous pour la base de données : quotidienne, hebdomadaire ou mensuelle ? De plus, à quel moment de la journée préférez-vous que les sauvegardes soient effectuées ? Merci de nous faire part ');
INSERT INTO "T_Message" VALUES (17,9,2,'0014','Autorisations d''accès. Quels utilisateurs ou groupes devraient avoir accès en lecture/écriture à la base de données ? Veuillez spécifier les autorisations requises pour chaque utilisateur ou groupe afin que nous puissions configurer les autorisations appr');
INSERT INTO "T_Utilisateur" VALUES (1,'e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855','e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855');
COMMIT;
