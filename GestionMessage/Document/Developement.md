# Nomenclature
Nommage en PascalCase, exemple: MaVariable.

# Classe

## Cl_BDD
Cette classe effectue une connexion à la base de données. Elle est utilisée pour héritée certaine classe.
## Cl_ConnexionBDD
Cette classe permet simplement d'effectuer des requêtes à la base de données. Elle est utilisée par les fenêtres.
## Cl_AfficheMessageBox
Il permet d'afficher différents types de message (information, alerte, erreur) pour informer l'utilisateur.
## Cl_GroupeMessage
Cette classe représente la table T_GroupeMessage dans la base de données, elle hérité de Cl_BDD
## Cl_TypeMessage
Cette classe représente la table T_TypeMessage dans la base de données, elle hérité de Cl_BDD
## Cl_Message
Cette classe représente la table T_Message dans la base de données, elle hérité de Cl_BDD
## Cl_Utilisateur
Cette classe gère la connexion a l'application, elle hérité de Cl_BDD

# Fenêtre
## Fn_Authentification
Page d'authentification

## Autre
Le code "XXXX" est réserver par l'application car c'est cette valeur qu'il affiche lorsque l'utilisateur ajoute un nouveau messaged