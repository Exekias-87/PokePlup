# PokePlup

## Fonctionnalités présentes

### Onglet 1 : HomePage
Page de présentation de l'application

### Onglet 2 : AddPage
Page qui nous permet d'ajouter des pokémons. On peux ajouter un pokémon avec :  
- Un nom
- Un type
- Un type secondaire (non-obligatoire)
- Une description
- Un nombre de point d'HP 
- Un nombre de point d'Atk
- Un nombre de point de Def
- Un nombre de point d'Atk Spécial
- Un nombre de point de Def Spécial
- Une photo
Lorsqu'un pokémon est ajouté, il est ajouté directement à la base de donnéeet apparait donc dans l'onglet suivant : la liste des pokemon. 

### Onglet 3 : ListPage
Page qui répertorie tout les pokémons. Au lancement de l'appliquation, 20 pokémons y sont instancié depuis l'API (pokéApi). Les pokémons ajoutés via la recherche sont aussi ajouté ici. Tous les pokémons sont en francais (nom, type description etc...). Lorsque un appuie est detecté sur un pokemon, le detail du pokémon s'affiche.

### Onglet 4 : SearchPage
Page qui permet de rechercher des pokémons de l'API. La recherche ne fonctionne qu'avec les nom des pokémons en anglais. En revanche, ceux-ci sont bien affiché en anglais et ajouter à la liste en francais aussi.  

### DetailPage
Dans cette page on retrouve le détails d'un pokémon en français. 
