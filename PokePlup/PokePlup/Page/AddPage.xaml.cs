using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PokePiplup.ModelView;
using PokePlup.Model;
using PokePlup;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace PokePiplup.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPage : ContentPage
    {
        private MediaFile Image { get; set; }
        private MyPokemon currentPokemon;

        public AddPage()
        {
            type.SelectedItem = "NORMAL";
            type2.SelectedItem = "AUCUN";
            InitializeComponent();
            
        }

        //Méthode qui permet d'ajouter un pokémon dans la liste ainsi que dans la base en se servant du formulaire
        public async void AddPokemonAsync(object sender, EventArgs e)
        {
            var vm= ListViewModel.Instance;
            PokePlupDatabase pokemonDB = await PokePlupDatabase.Instance;
            string Type2;

            //Ici, on regarde que le pokémon à 1 ou 2 types, afin de voir si on le récupère, et ainsi évité des dépassement de la taille du tableau qui contient les types
            if (type2.SelectedItem.ToString().ToLower() == "aucun")
            {
                Type2 = null;
            }
            else
            {
                Type2 = type2.SelectedItem.ToString();
            }

            //On crée un pokémon avec les information du formulaire
            MyPokemon pokemon = new MyPokemon
            {
               Nom = nom.Text,
               Type = type.SelectedItem.ToString(),
               Type2 = Type2,
               CouleurType=CouleurPrincipalPokemon(type.SelectedItem.ToString()),
               Description = description.Text,
               HP = (int)hp.Value,
               ATK = (int)atk.Value,
               DEF = (int)def.Value,
               SATK = (int)satk.Value,
               SDEF = (int)sdef.Value,
           };
            pokemon.Image = this.Image == null ? currentPokemon.Image : this.Image.Path;

            //Message pop-ip nous indiquant 
            await DisplayAlert("Pokemon ajouté : ", nom.Text + " " , "OK");
            await pokemonDB.SaveItemAsync(pokemon); 
            vm.addPokemon(pokemon);

            //On redirige vers la page "list"
            await Shell.Current.GoToAsync($"//List", true);

            //On réinitialise le formulaire
            RenitializeValue();
        }

        //Méthode qui permet de remettre à 0 le formulaire
        public void RenitializeValue()
        {
            nom.Text = null;
            type.SelectedItem = "NORMAL";
            type2.SelectedItem = "AUCUN";
            description.Text = null;
            hp.Value = 1;
            atk.Value = 1;
            satk.Value = 1;
            sdef.Value = 1;
            def.Value = 1;
            imagePicker.Source = "image.png";
        }

        //Méthode permettant de trouver la couleur en fonction du type du pokémon
        public string CouleurPrincipalPokemon(string Type)
        {
            switch (Type)
            {
                case "Normal": return "#ADA594";
                case "Poison": return "#B55AA5";
                case "Plante": return "#7BCE52";
                case "Psy": return "#FF73A5";
                case "Sol": return "#D6B55A";
                case "Glace": return "#5ACEE7";
                case "Feu": return "#F75231";
                case "Roche": return "#BDA55A";
                case "Dragon": return "#8858F6";
                case "Eau": return "#399CFF";
                case "Insecte": return "#ADBD21";
                case "Tenebre": return "#735A4A";
                case "Combat": return "#A55239";
                case "Spectre": return "#6363B5";
                case "Acier": return "#ADADC6";
                case "Vol": return "#9CADF7";
                case "Electrik": return "#FFC631";
                case "Fee": return "#E09AE3";
                default: return null;
            }
        }

        //Méthode permettant de choisir une photo dans sa galerie
        private async void OnPickImageClick(object sender, EventArgs args)
        {
            this.Image = await CrossMedia.Current.PickPhotoAsync();

            if (this.Image == null) return;

            imagePicker.Source = ImageSource.FromStream(() => this.Image.GetStream());
        }

    }
}