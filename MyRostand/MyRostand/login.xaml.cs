using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyRostand
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class login : ContentPage
    {
        public login()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            StackLayout stackPrincipal = new StackLayout()
            {
                Margin = new Thickness(30,20,30,0)
            };

            StackLayout stackForm = new StackLayout();
            Entry loginEntry = new Entry()
            {
                Placeholder = "Identifiant"
            };
            Entry passwordEntry = new Entry()
            {
                Placeholder = "Mot de passe",
                IsPassword = true
            };

            Button connexion = new Button()
            {
                BackgroundColor = Color.FromHex("#27ae60"),
                CornerRadius = 10,
                Text = "Se connecter",
                TextColor = Color.White
            };

            connexion.Clicked += Connexion_Clicked;

            stackForm.Children.Add(loginEntry);
            stackForm.Children.Add(passwordEntry);
            stackForm.Children.Add(connexion);
            stackPrincipal.Children.Add(stackForm);

            Content = stackPrincipal;

        }

        private void Connexion_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Connexion", "Connexion réussie", "OK");
        }
    }
}