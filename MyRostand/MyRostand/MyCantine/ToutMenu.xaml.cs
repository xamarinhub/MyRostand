using MyRostand.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyRostand.MyCantine
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToutMenu : ContentPage
    {
        //ON DECLARE LES LABELS AU DEBUT POUR LES APPELER DANS L'ENSEMBLE DES FONCTIONS (ça sera utile pour la suite !)
        StackLayout menuStack = new StackLayout();
        Label jourChoisi = new Label() { FontSize = 20 };
        Label toutesresistances = new Label() { FontSize = 20 };
        Label jourAccompagnement = new Label() { FontSize = 20 };
        Label eleveabsent = new Label() { FontSize = 20 };

        DateTime ancienneDate = DateTime.Today;

        public ToutMenu()
        {
            InitializeComponent();
            Title = "Tout les plats de resistances du jour";
            StackLayout stackPrincipal = new StackLayout();

            /*==================================================*/
            /*==============NAVBAR DES JOURS====================*/
            /*==================================================*/

            StackLayout barJours = new StackLayout();

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
                if (libelleJour == "Tuesday")
                {
                    libelleJour = "Mardi";
                }
                else if (libelleJour == "Wednesday")
                {
                    libelleJour = "Mercredi";
                }
                else if (libelleJour == "Monday")
                {
                    libelleJour = "Lundi";
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

                /*==========================*/

                string jourcomplet = libelleJour + "\n" + numjour + "\n" + nommois;
                string daterequete = DateTime.Today.Year + "-" + nummois + "-" + numjour;
                if (libelleJour == "Dimanche" | libelleJour == "Samedi")
                {
                    Button boutonferme = new Button()
                    {
                        Margin = new Thickness(1, 1, 1, 1),
                        BackgroundColor = Color.Gray,
                        BorderColor = Color.Gold,
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

            /*--------------------------------------------------*/
            /*--------------PLATS DE RESISTANCES ---------------*/
            /*--------------------------------------------------*/

            StackLayout stackCardToutesresistances = new StackLayout();

            Frame frameToutesresistances = new Frame()
            {
                CornerRadius = 10,
                BorderColor = Color.FromHex("#27ae60"),
                Margin = new Thickness(100, 0, 100, 20),
                Padding = new Thickness(0, 0, 0, 0)
            };
            StackLayout titreToutesresistances = new StackLayout()
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

            StackLayout descToutesresistances = new StackLayout()
            {
                Padding = new Thickness(10, 0, 10, 20)
            };
            Label DescToutesresistances = new Label()
            {
                Text = "Ce genre de Plat",
                FontSize = 20
            };

            descToutesresistances.Children.Add(toutesresistances);
            titreToutesresistances.Children.Add(titre3);
            stackCardToutesresistances.Children.Add(titreToutesresistances);
            stackCardToutesresistances.Children.Add(descToutesresistances);
            frameToutesresistances.Content = stackCardToutesresistances;

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

            /*--------------------------------------------------*/
            /*---------------------PRESENCE---------------*/
            /*--------------------------------------------------*/

            StackLayout stackCardPrensence = new StackLayout();

            Frame framePresence = new Frame()
            {
                CornerRadius = 10,
                BorderColor = Color.FromHex("#27ae60"),
                Margin = new Thickness(100, 0, 100, 20),
                Padding = new Thickness(0, 0, 0, 0)
            };
            StackLayout titrePresence = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.Fill,
                BackgroundColor = Color.FromHex("#27ae60"),
                HeightRequest = 35,
                Padding = new Thickness(0, 10, 0, 0)
            };
            Label titreP = new Label()
            {
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                Text = "Nombres d'Eleves Absents",
                FontSize = 20,
                TextColor = Color.White
            };

            StackLayout descPresence = new StackLayout()
            {
                Padding = new Thickness(10, 0, 10, 20)
            };
            Label DescPresence = new Label()
            {
                Text = jourAccompagnement.Text,
                FontSize = 20
            };

            descPresence.Children.Add(eleveabsent);
            titrePresence.Children.Add(titreP);
            stackCardPrensence.Children.Add(titrePresence);
            stackCardPrensence.Children.Add(descPresence);
            framePresence.Content = stackCardPrensence;

            /*------------------------------------------*/

            menuStack.Children.Add(frameToutesresistances);
            menuStack.Children.Add(frameAccompagnement);
            menuStack.Children.Add(framePresence);

            Button Cuisto = new Button()
            {
                BackgroundColor = Color.Red,
                Margin = new Thickness(60, 10, 20, 0),
                Text = "Gestion des quantitées",
                FontSize = 20,
                TextColor = Color.White
            };

            Cuisto.Clicked += Cuisto_Clicked;

            async void Cuisto_Clicked(object sender, EventArgs e)
            {
                await Navigation.PushAsync(new ModifGrammage());
            }

            /*==================================================*/
            /*==================================================*/

            stackPrincipal.Children.Add(barJours);
            stackPrincipal.Children.Add(menuStack);
            stackPrincipal.Children.Add(Cuisto);
            Content = stackPrincipal;

        }

        private void Bouton_Clicked(object sender, EventArgs e)
        {
            //cette variable sert à récupérer le jour en question, et afficher les menus correspondants
            string jourcomplet = ((Button)sender).Text;
            string daterequete = ((Button)sender).StyleId;
            menuStack.IsVisible = true;

            jourChoisi.Text = "Jour choisi : " + jourcomplet;

            string barre;
            string barre1 = "⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜";
            string barre2 = "⬛⬛⬜⬜⬜⬜⬜⬜⬜⬜";
            string barre3 = "⬛⬛⬛⬜⬜⬜⬜⬜⬜⬜";
            string barre4 = "⬛⬛⬛⬛⬜⬜⬜⬜⬜⬜";
            string barre5 = "⬛⬛⬛⬛⬛⬜⬜⬜⬜⬜";
            string barre6 = "⬛⬛⬛⬛⬛⬛⬜⬜⬜⬜";
            string barre7 = "⬛⬛⬛⬛⬛⬛⬛⬜⬜⬜";
            string barre8 = "⬛⬛⬛⬛⬛⬛⬛⬛⬜⬜";
            string barre9 = "⬛⬛⬛⬛⬛⬛⬛⬛⬛⬜";
            string barre10 = "⬛⬛⬛⬛⬛⬛⬛⬛⬛⬛";

            ///////////////////////////////////////////////////////////////Fonction Afficher toutes les Résistances////////////////////////////////////////////////
            toutesresistances.Text = $"";
            String Viande = "";
            int c = 0;
            List<Resistance> TouteslesResistances = Database.MyCantineSQL.getTouteslesResistances(daterequete);
            for (int i = 0; i < TouteslesResistances.Count; i++)
            {
                Resistance uneResistance = TouteslesResistances[i];
                if (Viande == "" && TouteslesResistances.Count == 1)
                {
                    Viande = uneResistance.Libelle;
                    c++;
                    double p = ((double)c / TouteslesResistances.Count);
                   
                    toutesresistances.Text += Viande + ": " + c + " soit " + p * 100 + "%" + "\n" + barre10;
                }
                else if (Viande == "" && TouteslesResistances.Count > 1)
                {
                    Viande = uneResistance.Libelle;
                    c++;
                }
                else if (i + 1 == TouteslesResistances.Count)
                {
                    if (Viande == uneResistance.Libelle)
                    {
                        c++;
                        double p = ((double)c / TouteslesResistances.Count);
                        if (p <= 0.1)
                        {
                            barre = barre1;
                        }
                        else if(p <= 0.2)
                        {
                            barre = barre2;
                        }
                        else if(p <= 0.3)
                        {
                            barre = barre3;
                        }
                        else if(p <= 0.4)
                        {
                            barre = barre4;
                        }
                        if (p <= 0.5)
                        {
                            barre = barre5;
                        }
                        else if(p <= 0.6)
                        {
                            barre = barre6;
                        }
                        else if(p <= 0.7)
                        {
                            barre = barre7;
                        }
                        else if(p <= 0.8)
                        {
                            barre = barre8;
                        }
                        else if(p <= 0.9)
                        {
                            barre = barre9;
                        }
                        else
                        {
                            barre = barre10;
                        }
                        toutesresistances.Text += Viande + ": " + c + " soit " + p * 100 + "%" + "\n" + barre;
                    }
                    else
                    {
                        double p = ((double)c / TouteslesResistances.Count);
                        if (p <= 0.1)
                        {
                            barre = barre1;
                        }
                        else if(p <= 0.2)
                        {
                            barre = barre2;
                        }
                        else if(p <= 0.3)
                        {
                            barre = barre3;
                        }
                        else if(p <= 0.4)
                        {
                            barre = barre4;
                        }
                        else if(p <= 0.5)
                        {
                            barre = barre5;
                        }
                        else if(p <= 0.6)
                        {
                            barre = barre6;
                        }
                        else if(p <= 0.7)
                        {
                            barre = barre7;
                        }
                        else if(p <= 0.8)
                        {
                            barre = barre8;
                        }
                        else if(p <= 0.9)
                        {
                            barre = barre9;
                        }
                        else
                        {
                            barre = barre10;
                        }
                        toutesresistances.Text += Viande + ": " + c + " soit " + p * 100 + "%" + "\n" + barre +"\n";
                        c = 1;
                        Viande = uneResistance.Libelle;
                        double pp = ((double)c / TouteslesResistances.Count);
                        if (pp <= 0.1)
                        {
                            barre = barre1;
                        }
                        else if(pp <= 0.2)
                        {
                            barre = barre2;
                        }
                        else if(pp <= 0.3)
                        {
                            barre = barre3;
                        }
                        else if(pp <= 0.4)
                        {
                            barre = barre4;
                        }
                        else if(pp <= 0.5)
                        {
                            barre = barre5;
                        }
                        else if(pp <= 0.6)
                        {
                            barre = barre6;
                        }
                        else if(pp <= 0.7)
                        {
                            barre = barre7;
                        }
                        else if(pp <= 0.8)
                        {
                            barre = barre8;
                        }
                        else if(pp <= 0.9)
                        {
                            barre = barre9;
                        }
                        else
                        {
                            barre = barre10;
                        }
                        toutesresistances.Text += Viande + ": " + c + " soit " + pp * 100 + "%" + "\n" + barre;
                    }
                }
                else if (Viande == uneResistance.Libelle)
                {
                    c++;
                }
                else if (Viande != uneResistance.Libelle)
                {
                    double p = ((double)c / TouteslesResistances.Count);
                    if (p <= 0.1)
                    {
                        barre = barre1;
                    }
                    else if(p <= 0.2)
                    {
                        barre = barre2;
                    }
                    else if(p <= 0.3)
                    {
                        barre = barre3;
                    }
                    else if(p <= 0.4)
                    {
                        barre = barre4;
                    }
                    else if(p <= 0.5)
                    {
                        barre = barre5;
                    }
                    else if(p <= 0.6)
                    {
                        barre = barre6;
                    }
                    else if(p <= 0.7)
                    {
                        barre = barre7;
                    }
                    else if(p <= 0.8)
                    {
                        barre = barre8;
                    }
                    else if(p <= 0.9)
                    {
                        barre = barre9;
                    }
                    else
                    {
                        barre = barre10;
                    }
                    toutesresistances.Text += Viande + ": " + c + " soit " + p * 100 + "%" + "\n" + barre + "\n";
                    Viande = uneResistance.Libelle;
                    c = 1;
                }
                else
                {
                    toutesresistances.Text += uneResistance.Libelle + "\n";
                }

            }
            ///////////////////////////////////////////////////////////////Fonction Afficher tout les Accompagnements////////////////////////////////////////////////
            jourAccompagnement.Text = $"";
            String Accompagnement = "";
            int a = 0;
            int prop = 0;
            List<Accompagnement> lesAccompagnements = Database.MyCantineSQL.getToutlesAccompagnements(daterequete);
            for (int i = 0; i < lesAccompagnements.Count; i++)
            {
                Accompagnement unAccompagnement = lesAccompagnements[i];
                if (Accompagnement == "" && lesAccompagnements.Count == 1)
                {
                    Accompagnement = unAccompagnement.Libelle;
                    a++;
                    prop = unAccompagnement.Gramme;
                    double p = ((double)c / lesAccompagnements.Count);
                    if (p <= 0.1)
                    {
                        barre = barre1;
                    }
                    else if (p <= 0.2)
                    {
                        barre = barre2;
                    }
                    else if (p <= 0.3)
                    {
                        barre = barre3;
                    }
                    else if (p <= 0.4)
                    {
                        barre = barre4;
                    }
                    else if (p <= 0.5)
                    {
                        barre = barre5;
                    }
                    else if (p <= 0.6)
                    {
                        barre = barre6;
                    }
                    else if (p <= 0.7)
                    {
                        barre = barre7;
                    }
                    else if (p <= 0.8)
                    {
                        barre = barre8;
                    }
                    else if (p <= 0.9)
                    {
                        barre = barre9;
                    }
                    else
                    {
                        barre = barre10;
                    }
                    jourAccompagnement.Text += Accompagnement + ": " + a + " soit " + a * prop + " g " + " soit " + p*100 + "%" + "\n" + barre;
                }
                else if (Accompagnement == "" && lesAccompagnements.Count > 1)
                {
                    Accompagnement = unAccompagnement.Libelle;
                    a++;
                    prop = unAccompagnement.Gramme;
                }
                else if (i + 1 == lesAccompagnements.Count)
                {
                    if (Accompagnement == unAccompagnement.Libelle)
                    {
                        a++;
                        double p = ((double)c / TouteslesResistances.Count);
                        if (p <= 0.1)
                        {
                            barre = barre1;
                        }
                        else if (p <= 0.2)
                        {
                            barre = barre2;
                        }
                        else if (p <= 0.3)
                        {
                            barre = barre3;
                        }
                        else if (p <= 0.4)
                        {
                            barre = barre4;
                        }
                        else if (p <= 0.5)
                        {
                            barre = barre5;
                        }
                        else if (p <= 0.6)
                        {
                            barre = barre6;
                        }
                        else if (p <= 0.7)
                        {
                            barre = barre7;
                        }
                        else if (p <= 0.8)
                        {
                            barre = barre8;
                        }
                        else if (p <= 0.9)
                        {
                            barre = barre9;
                        }
                        else
                        {
                            barre = barre10;
                        }
                        jourAccompagnement.Text += Accompagnement + ": " + a + " soit " + a * prop + " g " + " soit " + p * 100 + "%" + "\n" + barre;
                    }
                    else if (Accompagnement != unAccompagnement.Libelle)
                    {
                        double p = ((double)c / TouteslesResistances.Count);
                        if (p <= 0.1)
                        {
                            barre = barre1;
                        }
                        else if (p <= 0.2)
                        {
                            barre = barre2;
                        }
                        else if (p <= 0.3)
                        {
                            barre = barre3;
                        }
                        else if (p <= 0.4)
                        {
                            barre = barre4;
                        }
                        else if (p <= 0.5)
                        {
                            barre = barre5;
                        }
                        else if (p <= 0.6)
                        {
                            barre = barre6;
                        }
                        else if (p <= 0.7)
                        {
                            barre = barre7;
                        }
                        else if (p <= 0.8)
                        {
                            barre = barre8;
                        }
                        else if (p <= 0.9)
                        {
                            barre = barre9;
                        }
                        else
                        {
                            barre = barre10;
                        }
                        jourAccompagnement.Text += Accompagnement + ": " + a + " soit " + a * prop + " g " + " soit " + p * 100 + "%" + "\n" + barre + "\n";
                        a = 1;
                        prop = unAccompagnement.Gramme;
                        double pp = ((double)c / TouteslesResistances.Count);
                        if (pp <= 0.1)
                        {
                            barre = barre1;
                        }
                        else if (pp <= 0.2)
                        {
                            barre = barre2;
                        }
                        else if (pp <= 0.3)
                        {
                            barre = barre3;
                        }
                        else if (pp <= 0.4)
                        {
                            barre = barre4;
                        }
                        else if (pp <= 0.5)
                        {
                            barre = barre5;
                        }
                        else if (pp <= 0.6)
                        {
                            barre = barre6;
                        }
                        else if (pp <= 0.7)
                        {
                            barre = barre7;
                        }
                        else if (pp <= 0.8)
                        {
                            barre = barre8;
                        }
                        else if (pp <= 0.9)
                        {
                            barre = barre9;
                        }
                        else
                        {
                            barre = barre10;
                        }
                        jourAccompagnement.Text += Accompagnement + ": " + a + " soit " + a * prop + " g " + " soit " + pp * 100 + "%" + barre + "\n";
                    }
                }
                else if (Accompagnement == unAccompagnement.Libelle)
                {
                    a++;
                }
                else if (Accompagnement != unAccompagnement.Libelle)
                {
                    double p = ((double)c / TouteslesResistances.Count);
                    if (p <= 0.1)
                    {
                        barre = barre1;
                    }
                    else if (p <= 0.2)
                    {
                        barre = barre2;
                    }
                    else if (p <= 0.3)
                    {
                        barre = barre3;
                    }
                    else if (p <= 0.4)
                    {
                        barre = barre4;
                    }
                    else if (p <= 0.5)
                    {
                        barre = barre5;
                    }
                    else if (p <= 0.6)
                    {
                        barre = barre6;
                    }
                    else if (p <= 0.7)
                    {
                        barre = barre7;
                    }
                    else if (p <= 0.8)
                    {
                        barre = barre8;
                    }
                    else if (p <= 0.9)
                    {
                        barre = barre9;
                    }
                    else
                    {
                        barre = barre10;
                    }
                    jourAccompagnement.Text += Accompagnement + ": " + a + " soit " + a * prop + " g " + " soit " + p * 100 + "%" + "\n" + barre + "\n";
                    Accompagnement = unAccompagnement.Libelle;
                    prop = unAccompagnement.Gramme;
                    a = 1;
                }
                else
                {
                    jourAccompagnement.Text += unAccompagnement.Libelle + " soit " + a * prop + ", \n";
                }
            }
            ///////////////////////////////////////////////////////////////Fonction Afficher tout les Absents////////////////////////////////////////////////
            eleveabsent.Text = $"";
            List<Present> LesAbsents = Database.MyCantineSQL.getToutEleveS(daterequete);
            for (int i = 0; i < LesAbsents.Count; i++)
            {
                Present unAbsent = LesAbsents[i];
                eleveabsent.Text = unAbsent.Uti + "";
            }


        }
        ///////////////////////////////////////////////////////////////////Fin des Algorithmes//////////////////////////////////////////////////
    }
}