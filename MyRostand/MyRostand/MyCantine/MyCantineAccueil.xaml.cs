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
        Label notificationJour = new Label() { FontSize = 20 };
        Button joursEntree = new Button();
        Button AnnulerReservation;
        Button Nevienspas;
        CheckBox checkBoxAccompagnement = new CheckBox { IsChecked = true };
        int idutilisateur = 1;
        bool RepasDejaReserve = false;

        DateTime ancienneDate = DateTime.Today;
        DateTime lendemainDate = DateTime.Today.AddDays(1);
        DateTime WeekenDate = DateTime.Today.AddDays(3);
        private bool boutonlaitageClicked;

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
            Image LogoAccueil = new Image()
            {
                Source = ""
            };

            string numjour;
            string nummois;
            string nommois = "";
            string libelleJour = "";
            string numlendemain;
            string nummoislendemain;
            string numweekend;
            string nummoisweekend;


            for (int i = 1; i <= 14; i++)
            {
                numjour = $"{ancienneDate.Day}";
                nummois = $"{ancienneDate.Month}";
                libelleJour = $"{ ancienneDate.DayOfWeek }";
                numlendemain = $"{lendemainDate.Day}";
                nummoislendemain = $"{lendemainDate.Month}";
                numweekend = $"{WeekenDate.Day}";
                nummoisweekend = $"{WeekenDate.Month}";

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
                string datecount = DateTime.Today.Year + "-" + nummoislendemain + "-" + numlendemain;
                string datecountweekend = DateTime.Today.Year + "-" + nummoisweekend + "-" + numweekend;


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
                        ClassId = datecount,
                        AutomationId = datecountweekend,
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
                        ClassId = datecount,
                        AutomationId = datecountweekend,
                        IsVisible = true,
                        TextColor = Color.White,
                    };


                    bouton.Clicked += Bouton_Clicked; //QUAND ON CLIQUE, ON AFFICHE LE MENU

                    jourScroll.Children.Add(bouton);
                }
                ancienneDate = ancienneDate.AddDays(1);
                lendemainDate = lendemainDate.AddDays(1);
                WeekenDate = WeekenDate.AddDays(1);

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
                LogoAccueil.IsVisible = false;
                //cette variable sert à récupérer le jour en question, et afficher les menus correspondants
                string jourcomplet = ((Button)sender).Text;
                string daterequete = ((Button)sender).StyleId;
                string datecount = ((Button)sender).ClassId;
                string datecountweekend = ((Button)sender).AutomationId;
                int idrepas = Database.MyCantineSQL.getIdRepas(daterequete);
                int idReservationMenu = Database.MyCantineSQL.getIdReservationMenu(idrepas);
                bool RepasDejaReserve =  Database.MyCantineSQL.getStatutReserver(daterequete, idutilisateur);

                //FRAME PRINCIPAL QUI RECUPERE TOUTE LES CARDS
                Frame frameMenu = new Frame();

                //STACKLAYOUT QUI SERA LE CONTENU DE FRAMEMENU
                StackLayout stackCardMenu = new StackLayout();

                menuStack.IsVisible = true;

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
                        Margin = new Thickness(120, 10, 120, 10),
                        Padding = new Thickness(0, 10, 0, -10),
                        BackgroundColor = Color.LightGray,
                        Text = uneEntree.Libelle + "\n",
                        FontSize = 16
                    };

                    stackCardEntree2.Children.Add(boutonEntree);

                    stackCardMenu.Children.Add(stackCardEntree2);
                    string textbouton = boutonEntree.Text;
                    boutonEntree.Clicked += boutonEntree_Click;
                    async void boutonEntree_Click(object senders, EventArgs ex)
                    {
                        if (boutonEntree.BackgroundColor == Color.LightGray)
                        {
                            string textuncheck = textbouton;
                            boutonEntree.BackgroundColor = Color.LightGreen;
                            boutonEntree.Text = "vide";
                            boutonEntree.Text = textuncheck + "✓";
                        }
                        else 
                        {
                            string textchecked = textbouton;
                            boutonEntree.BackgroundColor = Color.LightGray;
                            boutonEntree.Text = "vide2";
                            boutonEntree.Text = textchecked + "";
                        }
                    }

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
                    Margin = new Thickness(100, 20, 100, 10),
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
                    Text = "Plats",
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
                List<Resistance> lesResistancesNotifDate = Database.MyCantineSQL.getlesResistances(datecount);
                List<Resistance> lesResistancesNotifDateWeekEnd = Database.MyCantineSQL.getlesResistances(datecountweekend);
                int ViandeC = lesResistancesNotifDate.Count;
                int ViandeCWE = lesResistancesNotifDateWeekEnd.Count;
                for (int i = 0; i < lesResistances.Count; i++)
                {
                    Resistance uneResistance = lesResistances[i];
                    StackLayout stackCardResistance = new StackLayout();

                    Button boutonResistance = new Button
                    {
                        TextColor = Color.White,
                        Margin = new Thickness(120, 10, 120, 10),
                        Padding = new Thickness(0, 10, 0, -10),
                        BackgroundColor = Color.LightGray,
                        Text = uneResistance.Libelle + "\n",
                        FontSize = 16
                    };
                    int idresistance = uneResistance.Id;
                    stackCardResistance.Children.Add(boutonResistance);
                    string textbouton = boutonResistance.Text;
                    stackCardMenu.Children.Add(stackCardResistance);

                    boutonResistance.Clicked += boutonResistance_Click;
                    async void boutonResistance_Click(object senders, EventArgs ex)
                    {
                        if (boutonResistance.BackgroundColor == Color.LightGray)
                        {
                            string textuncheck = textbouton;
                            string DateToday = DateTime.Today.Year + "-" + nummois + "-" + DateTime.Today.Day;
                            boutonResistance.BackgroundColor = Color.LightGreen;
                            boutonResistance.Text = "vide";
                            boutonResistance.Text = textuncheck + "✓";
                            if (daterequete != DateToday)
                            {
                                Database.MyCantineSQL.AjouterResistance(idrepas, idReservationMenu, idresistance, idutilisateur);
                            }
                        }
                        else
                        {
                            string textchecked = textbouton;
                            boutonResistance.BackgroundColor = Color.LightGray;
                            boutonResistance.Text = "vide2";
                            boutonResistance.Text = textchecked + "";
                            string DateToday = DateTime.Today + "-" + DateTime.Today.Month;
                            if (daterequete != DateToday)
                            {
                                Database.MyCantineSQL.SupprimerResistance(idrepas, idReservationMenu, idutilisateur);
                            }
                        }
                    }
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
                    Margin = new Thickness(100, 20, 100, 10),
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
                List<Accompagnement> NotifDate = Database.MyCantineSQL.getlesAccompagnements(datecount);
                List<Accompagnement> NotifDateWeekEnd = Database.MyCantineSQL.getlesAccompagnements(datecountweekend);
                int AccompC = NotifDate.Count;
                int AccompCWE = NotifDateWeekEnd.Count;
                for (int i = 0; i < lesAccompagnements.Count; i++)
                {
                    Accompagnement unAccompagnement = lesAccompagnements[i];
                    StackLayout stackCardAccompagnement2 = new StackLayout();

                    Button boutonAccompagnement = new Button
                    {
                        TextColor = Color.White,
                        Margin = new Thickness(120, 10, 120, 10),
                        Padding = new Thickness(0, 10, 0, -10),
                        BackgroundColor = Color.LightGray,
                        Text = unAccompagnement.Libelle + "\n",
                        FontSize = 16
                    };
                    int idaccompagnement = unAccompagnement.Id;
                    stackCardAccompagnement2.Children.Add(boutonAccompagnement);
                    string textbouton = boutonAccompagnement.Text;
                    stackCardMenu.Children.Add(stackCardAccompagnement2);

                    boutonAccompagnement.Clicked += boutonAccompagnement_Click;
                    async void boutonAccompagnement_Click(object senders, EventArgs ex)
                    {
                        if (boutonAccompagnement.BackgroundColor == Color.LightGray)
                        {
                            string textuncheck = textbouton;
                            boutonAccompagnement.BackgroundColor = Color.LightGreen;
                            boutonAccompagnement.Text = "vide";
                            boutonAccompagnement.Text = textuncheck + "✓";
                            string DateToday = DateTime.Today.Year + "-" + nummois + "-" + DateTime.Today.Day;
                            if (daterequete != DateToday)
                            {
                                Database.MyCantineSQL.AjouterAccompagnement(idReservationMenu, idaccompagnement);
                            }
                        }
                        else
                        {
                            string textchecked = textbouton;
                            boutonAccompagnement.BackgroundColor = Color.LightGray;
                            boutonAccompagnement.Text = "vide2";
                            boutonAccompagnement.Text = textchecked + "";
                            string DateToday = DateTime.Today.Year + "-" + nummois + "-" + DateTime.Today.Day;
                            if (daterequete != DateToday)
                            {
                                Database.MyCantineSQL.SupprimerAccompagnement(idReservationMenu, idaccompagnement);
                            }
                        }
                    }
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
                    Margin = new Thickness(100, 20, 100, 10),
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
                        Margin = new Thickness(120, 10, 120, 10),
                        Padding = new Thickness(0, 10, 0, -10),
                        BackgroundColor = Color.LightGray,
                        Text = unLaitage.Libelle + "\n",
                        FontSize = 16

                    };
                    string textbouton = boutonLaitage.Text;
                    boutonLaitage.Clicked += boutonlaitage_Click;
                    stackCardALaitage.Children.Add(boutonLaitage);
                    stackCardMenu.Children.Add(stackCardALaitage);
                    
                    async void boutonlaitage_Click(object senders, EventArgs ex)
                    {
                        if (boutonLaitage.BackgroundColor == Color.LightGray)
                        {
                            string textuncheck = textbouton;
                            boutonLaitage.BackgroundColor = Color.LightGreen;
                            boutonLaitage.Text = "vide";
                            boutonLaitage.Text = textuncheck + "✓";
                        }
                        else
                        {
                            string textchecked = textbouton;
                            boutonLaitage.BackgroundColor = Color.LightGray;
                            boutonLaitage.Text = "vide2";
                            boutonLaitage.Text = textchecked + "";
                        }
                    }

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
                    Margin = new Thickness(100, 20, 100, 10),
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
                        Margin = new Thickness(120, 10, 120, 10),
                        Padding = new Thickness(0, 10, 0, -10),
                        BackgroundColor = Color.LightGray,
                        Text = unDessert.Libelle + "\n",
                        FontSize = 16
                    };

                    stackCardDessert2.Children.Add(boutonDessert);
                    string textbouton = boutonDessert.Text;
                    stackCardMenu.Children.Add(stackCardDessert2);

                    boutonDessert.Clicked += boutonDessert_Click;
                    async void boutonDessert_Click(object senders, EventArgs ex)
                    {
                        if (boutonDessert.BackgroundColor == Color.LightGray)
                        {
                            string textuncheck = textbouton;
                            boutonDessert.BackgroundColor = Color.LightGreen;
                            boutonDessert.Text = "vide";
                            boutonDessert.Text = textuncheck + "✓";
                        }
                        else
                        {
                            string textchecked = textbouton;
                            boutonDessert.BackgroundColor = Color.LightGray;
                            boutonDessert.Text = "vide2";
                            boutonDessert.Text = textchecked + "";
                        }
                    }
                }
                ////////////////////////////////////////////////////////////////////////////////////////
                ///

                /*-------------------------------------------------------*/
                /*---------------------ANNULATION----------------------*/
                /*-------------------------------------------------------*/
                StackLayout stackCardAnnulation = new StackLayout();

                Frame frameAnnulation = new Frame()
                {
                    CornerRadius = 10,
                    BackgroundColor = Color.Crimson,
                    BorderColor = Color.Crimson,
                    Margin = new Thickness(100, 0, 100, 20),
                    Padding = new Thickness(0, 0, 0, 0)
                };
                StackLayout titreAnnulation = new StackLayout()
                {
                    HorizontalOptions = LayoutOptions.Fill,
                    BackgroundColor = Color.Crimson,
                    HeightRequest = 35,
                    Padding = new Thickness(0, 10, 0, 0)
                };
                Label titre7 = new Label()
                {
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    Text = "ACTIONS",
                    FontSize = 20,
                    TextColor = Color.AntiqueWhite
                };


                /*-------------------------------------------------------*/
                /*---CONDITION SI REPAS DEJA RESERVE---------------------*/
                /*-------------------------------------------------------*/
                Button AnnulerReservation;
                Button Nevienspas;
                if (RepasDejaReserve == false)
                {
                    Database.MyCantineSQL.AjouterReservationMenu(idrepas, idutilisateur);
                }
                else
                {
                    string DateToday = DateTime.Today.Year + "-" + "01" + "-" + DateTime.Today.Day;
                    if (daterequete != DateToday)
                    {
                        AnnulerReservation = new Button()
                        {
                            Text = "Annuler ma réservation",
                            TextColor = Color.Red,
                            BackgroundColor = Color.LightGray,
                            FontSize = 16
                        };
                        Nevienspas = new Button()
                        {
                            Text = "Je ne viendrais pas au self ce jour.",
                            TextColor = Color.Red,
                            BackgroundColor = Color.LightGray,
                            FontSize = 16
                        };
                        titreAnnulation.Children.Add(titre7);
                        stackCardAnnulation.Children.Add(titreAnnulation);
                        frameAnnulation.Content = stackCardAnnulation;
                        stackCardMenu.Children.Add(frameAnnulation);
                        stackCardAnnulation.Children.Add(AnnulerReservation);
                        stackCardAnnulation.Children.Add(Nevienspas);
                        AnnulerReservation.Clicked += AnnulerReservation_Clicked;
                        Nevienspas.Clicked += Nevienspas_Clicked;
                    }
                }
                async void AnnulerReservation_Clicked(object senders, EventArgs ex)
                {
                    AnnulerReservation.Text = "Annulation de votre réservation avec succès !";
                    AnnulerReservation.TextColor = Color.Green;
                    AnnulerReservation.BorderColor = Color.Green;
                    Database.MyCantineSQL.AnnulerReservationMenu(idrepas, idReservationMenu, idutilisateur);
                    stackCardAnnulation.Children.Remove(AnnulerReservation);
                }

                async void Nevienspas_Clicked(object senders, EventArgs ex)
                {
                    if (Nevienspas.BackgroundColor == Color.LightGray)
                    {
                        Nevienspas.BackgroundColor = Color.LightGoldenrodYellow;
                        Database.MyCantineSQL.NonPresent(idrepas, idutilisateur);
                        Nevienspas.Text = "Je viendrais au self ce jour.";
                    }
                    else
                    {
                        Nevienspas.BackgroundColor = Color.LightGray;
                        Database.MyCantineSQL.Present(idrepas, idutilisateur);
                        Nevienspas.Text = "Je ne viendrais pas au self ce jour.";
                    }
                }


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

            //////////////////////////////////////////////////////////////////////////////////

            stackPrincipal.Children.Add(Selectionjour);
            stackPrincipal.Children.Add(barJours);
            stackPrincipal.Children.Add(LogoAccueil);
            stackPrincipal.Children.Add(VerticalScroll);
            Content = stackPrincipal;

            ////////////////////////////////////////////////////////////////////////////////////////
        }

    }
}