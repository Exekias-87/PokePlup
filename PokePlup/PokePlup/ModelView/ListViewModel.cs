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

        public ListViewModel()
        {

            ListeofPokemon = new ObservableCollection<MyPokemon>();
            

            InitList();

        }

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

        public void addPokemon(MyPokemon pokemon)
        {
            ListeofPokemon.Add(pokemon);
        }

        public async void fillPokemonDatabase()
        {
            PokeApiClient pokeClient = new PokeApiClient();
            PokePlupDatabase pokemonDB = await PokePlupDatabase.Instance;

            var random = new Random();

            for (int i = 1; i <= 20; i++)
            {
                string type2="";
                Pokemon pokemon = await Task.Run(() => pokeClient.GetResourceAsync<PokeApiNet.Pokemon>(random.Next(1, 908)));
                PokemonSpecies species = Task.Run(() => pokeClient.GetResourceAsync(pokemon.Species)).Result;
                if (pokemon.Types.Count > 1) type2 = pokemon.Types[1].Type.Name;

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


    }
}