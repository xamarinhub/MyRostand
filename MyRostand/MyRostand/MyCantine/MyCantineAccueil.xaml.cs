using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRostand.Database;
using MyRostand.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyRostand.MyCantine
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class MyCantineAccueil : ContentPage
    {
        //ON DECLARE LES LABELS AU DEBUT POUR LES APPELER DANS L'ENSEMBLE DES FONCTIONS (ça sera utile pour la suite !)
        StackLayout menuStack = new StackLayout();
        Label jourChoisi = new Label() { FontSize = 20 };
        Label jourEntree = new Label() { FontSize = 20 };
        Label jourViande = new Label() { FontSize = 20 };
        Label jourAccompagnement = new Label() { FontSize = 20 };
        Label jourLaitage = new Label() { FontSize = 20 };
        Label jourDesserts = new Label() { FontSize = 20 };
        CheckBox checkBoxAccompagnement = new CheckBox { IsChecked = true };


        DateTime ancienneDate = DateTime.Today;
        public MyCantineAccueil()
        {
            InitializeComponent();

            Title = "Menu de la semaine";
            StackLayout stackPrincipal = new StackLayout();

            /*==================================================*/
            /*==============NAVBAR DES JOURS====================*/
            /*==================================================*/

            StackLayout barJours = new StackLayout();

            ScrollView scroll = new ScrollView();

            ScrollView horizontalScroll = new ScrollView()
            {
                Orientation = ScrollOrientation.Horizontal,
                HeightRequest = 90,
            };

            StackLayout jourScroll = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal
            };

            for (int i = 1; i <= 14; i++)
            {
                string numjour;
                string nummois;
                string nommois = "";
                string libelleJour = "";
                numjour = $"{ancienneDate.Day}";
                nummois = $"{ancienneDate.Month}";
                libelleJour = $"{ ancienneDate.DayOfWeek }";
                /*============JOURS==============*/
                if (libelleJour == "Monday")
                {
                    libelleJour = "Lundi";
                }
                else if (libelleJour == "Tuesday")
                {
                    libelleJour = "Mardi";
                }
                else if (libelleJour == "Wednesday")
                {
                    libelleJour = "Mercredi";
                }
                else if (libelleJour == "Thursday")
                {
                    libelleJour = "Jeudi";
                }
                else if (libelleJour == "Friday")
                {
                    libelleJour = "Vendredi";
                }
                else if (libelleJour == "Saturday")
                {
                    libelleJour = "Samedi";
                }
                else
                {
                    libelleJour = "Dimanche";
                }

                /*============MOIS==============*/
                if (nummois == "1")
                {
                    nommois = "Janvier";
                }
                else if (nummois == "2")
                {
                    nommois = "Février";
                }
                else if (nummois == "3")
                {
                    nommois = "Mars";
                }
                else if (nummois == "4")
                {
                    nommois = "Avril";
                }
                else if (nummois == "5")
                {
                    nommois = "Mai";
                }
                else if (nummois == "6")
                {
                    nommois = "Juin";
                }
                else if (nummois == "7")
                {
                    nommois = "Juillet";
                }
                else if (nummois == "9")
                {
                    nommois = "Septembre";
                }
                else if (nummois == "10")
                {
                    nommois = "Octobre";
                }
                else if (nummois == "11")
                {
                    nommois = "Novembre";
                }
                else
                {
                    nommois = "Décembre";
                }
                string jourcomplet = libelleJour + "\n" + numjour + "\n" + nommois;
                Button bouton = new Button()
                {
                    Margin = new Thickness(1, 1, 1, 1),
                    BackgroundColor = Color.FromHex("#27ae60"),
                    BorderColor = Color.GhostWhite,
                    BorderWidth = 2,
                    CornerRadius = 10,
                    Text = jourcomplet,
                    IsVisible = true,
                    TextColor = Color.White,

                };
                bouton.Clicked += Bouton_Clicked; //QUAND ON CLIQUE, ON AFFICHE LE MENU

                jourScroll.Children.Add(bouton);

                ancienneDate = ancienneDate.AddDays(1);
            }
           
            horizontalScroll.Content = jourScroll;
            barJours.Children.Add(horizontalScroll);

            /*==================================================*/
            /*=============AFFICHAGE DU MENU====================*/
            /*==================================================*/

            menuStack.IsVisible = false; //SI ON CLIQUE SUR UN JOUR ON PASSE A TRUE (voir la fonction clicked)

            //IL FAUT FAIRE LE RESTE !

            /*--------------------------------------------------*/
            /*---------------------ENTRÉES----------------------*/
            /*--------------------------------------------------*/

            StackLayout stackCardEntree = new StackLayout();

            Frame frameEntree = new Frame()
            {
                CornerRadius = 10,
                BorderColor = Color.FromHex("#27ae60"),
                Margin = new Thickness(100, 20, 100, 20),
                Padding = new Thickness(0, 0, 0, 0)
            };
            StackLayout titreEntree = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.Fill,
                BackgroundColor = Color.FromHex("#27ae60"),
                HeightRequest = 35,
                Padding = new Thickness(0, 10, 0, 0)
            };
            Label titre2 = new Label()
            {
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                Text = "Entrées",
                FontSize = 20,
                TextColor = Color.White
            };

            StackLayout descEntree = new StackLayout()
            {
                Padding = new Thickness(10, 0, 10, 20)
            };
            Label DescEntree = new Label()
            {
                Text = "Ce genre d'entrées",
                FontSize = 20
            };

            descEntree.Children.Add(jourEntree);
            titreEntree.Children.Add(titre2);
            stackCardEntree.Children.Add(titreEntree);
            stackCardEntree.Children.Add(descEntree);
            frameEntree.Content = stackCardEntree;

            /*--------------------------------------------------*/
            /*--------------PLATS DE RESISTANCES ---------------*/
            /*--------------------------------------------------*/

            StackLayout stackCardViande = new StackLayout();

            Frame frameViande = new Frame()
            {
                CornerRadius = 10,
                BorderColor = Color.FromHex("#27ae60"),
                Margin = new Thickness(100, 0, 100, 20),
                Padding = new Thickness(0, 0, 0, 0)
            };
            StackLayout titreViande = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.Fill,
                BackgroundColor = Color.FromHex("#27ae60"),
                HeightRequest = 35,
                Padding = new Thickness(0, 10, 0, 0)
            };
            Label titre3 = new Label()
            {
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                Text = "Plats de résistance",
                FontSize = 20,
                TextColor = Color.White
            };

            StackLayout descViande = new StackLayout()
            {
                Padding = new Thickness(10, 0, 10, 20)
            };
            Label DescViande = new Label()
            {
                Text = "Ce genre de Plat",
                FontSize = 20
            };

            descViande.Children.Add(jourViande);
            titreViande.Children.Add(titre3);
            stackCardViande.Children.Add(titreViande);
            stackCardViande.Children.Add(descViande);
            frameViande.Content = stackCardViande;

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
                Text = jourEntree.Text,
                FontSize = 20
            };

            descAccompagnement.Children.Add(jourAccompagnement);
            titreAccompagnement.Children.Add(titre4);
            stackCardAccompagnement.Children.Add(titreAccompagnement);
            stackCardAccompagnement.Children.Add(descAccompagnement);
            frameAccompagnement.Content = stackCardAccompagnement;

            /*--------------------------------------------------*/
            /*---------------------LAITAGE----------------------*/
            /*--------------------------------------------------*/

            StackLayout stackCardLaitage = new StackLayout();

            Frame frameLaitage = new Frame()
            {
                CornerRadius = 10,
                BorderColor = Color.FromHex("#27ae60"),
                Margin = new Thickness(100, 0, 100, 20),
                Padding = new Thickness(0, 0, 0, 0)
            };
            StackLayout titreLaitage = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.Fill,
                BackgroundColor = Color.FromHex("#27ae60"),
                HeightRequest = 35,
                Padding = new Thickness(0, 10, 0, 0)
            };
            Label titre5 = new Label()
            {
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                Text = "Laitages",
                FontSize = 20,
                TextColor = Color.White
            };

            StackLayout descLaitage = new StackLayout()
            {
                Padding = new Thickness(10, 0, 10, 20)
            };
            Label description = new Label()
            {
                Text = "Ce genre de laitage",
                FontSize = 20
            };

            descLaitage.Children.Add(jourLaitage);
            titreLaitage.Children.Add(titre5);
            stackCardLaitage.Children.Add(titreLaitage);
            stackCardLaitage.Children.Add(descLaitage);
            frameLaitage.Content = stackCardLaitage;

            /*--------------------------------------------------*/
            /*---------------------DESSERT----------------------*/
            /*--------------------------------------------------*/

            StackLayout stackCardDessert = new StackLayout();

            Frame frameDessert = new Frame()
            {
                CornerRadius = 10,
                BorderColor = Color.FromHex("#27ae60"),
                Margin = new Thickness(100, 0, 100, 20),
                Padding = new Thickness(0, 0, 0, 0)
            };
            StackLayout titreDessert = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.Fill,
                BackgroundColor = Color.FromHex("#27ae60"),
                HeightRequest = 35,
                Padding = new Thickness(0, 10, 0, 0)
            };
            Label titre6 = new Label()
            {
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                Text = "Desserts",
                FontSize = 20,
                TextColor = Color.White
            };

            StackLayout descDessert = new StackLayout()
            {
                Padding = new Thickness(10, 0, 10, 20)
            };

            descDessert.Children.Add(jourDesserts);
            titreDessert.Children.Add(titre6);
            stackCardDessert.Children.Add(titreDessert);
            stackCardDessert.Children.Add(descDessert);
            frameDessert.Content = stackCardDessert;

            /*------------------------------------------*/

            menuStack.Children.Add(frameEntree);
            menuStack.Children.Add(frameViande);
            menuStack.Children.Add(frameAccompagnement);
            menuStack.Children.Add(frameLaitage);
            menuStack.Children.Add(frameDessert);

            /*==================================================*/
            /*==================================================*/
            Button reserver = new Button()
            {
                BackgroundColor = Color.FromHex("#27ae60"),
                Margin = new Thickness(120, 30, 120,0),               
                Text = "Réserver mon repas",
                FontSize = 20,
                TextColor = Color.White
            };
////////////////////////////////////////////////////////////////////////////////////////
            Label Selectionjour = new Label()
            {
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                BackgroundColor = Color.FromHex("#27ae60"),
                Margin = new Thickness(0, 0, 0, 20),
                Text = "Veuillez sélectionner un jour pour réserver votre repas",
                FontSize = 20,
                TextColor = Color.White
            };

///////////////////////////////////////////////////////////////////////////////////////
            Button Cuisto = new Button()
            {
                BackgroundColor = Color.Red,
                Margin = new Thickness(120, 10, 120, 0),
                Text = "Accès Cuisinier",
                FontSize = 20,
                TextColor = Color.White
            };

            Cuisto.Clicked += Cuisto_Clicked;

            async void Cuisto_Clicked(object sender, EventArgs e)
            {
                await Navigation.PushAsync(new ToutMenu());
            }
//////////////////////////////////////////////////////////////////////////////////


            stackPrincipal.Children.Add(Selectionjour);
            stackPrincipal.Children.Add(barJours);
            stackPrincipal.Children.Add(menuStack);
            stackPrincipal.Children.Add(reserver);
            stackPrincipal.Children.Add(Cuisto);
            Content = stackPrincipal;

    }

        private void Bouton_Clicked(object sender, EventArgs e)
        {
            //cette variable sert à récupérer le jour en question, et afficher les menus correspondants
            string jourcomplet = ((Button)sender).Text;

            menuStack.IsVisible = true;
            
            jourChoisi.Text = "Jour choisi : "+jourcomplet;

            jourEntree.Text = $"";

            List<Entree> lesEntrees = Database.MyCantineSQL.getLesEntrees();

            for (int i = 0; i < lesEntrees.Count; i++)
            {
                Entree uneEntree = lesEntrees[i];
                jourEntree.Text += uneEntree.Libelle + "\n";
            }


            jourViande.Text = $"";

            List<Resistance> lesResistances = Database.MyCantineSQL.getlesResistances();
            for (int i = 0; i < lesResistances.Count; i++)
            {
                Resistance uneResistance = lesResistances[i];
                jourViande.Text += uneResistance.Libelle + "\n";
            }

            jourAccompagnement.Text = $"";
            List<Accompagnement> lesAccompagnements = Database.MyCantineSQL.getlesAccompagnements();
            for (int i = 0; i < lesAccompagnements.Count; i++)
            {
                Accompagnement unAccompagnement = lesAccompagnements[i];
                jourAccompagnement.Text += unAccompagnement.Libelle + "\n";
            }

            jourLaitage.Text = $"";
            List<Laitage> lesLaitages = Database.MyCantineSQL.getlesLaitages();
            for (int i = 0; i < lesLaitages.Count; i++)
            {
                Laitage unLaitage = lesLaitages[i];
                jourLaitage.Text += unLaitage.Libelle + "\n";
            }

            jourDesserts.Text = $"";
            List<Dessert> lesDesserts = Database.MyCantineSQL.getLesDesserts();
            for (int i = 0; i < lesDesserts.Count; i++)
            {
                Dessert unDessert = lesDesserts[i];
                jourDesserts.Text += unDessert.Libelle + "\n";
            }
        }
       
    }
}