# PokePlup

## Fonctionnalités présentes

### Onglet 1 : HomePage
Page de présentation de l'application contenant le titre et un rapide message.

### Onglet 2 : AddPage
Page qui nous permet d'ajouter des pokémons. On peut ajouter un pokémon avec :  

- Un nom
- Un type
- Un type secondaire (non-obligatoire)
- Une description
- Un nombre de point d'HP (Points de vie)
- Un nombre de point d'Atk (Attaque)
- Un nombre de point de Def (Défense)
- Un nombre de point d'Atk Spécial
- Un nombre de point de Def Spécial
- Une photo

Lorsqu'un pokémon est ajouté, il est ajouté directement à la base de donnée, et apparaît donc dans l'onglet suivant : la liste des pokémons. 

### Onglet 3 : ListPage
Page qui répertorie tout les pokémons. Au lancement de l'application, 50 pokémons y sont instanciés depuis l'API (pokéApi). Les pokémons ajoutés via la recherche sont aussi ajouté ici. Tous les pokémons sont en français (nom, type description etc...). Lorsqu'un appui est detecté sur un pokemon, le détail du pokémon s'affiche. Cela nous ouvre donc une page de détail qui concerne le dit pokémon.

### Onglet 4 : SearchPage
Page qui permet de rechercher des pokémons de l'API. La recherche ne fonctionne qu'avec les noms des pokémons en anglais. En revanche, ceux-ci sont bien affiché en français et ajouté à la liste en français aussi.  

### DetailPage
Dans cette page on retrouve le détail d'un pokémon en français. Son image (ainsi que celle de son shiny s'il s'agit d'un pokémon de l'api), ses types, ses stats et sa description.
