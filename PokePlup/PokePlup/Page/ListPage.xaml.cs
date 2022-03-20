using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PokeApiNet;
using System.Diagnostics;
using PokePiplup.ModelView;
using PokePlup.Page;
using PokePlup.Model;

namespace PokePiplup.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
            BindingContext = ListViewModel.Instance;            
        }

        //Méthode permettant lors d'un appui sur un pokémon de la liste, de consulter une page de détail sur le pokémon en question
        public async void SeeMore(object sender, SelectionChangedEventArgs e)
        {
            MyPokemon pokemon = (e.CurrentSelection.FirstOrDefault() as MyPokemon);
            if (pokemon == null)
            {
                return;
            }

            (sender as CollectionView).SelectedItem = null;
            
            await Navigation.PushModalAsync(new DetailsPage(pokemon));
        }
        
    }
}