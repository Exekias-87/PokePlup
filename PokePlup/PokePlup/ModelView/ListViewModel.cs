using PokeApiNet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PokePiplup.ModelView
{
    internal class ListViewModel : BaseViewModel
    {
        private static ListViewModel _instance = new ListViewModel();
        public static ListViewModel Instance { get { return _instance; } }
        public ObservableCollection<Pokemon> ListeofPokemon
        {
            get => GetValue<ObservableCollection<Pokemon>>();
            set => SetValue(value);
        }

    }
}