﻿using System;
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
        Label notificationJour = new Label() { FontSize = 20 };
        Button joursEntree = new Button();
        Button AnnulerReservation;
        Button Nevienspas;
        Button bouton;
        CheckBox checkBoxAccompagnement = new CheckBox { IsChecked = true };

        bool RepasDejaReserve = false;
        bool ResistanceReserver;
        bool AccompagnementReserver;

        DateTime ancienneDate = DateTime.Today;

        public MyCantineAccueil()
        {
            InitializeComponent();
            var value = Application.Current.Properties["IdUser"];
            int transfer = Convert.ToInt32(value);
            int idutilisateur = transfer;

            Title = "Menu de la semaine";
            StackLayout stackPrincipal = new StackLayout();

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
            int nummois;
            string nommois = "";
            string libelleJour = "";


            for (int i = 1; i <= 14; i++)
            {
                numjour = $"" + ancienneDate.Day;
                nummois = ancienneDate.Month;
                libelleJour = $"{ ancienneDate.DayOfWeek }";

                string[] LibelleJourFrancais = new string[7] { "Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi", "Samedi", "Dimanche" };
                string[] LibelleJourAnglais = new string[7] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

                for (int c = 0; c < LibelleJourFrancais.Length; c++)
                {
                    if (LibelleJourAnglais[c] == libelleJour)
                    {
                        libelleJour = LibelleJourFrancais[c];
                        break;
                    }
                }

                string[] ListeMois = new string[12] { "Janvier", "Février", "Mars", "Avril", "Mai", "Juin", "Juillet", "Aout", "Septembre", "Octobre", "Novembre", "Décembre" };
                int[] ListeNumMois = new int[12] { 01, 02, 03, 04, 05, 06, 07, 08, 09, 10, 11, 12 };
                for (int c = 0; c < ListeMois.Length; c++)
                {
                    if (c + 1 == nummois)
                    {
                        nommois = ListeMois[c];
                        nummois = ListeNumMois[c];
                        break;
                    }
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
                /*============MOIS==============*/
                DateTime DateActuelle = DateTime.Today;
                string nummois2 = "" + DateActuelle.Month;
                LogoAccueil.IsVisible = false;
                //Chaque variable avec ((Button)sender).Exemple sert a recuperer la valeur de la proprieté du bouton.
                string jourcomplet = ((Button)sender).Text;
                string daterequete = ((Button)sender).StyleId;
                int idrepas = Database.MyCantineSQL.getIdRepas(daterequete);
                int idReservationMenu = Database.MyCantineSQL.getIdReservationMenu(idrepas, idutilisateur);
                bool RepasDejaReserve = Database.MyCantineSQL.getStatutReserver(daterequete, idutilisateur);
                int RequeteResistance = Database.MyCantineSQL.getStatutReserverResistance(daterequete, idutilisateur, idReservationMenu);
                List<Accompagnement> lesAccompagnementsReserves = Database.MyCantineSQL.getStatutReserverAccompagnement(idReservationMenu);
                int RequeteAccompagnement = lesAccompagnementsReserves.Count;
                int acc1 = 0;
                int acc2 = 0;
                int acc3 = 0;
                int acc4 = 0;
                for (int b = 0; b < lesAccompagnementsReserves.Count; b++)
                {
                    Accompagnement unAccompagnement1 = lesAccompagnementsReserves[b];

                    if (lesAccompagnementsReserves.Count == 1)
                    {
                        acc1 = unAccompagnement1.Id;
                    }
                    else if (lesAccompagnementsReserves.Count == 2)
                    {
                        if (b == 0)
                        {
                            acc1 = unAccompagnement1.Id;
                        }
                        else
                        {
                            acc2 = unAccompagnement1.Id;
                        }
                    }
                    else if (lesAccompagnementsReserves.Count == 3)
                    {
                        if (b == 0)
                        {
                            acc1 = unAccompagnement1.Id;
                        }
                        else if (b == 1)
                        {
                            acc2 = unAccompagnement1.Id;
                        }
                        else
                        {
                            acc3 = unAccompagnement1.Id;
                        }
                    }

                    else if (lesAccompagnementsReserves.Count == 4)
                    {
                        if (b == 0)
                        {
                            acc1 = unAccompagnement1.Id;
                        }
                        else if (b == 1)
                        {
                            acc2 = unAccompagnement1.Id;
                        }
                        else if (b == 2)
                        {
                            acc3 = unAccompagnement1.Id;
                        }
                        else
                        {
                            acc4 = unAccompagnement1.Id;
                        }
                    }

                }

                //FRAME PRINCIPAL QUI RECUPERE TOUTE LES CARDS
                Frame frameMenu = new Frame();

                //STACKLAYOUT QUI SERA LE CONTENU DE FRAMEMENU
                StackLayout stackCardMenu = new StackLayout();

                menuStack.IsVisible = true;

                /*-------------------------------------------------------*/
                /*---CONDITION SI REPAS NON RESERVE DANS LES TEMPS-------*/
                /*-------------------------------------------------------*/
                Label TropTard = new Label()
                {
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    BackgroundColor = Color.Red,
                    Margin = new Thickness(0, 0, 0, 20),
                    Text = "Désolé, réservation non dans les temps !",
                    FontSize = 20,
                    TextColor = Color.White

                };
                string DateAujourdhui = DateTime.Today.Year + "-" + nummois2 + "-" + DateTime.Today.Day;
                if (daterequete == DateAujourdhui && RequeteAccompagnement == 0 && RequeteResistance == 0)
                {
                    stackCardMenu.Children.Add(TropTard);
                    TropTard.Text = "La réservation n'est plus possible le jour même !";
                }
                else
                {
                    stackCardMenu.Children.Remove(TropTard);
                }
                /*-------------------------------------------------------*/

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
                /*-------------------------------------------------------*/

                titreEntree.Children.Add(titre2);
                stackCardEntree.Children.Add(titreEntree);
                frameEntree.Content = stackCardEntree;
                stackCardMenu.Children.Add(frameEntree);

                /*-------------------------------------------------------*/

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

                };
                /*-------------------------------------------------------*/

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
                /*-------------------------------------------------------*/

                titreViande.Children.Add(titre3);
                stackCardViande.Children.Add(titreViande);
                frameViande.Content = stackCardViande;
                stackCardMenu.Children.Add(frameViande);

                /*-------------------------------------------------------*/
                int cou = 0;
                int count = 0;

                List<Resistance> lesResistances = Database.MyCantineSQL.getlesResistances(daterequete);
                for (int i = 0; i < lesResistances.Count; i++)
                {
                    cou++;
                    Resistance uneResistance = lesResistances[i];
                    StackLayout stackCardResistance = new StackLayout();

                    int idresistance = uneResistance.Id;

                    Button boutonResistance = new Button
                    {
                        TextColor = Color.White,
                        Margin = new Thickness(120, 10, 120, 10),
                        Padding = new Thickness(0, 10, 0, -10),
                        StyleId = 0 + "",
                        ClassId = cou + "",
                        Text = uneResistance.Libelle + "\n",
                        FontSize = 16
                    };
                    var idbouton = boutonResistance.Id;
                    boutonResistance.Text = uneResistance.Libelle + "\n";
                    stackCardResistance.Children.Add(boutonResistance);
                    string textbouton = boutonResistance.Text;
                    if (RequeteResistance > 0 && RequeteResistance == idresistance)
                    {
                        ResistanceReserver = true;
                    }
                    else
                    {
                        ResistanceReserver = false;
                    }

                    if (ResistanceReserver == true)
                    {
                        string textuncheck = textbouton;
                        boutonResistance.BackgroundColor = Color.LightGreen;
                        boutonResistance.Text = "vide";
                        boutonResistance.Text = textuncheck;
                    }
                    else
                    {
                        string textchecked = textbouton;
                        boutonResistance.BackgroundColor = Color.LightGray;
                        boutonResistance.Text = "vide2";
                        boutonResistance.Text = textchecked;
                    }
                    stackCardMenu.Children.Add(stackCardResistance);
                    if (daterequete != DateAujourdhui)
                    {
                        boutonResistance.Clicked += boutonResistance_Click;
                    }

                    /*-------------------------------------------------------*/
                    async void boutonResistance_Click(object senders, EventArgs ex)
                    {
                        if (boutonResistance.BackgroundColor == Color.LightGreen)
                        {
                            string DateToday = DateTime.Today.Year + "-" + nummois2 + "-" + DateTime.Today.Day;
                            if (daterequete != DateToday)
                            {
                                Database.MyCantineSQL.SupprimerResistance(idrepas, idReservationMenu, idutilisateur);
                            }
                            string textchecked = textbouton;
                            boutonResistance.StyleId = 0 + "";
                        }
                        else
                        {
                            string DateToday = DateTime.Today.Year + "-" + nummois2 + "-" + DateTime.Today.Day;
                            if (daterequete != DateToday)
                            {
                                Database.MyCantineSQL.AjouterResistance(idrepas, idReservationMenu, idresistance, idutilisateur);
                            }
                            string textuncheck = textbouton;
                            boutonResistance.StyleId = 0 + "";
                            boutonResistance.StyleId = 1 + "";
                        }
                        if (boutonResistance.StyleId == "0")
                        {
                            for (count = 0; count < cou; count++)
                            {

                                if (count + "" == ClassId)
                                {
                                    boutonResistance.BackgroundColor = Color.LightGray;
                                }
                                else
                                {
                                    boutonResistance.BackgroundColor = Color.LightGray;
                                }
                            }
                        }
                        else
                        {
                            boutonResistance.BackgroundColor = Color.LightGreen;
                        }
                    }
                }
                /*-------------------------------------------------------*/


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
                /*-------------------------------------------------------*/

                titreAccompagnement.Children.Add(titre4);
                stackCardAccompagnement.Children.Add(titreAccompagnement);
                frameAccompagnement.Content = stackCardAccompagnement;
                //STACKCARDMENU recupère cette card
                stackCardMenu.Children.Add(frameAccompagnement);

                /*-------------------------------------------------------*/
                List<Accompagnement> lesAccompagnements = Database.MyCantineSQL.getlesAccompagnements(daterequete);
                for (int i = 0; i < lesAccompagnements.Count; i++)
                {
                    Accompagnement unAccompagnement = lesAccompagnements[i];

                    StackLayout stackCardAccompagnement2 = new StackLayout();

                    Button boutonAccompagnement = new Button
                    {
                        TextColor = Color.White,
                        Margin = new Thickness(120, 10, 120, 10),
                        Padding = new Thickness(0, 10, 0, -10),
                        Text = unAccompagnement.Libelle + "\n",
                        FontSize = 16
                    };
                    /*-------------------------------------------------------*/

                    int idaccompagnement = unAccompagnement.Id;
                    stackCardAccompagnement2.Children.Add(boutonAccompagnement);
                    string textbouton = boutonAccompagnement.Text;
                    stackCardMenu.Children.Add(stackCardAccompagnement2);
                    if (daterequete != DateAujourdhui)
                    {
                        boutonAccompagnement.Clicked += boutonAccompagnement_Click;
                    }
                    /*-------------------------------------------------------*/
                    if (RequeteAccompagnement > 0 && acc1 == idaccompagnement)
                    {
                        AccompagnementReserver = true;
                    }
                    else if (RequeteAccompagnement > 3 && acc1 == idaccompagnement || acc2 == idaccompagnement || acc3 == idaccompagnement || acc4 == idaccompagnement)
                    {
                        AccompagnementReserver = true;
                    }
                    else if (RequeteAccompagnement > 2 && acc1 == idaccompagnement || acc2 == idaccompagnement || acc3 == idaccompagnement)
                    {
                        AccompagnementReserver = true;
                    }
                    else if (RequeteAccompagnement > 1 && acc1 == idaccompagnement || acc2 == idaccompagnement)
                    {
                        AccompagnementReserver = true;
                    }
                    else
                    {
                        AccompagnementReserver = false;
                    }


                    if (AccompagnementReserver == true)
                    {
                        string textuncheck = textbouton;
                        boutonAccompagnement.BackgroundColor = Color.LightGreen;
                        boutonAccompagnement.Text = "vide";
                        boutonAccompagnement.Text = textuncheck;
                    }
                    else
                    {
                        string textchecked = textbouton;
                        boutonAccompagnement.BackgroundColor = Color.LightGray;
                        boutonAccompagnement.Text = "vide2";
                        boutonAccompagnement.Text = textchecked;
                    }

                    /*-------------------------------------------------------*/

                    async void boutonAccompagnement_Click(object senders, EventArgs ex)
                    {
                        if (boutonAccompagnement.BackgroundColor == Color.LightGreen)
                        {
                            string textuncheck = textbouton;
                            string DateToday = DateTime.Today.Year + "-" + nummois2 + "-" + DateTime.Today.Day;
                            if (daterequete != DateToday)
                            {
                                Database.MyCantineSQL.SupprimerAccompagnement(idReservationMenu, idaccompagnement);
                            }
                            boutonAccompagnement.BackgroundColor = Color.LightGray;
                            boutonAccompagnement.Text = "vide";
                            boutonAccompagnement.Text = textuncheck;
                        }
                        else
                        {
                            string textchecked = textbouton;
                            string DateToday = DateTime.Today.Year + "-" + nummois2 + "-" + DateTime.Today.Day;
                            if (daterequete != DateToday)
                            {
                                Database.MyCantineSQL.AjouterAccompagnement(idReservationMenu, idaccompagnement);
                            }
                            boutonAccompagnement.BackgroundColor = Color.LightGreen;
                            boutonAccompagnement.Text = "vide2";
                            boutonAccompagnement.Text = textchecked;
                        }
                    }
                }
                /*-------------------------------------------------------*/

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
                    Text = "Laitages et Fromages",
                    FontSize = 20,
                    TextColor = Color.White
                };

                /*-------------------------------------------------------*/

                titreLaitage.Children.Add(titre5);
                stackCardLaitage.Children.Add(titreLaitage);
                frameLaitage.Content = stackCardLaitage;
                stackCardMenu.Children.Add(frameLaitage);

                /*-------------------------------------------------------*/

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
                    stackCardALaitage.Children.Add(boutonLaitage);
                    stackCardMenu.Children.Add(stackCardALaitage);

                }
                /*-------------------------------------------------------*/

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
                    Text = "Desserts et Fruits",
                    FontSize = 20,
                    TextColor = Color.White
                };
                /*-------------------------------------------------------*/

                titreDessert.Children.Add(titre6);
                stackCardDessert.Children.Add(titreDessert);
                frameDessert.Content = stackCardDessert;
                stackCardMenu.Children.Add(frameDessert);

                /*-------------------------------------------------------*/
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

                }

                /*-------------------------------------------------------*/
                /*---------------------ANNULATION------------------------*/
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
                    string DateToday = DateTime.Today.Year + "-" + nummois2 + "-" + DateTime.Today.Day;
                    if (daterequete != DateToday)
                    {
                        AnnulerReservation = new Button()
                        {
                            Text = "Annuler ma réservation",
                            TextColor = Color.Red,
                            BackgroundColor = Color.LightGray,
                            FontSize = 16
                        };
                        titreAnnulation.Children.Add(titre7);
                        stackCardAnnulation.Children.Add(titreAnnulation);
                        frameAnnulation.Content = stackCardAnnulation;
                        stackCardMenu.Children.Add(frameAnnulation);
                        stackCardAnnulation.Children.Add(AnnulerReservation);
                        AnnulerReservation.Clicked += AnnulerReservation_Clicked;
                    }
                }

                string DateToday2 = DateTime.Today.Year + "-" + nummois2 + "-" + DateTime.Today.Day;
                if (daterequete != DateToday2)
                {
                    Nevienspas = new Button()
                    {
                        Text = "Je ne viendrais pas au self ce jour.",
                        TextColor = Color.Red,
                        BackgroundColor = Color.LightGray,
                        FontSize = 16
                    };
                    Nevienspas.Clicked += Nevienspas_Clicked;
                    stackCardAnnulation.Children.Add(Nevienspas);
                }
                /*-------------------------------------------------------*/


                //LORSQUE L'ON CLIQUE SUR LE BOUTON ANNULER RESERVATION ALORS ...
                async void AnnulerReservation_Clicked(object senders, EventArgs ex)
                {
                    AnnulerReservation.Text = "Annulation de votre réservation avec succès !";
                    AnnulerReservation.TextColor = Color.Green;
                    AnnulerReservation.BorderColor = Color.Green;
                    Database.MyCantineSQL.AnnulerReservationMenu(idrepas, idReservationMenu, idutilisateur);
                    stackCardAnnulation.Children.Remove(AnnulerReservation);
                }

                //LORSQUE L'ON CLIQUE SUR LE BOUTON NEVIENSPAS ALORS ...
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
                /*-------------------------------------------------------*/

                //FRAMEMENU RECUPERE STACKCARDMENU QUI LUI MEME RECUPERE TOUTE LES CARD ET ITEMS DU MENU
                frameMenu.Content = stackCardMenu;

                //ET DONC LE CONTENU ACTUEL DE MENUSTACK EST REMPLACE PAR CE FRAMEMENU MIS A JOUR
                menuStack.Content = frameMenu;
            }

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