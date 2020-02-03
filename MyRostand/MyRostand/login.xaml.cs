using MyRostand.Models;
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
        StackLayout menuStack = new StackLayout();
        StackLayout menuStack2 = new StackLayout();
        public login()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            StackLayout stackPrincipal = new StackLayout()
            {
                Margin = new Thickness(30,20,30,0)
            };
            Image LogoAccueil = new Image()
            {
                Source = "myrostandaccueil.jpg"
            };

            StackLayout stackForm = new StackLayout();

            Frame frameInformation = new Frame()
            {
                CornerRadius = 10,
                BorderColor = Color.FromHex("#27ae60"),
                Margin = new Thickness(100, 20, 100, 20),
                Padding = new Thickness(0, 10, 0, 10),
            };
            StackLayout titreInformation = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.Fill,
                BackgroundColor = Color.FromHex("#27ae60"),
                HeightRequest = 35,
            };
            Label titre2 = new Label()
            {
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                Text = "Informations",
                FontSize = 20,
                TextColor = Color.White
            };
            Label descriptionInformation = new Label()
            {
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                Text = "Pour vous connecter, veuillez utiliser votre adresse mail et votre mot de passe fourni par l'établissement " + "\n" + " Exemple : t.t@t.t MDP: TEST",
                FontSize = 15,
                BackgroundColor = Color.LightGray,
                TextColor = Color.White
            };

            titreInformation.Children.Add(titre2);
            stackForm.Children.Add(titreInformation);
            stackForm.Children.Add(descriptionInformation);
            frameInformation.Content = stackForm;

            StackLayout Layout1 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };
            var label1 = new Label
            {
                Text =  "Identifiant",
                FontSize = 20
            };
            var MyEntryID = new Entry { Text = "", Placeholder = "Identifiant                                                        "};
            StackLayout Layout2 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };
            var label2 = new Label
            {
                Text = "Mot de passe",
                FontSize = 20
            };           
             var MyEntryMDP = new Entry { Text = "", Placeholder = "Mot de passe                                               ", IsPassword = true };


            Button connexion = new Button()
            {
                BackgroundColor = Color.FromHex("#27ae60"),
                CornerRadius = 10,
                Text = "Se connecter",
                Margin = new Thickness(220, 10, 220, 10),
                Padding = new Thickness(0, 10, 0, 10),
                TextColor = Color.White
            };

            connexion.Clicked += Connexion_Clicked;

            async void Connexion_Clicked(object sender, EventArgs e)
            {
                String Valide = Database.MyCantineSQL.ConnexionUser(MyEntryID.Text);
                String MDP = MyEntryMDP.Text;
                if (MyEntryMDP.Text != "" && MyEntryMDP.Text != "")
                {
                    if (Valide == MDP)
                    {
                        Application.Current.Properties["AppUser"] = MyEntryID.Text;
                        await Navigation.PushAsync(new MainPage());                       
                    }
                    else
                    {
                        await Navigation.PushAsync(new login());
                    }
                }
                else
                {
                    await Navigation.PushAsync(new login());
                }


            }

            stackPrincipal.Children.Add(LogoAccueil);
            stackPrincipal.Children.Add(frameInformation);
            stackPrincipal.Children.Add(stackForm);

            Layout1.Children.Add(label1);
            Layout1.Children.Add(MyEntryID);
            menuStack.Children.Add(Layout1);

            Layout2.Children.Add(label2);
            Layout2.Children.Add(MyEntryMDP);
            menuStack2.Children.Add(Layout2);

            this.Content = new StackLayout
            {
                Children =
                {
                      stackPrincipal,
                      menuStack,
                      menuStack2,
                      connexion
                }
            };


        }

        private void Connexion_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Connexion", "Connexion réussie", "OK");
        }
    }
}