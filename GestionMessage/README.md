# T_GroupeMessage
```sql
CREATE TABLE IF NOT EXISTS "T_GroupeMessage" (
	"IdGroupeMessage"	INTEGER NOT NULL UNIQUE,
	"LabelGroupeMessage"	TEXT(100) NOT NULL UNIQUE,
	PRIMARY KEY("IdGroupeMessage" AUTOINCREMENT),
	UNIQUE("LabelGroupeMessage")
);
```
IdGroupeMessage --Id
LabelGroupeMessage --Le nom du groupe

# T_TypeMessage
```sql
CREATE TABLE IF NOT EXISTS "T_TypeMessage" (
	"IdTypeMessage"	INTEGER NOT NULL UNIQUE,
	"LabelTypeMessage"	TEXT(20) NOT NULL UNIQUE,
	PRIMARY KEY("IdTypeMessage" AUTOINCREMENT),
	UNIQUE("LabelTypeMessage")
);
```
IdTypeMessage --Id
LabelTypeMessage --(Erreur,Question,Alerte,etc)

# T_Message
```sql
CREATE TABLE IF NOT EXISTS "T_Message" (
	"IdMessage"	INTEGER NOT NULL UNIQUE,
	"IdGroupeMessage"	INTEGER NOT NULL,
	"IdTypeMessage"	INTEGER NOT NULL,
	"CodeMessage"	TEXT(4) NOT NULL UNIQUE,
	"Message"	TEXT(255) NOT NULL,
	PRIMARY KEY("IdMessage" AUTOINCREMENT),
	FOREIGN KEY("IdGroupeMessage") REFERENCES "T_GroupeMessage"("IdGroupeMessage"),
	FOREIGN KEY("IdTypeMessage") REFERENCES "T_TypeMessage"("IdTypeMessage"),
	UNIQUE("CodeMessage"),
	UNIQUE("Message")
);
```
IdMessage --Id
IdGroupeMessage --Lien avec la table T_GroupeMessage
IdTypeMessage --Lien avec la table T_TypeMessage
CodeMessage --Le code du message, exemple (0004, 0520, 0025, etc)
Message --Le message qui informera