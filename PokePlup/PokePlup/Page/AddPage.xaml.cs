using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PokePiplup.ModelView;
using PokePlup.Model;
using PokePlup;

namespace PokePiplup.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPage : ContentPage
    {
        public AddPage()
        {

            InitializeComponent();
        }

        public async void AddPokemonAsync(object sender, EventArgs e)
        {
            var vm= ListViewModel.Instance;
            PokePlupDatabase pokemonDB = await PokePlupDatabase.Instance;



           MyPokemon pokemon= new MyPokemon
           {
               Nom = nom.Text,
               Type = type.Text,
               Type2 = type2.Text,
               Description = description.Text,
               HP = (int)hp.Value,
               ATK = (int)atk.Value,
               DEF = (int)def.Value,
               SATK = (int)satk.Value,
               SDEF = (int)sdef.Value,
           };
            await DisplayAlert("Detail ", nom.Text + " " + (int)hp.Value, "OK");
            await pokemonDB.SaveItemAsync(pokemon); 
            vm.addPokemon(pokemon);

            await Shell.Current.GoToAsync($"//List", true);

        }
    }
}