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
    [Xamarin.Forms.TypeConverter(typeof(Xamarin.Forms.KeyboardTypeConverter))]
    public partial class ModifGrammage : ContentPage
    {
        //ON DECLARE LES LABELS AU DEBUT POUR LES APPELER DANS L'ENSEMBLE DES FONCTIONS (ça sera utile pour la suite !)
        StackLayout menuStack = new StackLayout();
        Label jourAccompagnement = new Label() { FontSize = 20 };




        public ModifGrammage()
        {
            Title = "Modification des grammage de chaque accompagnements";
            StackLayout stackPrincipal = new StackLayout();


            Label header = new Label
            {
                Text = "Type d'Accompagnement",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(EntryCell)),
                HorizontalOptions = LayoutOptions.Center
            };

            String Accompagnement = "";
            int prop = 0;
            String Accompagnement2 = "";
            int prop2 = 0;
            String Accompagnement3 = "";
            int prop3 = 0;

            List<TypeAC> lesAccompagnements = Database.MyCantineSQL.getType();
            for (int i = 0; i < lesAccompagnements.Count; i++)
            {
                TypeAC unAccompagnement = lesAccompagnements[i];
                if (Accompagnement == "")
                {
                    Accompagnement = unAccompagnement.Libelle;
                    prop = unAccompagnement.Gramme;
                }
                else if (i + 1 == lesAccompagnements.Count)
                {
                    Accompagnement3 = unAccompagnement.Libelle;
                    prop3 = unAccompagnement.Gramme;
                }
                else
                {
                    Accompagnement2 = unAccompagnement.Libelle;
                    prop2 = unAccompagnement.Gramme;
                }
            }
            var MyEntry = new Entry { Text = "", Placeholder = Accompagnement + " : " + prop + " g/p", ClassId = Accompagnement, Keyboard = Keyboard.Numeric };
            var MyEntry2 = new Entry { Text = "", Placeholder = Accompagnement2 + " : " + prop2 + " g/p", ClassId = Accompagnement2, Keyboard = Keyboard.Numeric };
            var MyEntry3 = new Entry { Text = "", Placeholder = Accompagnement3 + " : " + prop3 + " g/p", ClassId = Accompagnement3, Keyboard = Keyboard.Numeric };


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
                if (MyEntry.Text != "")
                {
                    if (MyEntry2.Text != "" && MyEntry3.Text != "")
                    {
                        Database.MyCantineSQL.setUnGrammage(MyEntry.Text, Accompagnement);
                        Database.MyCantineSQL.setUnGrammage(MyEntry2.Text, Accompagnement2);
                        Database.MyCantineSQL.setUnGrammage(MyEntry3.Text, Accompagnement3);
                    }
                    else if (MyEntry2.Text != "" && MyEntry3.Text == "")
                    {
                        Database.MyCantineSQL.setUnGrammage(MyEntry.Text, Accompagnement);
                        Database.MyCantineSQL.setUnGrammage(MyEntry2.Text, Accompagnement2);
                    }
                    else if (MyEntry2.Text == "" && MyEntry3.Text != "")
                    {
                        Database.MyCantineSQL.setUnGrammage(MyEntry.Text, Accompagnement);
                        Database.MyCantineSQL.setUnGrammage(MyEntry3.Text, Accompagnement3);
                    }
                    else
                    {
                        Database.MyCantineSQL.setUnGrammage(MyEntry.Text, Accompagnement);
                    }

                }
                else if (MyEntry2.Text != "")
                {
                    if (MyEntry.Text != "" && MyEntry3.Text != "")
                    {

                        Database.MyCantineSQL.setUnGrammage(MyEntry.Text, Accompagnement);
                        Database.MyCantineSQL.setUnGrammage(MyEntry2.Text, Accompagnement2);
                        Database.MyCantineSQL.setUnGrammage(MyEntry3.Text, Accompagnement3);
                    }
                    else if (MyEntry.Text == "" && MyEntry3.Text != "")
                    {
                        Database.MyCantineSQL.setUnGrammage(MyEntry2.Text, Accompagnement2);
                        Database.MyCantineSQL.setUnGrammage(MyEntry3.Text, Accompagnement3);
                    }                  
                    else
                    {
                        Database.MyCantineSQL.setUnGrammage(MyEntry2.Text, Accompagnement2);
                    }
                }
                else if (MyEntry3.Text != "")
                {
                    if (MyEntry.Text != "" && MyEntry2.Text != "")
                    {

                        Database.MyCantineSQL.setUnGrammage(MyEntry.Text, Accompagnement);
                        Database.MyCantineSQL.setUnGrammage(MyEntry2.Text, Accompagnement2);
                        Database.MyCantineSQL.setUnGrammage(MyEntry3.Text, Accompagnement3);
                    }               
                    else
                    {
                        Database.MyCantineSQL.setUnGrammage(MyEntry3.Text, Accompagnement3);
                    }
                    
                }
                await Navigation.PushAsync(new ModifGrammage());
            }
                // Accomodate iPhone status bar.
                this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

                this.Content = new StackLayout
                {
                    Children =
                {
                        MyEntry,
                        MyEntry2,
                        MyEntry3,
                        bouton
                }
                };



        }
    }
}
        