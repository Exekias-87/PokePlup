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
        public async void SeeMore(object sender, EventArgs e)
        {
            
            
            Navigation.PushModalAsync(new DetailsPage());
        }
        
    }
}