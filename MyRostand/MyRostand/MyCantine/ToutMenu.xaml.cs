﻿using MyRostand.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyRostand.MyCantine
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToutMenu : ContentPage
    {
        private const string V = "Yellow";

        //ON DECLARE LES LABELS AU DEBUT POUR LES APPELER DANS L'ENSEMBLE DES FONCTIONS (ça sera utile pour la suite !)
        StackLayout barJours = new StackLayout();
        StackLayout menuStack = new StackLayout();
        Label jourChoisi = new Label() { FontSize = 20 };
        Label toutesresistances = new Label() { FontSize = 20 };
        Label jourAccompagnement = new Label() { FontSize = 20 };
        Label eleveabsent = new Label() { FontSize = 20 };
        Button Cuisto = new Button()
        {
            BackgroundColor = Color.Red,
            Margin = new Thickness(220, 10, 220, 10),
            Padding = new Thickness(0, 10, 0, 10),
            Text = "Gestion des quantitées",
            FontSize = 20,
            TextColor = Color.White
        };        

        DateTime ancienneDate = DateTime.Today;
        Label titleviande = new Label
        {
            Text = " Plats de résistance ",
            FontSize = 30,
            HorizontalTextAlignment = TextAlignment.Center,
            VerticalTextAlignment = TextAlignment.Center,
            TextColor = Color.FromHex("#FFFFFF")
        };
        StackLayout LayoutViandetitle = new StackLayout
        {
            HorizontalOptions = LayoutOptions.Fill,
            BackgroundColor = Color.FromHex("#27ae60"),
            HeightRequest = 35,       
        };
        StackLayout LayoutViande1 = new StackLayout
        {
            Orientation = StackOrientation.Horizontal
        };
        StackLayout LayoutViande1barre = new StackLayout
        {
        };
        Label Avantviande = new Label
        {
            Text = "  ",
            FontSize = 30,
        };
        Label countviande = new Label
        {
            Text = "  ",
            FontSize = 30,
            TextColor = Color.FromHex("#77d065")
        };
        Label soitviande = new Label
        {
            Text = "  ",
            FontSize = 30,
        };
        Label pourcentviande = new Label
        {
            Text = "  ",
            FontSize = 30,
            TextColor = Color.FromHex("#FF5733")
        };
        Label pourcentviande12 = new Label
        {
            Text = "  ",
            FontSize = 30,
            TextColor = Color.FromHex("#FF5733")
        };
        Label barreviande = new Label
        {
            Text = "  ",
            FontSize = 30,
            TextColor = Color.FromHex("#FF5733")
        };
        StackLayout LayoutViande2 = new StackLayout
        {
            Orientation = StackOrientation.Horizontal
        };
        StackLayout LayoutViande2barre = new StackLayout
        {
        };
        Label Avantviande2 = new Label
        {
            Text = "  ",
            FontSize = 30,
        };
        Label countviande2 = new Label
        {
            Text = "  ",
            FontSize = 30,
            TextColor = Color.FromHex("#77d065")
        };
        Label soitviande2 = new Label
        {
            Text = "  ",
            FontSize = 30,
        };
        Label pourcentviande2 = new Label
        {
            Text = "  ",
            FontSize = 30,
            TextColor = Color.FromHex("#FF5733")
        };
        Label pourcentviande22 = new Label
        {
            Text = "  ",
            FontSize = 30,
            TextColor = Color.FromHex("#FF5733")
        };
        Label barreviande2 = new Label
        {
            Text = "  ",
            FontSize = 30,
            TextColor = Color.FromHex("#FF5733")
        };
        StackLayout LayoutViande3 = new StackLayout
        {
            Orientation = StackOrientation.Horizontal
        };
        StackLayout LayoutViande3barre = new StackLayout
        {
        };
        Label Avantviande3 = new Label
        {
            Text = "  ",
            FontSize = 30,
        };
        Label countviande3 = new Label
        {
            Text = "  ",
            FontSize = 30,
            TextColor = Color.FromHex("#77d065")
        };
        Label soitviande3 = new Label
        {
            Text = "  ",
            FontSize = 30,
        };
        Label pourcentviande3 = new Label
        {
            Text = "  ",
            FontSize = 30,
            TextColor = Color.FromHex("#FF5733")
        };
        Label pourcentviande32 = new Label
        {
            Text = "  ",
            FontSize = 30,
            TextColor = Color.FromHex("#FF5733")
        };
        Label barreviande3 = new Label
        {
            Text = "  ",
            FontSize = 30,
            TextColor = Color.FromHex("#FF5733")
        };
        StackLayout LayoutViande4 = new StackLayout
        {
            Orientation = StackOrientation.Horizontal
        };
        StackLayout LayoutViande4barre = new StackLayout
        {
        };
        Label Avantviande4= new Label
        {
            Text = "  ",
            FontSize = 30,
        };
        Label countviande4 = new Label
        {
            Text = "  ",
            FontSize = 30,
            TextColor = Color.FromHex("#77d065")
        };
        Label soitviande4 = new Label
        {
            Text = "  ",
            FontSize = 30,
        };
        Label pourcentviande4 = new Label
        {
            Text = "  ",
            FontSize = 30,
            TextColor = Color.FromHex("#FF5733")
        };
        Label pourcentviande42 = new Label
        {
            Text = "  ",
            FontSize = 30,
            TextColor = Color.FromHex("#FF5733")
        };
        Label barreviande4 = new Label
        {
            Text = "  ",
            FontSize = 30,
            TextColor = Color.FromHex("#FF5733")
        };
        public ToutMenu()
        {
            InitializeComponent();
            Title = "Tout les plats de resistances du jour";
            StackLayout stackPrincipal = new StackLayout();

            /*==================================================*/
            /*==============NAVBAR DES JOURS====================*/
            /*==================================================*/

           

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

            menuStack.Children.Add(frameAccompagnement);
            menuStack.Children.Add(framePresence);


            Cuisto.Clicked += Cuisto_Clicked;
            async void Cuisto_Clicked(object sender, EventArgs e)
            {
                await Navigation.PushAsync(new ModifGrammage());
            }

            
            /*==================================================*/
            /*==================================================*/
      
            this.Content = new StackLayout
            {
                Children =
                {
                    barJours,
                    menuStack
                }
            };

        }

        private void Bouton_Clicked(object sender, EventArgs e)
        {
            //cette variable sert à récupérer le jour en question, et afficher les menus correspondants
            string jourcomplet = ((Button)sender).Text;
            string daterequete = ((Button)sender).StyleId;
            Title = "Tout les plats de resistances du jour";
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

            string co = "0";
            List<Resistance> LeNb = Database.MyCantineSQL.getNBTouteslesResistances(daterequete);
            for (int i = 0; i < LeNb.Count; i++)
            {
                Resistance uneResistance = LeNb[i];
                co = uneResistance.Id + "";
            }
            ///////////////////////////////////////////////////////////////Fonction Afficher toutes les Résistances////////////////////////////////////////////////
            toutesresistances.Text = $"";
            String Viande = "";
            String Viande2 = "";
            String Viande3 = "";
            String Viande4 = "";
            int c = 0;
            List<Resistance> TouteslesResistances = Database.MyCantineSQL.getTouteslesResistances(daterequete);
            for (int i = 0; i < TouteslesResistances.Count; i++)
            {
                Resistance uneResistance = TouteslesResistances[i];
                if (co == "1")
                {
                    if (Viande == "")
                    {
                        Viande = uneResistance.Libelle;
                        c++;
                    }                   
                    else if (Viande == uneResistance.Libelle && i+1 == TouteslesResistances.Count)
                    {
                        c++;
                        double p = ((double)c / TouteslesResistances.Count) * 100;
                        string tp = String.Format("{0:N1}", p);
                        Avantviande.Text = Viande + ": ";
                        countviande.Text = c + "";
                        soitviande.Text = " soit ";
                        pourcentviande.Text = tp ;
                        pourcentviande12.Text = "%";
                        barreviande.Text = barre10;
                        LayoutViande1.Children.Add(Avantviande);
                        LayoutViande1.Children.Add(countviande);
                        LayoutViande1.Children.Add(soitviande);
                        LayoutViande1.Children.Add(pourcentviande);
                        LayoutViande1.Children.Add(pourcentviande12);
                        LayoutViande1barre.Children.Add(barreviande);
                        LayoutViandetitle.Children.Add(titleviande);
                    }
                    else if (Viande == uneResistance.Libelle)
                    {
                        c++;
                    }
                }
                else if (co == "2")
                {
                    if (Viande == "")
                    {
                        Viande = uneResistance.Libelle;
                        c++;
                    }
                    else if (Viande == uneResistance.Libelle)
                    {
                        c++;
                    }
                    else if (Viande != uneResistance.Libelle && i + 1 != TouteslesResistances.Count)
                    {
                        double p = ((double)c / TouteslesResistances.Count) * 100;
                        if (p <= 15)
                        {
                            barre = barre1;
                        }
                        else if (p <= 25)
                        {
                            barre = barre2;
                        }
                        else if (p <= 35)
                        {
                            barre = barre3;
                        }
                        else if (p <= 45)
                        {
                            barre = barre4;
                        }
                        else if (p <= 55)
                        {
                            barre = barre5;
                        }
                        else if (p <= 65)
                        {
                            barre = barre6;
                        }
                        else if (p <= 75)
                        {
                            barre = barre7;
                        }
                        else if (p <= 85)
                        {
                            barre = barre8;
                        }
                        else if (p <= 95)
                        {
                            barre = barre9;
                        }
                        else
                        {
                            barre = barre10;
                        }
                        string tp = String.Format("{0:N1}", p);
                        Avantviande.Text = Viande + ": ";
                        countviande.Text = c + "";
                        soitviande.Text = " soit ";
                        pourcentviande.Text = tp;
                        pourcentviande12.Text = "%";
                        barreviande.Text = barre;
                        LayoutViande1.Children.Add(Avantviande);
                        LayoutViande1.Children.Add(countviande);
                        LayoutViande1.Children.Add(soitviande);
                        LayoutViande1.Children.Add(pourcentviande);
                        LayoutViande1.Children.Add(pourcentviande12);
                        LayoutViande1barre.Children.Add(barreviande);
                        LayoutViandetitle.Children.Add(titleviande);
                        Viande2 = uneResistance.Libelle;
                        c = 1;
                    }
                    else if (Viande != uneResistance.Libelle && i + 1 == TouteslesResistances.Count)
                    {
                        double p = ((double)c / TouteslesResistances.Count) * 100;
                        if (p <= 15)
                        {
                            barre = barre1;
                        }
                        else if (p <= 25)
                        {
                            barre = barre2;
                        }
                        else if (p <= 35)
                        {
                            barre = barre3;
                        }
                        else if (p <= 45)
                        {
                            barre = barre4;
                        }
                        else if (p <= 55)
                        {
                            barre = barre5;
                        }
                        else if (p <= 65)
                        {
                            barre = barre6;
                        }
                        else if (p <= 75)
                        {
                            barre = barre7;
                        }
                        else if (p <= 85)
                        {
                            barre = barre8;
                        }
                        else if (p <= 95)
                        {
                            barre = barre9;
                        }
                        else
                        {
                            barre = barre10;
                        }
                        string tp = String.Format("{0:N1}", p);
                        Avantviande.Text = Viande + ": ";
                        countviande.Text = c + "" ;
                        soitviande.Text = " soit ";
                        pourcentviande.Text = tp;
                        pourcentviande12.Text = "%";
                        barreviande.Text = barre;
                        LayoutViande1.Children.Add(Avantviande);
                        LayoutViande1.Children.Add(countviande);
                        LayoutViande1.Children.Add(soitviande);
                        LayoutViande1.Children.Add(pourcentviande);
                        LayoutViande1.Children.Add(pourcentviande12);
                        LayoutViande1barre.Children.Add(barreviande);
                        LayoutViandetitle.Children.Add(titleviande);
                        Viande2 = uneResistance.Libelle;
                        c = 1;
                        double pp = ((double)c / TouteslesResistances.Count) * 100;
                        if (pp <= 15)
                        {
                            barre = barre1;
                        }
                        else if (pp <= 25)
                        {
                            barre = barre2;
                        }
                        else if (pp <= 35)
                        {
                            barre = barre3;
                        }
                        else if (pp <= 45)
                        {
                            barre = barre4;
                        }
                        else if (pp <= 55)
                        {
                            barre = barre5;
                        }
                        else if (pp <= 65)
                        {
                            barre = barre6;
                        }
                        else if (pp <= 75)
                        {
                            barre = barre7;
                        }
                        else if (pp <= 85)
                        {
                            barre = barre8;
                        }
                        else if (pp <= 95)
                        {
                            barre = barre9;
                        }
                        else
                        {
                            barre = barre10;
                        }
                        string tpp = String.Format("{0:N1}", pp);
                        Avantviande2.Text = Viande2 + ": ";
                        countviande2.Text = c + "";
                        soitviande2.Text = " soit ";
                        pourcentviande2.Text = tpp;
                        pourcentviande22.Text = "%";
                        barreviande2.Text = barre;
                        LayoutViande2.Children.Add(Avantviande2);
                        LayoutViande2.Children.Add(countviande2);
                        LayoutViande2.Children.Add(soitviande2);
                        LayoutViande2.Children.Add(pourcentviande2);
                        LayoutViande2.Children.Add(pourcentviande22);
                        LayoutViande2barre.Children.Add(barreviande2);
                    }
                    else if (Viande2 == uneResistance.Libelle && i + 1 != TouteslesResistances.Count)
                    {
                        c++;
                    }
                    else if (i + 1 == TouteslesResistances.Count)
                    {
                        double p = ((double)c / TouteslesResistances.Count) * 100;
                        if (p <= 15)
                        {
                            barre = barre1;
                        }
                        else if (p <= 25)
                        {
                            barre = barre2;
                        }
                        else if (p <= 35)
                        {
                            barre = barre3;
                        }
                        else if (p <= 45)
                        {
                            barre = barre4;
                        }
                        else if (p <= 55)
                        {
                            barre = barre5;
                        }
                        else if (p <= 65)
                        {
                            barre = barre6;
                        }
                        else if (p <= 75)
                        {
                            barre = barre7;
                        }
                        else if (p <= 85)
                        {
                            barre = barre8;
                        }
                        else if (p <= 95)
                        {
                            barre = barre9;
                        }
                        else
                        {
                            barre = barre10;
                        }
                        string tp = String.Format("{0:N1}", p);
                        Avantviande2.Text = Viande2 + ": ";
                        countviande2.Text = c + "";
                        soitviande2.Text = " soit ";
                        pourcentviande2.Text = tp;
                        pourcentviande22.Text = "%";
                        barreviande2.Text = barre;
                        LayoutViande2.Children.Add(Avantviande2);
                        LayoutViande2.Children.Add(countviande2);
                        LayoutViande2.Children.Add(soitviande2);
                        LayoutViande2.Children.Add(pourcentviande2);
                        LayoutViande2.Children.Add(pourcentviande22);
                        LayoutViande2barre.Children.Add(barreviande2);
                    }


                }
                else if (co == "3")
                {
                    if (Viande == "")
                    {
                        Viande = uneResistance.Libelle;
                        c++;
                    }
                    else if (Viande == uneResistance.Libelle)
                    {
                        c++;
                    }
                    else if (Viande != uneResistance.Libelle)
                    {
                        double p = ((double)c / TouteslesResistances.Count) * 100;
                        if (p <= 15)
                        {
                            barre = barre1;
                        }
                        else if (p <= 25)
                        {
                            barre = barre2;
                        }
                        else if (p <= 35)
                        {
                            barre = barre3;
                        }
                        else if (p <= 45)
                        {
                            barre = barre4;
                        }
                        else if (p <= 55)
                        {
                            barre = barre5;
                        }
                        else if (p <= 65)
                        {
                            barre = barre6;
                        }
                        else if (p <= 75)
                        {
                            barre = barre7;
                        }
                        else if (p <= 85)
                        {
                            barre = barre8;
                        }
                        else if (p <= 95)
                        {
                            barre = barre9;
                        }
                        else
                        {
                            barre = barre10;
                        }
                        string tp = String.Format("{0:N1}", p);
                        Avantviande.Text = Viande + ": ";
                        countviande.Text = c + "";
                        soitviande.Text = " soit ";
                        pourcentviande.Text = tp;
                        pourcentviande12.Text = "%";
                        barreviande.Text = barre;
                        LayoutViande1.Children.Add(Avantviande);
                        LayoutViande1.Children.Add(countviande);
                        LayoutViande1.Children.Add(soitviande);
                        LayoutViande1.Children.Add(pourcentviande);
                        LayoutViande1.Children.Add(pourcentviande12);
                        LayoutViande1barre.Children.Add(barreviande);
                        LayoutViandetitle.Children.Add(titleviande);
                        Viande2 = uneResistance.Libelle;
                        c = 1;
                    }
                    else if (Viande2 == uneResistance.Libelle)
                    {
                        c++;
                    }
                    else if (Viande2 != uneResistance.Libelle && i + 1 == TouteslesResistances.Count)
                    {
                        double p = ((double)c / TouteslesResistances.Count) * 100;
                        if (p <= 15)
                        {
                            barre = barre1;
                        }
                        else if (p <= 25)
                        {
                            barre = barre2;
                        }
                        else if (p <= 35)
                        {
                            barre = barre3;
                        }
                        else if (p <= 45)
                        {
                            barre = barre4;
                        }
                        else if (p <= 55)
                        {
                            barre = barre5;
                        }
                        else if (p <= 65)
                        {
                            barre = barre6;
                        }
                        else if (p <= 75)
                        {
                            barre = barre7;
                        }
                        else if (p <= 85)
                        {
                            barre = barre8;
                        }
                        else if (p <= 95)
                        {
                            barre = barre9;
                        }
                        else
                        {
                            barre = barre10;
                        }
                        string tp = String.Format("{0:N1}", p);
                        Avantviande2.Text = Viande2 + ": ";
                        countviande2.Text = c + "";
                        soitviande2.Text = " soit ";
                        pourcentviande2.Text = tp;
                        pourcentviande22.Text = "%";
                        barreviande2.Text = barre;
                        LayoutViande2.Children.Add(Avantviande2);
                        LayoutViande2.Children.Add(countviande2);
                        LayoutViande2.Children.Add(soitviande2);
                        LayoutViande2.Children.Add(pourcentviande2);
                        LayoutViande2.Children.Add(pourcentviande22);
                        LayoutViande2barre.Children.Add(barreviande2);
                        Viande3 = uneResistance.Libelle;
                        c = 1;
                        double pp = ((double)c / TouteslesResistances.Count) * 100;
                        if (pp <= 15)
                        {
                            barre = barre1;
                        }
                        else if (pp <= 25)
                        {
                            barre = barre2;
                        }
                        else if (pp <= 35)
                        {
                            barre = barre3;
                        }
                        else if (pp <= 45)
                        {
                            barre = barre4;
                        }
                        else if (pp <= 55)
                        {
                            barre = barre5;
                        }
                        else if (pp <= 65)
                        {
                            barre = barre6;
                        }
                        else if (pp <= 75)
                        {
                            barre = barre7;
                        }
                        else if (pp <= 85)
                        {
                            barre = barre8;
                        }
                        else if (pp <= 95)
                        {
                            barre = barre9;
                        }
                        else
                        {
                            barre = barre10;
                        }
                        string tpp = String.Format("{0:N1}", pp);
                        Avantviande3.Text = Viande3 + ": ";
                        countviande3.Text = c + "";
                        soitviande3.Text = " soit ";
                        pourcentviande3.Text = tpp;
                        pourcentviande32.Text = "%";
                        barreviande3.Text = barre;
                        LayoutViande3.Children.Add(Avantviande3);
                        LayoutViande3.Children.Add(countviande3);
                        LayoutViande3.Children.Add(soitviande3);
                        LayoutViande3.Children.Add(pourcentviande3);
                        LayoutViande3.Children.Add(pourcentviande32);
                        LayoutViande3barre.Children.Add(barreviande3);
                    }
                    else if (Viande2 == uneResistance.Libelle)
                    {
                        c++;
                    }
                    else if (Viande2 != uneResistance.Libelle && i + 1 != TouteslesResistances.Count)
                    {
                        double p = ((double)c / TouteslesResistances.Count) * 100;
                        if (p <= 15)
                        {
                            barre = barre1;
                        }
                        else if (p <= 25)
                        {
                            barre = barre2;
                        }
                        else if (p <= 35)
                        {
                            barre = barre3;
                        }
                        else if (p <= 45)
                        {
                            barre = barre4;
                        }
                        else if (p <= 55)
                        {
                            barre = barre5;
                        }
                        else if (p <= 65)
                        {
                            barre = barre6;
                        }
                        else if (p <= 75)
                        {
                            barre = barre7;
                        }
                        else if (p <= 85)
                        {
                            barre = barre8;
                        }
                        else if (p <= 95)
                        {
                            barre = barre9;
                        }
                        else
                        {
                            barre = barre10;
                        }
                        string tp = String.Format("{0:N1}", p);
                        Avantviande2.Text = Viande2 + ": ";
                        countviande2.Text = c + "";
                        soitviande2.Text = " soit ";
                        pourcentviande2.Text = tp;
                        pourcentviande22.Text = "%";
                        barreviande2.Text = barre;
                        LayoutViande2.Children.Add(Avantviande2);
                        LayoutViande2.Children.Add(countviande2);
                        LayoutViande2.Children.Add(soitviande2);
                        LayoutViande2.Children.Add(pourcentviande2);
                        LayoutViande2.Children.Add(pourcentviande22);
                        LayoutViande2barre.Children.Add(barreviande2);
                        Viande3 = uneResistance.Libelle;
                        c = 1;
                    }
                    else if (i + 1 == TouteslesResistances.Count)
                    {
                        double p = ((double)c / TouteslesResistances.Count) * 100;
                        if (p <= 15)
                        {
                            barre = barre1;
                        }
                        else if (p <= 25)
                        {
                            barre = barre2;
                        }
                        else if (p <= 35)
                        {
                            barre = barre3;
                        }
                        else if (p <= 45)
                        {
                            barre = barre4;
                        }
                        else if (p <= 55)
                        {
                            barre = barre5;
                        }
                        else if (p <= 65)
                        {
                            barre = barre6;
                        }
                        else if (p <= 75)
                        {
                            barre = barre7;
                        }
                        else if (p <= 85)
                        {
                            barre = barre8;
                        }
                        else if (p <= 95)
                        {
                            barre = barre9;
                        }
                        else
                        {
                            barre = barre10;
                        }
                        string tp = String.Format("{0:N1}", p);
                        Avantviande3.Text = Viande3 + ": ";
                        countviande3.Text = c + "";
                        soitviande3.Text = " soit ";
                        pourcentviande3.Text = tp;
                        pourcentviande32.Text = "%";
                        barreviande3.Text = barre;
                        LayoutViande3.Children.Add(Avantviande3);
                        LayoutViande3.Children.Add(countviande3);
                        LayoutViande3.Children.Add(soitviande3);
                        LayoutViande3.Children.Add(pourcentviande3);
                        LayoutViande3.Children.Add(pourcentviande32);
                        LayoutViande3barre.Children.Add(barreviande3);
                    }
                    else if (Viande3 == uneResistance.Libelle)
                    {
                        c++;
                    }
                }
                else if (co == "4")
                {
                    if (Viande == "")
                    {
                        Viande = uneResistance.Libelle;
                        c++;
                    }
                    else if (Viande == uneResistance.Libelle)
                    {
                        c++;
                    }
                    else if (Viande != uneResistance.Libelle)
                    {
                        double p = ((double)c / TouteslesResistances.Count) * 100;
                        if (p <= 15)
                        {
                            barre = barre1;
                        }
                        else if (p <= 25)
                        {
                            barre = barre2;
                        }
                        else if (p <= 35)
                        {
                            barre = barre3;
                        }
                        else if (p <= 45)
                        {
                            barre = barre4;
                        }
                        else if (p <= 55)
                        {
                            barre = barre5;
                        }
                        else if (p <= 65)
                        {
                            barre = barre6;
                        }
                        else if (p <= 75)
                        {
                            barre = barre7;
                        }
                        else if (p <= 85)
                        {
                            barre = barre8;
                        }
                        else if (p <= 95)
                        {
                            barre = barre9;
                        }
                        else
                        {
                            barre = barre10;
                        }
                        string tp = String.Format("{0:N1}", p);
                        Avantviande.Text = Viande + ": ";
                        countviande.Text = c + "";
                        soitviande.Text = " soit ";
                        pourcentviande.Text = tp;
                        pourcentviande12.Text = "%";
                        barreviande.Text = barre;
                        LayoutViande1.Children.Add(Avantviande);
                        LayoutViande1.Children.Add(countviande);
                        LayoutViande1.Children.Add(soitviande);
                        LayoutViande1.Children.Add(pourcentviande);
                        LayoutViande1.Children.Add(pourcentviande12);
                        LayoutViande1barre.Children.Add(barreviande);
                        LayoutViandetitle.Children.Add(titleviande);
                        Viande2 = uneResistance.Libelle;
                        c = 1;
                    }
                    else if (Viande2 == uneResistance.Libelle)
                    {
                        c++;
                    }
                    else if (Viande2 != uneResistance.Libelle)
                    {
                        double p = ((double)c / TouteslesResistances.Count) * 100;
                        if (p <= 15)
                        {
                            barre = barre1;
                        }
                        else if (p <= 25)
                        {
                            barre = barre2;
                        }
                        else if (p <= 35)
                        {
                            barre = barre3;
                        }
                        else if (p <= 45)
                        {
                            barre = barre4;
                        }
                        else if (p <= 55)
                        {
                            barre = barre5;
                        }
                        else if (p <= 65)
                        {
                            barre = barre6;
                        }
                        else if (p <= 75)
                        {
                            barre = barre7;
                        }
                        else if (p <= 85)
                        {
                            barre = barre8;
                        }
                        else if (p <= 95)
                        {
                            barre = barre9;
                        }
                        else
                        {
                            barre = barre10;
                        }
                        string tp = String.Format("{0:N1}", p);
                        Avantviande2.Text = Viande2 + ": ";
                        countviande2.Text = c + "";
                        soitviande2.Text = " soit ";
                        pourcentviande2.Text = tp;
                        pourcentviande22.Text = "%";
                        barreviande2.Text = barre;
                        LayoutViande2.Children.Add(Avantviande2);
                        LayoutViande2.Children.Add(countviande2);
                        LayoutViande2.Children.Add(soitviande2);
                        LayoutViande2.Children.Add(pourcentviande2);
                        LayoutViande2.Children.Add(pourcentviande22);
                        LayoutViande2barre.Children.Add(barreviande2);
                        Viande3 = uneResistance.Libelle;
                        c = 1;
                    }
                    else if (Viande3 == uneResistance.Libelle)
                    {
                        c++;
                    }
                    else if (Viande3 != uneResistance.Libelle && i + 1 == TouteslesResistances.Count)
                    {
                        double p = ((double)c / TouteslesResistances.Count) * 100;
                        if (p <= 15)
                        {
                            barre = barre1;
                        }
                        else if (p <= 25)
                        {
                            barre = barre2;
                        }
                        else if (p <= 35)
                        {
                            barre = barre3;
                        }
                        else if (p <= 45)
                        {
                            barre = barre4;
                        }
                        else if (p <= 55)
                        {
                            barre = barre5;
                        }
                        else if (p <= 65)
                        {
                            barre = barre6;
                        }
                        else if (p <= 75)
                        {
                            barre = barre7;
                        }
                        else if (p <= 85)
                        {
                            barre = barre8;
                        }
                        else if (p <= 95)
                        {
                            barre = barre9;
                        }
                        else
                        {
                            barre = barre10;
                        }
                        string tp = String.Format("{0:N1}", p);
                        Avantviande3.Text = Viande3 + ": ";
                        countviande3.Text = c + "";
                        soitviande3.Text = " soit ";
                        pourcentviande3.Text = tp;
                        pourcentviande32.Text = "%";
                        barreviande3.Text = barre;
                        LayoutViande3.Children.Add(Avantviande3);
                        LayoutViande3.Children.Add(countviande3);
                        LayoutViande3.Children.Add(soitviande3);
                        LayoutViande3.Children.Add(pourcentviande3);
                        LayoutViande3.Children.Add(pourcentviande32);
                        LayoutViande3barre.Children.Add(barreviande3);
                        Viande4 = uneResistance.Libelle;
                        c = 1;
                        double pp = ((double)c / TouteslesResistances.Count) * 100;
                        if (pp <= 15)
                        {
                            barre = barre1;
                        }
                        else if (pp <= 25)
                        {
                            barre = barre2;
                        }
                        else if (pp <= 35)
                        {
                            barre = barre3;
                        }
                        else if (pp <= 45)
                        {
                            barre = barre4;
                        }
                        else if (pp <= 55)
                        {
                            barre = barre5;
                        }
                        else if (pp <= 65)
                        {
                            barre = barre6;
                        }
                        else if (pp <= 75)
                        {
                            barre = barre7;
                        }
                        else if (pp <= 85)
                        {
                            barre = barre8;
                        }
                        else if (pp <= 95)
                        {
                            barre = barre9;
                        }
                        else
                        {
                            barre = barre10;
                        }
                        string tpp = String.Format("{0:N1}", pp);
                        Avantviande4.Text = Viande4 + ": ";
                        countviande4.Text = c + "";
                        soitviande4.Text = " soit ";
                        pourcentviande4.Text = tpp;
                        pourcentviande42.Text = "%";
                        barreviande4.Text = barre;
                        LayoutViande4.Children.Add(Avantviande4);
                        LayoutViande4.Children.Add(countviande4);
                        LayoutViande4.Children.Add(soitviande4);
                        LayoutViande4.Children.Add(pourcentviande4);
                        LayoutViande4.Children.Add(pourcentviande42);
                        LayoutViande3barre.Children.Add(barreviande4);
                    }
                    else if (Viande3 != uneResistance.Libelle && i + 1 != TouteslesResistances.Count)
                    {
                        double p = ((double)c / TouteslesResistances.Count) * 100;
                        if (p <= 15)
                        {
                            barre = barre1;
                        }
                        else if (p <= 25)
                        {
                            barre = barre2;
                        }
                        else if (p <= 35)
                        {
                            barre = barre3;
                        }
                        else if (p <= 45)
                        {
                            barre = barre4;
                        }
                        else if (p <= 55)
                        {
                            barre = barre5;
                        }
                        else if (p <= 65)
                        {
                            barre = barre6;
                        }
                        else if (p <= 75)
                        {
                            barre = barre7;
                        }
                        else if (p <= 85)
                        {
                            barre = barre8;
                        }
                        else if (p <= 95)
                        {
                            barre = barre9;
                        }
                        else
                        {
                            barre = barre10;
                        }
                        string tp = String.Format("{0:N1}", p);
                        Avantviande3.Text = Viande3 + ": ";
                        countviande3.Text = c + "";
                        soitviande3.Text = " soit ";
                        pourcentviande3.Text = tp;
                        pourcentviande32.Text = "%";
                        barreviande3.Text = barre;
                        LayoutViande3.Children.Add(Avantviande3);
                        LayoutViande3.Children.Add(countviande3);
                        LayoutViande3.Children.Add(soitviande3);
                        LayoutViande3.Children.Add(pourcentviande3);
                        LayoutViande3.Children.Add(pourcentviande32);
                        LayoutViande3barre.Children.Add(barreviande3);
                        Viande4 = uneResistance.Libelle;
                        c = 1;
                    }
                    else if (i + 1 == TouteslesResistances.Count)
                    {
                        double p = ((double)c / TouteslesResistances.Count) * 100;
                        if (p <= 15)
                        {
                            barre = barre1;
                        }
                        else if (p <= 25)
                        {
                            barre = barre2;
                        }
                        else if (p <= 35)
                        {
                            barre = barre3;
                        }
                        else if (p <= 45)
                        {
                            barre = barre4;
                        }
                        else if (p <= 55)
                        {
                            barre = barre5;
                        }
                        else if (p <= 65)
                        {
                            barre = barre6;
                        }
                        else if (p <= 75)
                        {
                            barre = barre7;
                        }
                        else if (p <= 85)
                        {
                            barre = barre8;
                        }
                        else if (p <= 95)
                        {
                            barre = barre9;
                        }
                        else
                        {
                            barre = barre10;
                        }
                        string tp = String.Format("{0:N1}", p);
                        Avantviande4.Text = Viande4 + ": ";
                        countviande4.Text = c + "";
                        soitviande4.Text = " soit ";
                        pourcentviande4.Text = tp;
                        pourcentviande42.Text = "%";
                        barreviande4.Text = barre;
                        LayoutViande4.Children.Add(Avantviande4);
                        LayoutViande4.Children.Add(countviande4);
                        LayoutViande4.Children.Add(soitviande4);
                        LayoutViande4.Children.Add(pourcentviande4);
                        LayoutViande4.Children.Add(pourcentviande42);
                        LayoutViande3barre.Children.Add(barreviande4);
                    }
                    else if (Viande4 == uneResistance.Libelle)
                    {
                        c++;
                    }
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
                    double p = ((double)a / lesAccompagnements.Count) * 100;
                    string tp = String.Format("{0:N1}", p);                   
                    jourAccompagnement.Text += Accompagnement + ": " + a + " soit " + a * prop + " g " + " soit " + tp + "%" + "\n" + barre10;
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
                        double p = ((double)a / lesAccompagnements.Count) * 100;
                        if (p <= 15)
                        {
                            barre = barre1;
                        }
                        else if (p <= 25)
                        {
                            barre = barre2;
                        }
                        else if (p <= 35)
                        {
                            barre = barre3;
                        }
                        else if (p <= 45)
                        {
                            barre = barre4;
                        }
                        else if (p <= 55)
                        {
                            barre = barre5;
                        }
                        else if (p <= 65)
                        {
                            barre = barre6;
                        }
                        else if (p <= 75)
                        {
                            barre = barre7;
                        }
                        else if (p <= 85)
                        {
                            barre = barre8;
                        }
                        else if (p <= 95)
                        {
                            barre = barre9;
                        }
                        else
                        {
                            barre = barre10;
                        }
                        string tp = String.Format("{0:N1}", p);
                        jourAccompagnement.Text += Accompagnement + ": " + a + " soit " + a * prop + " g " + " soit " + tp + "%" + "\n" + barre;
                    }
                    else
                    {
                        double p = ((double)a / lesAccompagnements.Count) * 100;
                        if (p <= 15)
                        {
                            barre = barre1;
                        }
                        else if (p <= 25)
                        {
                            barre = barre2;
                        }
                        else if (p <= 35)
                        {
                            barre = barre3;
                        }
                        else if (p <= 45)
                        {
                            barre = barre4;
                        }
                        else if (p <= 55)
                        {
                            barre = barre5;
                        }
                        else if (p <= 65)
                        {
                            barre = barre6;
                        }
                        else if (p <= 75)
                        {
                            barre = barre7;
                        }
                        else if (p <= 85)
                        {
                            barre = barre8;
                        }
                        else if (p <= 95)
                        {
                            barre = barre9;
                        }
                        else
                        {
                            barre = barre10;
                        }
                        string tp = String.Format("{0:N1}", p);
                        jourAccompagnement.Text += Accompagnement + ": " + a + " soit " + a * prop + " g " + " soit " + tp + "%" + "\n" + barre + "\n";
                        a = 1;
                        prop = unAccompagnement.Gramme;
                        double pp = ((double)a / lesAccompagnements.Count) * 100;
                        if (pp <= 15)
                        {
                            barre = barre1;
                        }
                        else if (pp <= 25)
                        {
                            barre = barre2;
                        }
                        else if (pp <= 35)
                        {
                            barre = barre3;
                        }
                        else if (pp <= 45)
                        {
                            barre = barre4;
                        }
                        else if (pp <= 55)
                        {
                            barre = barre5;
                        }
                        else if (pp <= 65)
                        {
                            barre = barre6;
                        }
                        else if (pp <= 75)
                        {
                            barre = barre7;
                        }
                        else if (pp <= 85)
                        {
                            barre = barre8;
                        }
                        else if (pp <= 95)
                        {
                            barre = barre9;
                        }
                        else
                        {
                            barre = barre10;
                        }
                        string tpp = String.Format("{0:N1}", pp);
                        jourAccompagnement.Text += unAccompagnement.Libelle + ": " + a + " soit " + a * prop + " g " + " soit " + tpp + "%" + "\n" + barre ;
                    }
                }
                else if (Accompagnement == unAccompagnement.Libelle)
                {
                    a++;
                }
                else if (Accompagnement != unAccompagnement.Libelle)
                {
                    double p = ((double)a / lesAccompagnements.Count);
                    if (p <= 15)
                    {
                        barre = barre1;
                    }
                    else if (p <= 25)
                    {
                        barre = barre2;
                    }
                    else if (p <= 35)
                    {
                        barre = barre3;
                    }
                    else if (p <= 45)
                    {
                        barre = barre4;
                    }
                    else if (p <= 55)
                    {
                        barre = barre5;
                    }
                    else if (p <= 65)
                    {
                        barre = barre6;
                    }
                    else if (p <= 75)
                    {
                        barre = barre7;
                    }
                    else if (p <= 85)
                    {
                        barre = barre8;
                    }
                    else if (p <= 95)
                    {
                        barre = barre9;
                    }
                    else
                    {
                        barre = barre10;
                    }
                    string tp = String.Format("{0:N1}", p);
                    jourAccompagnement.Text += Accompagnement + ": " + a + " soit " + a * prop + " g " + " soit " + tp + "%" + "\n" + barre + "\n";
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
                eleveabsent.Text = co + "";
            }
            if (co == "1")
            {
                this.Content = new StackLayout
                {
                    Children =
                {
                    barJours,
                    menuStack,
                    LayoutViandetitle,
                    LayoutViande1,
                    LayoutViande1barre,
                    Cuisto

                }
                };
            }
            else if (co == "2")
            {
                this.Content = new StackLayout
                {
                    Children =
                {
                    barJours,
                    menuStack,
                    LayoutViandetitle,
                    LayoutViande1,
                    LayoutViande1barre,
                    LayoutViande2,
                    LayoutViande2barre,
                    Cuisto

                }
                };
            }
            else if (co == "3")
            {
                this.Content = new StackLayout
                {
                    Children =
                {
                    barJours,
                    menuStack,
                    LayoutViandetitle,
                    LayoutViande1,
                    LayoutViande1barre,
                    LayoutViande2,
                    LayoutViande2barre,
                    LayoutViande3,
                    LayoutViande3barre,
                    Cuisto

                }
                };
            }
            else { 
            this.Content = new StackLayout
            {
                Children =
                {
                    barJours,
                    menuStack,
                    LayoutViandetitle,
                    LayoutViande1,
                    LayoutViande1barre,
                    LayoutViande2,
                    LayoutViande2barre,
                    LayoutViande3,
                    LayoutViande3barre,
                    LayoutViande4,
                    LayoutViande4barre,
                    Cuisto

                }
            };
            }

        }
        ///////////////////////////////////////////////////////////////////Fin des Algorithmes//////////////////////////////////////////////////
    }
}