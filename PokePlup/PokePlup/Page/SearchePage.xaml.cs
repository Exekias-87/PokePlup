using PokeApiNet;
using PokePiplup.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PokePlup.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchePage : ContentPage
    {
        public SearchePage()
        {
            InitializeComponent();
           
        }

        private void Rechercher(object sender, EventArgs e)
        {
            var vm = ListViewModel.Instance;
            string PokemonName = vm.GetPokemonApi(searchBar.Text)[0];
            string PokemonImage = vm.GetPokemonApi(searchBar.Text)[1];
            
            NamePoke.Text = PokemonName;
            ImagePoke.Source = PokemonImage;
        }
        private void AjoutPokemonBd(object sender, EventArgs e)
        {
            var vm = ListViewModel.Instance;
            string PokemonName =searchBar.Text;
           
            vm.addPokemonWithName(PokemonName);

           
        }
    }
}