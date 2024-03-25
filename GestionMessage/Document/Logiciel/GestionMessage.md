# Description
Gestion Message est une application conçue pour éditer des messages destinés à être utilisés dans d'autres applications. Chaque message est composé d'un code à 4 caractères (par exemple : 0245, 5210, 0010), d'un contenu (par exemple : "Connexion interrompue", "Authentification échouée"), d'un groupe (par exemple : base de données, API) et d'un type (par exemple : ALERTE, QUESTION, ERREUR).

# Objectif
L'objectif de GestionMessage est de simplifier la gestion des messages en évitant la réécriture répétitive de ceux-ci, ce qui peut entraîner une surcharge de code. Cette tâche incombe souvent uniquement au développeur et peut nécessiter la recompilation de l'application ou sa mise en ligne pour corriger un simple message. GestionMessage offre une solution en fournissant une interface utilisateur graphique (GUI) permettant à l'utilisateur ainsi qu'au client de collaborer efficacement pour éditer et personnaliser les messages. Une fois les messages édités, il suffit de les intégrer dans le code et de les appeler simplement en utilisant leur code correspondant.

# Base de données
La base de données utilisée est SQLite, ce choix a été fait pour sa portabilité, ce qui permet de transporter facilement la base de données, et elle peut également être utilisée avec des outils de versionnement.

# UML BDD
![[MCD BDD GestionMessage_2.jpg]]
# UML Classe
![[Classe/Diagramme de classe.drawio.png]]
# Schéma environnement informatique
![[Schéma environnement informatique.drawio.png]]