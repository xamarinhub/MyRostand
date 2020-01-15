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
        Frame menuStack = new Frame();
        Label jourChoisi = new Label() { FontSize = 20 };
        Label jourEntree = new Label() { FontSize = 20 };
        Label jourViande = new Label() { FontSize = 20 };
        Label jourAccompagnement = new Label() { FontSize = 20 };
        Label jourLaitage = new Label() { FontSize = 20 };
        Label jourDesserts = new Label() { FontSize = 20 };
        Button joursEntree = new Button();
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
            barJours.Margin = new Thickness(10, 10, 10, 30);

            ScrollView scroll = new ScrollView();

            ScrollView horizontalScroll = new ScrollView()
            {
                Orientation = ScrollOrientation.Horizontal,
                HeightRequest = 120,
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
                    nummois = "01";
                }
                else if (nummois == "2")
                {
                    nommois = "Février";
                    nummois = "02";
                }
                else if (nummois == "3")
                {
                    nommois = "Mars";
                    nummois = "03";
                }
                else if (nummois == "4")
                {
                    nommois = "Avril";
                    nummois = "04";
                }
                else if (nummois == "5")
                {
                    nommois = "Mai";
                    nummois = "05";
                }
                else if (nummois == "6")
                {
                    nommois = "Juin";
                    nummois = "06";
                }
                else if (nummois == "7")
                {
                    nommois = "Juillet";
                    nummois = "07";
                }
                else if (nummois == "9")
                {
                    nommois = "Septembre";
                    nummois = "09";
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
                string daterequete = DateTime.Today.Year + "-" + nummois + "-" + numjour;
                if (libelleJour == "Dimanche" | libelleJour == "Samedi")
                {
                    Button boutonferme = new Button()
                    {
                        Margin = new Thickness(1, 1, 1, 1),
                        BackgroundColor = Color.Gray,
                        BorderColor = Color.Black,
                        BorderWidth = 2,
                        CornerRadius = 10,
                        Text = jourcomplet,
                        StyleId = daterequete,
                        IsVisible = true,
                        TextColor = Color.White,
                    };
                    jourScroll.Children.Add(boutonferme);
                }
                else
                {
                    Button bouton = new Button()
                    {
                        Margin = new Thickness(1, 1, 1, 1),
                        BackgroundColor = Color.FromHex("#27ae60"),
                        BorderColor = Color.GhostWhite,
                        BorderWidth = 2,
                        CornerRadius = 10,
                        Text = jourcomplet,
                        StyleId = daterequete,
                        IsVisible = true,
                        TextColor = Color.White,
                    };


                    bouton.Clicked += Bouton_Clicked; //QUAND ON CLIQUE, ON AFFICHE LE MENU

                    jourScroll.Children.Add(bouton);
                }
                ancienneDate = ancienneDate.AddDays(1);

            }

            horizontalScroll.Content = jourScroll;
            barJours.Children.Add(horizontalScroll);

            /*==================================================*/
            /*=============AFFICHAGE DU MENU====================*/
            /*==================================================*/

            menuStack.IsVisible = false; //SI ON CLIQUE SUR UN JOUR ON PASSE A TRUE (voir la fonction clicked)

            //IL FAUT FAIRE LE RESTE !   

            ScrollView VerticalScroll = new ScrollView()
            {
                Orientation = ScrollOrientation.Vertical,
                HeightRequest = 1800,
            };

            StackLayout MenuScroll = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal
            };
            VerticalScroll.Content = menuStack;

            async void Bouton_Clicked(object sender, EventArgs e)
            {
                //cette variable sert à récupérer le jour en question, et afficher les menus correspondants
                string jourcomplet = ((Button)sender).Text;
                string daterequete = ((Button)sender).StyleId;
                menuStack.IsVisible = true;


                //FRAME PRINCIPAL QUI RECUPERE TOUTE LES CARDS
                Frame frameMenu = new Frame();

                //STACKLAYOUT QUI SERA LE CONTENU DE FRAMEMENU
                StackLayout stackCardMenu = new StackLayout();

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

                titreEntree.Children.Add(titre2);
                stackCardEntree.Children.Add(titreEntree);
                frameEntree.Content = stackCardEntree;
                //STACKCARDMENU recupère cette card
                stackCardMenu.Children.Add(frameEntree);

                ////////////////////////////////////////////////////////////////////////////////////////

                jourEntree.Text = $"";

                List<Entree> lesEntrees = Database.MyCantineSQL.getLesEntrees(daterequete);

                for (int i = 0; i < lesEntrees.Count; i++)
                {
                    Entree uneEntree = lesEntrees[i];

                    StackLayout stackCardEntree2 = new StackLayout();

                    Button boutonEntree = new Button
                    {
                        TextColor = Color.White,
                        Margin = new Thickness(120, 5, 120, 5),
                        Text = uneEntree.Libelle + "\n",
                        FontSize = 10
                    };

                    stackCardEntree2.Children.Add(boutonEntree);

                    stackCardMenu.Children.Add(stackCardEntree2);

                };

                ////////////////////////////////////////////////////////////////////////////////////////
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


                titreViande.Children.Add(titre3);
                stackCardViande.Children.Add(titreViande);
                frameViande.Content = stackCardViande;
                //STACKCARDMENU recupère cette card
                stackCardMenu.Children.Add(frameViande);

                ////////////////////////////////////////////////////////////
                jourViande.Text = $"";

                List<Resistance> lesResistances = Database.MyCantineSQL.getlesResistances(daterequete);
                for (int i = 0; i < lesResistances.Count; i++)
                {
                    Resistance uneResistance = lesResistances[i];
                    StackLayout stackCardResistance = new StackLayout();

                    Button boutonResistance = new Button
                    {
                        TextColor = Color.White,
                        Margin = new Thickness(120, 5, 120, 5),
                        Text = uneResistance.Libelle + "\n",
                        FontSize = 10
                    };

                    stackCardResistance.Children.Add(boutonResistance);

                    stackCardMenu.Children.Add(stackCardResistance);
                }
                ////////////////////////////////////////////////////////////////////////////////////////
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
                titreAccompagnement.Children.Add(titre4);
                stackCardAccompagnement.Children.Add(titreAccompagnement);
                frameAccompagnement.Content = stackCardAccompagnement;
                //STACKCARDMENU recupère cette card
                stackCardMenu.Children.Add(frameAccompagnement);

                jourAccompagnement.Text = $"";
                List<Accompagnement> lesAccompagnements = Database.MyCantineSQL.getlesAccompagnements(daterequete);
                for (int i = 0; i < lesAccompagnements.Count; i++)
                {
                    Accompagnement unAccompagnement = lesAccompagnements[i];
                    StackLayout stackCardAccompagnement2 = new StackLayout();

                    Button boutonAccompagnement = new Button
                    {
                        TextColor = Color.White,
                        Margin = new Thickness(120, 5, 120, 5),
                        Text = unAccompagnement.Libelle + "\n",
                        FontSize = 10
                    };

                    stackCardAccompagnement2.Children.Add(boutonAccompagnement);

                    stackCardMenu.Children.Add(stackCardAccompagnement2);
                }

                ////////////////////////////////////////////////////////////////////////////////////////
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

                titreLaitage.Children.Add(titre5);
                stackCardLaitage.Children.Add(titreLaitage);
                frameLaitage.Content = stackCardLaitage;
                //STACKCARDMENU recupère cette card
                stackCardMenu.Children.Add(frameLaitage);

                jourLaitage.Text = $"";
                List<Laitage> lesLaitages = Database.MyCantineSQL.getlesLaitages(daterequete);
                for (int i = 0; i < lesLaitages.Count; i++)
                {
                    Laitage unLaitage = lesLaitages[i];
                    StackLayout stackCardALaitage = new StackLayout();

                    Button boutonLaitage = new Button
                    {
                        TextColor = Color.White,
                        Margin = new Thickness(120, 5, 120, 5),
                        Text = unLaitage.Libelle + "\n",
                        FontSize = 10
                    };

                    stackCardALaitage.Children.Add(boutonLaitage);

                    stackCardMenu.Children.Add(stackCardALaitage);
                }
                ////////////////////////////////////////////////////////////////////////////////////////
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

                titreDessert.Children.Add(titre6);
                stackCardDessert.Children.Add(titreDessert);
                frameDessert.Content = stackCardDessert;
                //STACKCARDMENU recupère cette card
                stackCardMenu.Children.Add(frameDessert);
                /*------------------------------------------*/
                jourDesserts.Text = $"";
                List<Dessert> lesDesserts = Database.MyCantineSQL.getLesDesserts(daterequete);
                for (int i = 0; i < lesDesserts.Count; i++)
                {
                    Dessert unDessert = lesDesserts[i];
                    StackLayout stackCardDessert2 = new StackLayout();

                    Button boutonDessert = new Button
                    {
                        TextColor = Color.White,
                        Margin = new Thickness(120, 5, 120, 5),
                        Text = unDessert.Libelle + "\n",
                        FontSize = 10
                    };

                    stackCardDessert2.Children.Add(boutonDessert);

                    stackCardMenu.Children.Add(stackCardDessert2);
                }
                ////////////////////////////////////////////////////////////////////////////////////////
                //FRAMEMENU RECUPERE STACKCARDMENU QUI LUI MEME RECUPERE TOUTE LES CARD ET ITEMS DU MENU
                frameMenu.Content = stackCardMenu;

                //ET DONC LE CONTENU ACTUEL DE MENUSTACK EST REMPLACE PAR CE FRAMEMENU MIS A JOUR
                menuStack.Content = frameMenu;
            }

            /*==================================================*/
            /*==================================================*/

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
            stackPrincipal.Children.Add(VerticalScroll);
            stackPrincipal.Children.Add(Cuisto);
            Content = stackPrincipal;

            ////////////////////////////////////////////////////////////////////////////////////////
        }

    }
}