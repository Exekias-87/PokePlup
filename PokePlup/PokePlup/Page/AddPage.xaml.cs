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
            PokePlupDatabase pokemonDB = await PokePlupDatabase.Instance;

            await pokemonDB.SaveItemAsync( new MyPokemon
            {
                Nom = nom.Text,
                Type = type.Text,
                Type2 = type2.Text,
                Description = description.Text,
                HP = Int32.Parse(hp.ToString()), 
                ATK = Int32.Parse(atk.ToString()),
                DEF = Int32.Parse(def.ToString()),
                SATK = Int32.Parse(satk.ToString()),
                SDEF = Int32.Parse(sdef.ToString()),    
            });
        }
    }
}