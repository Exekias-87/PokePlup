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
        //On donne en binding context, un seul pokémon et donc ou pourra affficher l'ensemble de ses attributs
        public DetailsPage(MyPokemon pokemon)
        {
            InitializeComponent();
            BindingContext = pokemon;
        }

        //Une méthode que l'on attribut à un bouton permettant de fermer la page de détails
        private void Return(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}