# Nomenclature
Nommage en PascalCase, exemple: MaVariable.

# Classe

## Cl_BDD
Cette classe effectue une connexion � la base de donn�es. Elle est utilis�e pour h�rit�e certaine classe.
## Cl_ConnexionBDD
Cette classe permet simplement d'effectuer des requ�tes � la base de donn�es. Elle est utilis�e par les fen�tres.
## Cl_AfficheMessageBox
Il permet d'afficher diff�rents types de message (information, alerte, erreur) pour informer l'utilisateur.
## Cl_GroupeMessage
Cette classe repr�sente la table T_GroupeMessage dans la base de donn�es, elle h�rit� de Cl_BDD
## Cl_TypeMessage
Cette classe repr�sente la table T_TypeMessage dans la base de donn�es, elle h�rit� de Cl_BDD
## Cl_Message
Cette classe repr�sente la table T_Message dans la base de donn�es, elle h�rit� de Cl_BDD
## Cl_Utilisateur
Cette classe g�re la connexion a l'application, elle h�rit� de Cl_BDD

# Fen�tre
## Fn_Authentification
Page d'authentification

## Autre
Le code "XXXX" est r�server par l'application car c'est cette valeur qu'il affiche lorsque l'utilisateur ajoute un nouveau messaged