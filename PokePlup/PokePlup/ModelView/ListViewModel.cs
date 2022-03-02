using PokeApiNet;
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
            PokeApiClient pokeClient = new PokeApiClient();

            for (int i = 1; i <= 20; i++)
            {
                Pokemon pokemon = await Task.Run(() => pokeClient.GetResourceAsync<Pokemon>(i));
                MyPokemon mypokemon = new MyPokemon();
                mypokemon.Nom = pokemon.Name;
                //mypokemon.Type = pokemon.Types[0].Type.Name;
                ListeofPokemon.Add(mypokemon);
            }

        }
        


    }
}