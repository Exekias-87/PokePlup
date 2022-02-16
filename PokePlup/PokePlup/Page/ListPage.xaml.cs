using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PokeApiNet;
using System.Diagnostics;

namespace PokePiplup.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ConnectApi();
        }
        public async void ConnectApi()
        {
            PokeApiClient pokeClient = new PokeApiClient();
            for (int i = 100; i < 120; i++)
            {
                Pokemon pokemon = await Task.Run(() => pokeClient.GetResourceAsync<Pokemon>(i));
                Debug.WriteLine(pokemon.Name);
            }

        }


    }
}