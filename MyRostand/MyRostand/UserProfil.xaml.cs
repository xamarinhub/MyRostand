using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRostand.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyRostand
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserProfil : ContentPage
    {
        public UserProfil()
        {
            InitializeComponent();
            var value = Application.Current.Properties["AppUser"];
            String id = value.ToString();
            String nom = "";
            String prenom = "";
            String bio = "";
            String telephone = "";           
            var datenaissance = new DateTime(2008, 3, 1, 7, 0, 0);
            String mail = "";
            String rue = "";
            String codpost = "";
            String ville = "";
            String mdp = "";
            String rolelibelle = "";
            List<User> LeUser = Database.MyCantineSQL.UnUser(id);
            for (int i = 0; i < LeUser.Count; i++)
            {
                User UnUser = LeUser[i];
                nom = UnUser.Nom;
                prenom = UnUser.Prenom;
                bio = UnUser.Bio;
                telephone = UnUser.Telephone;
                datenaissance = UnUser.DateNaissance;
                mail = UnUser.Mail;
                rue = UnUser.Rue;
                codpost = UnUser.CodePostal;
                ville = UnUser.Ville;
                mdp = UnUser.MDP;
                rolelibelle = UnUser.Rolelibelle;
            }
            
            StackLayout Layout1 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };

            var labelNom = new Label
            {
                Text = " Nom : ",
                FontSize = 30
            };
            var MyEntryNom = new Entry { Text = "", Placeholder = nom + "" };

            StackLayout Layout2 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };

            var labelPrenom = new Label
            {
                Text = " Prenom : ",
                FontSize = 30
            };
            var MyEntryPrenom = new Entry { Text = "", Placeholder = prenom + "" };

            StackLayout Layout3 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };

            var labelBio = new Label
            {
                Text = " Bio : ",
                FontSize = 30
            };
            var MyEntryBio = new Entry { Text = "", Placeholder = bio + "             " };

            StackLayout Layout4 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };

            var labelTel= new Label
            {
                Text = " Telephone : ",
                FontSize = 30
            };
            var MyEntryTel = new Entry { Text = "", Placeholder = telephone + "  " , FontSize = 30, Keyboard = Keyboard.Numeric };

            StackLayout Layout5 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };
            var labelDateN = new Label
            {
                Text = " Date de Naissance : ",
                FontSize = 25
            };
            
            var MyEntryDateN = new DatePicker { FontSize = 25, Date = datenaissance };

            StackLayout Layout6 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };
            var labelEMAIL = new Label
            {
                Text = " Adresse Mail : ",
                FontSize = 25
            };

            var MyEntryEMAIL = new Entry { Text = "", Placeholder = mail + "  ", FontSize = 30, IsEnabled = false };

            StackLayout Layout7 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };
            var labelRUE = new Label
            {
                Text = " Rue : ",
                FontSize = 25
            };

            var MyEntryRue = new Entry { Text = "", Placeholder = rue + "  ",};

            StackLayout Layout8 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };
            var labelCP = new Label
            {
                Text = " Code Postal : ",
                FontSize = 25
            };

            var MyEntryCP= new Entry { Text = "", Placeholder = codpost + "  ", FontSize = 30};

            StackLayout Layout9 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };
            var labelVILLE = new Label
            {
                Text = " Ville : ",
                FontSize = 25
            };

            var MyEntryVILLE = new Entry { Text = "", Placeholder = ville + "  ", FontSize = 30};
            
            StackLayout Layout10 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };
            var labelMDP = new Label
            {
                Text = " Mot de passe : ",
                FontSize = 25
            };

            var MyEntryMDP = new Entry { Text = "", Placeholder = " ****************** ", FontSize = 30, IsPassword = true};
            Button boutonMDP = new Button()
            {
                Margin = new Thickness(1, 1, 1, 1),
                BackgroundColor = Color.FromHex("#27ae60"),
                BorderColor = Color.GhostWhite,
                BorderWidth = 2,
                CornerRadius = 10,
                Text = "Afficher",
                IsVisible = true,
                TextColor = Color.White,
            };
            boutonMDP.Clicked += Afficher;
            async void Afficher(object sender, EventArgs e)
            {
                if (MyEntryMDP.Placeholder ==  mdp)
                {
                    MyEntryMDP.Placeholder = " ****************** ";
                }
                else
                {
                    MyEntryMDP.Placeholder = mdp;
                }
            }

            StackLayout Layout11 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };
            var labelROLE = new Label
            {
                Text = "  Votre role : ",
                FontSize = 25
            };
            var MyEntryROLE = new Entry { Text = "", Placeholder = rolelibelle + "  ", FontSize = 30, IsEnabled = false };

            Layout1.Children.Add(labelNom);
            Layout1.Children.Add(MyEntryNom);

            Layout2.Children.Add(labelPrenom);
            Layout2.Children.Add(MyEntryPrenom);

            Layout3.Children.Add(labelBio);
            Layout3.Children.Add(MyEntryBio);

            Layout4.Children.Add(labelTel);
            Layout4.Children.Add(MyEntryTel);

            Layout5.Children.Add(labelDateN);
            Layout5.Children.Add(MyEntryDateN);

            Layout6.Children.Add(labelEMAIL);
            Layout6.Children.Add(MyEntryEMAIL);

            Layout7.Children.Add(labelRUE);
            Layout7.Children.Add(MyEntryRue);
            
            Layout8.Children.Add(labelCP);
            Layout8.Children.Add(MyEntryCP);

            Layout9.Children.Add(labelVILLE);
            Layout9.Children.Add(MyEntryVILLE);

            Layout10.Children.Add(labelMDP);
            Layout10.Children.Add(MyEntryMDP);
            Layout10.Children.Add(boutonMDP);

            Layout11.Children.Add(labelROLE);
            Layout11.Children.Add(MyEntryROLE);

            Button bouton = new Button()
            {
                Margin = new Thickness(1, 1, 1, 1),
                BackgroundColor = Color.FromHex("#27ae60"),
                BorderColor = Color.GhostWhite,
                BorderWidth = 2,
                CornerRadius = 10,
                Text = "Validation",
                IsVisible = true,
                TextColor = Color.White,
            };
            bouton.Clicked += Validation;
            async void Validation(object sender, EventArgs e)
            { 
            }

                this.Content = new StackLayout
            {
                Children =
                {
                    Layout1,
                    Layout2,
                    Layout3,
                    Layout4,
                    Layout5,
                    Layout6,
                    Layout7,
                    Layout8,
                    Layout9,
                    Layout10,
                    Layout11,
                    bouton

                }
            };
        }
    }
}