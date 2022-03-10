using PokePlup.Model;
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
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage(MyPokemon pokemon)
        {
             
            InitializeComponent();
            BindingContext = pokemon;
        }

        private void Return(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}