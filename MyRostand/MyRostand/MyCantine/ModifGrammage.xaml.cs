using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using MyRostand.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyRostand.MyCantine
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModifGrammage : ContentPage
    {
        //ON DECLARE LES LABELS AU DEBUT POUR LES APPELER DANS L'ENSEMBLE DES FONCTIONS (ça sera utile pour la suite !)
        StackLayout menuStack = new StackLayout();
        Label jourAccompagnement = new Label() { FontSize = 20 };


        List<Accompagnement> UnAccompagnements = Database.MyCantineSQL.getUnAccompagnements();



        public ModifGrammage()
        {
            Title = "Modification des grammage de chaque accompagnements";
            StackLayout stackPrincipal = new StackLayout();

            menuStack.IsVisible = true;
            /*--------------------------------------------------*/
            /*---------------------ACCOMPAGNEMENT---------------*/
            /*--------------------------------------------------*/

            StackLayout stackCardAccompagnement = new StackLayout();

            Frame frameAccompagnement = new Frame()
            {
                CornerRadius = 10,
                BorderColor = Color.FromHex("#27ae60"),
                Margin = new Thickness(100, 0, 100, 20),
                Padding = new Thickness(0, 0, 0, 0)
            };
            StackLayout titreAccompagnement = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.Fill,
                BackgroundColor = Color.FromHex("#27ae60"),
                HeightRequest = 35,
                Padding = new Thickness(0, 10, 0, 0)
            };
            Label titre4 = new Label()
            {
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                Text = "Accompagnements",
                FontSize = 20,
                TextColor = Color.White
            };

            StackLayout descAccompagnement = new StackLayout()
            {
                Padding = new Thickness(10, 0, 10, 20)
            };
            Label DescAccompagnement = new Label()
            {
                Text = jourAccompagnement.Text,
                FontSize = 20
            };

            descAccompagnement.Children.Add(jourAccompagnement);
            titreAccompagnement.Children.Add(titre4);
            stackCardAccompagnement.Children.Add(titreAccompagnement);
            stackCardAccompagnement.Children.Add(descAccompagnement);
            frameAccompagnement.Content = stackCardAccompagnement;





            
        
            jourAccompagnement.Text = $"";
            String Accompagnement = "";
            int a = 0;
            int prop = 0;
            List<Accompagnement> lesAccompagnements = Database.MyCantineSQL.getUnAccompagnements();
            for (int i = 0; i < lesAccompagnements.Count; i++)
            {
                Accompagnement unAccompagnement = lesAccompagnements[i];
                Accompagnement = unAccompagnement.Libelle;
                prop = unAccompagnement.Gramme;
                jourAccompagnement.Text += Accompagnement + ": " + prop + " g\n";
            }


            Picker picker = new Picker
            {
                Title = "Accompagnements",
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            String AccompNam = "";
            String AccompName = "";
            for (int i = 0; i < UnAccompagnements.Count; i++)
            {
                Accompagnement unAccompagnement = UnAccompagnements[i];
                AccompNam = unAccompagnement.Libelle;
                picker.Items.Add(AccompNam);
            }

            // Create BoxView for displaying picked Color
            BoxView boxView = new BoxView
            {
                WidthRequest = 150,
                HeightRequest = 150,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };


            int AccompGrame = 0;
            String Grammerequete = "";
            var MyEntry = new Entry { Text = "", Placeholder = "Poid en G"};
            picker.SelectedIndexChanged += (sender, args) =>
            {
                AccompName = picker.Items[picker.SelectedIndex];
                List<Accompagnement> Laproportion = Database.MyCantineSQL.getUnGrammage(AccompName);
                if (picker.SelectedIndex == -1)
                {
                    for (int i = 0; i < Laproportion.Count; i++)
                    {
                        Accompagnement uneProp = Laproportion[i];
                        AccompGrame = uneProp.Gramme;
                        MyEntry.Text = null;
                        MyEntry.Text += AccompGrame;
                        Grammerequete = MyEntry.Text;

                    }
                }
                else
                {
                    for (int i = 0; i < Laproportion.Count; i++)
                    {
                        Accompagnement uneProp = Laproportion[i];
                        AccompGrame = uneProp.Gramme;
                        MyEntry.Text = null;
                        MyEntry.Text += AccompGrame;
                        Grammerequete = MyEntry.Text;
                    }
                }
            };

            Button bouton = new Button()
            {
                Margin = new Thickness(1, 1, 1, 1),
                BackgroundColor = Color.FromHex("#27ae60"),
                BorderColor = Color.GhostWhite,
                BorderWidth = 2,
                CornerRadius = 10,
                Text = "Validation",
                ClassId = AccompName,
                IsVisible = true,
                TextColor = Color.White,
            };
            bouton.Clicked += Validation;

            void Validation(object sender, EventArgs e)
            {
                AccompName = picker.Items[picker.SelectedIndex];
                Database.MyCantineSQL.setUnGrammage(MyEntry.Text, AccompName);
            }



            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            menuStack.Children.Add(frameAccompagnement);
            menuStack.Children.Add(picker);
            menuStack.Children.Add(MyEntry);
            menuStack.Children.Add(bouton);


            stackPrincipal.Children.Add(menuStack);
            Content = stackPrincipal;      

       
        }

    }
}
        