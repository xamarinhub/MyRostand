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
            List<User> LeUser = Database.MyCantineSQL.UnUser(id);
            for (int i = 0; i < LeUser.Count; i++)
            {
                User UnUser = LeUser[i];
                nom = UnUser.Nom;
                prenom = UnUser.Prenom;
                bio = UnUser.Bio;
                telephone = UnUser.Telephone;
                
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
            var MyEntryTel = new Entry { Text = "", Placeholder = telephone + "  " };

            Layout1.Children.Add(labelNom);
            Layout1.Children.Add(MyEntryNom);

            Layout2.Children.Add(labelPrenom);
            Layout2.Children.Add(MyEntryPrenom);

            Layout3.Children.Add(labelBio);
            Layout3.Children.Add(MyEntryBio);

            Layout4.Children.Add(labelTel);
            Layout4.Children.Add(MyEntryTel);

            this.Content = new StackLayout
            {
                Children =
                {
                    Layout1,
                    Layout2,
                    Layout3,
                    Layout4

                }
            };
        }
    }
}