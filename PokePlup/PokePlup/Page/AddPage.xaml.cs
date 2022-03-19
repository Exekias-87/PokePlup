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
            string Type2;

            if (type2.SelectedItem.ToString().ToLower() == "aucun")
            {
                Type2 = null;
            }
            else
            {
                Type2 = type2.SelectedItem.ToString().ToLower();
            }


            MyPokemon pokemon = new MyPokemon
            {
               Nom = nom.Text,
               Type = type.SelectedItem.ToString().ToLower(),
               Type2 = Type2,
               Description = description.Text,
               HP = (int)hp.Value,
               ATK = (int)atk.Value,
               DEF = (int)def.Value,
               SATK = (int)satk.Value,
               SDEF = (int)sdef.Value,
           };
            await DisplayAlert("Pokemon ajouté : ", nom.Text + " " , "OK");
            await pokemonDB.SaveItemAsync(pokemon); 
            vm.addPokemon(pokemon);

            await Shell.Current.GoToAsync($"//List", true);

            RenitializeValue();
        }
        public void RenitializeValue()
        {
            nom.Text = "";
            type.SelectedItem = "NORMAL";
            type2.SelectedItem = "AUCUN";
            description.Text = "";
            hp.Value = 1;
            atk.Value = 1;
            satk.Value = 1;
            sdef.Value = 1;
            def.Value = 1;
        }
    }
}