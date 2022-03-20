using PokeApiNet;
using PokePlup;
using PokePlup.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PokePiplup.ModelView
{
    internal class ListViewModel : BaseViewModel
    {
        #region Instance
        private static ListViewModel _instance = new ListViewModel();
        public static ListViewModel Instance { get { return _instance; } }

        #endregion

        public ObservableCollection<MyPokemon> ListeofPokemon
        {
            get => GetValue<ObservableCollection<MyPokemon>>();
            set => SetValue(value);
        }

        //On initialise la liste
        public ListViewModel()
        {
            ListeofPokemon = new ObservableCollection<MyPokemon>();
            InitList();
        }

        //Là, on regarde si une base de données existe dans le téléphone, si oui alors on récupère une liste à partir de la bd, sinon on en créer une et récupère la liste ensuite
        public async void InitList()
        {
            PokePlupDatabase pokemonDB = await PokePlupDatabase.Instance;
           
            if (pokemonDB.isEmpty().Result)
            {
                this.fillPokemonDatabase();
            }
            else
            {
                this.fillPokemonList();
            }
        }

        //Méthode qui permet d'ajouter un pokémon dans la liste
        public void addPokemon(MyPokemon pokemon)
        {
            ListeofPokemon.Add(pokemon);
        }

        //Méthode qui permet d'ajouter un pokémon à partir de son nom en faisant une requête sur l'api
        public async void addPokemonWithName(string name)
        {

            PokeApiClient pokeClient = new PokeApiClient();
            PokePlupDatabase pokemonDB = await PokePlupDatabase.Instance;

            // Si le pokemon n'existe pas dans la BD -> erreur donc on utilise un try catch et on fait rien le cas ou le pokemon n'existe pas
            try
            {
                string type2 = "";
                Pokemon pokemon = await Task.Run(() => pokeClient.GetResourceAsync<PokeApiNet.Pokemon>(name));
                PokemonSpecies species = Task.Run(() => pokeClient.GetResourceAsync(pokemon.Species)).Result;
                if (pokemon.Types.Count > 1) type2 = pokemon.Types[1].Type.Name;

                //Création d'un pokémon à partir des données de l'api
                MyPokemon MyPokemon = new MyPokemon
                {
                    ID = pokemon.Id,
                    Nom = species.Names.Find(myname => myname.Language.Name.Equals("fr")).Name,
                    Type = TypeFrancais(pokemon.Types[0].Type.Name),
                    Type2 = TypeFrancais(type2),
                    CouleurType = CouleurPrincipalPokemon(TypeFrancais(pokemon.Types[0].Type.Name)),
                    Image = pokemon.Sprites.FrontDefault,
                    ImageShiny = pokemon.Sprites.FrontShiny,
                    Description = species.FlavorTextEntries.Find((flavor) => flavor.Language.Name == "fr").FlavorText,
                    HP = pokemon.Stats[0].BaseStat,
                    ATK = pokemon.Stats[1].BaseStat,
                    DEF = pokemon.Stats[2].BaseStat,
                    SATK = pokemon.Stats[3].BaseStat,
                    SDEF = pokemon.Stats[4].BaseStat,
                };

                // Sauvegarde dans la BD puis dans la liste de pokémon
                await pokemonDB.SaveItemAsync(MyPokemon);
                ListeofPokemon.Add(MyPokemon);
            }catch (Exception ex)
            {

            }
           
        }


        //Création de la base de données et récupérationd des pokémons dans la liste
        public async void fillPokemonDatabase()
        {
            PokeApiClient pokeClient = new PokeApiClient();
            PokePlupDatabase pokemonDB = await PokePlupDatabase.Instance;

            var random = new Random();

            for (int i = 1; i <= 50; i++)
            {
                string type2="";
                Pokemon pokemon = await Task.Run(() => pokeClient.GetResourceAsync<PokeApiNet.Pokemon>(random.Next(1, 908)));
                PokemonSpecies species = Task.Run(() => pokeClient.GetResourceAsync(pokemon.Species)).Result;
                if (pokemon.Types.Count > 1) type2 = pokemon.Types[1].Type.Name;

                // Sauvegarde dans la BD 
                await pokemonDB.SaveItemAsync(new MyPokemon
                {
                    ID = pokemon.Id,
                    Nom = species.Names.Find(name => name.Language.Name.Equals("fr")).Name,
                    Type = TypeFrancais(pokemon.Types[0].Type.Name),
                    Type2 = TypeFrancais(type2),
                    CouleurType=CouleurPrincipalPokemon(TypeFrancais(pokemon.Types[0].Type.Name)),
                    Image = pokemon.Sprites.FrontDefault,
                    ImageShiny = pokemon.Sprites.FrontShiny,
                    Description = species.FlavorTextEntries.Find((flavor)=>flavor.Language.Name=="fr").FlavorText,
                    HP = pokemon.Stats[0].BaseStat,
                    ATK = pokemon.Stats[1].BaseStat,
                    DEF = pokemon.Stats[2].BaseStat,
                    SATK = pokemon.Stats[3].BaseStat,
                    SDEF = pokemon.Stats[4].BaseStat,
                }) ;
            }

            this.fillPokemonList();
        }

        //Récupértation des pokémons dans la liste
        public async void fillPokemonList()
        {
            PokePlupDatabase pokemonDB = await PokePlupDatabase.Instance;
            List<MyPokemon> list = await pokemonDB.GetPokemonsAsync();

            for (int i = 0; i < list.Count; i++)
            {
                MyPokemon pokemon = list[i];
                ListeofPokemon.Add(pokemon);
            }
        }

        //Méthode qui permet de faire une requête à l'api afin de voir si le pokémon ayant ce nom existe
        public List<string> GetPokemonApi(string NomPokemon)
        {
            PokeApiClient pokeClient = new PokeApiClient();
            List<string> myList = new List<string>();
            try
            {
                Pokemon pokemon = Task.Run(() => pokeClient.GetResourceAsync<PokeApiNet.Pokemon>(NomPokemon)).Result;
                PokemonSpecies pokemonSpecies = Task.Run(() => pokeClient.GetResourceAsync(pokemon.Species)).Result;
                //Pokemon pokemon = Task.Run(() => pokeClient.GetResourceAsync<Pokemon>(NomPokemon)).Result;

                myList.Add(pokemonSpecies.Names.Find(name => name.Language.Name.Equals("fr")).Name);
                myList.Add(pokemon.Sprites.FrontDefault);

               
                return myList;
            }catch (Exception ex)
            {
                myList.Add("Pokemon non existant");
                myList.Add("Image de pokemon non existant");
                return myList;
           
            }
           
        }

        //Méthode qui transforme les types en français
        public string TypeFrancais(string TypeAnglais)
        {
            switch (TypeAnglais)
            {
                case "normal": return "Normal";
                case "poison": return "Poison";
                case "grass": return "Plante";
                case "psychic": return "Psy";
                case "ground": return "Sol";
                case "ice": return "Glace";
                case "fire": return "Feu";
                case "rock": return "Roche";
                case "dragon": return "Dragon";
                case "water": return "Eau";
                case "bug": return "Insecte";
                case "dark": return "Tenebre";
                case "fighting": return "Combat";
                case "ghost": return "Spectre";
                case "steel": return "Acier";
                case "flying": return "Vol";
                case "electric": return "Electrik";
                case "fairy": return "Fee";
                default: return null;
            }
        }

        //Méthode qui donne la couleur correspondant au type
        public string CouleurPrincipalPokemon(string Type)
        {
            switch (Type)
            {
                case "Normal": return "#ADA594";
                case "Poison": return "#B55AA5";
                case "Plante": return "#7BCE52";
                case "Psy": return "#FF73A5";
                case "Sol": return "#D6B55A";
                case "Glace": return "#5ACEE7";
                case "Feu": return "#F75231";
                case "Roche": return "#BDA55A";
                case "Dragon": return "#8858F6";
                case "Eau": return "#399CFF";
                case "Insecte": return "#ADBD21";
                case "Tenebre": return "#735A4A";
                case "Combat": return "#A55239";
                case "Spectre": return "#6363B5";
                case "Acier": return "#ADADC6";
                case "Vol": return "#9CADF7";
                case "Electrik": return "#FFC631";
                case "Fee": return "#E09AE3";
                default: return null;
            }
        }


    }
}