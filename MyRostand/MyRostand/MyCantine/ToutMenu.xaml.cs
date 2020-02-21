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
            Text = "Gestion des quantitées",
            FontSize = 25,
            TextColor = Color.White
        };        

        DateTime ancienneDate = DateTime.Today;
        Label titleviande = new Label
        {
            Text = " Plats de résistance ",
            FontSize = 20,
            HorizontalTextAlignment = TextAlignment.Center,
            VerticalTextAlignment = TextAlignment.Center,
            TextColor = Color.FromHex("#FFFFFF")
        };
        StackLayout LayoutViandetitle = new StackLayout
        {
            HorizontalOptions = LayoutOptions.Fill,
            BackgroundColor = Color.FromHex("#27ae60"),
            HeightRequest = 40,       
        };
        Label titleaccomp = new Label
        {
            Text = " Accompagnement ",
            FontSize = 20,
            HorizontalTextAlignment = TextAlignment.Center,
            VerticalTextAlignment = TextAlignment.Center,
            TextColor = Color.FromHex("#FFFFFF")
        };
        StackLayout LayoutAccomptitle = new StackLayout
        {
            HorizontalOptions = LayoutOptions.Fill,
            BackgroundColor = Color.FromHex("#27ae60"),
            HeightRequest = 40,
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
        StackLayout LayoutAccomp1 = new StackLayout
        {
            Orientation = StackOrientation.Horizontal
        };
        StackLayout LayoutAccomp1barre = new StackLayout
        {
        };
        Label Avantaccomp = new Label
        {
            Text = "  ",
            FontSize = 30,
        };
        Label countaccomp = new Label
        {
            Text = "  ",
            FontSize = 30,
            TextColor = Color.FromHex("#77d065")
        };
        Label soitaccomp = new Label
        {
            Text = "  ",
            FontSize = 30,
        };
        Label poidaccomp = new Label
        {
            Text = "  ",
            FontSize = 30,
            TextColor = Color.FromHex("#15B0D6")
        };
        Label pourcentaccomp = new Label
        {
            Text = "  ",
            FontSize = 30,
            TextColor = Color.FromHex("#FF5733")
        };
        Label barreaccomp = new Label
        {
            Text = "  ",
            FontSize = 30,
            TextColor = Color.FromHex("#FF5733")
        };
        StackLayout LayoutAccomp2 = new StackLayout
        {
            Orientation = StackOrientation.Horizontal
        };
        StackLayout LayoutAccomp2barre = new StackLayout
        {
        };
        Label Avantaccomp2 = new Label
        {
            Text = "  ",
            FontSize = 30,
        };
        Label countaccomp2 = new Label
        {
            Text = "  ",
            FontSize = 30,
            TextColor = Color.FromHex("#77d065")
        };
        Label soitaccomp2 = new Label
        {
            Text = "  ",
            FontSize = 30,
        };
        Label poidaccomp2 = new Label
        {
            Text = "  ",
            FontSize = 30,
            TextColor = Color.FromHex("#15B0D6")
        };
        Label pourcentaccomp2 = new Label
        {
            Text = "  ",
            FontSize = 30,
            TextColor = Color.FromHex("#FF5733")
        };
        Label barreaccomp2 = new Label
        {
            Text = "  ",
            FontSize = 30,
            TextColor = Color.FromHex("#FF5733")
        };
        StackLayout LayoutAccomp3 = new StackLayout
        {
            Orientation = StackOrientation.Horizontal
        };
        StackLayout LayoutAccomp3barre = new StackLayout
        {
        };
        Label Avantaccomp3 = new Label
        {
            Text = "  ",
            FontSize = 30,
        };
        Label countaccomp3 = new Label
        {
            Text = "  ",
            FontSize = 30,
            TextColor = Color.FromHex("#77d065")
        };
        Label soitaccomp3 = new Label
        {
            Text = "  ",
            FontSize = 30,
        };
        Label poidaccomp3 = new Label
        {
            Text = "  ",
            FontSize = 30,
            TextColor = Color.FromHex("#15B0D6")
        };
        Label pourcentaccomp3 = new Label
        {
            Text = "  ",
            FontSize = 30,
            TextColor = Color.FromHex("#FF5733")
        };
        Label barreaccomp3 = new Label
        {
            Text = "  ",
            FontSize = 30,
            TextColor = Color.FromHex("#FF5733")
        };
        StackLayout LayoutAccomp4 = new StackLayout
        {
            Orientation = StackOrientation.Horizontal
        };
        StackLayout LayoutAccomp4barre = new StackLayout
        {
        };
        Label Avantaccomp4 = new Label
        {
            Text = "  ",
            FontSize = 30,
        };
        Label countaccomp4 = new Label
        {
            Text = "  ",
            FontSize = 30,
            TextColor = Color.FromHex("#77d065")
        };
        Label soitaccomp4 = new Label
        {
            Text = "  ",
            FontSize = 30,
        };
        Label poidaccomp4 = new Label
        {
            Text = "  ",
            FontSize = 30,
            TextColor = Color.FromHex("#15B0D6")
        };
        Label pourcentaccomp4 = new Label
        {
            Text = "  ",
            FontSize = 30,
            TextColor = Color.FromHex("#FF5733")
        };
        Label barreaccomp4 = new Label
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
                FontSize = 10,
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
                    menuStack,
                    Cuisto
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
            string ca = "0";
            List<Resistance> LeNb = Database.MyCantineSQL.getNBTouteslesResistances(daterequete);
            for (int i = 0; i < LeNb.Count; i++)
            {
                Resistance uneResistance = LeNb[i];
                co = uneResistance.Id + "";
            }
            ///////////////////////////////////////////////////////////////Fonction Afficher toutes les Résistances////////////////////////////////////////////////
            String Viande = "";
            String Viande2 = "";
            String Viande3 = "";
            String Viande4 = "";
            int idres = 0;
            int idres2 = 0;
            int idres3 = 0;
            int idres4= 0;
            int c = 0;
            int c2 = 0;
            int c3 = 0;
            int c4 = 0;
            
            List<Resistance> TouteslesResistances = Database.MyCantineSQL.getTouteslesResistances(daterequete);
            
            for (int i = 0; i < TouteslesResistances.Count; i++)
            {
                Resistance uneResistance = TouteslesResistances[i];
                if (co == "1")
                {

                    Viande = uneResistance.Libelle;
                    idres = uneResistance.Id;
                    List<Resistance> NBlesResistances = Database.MyCantineSQL.getNBlesResistances(daterequete, idres);
                    for (int n = 0; n < NBlesResistances.Count; n++)
                    {
                        Resistance NBuneResistance = NBlesResistances[n];
                        c = NBuneResistance.Count;
                    }

                    double p = ((double)c / TouteslesResistances.Count) * 100;
                    string tp = String.Format("{0:N1}", p);
                    Avantviande.Text = Viande + ": ";
                    countviande.Text = c + "";
                    soitviande.Text = " soit ";
                    pourcentviande.Text = tp;
                    pourcentviande12.Text = "%";
                    barreviande.Text = barre10;
                    LayoutViande1.Children.Add(Avantviande);
                    LayoutViande1.Children.Add(countviande);
                    LayoutViande1.Children.Add(soitviande);
                    LayoutViande1.Children.Add(pourcentviande);
                    LayoutViande1.Children.Add(pourcentviande12);
                    LayoutViande1barre.Children.Add(barreviande);
                }
                else if (co == "2")
                {
                    if (Viande == "")
                    {
                        Viande = uneResistance.Libelle;
                        idres = uneResistance.Id;
                        List<Resistance> NBlesResistances = Database.MyCantineSQL.getNBlesResistances(daterequete, idres);
                        for (int n = 0; n < NBlesResistances.Count; n++)
                        {
                            Resistance NBuneResistance = NBlesResistances[n];
                            c = NBuneResistance.Count;
                        }
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
                    }
                    else if (i == c)
                    {
                        Viande2 = uneResistance.Libelle;
                        idres = uneResistance.Id;
                        List<Resistance> NBlesResistances = Database.MyCantineSQL.getNBlesResistances(daterequete, idres);
                        for (int n = 0; n < NBlesResistances.Count; n++)
                        {
                            Resistance NBuneResistance = NBlesResistances[n];
                            c = NBuneResistance.Count;
                        }
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

                }
                else if (co == "3")
                {          
                    if ( i == 0)
                    {                    
                        Viande = uneResistance.Libelle;
                        idres = uneResistance.Id;
                        List<Resistance> NBlesResistances = Database.MyCantineSQL.getNBlesResistances(daterequete, idres);
                        for (int n = 0; n < NBlesResistances.Count; n++)
                        {
                            Resistance NBuneResistance = NBlesResistances[n];
                            c = NBuneResistance.Count;
                        }
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
                    }
                    if (i == c)
                    {
                        Viande2 = uneResistance.Libelle;
                        idres2 = uneResistance.Id;
                        List<Resistance> NBllesResistances = Database.MyCantineSQL.getNBlesResistances(daterequete, idres2);
                        for (int n = 0; n < NBllesResistances.Count; n++)
                        {
                            Resistance NBuneResistance = NBllesResistances[n];
                            c2 = NBuneResistance.Count;
                        }
                        double pp = ((double)c2 / TouteslesResistances.Count) * 100;
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
                        countviande2.Text = c2 + "";
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
                    else if (Viande2 != uneResistance.Libelle)
                    {
                        Viande3 = uneResistance.Libelle;
                        idres3 = uneResistance.Id;
                        List<Resistance> NBllesResistances = Database.MyCantineSQL.getNBlesResistances(daterequete, idres3);
                        for (int n = 0; n < NBllesResistances.Count; n++)
                        {
                            Resistance NBuneResistance = NBllesResistances[n];
                            c3 = NBuneResistance.Count;
                        }
                        double pp = ((double)c3 / TouteslesResistances.Count) * 100;
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
                        countviande3.Text = c3 + "";
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
                }
                else if (co == "4")
                {
                    if (i == 0)
                    {
                        Viande = uneResistance.Libelle;
                        idres = uneResistance.Id;
                        List<Resistance> NBlesResistances = Database.MyCantineSQL.getNBlesResistances(daterequete, idres);
                        for (int n = 0; n < NBlesResistances.Count; n++)
                        {
                            Resistance NBuneResistance = NBlesResistances[n];
                            c = NBuneResistance.Count;
                        }
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
                    }
                    if (i == c)
                    {
                        Viande2 = uneResistance.Libelle;
                        idres2 = uneResistance.Id;
                        List<Resistance> NBllesResistances = Database.MyCantineSQL.getNBlesResistances(daterequete, idres2);
                        for (int n = 0; n < NBllesResistances.Count; n++)
                        {
                            Resistance NBuneResistance = NBllesResistances[n];
                            c2 = NBuneResistance.Count;
                        }
                        double pp = ((double)c2 / TouteslesResistances.Count) * 100;
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
                        countviande2.Text = c2 + "";
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
                    else if (i == c+c2)
                    {
                        Viande3 = uneResistance.Libelle;
                        idres3 = uneResistance.Id;
                        List<Resistance> NBllesResistances = Database.MyCantineSQL.getNBlesResistances(daterequete, idres3);
                        for (int n = 0; n < NBllesResistances.Count; n++)
                        {
                            Resistance NBuneResistance = NBllesResistances[n];
                            c3 = NBuneResistance.Count;
                        }
                        double pp = ((double)c3 / TouteslesResistances.Count) * 100;
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
                        countviande3.Text = c3 + "";
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
                    else if (i == c+c2+c3)
                    {
                        Viande4 = uneResistance.Libelle;
                        idres4 = uneResistance.Id;
                        List<Resistance> NBllesResistances = Database.MyCantineSQL.getNBlesResistances(daterequete, idres4);
                        for (int n = 0; n < NBllesResistances.Count; n++)
                        {
                            Resistance NBuneResistance = NBllesResistances[n];
                            c4 = NBuneResistance.Count;
                        }
                        double pp = ((double)c4 / TouteslesResistances.Count) * 100;
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
                        countviande4.Text = c4 + "";
                        soitviande4.Text = " soit ";
                        pourcentviande4.Text = tpp;
                        pourcentviande42.Text = "%";
                        barreviande4.Text = barre;
                        LayoutViande4.Children.Add(Avantviande4);
                        LayoutViande4.Children.Add(countviande4);
                        LayoutViande4.Children.Add(soitviande4);
                        LayoutViande4.Children.Add(pourcentviande4);
                        LayoutViande4.Children.Add(pourcentviande42);
                        LayoutViande4barre.Children.Add(barreviande4);
                    }
                }

            }
            ///////////////////////////////////////////////////////////////Fonction Afficher tout les Accompagnements////////////////////////////////////////////////
            List<Accompagnement> LeNbAccompagnement = Database.MyCantineSQL.getNBTouteslesAccompagnements(daterequete);
            for (int i = 0; i < LeNb.Count; i++)
            {
                Accompagnement NbAccompagnement = LeNbAccompagnement[i];
                ca = NbAccompagnement.Id + "";
            }
            String Accompagnement1 = "";
            String Accompagnement2 = "";
            String Accompagnement3 = "";
            String Accompagnement4 = "";
            int idacc = 0;
            int idacc2 = 0;
            int idacc3 = 0;
            int idacc4 = 0;
            int a = 0;
            int a2 = 0;
            int a3 = 0;
            int a4 = 0;
            int prop = 0;
            int prop2 = 0;
            int prop3 = 0;
            int prop4 = 0;
            List<Accompagnement> lesAccompagnements = Database.MyCantineSQL.getToutlesAccompagnements(daterequete);
            for (int i = 0; i < lesAccompagnements.Count; i++)
            {
                Accompagnement unAccompagnement = lesAccompagnements[i];
                if (ca == "1")
                {
                        Accompagnement1 = unAccompagnement.Libelle;
                        idacc = unAccompagnement.Id;
                        List<Accompagnement> NBlesAccompagnements = Database.MyCantineSQL.getNBlesAccompagnements(daterequete, idacc);
                        for (int n = 0; n < NBlesAccompagnements.Count; n++)
                        {
                        Accompagnement NBuneAccompagnement = NBlesAccompagnements[n];
                        a = NBuneAccompagnement.Count;
                        }
                        prop = unAccompagnement.Gramme;
                        double p = ((double)a / lesAccompagnements.Count) * 100;
                        string tp = String.Format("{0:N1}", p);
                        Avantaccomp.Text = Accompagnement1 + ": ";
                        countaccomp.Text = a + "";
                        soitaccomp.Text = " soit ";
                        poidaccomp.Text = prop*a + "g ";
                        pourcentaccomp.Text = tp + "%";
                        barreaccomp.Text = barre10;
                        LayoutAccomp1.Children.Add(Avantaccomp);
                        LayoutAccomp1.Children.Add(countaccomp);
                        LayoutAccomp1.Children.Add(soitaccomp);
                        LayoutAccomp1.Children.Add(poidaccomp);
                        LayoutAccomp1.Children.Add(pourcentaccomp);
                        LayoutAccomp1barre.Children.Add(barreaccomp);
                }   
                if (ca == "2")
                {
                    if (i == 0)
                    {
                        Accompagnement1 = unAccompagnement.Libelle;
                        idacc = unAccompagnement.Id;
                        List<Accompagnement> NBlesAccompagnements = Database.MyCantineSQL.getNBlesAccompagnements(daterequete, idacc);
                        for (int n = 0; n < NBlesAccompagnements.Count; n++)
                        {
                            Accompagnement NBuneAccompagnement = NBlesAccompagnements[n];
                            a = NBuneAccompagnement.Count;
                        }
                        prop = unAccompagnement.Gramme;
                        double p = ((double)a / TouteslesResistances.Count) * 100;
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
                        Avantaccomp.Text = Accompagnement1 + ": ";
                        countaccomp.Text = a + "";
                        soitaccomp.Text = " soit ";
                        poidaccomp.Text = prop*a + "g ";
                        pourcentaccomp.Text = tp + "%";
                        barreaccomp.Text = barre;
                        LayoutAccomp1.Children.Add(Avantaccomp);
                        LayoutAccomp1.Children.Add(countaccomp);
                        LayoutAccomp1.Children.Add(soitaccomp);
                        LayoutAccomp1.Children.Add(poidaccomp);
                        LayoutAccomp1.Children.Add(pourcentaccomp);
                        LayoutAccomp1barre.Children.Add(barreaccomp);
                    }
                    if (i == a)
                    {
                        Accompagnement2 = unAccompagnement.Libelle;
                        idacc2 = unAccompagnement.Id;
                        List<Accompagnement> NBlesAccompagnements = Database.MyCantineSQL.getNBlesAccompagnements(daterequete, idacc2);
                        for (int n = 0; n < NBlesAccompagnements.Count; n++)
                        {
                            Accompagnement NBuneAccompagnement = NBlesAccompagnements[n];
                            a2 = NBuneAccompagnement.Count;
                        }
                        prop2 = unAccompagnement.Gramme;
                        double p = ((double)a2 / TouteslesResistances.Count) * 100;
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
                        Avantaccomp2.Text = Accompagnement2 + ": ";
                        countaccomp2.Text = a2 + "";
                        soitaccomp2.Text = " soit ";
                        poidaccomp2.Text = prop2*a2 + "g ";
                        pourcentaccomp2.Text = tp + "%";
                        barreaccomp2.Text = barre;
                        LayoutAccomp2.Children.Add(Avantaccomp2);
                        LayoutAccomp2.Children.Add(countaccomp2);
                        LayoutAccomp2.Children.Add(soitaccomp2);
                        LayoutAccomp2.Children.Add(poidaccomp2);
                        LayoutAccomp2.Children.Add(pourcentaccomp2);
                        LayoutAccomp2barre.Children.Add(barreaccomp2);
                    }
                }
                if (ca == "3")
                {
                    if (i == 0)
                    {
                        Accompagnement1 = unAccompagnement.Libelle;
                        idacc = unAccompagnement.Id;
                        List<Accompagnement> NBlesAccompagnements = Database.MyCantineSQL.getNBlesAccompagnements(daterequete, idacc);
                        for (int n = 0; n < NBlesAccompagnements.Count; n++)
                        {
                            Accompagnement NBuneAccompagnement = NBlesAccompagnements[n];
                            a = NBuneAccompagnement.Count;
                        }
                        prop = unAccompagnement.Gramme;
                        double p = ((double)a / TouteslesResistances.Count) * 100;
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
                        Avantaccomp.Text = Accompagnement1 + ": ";
                        countaccomp.Text = a + "";
                        soitaccomp.Text = " soit ";
                        poidaccomp.Text = prop*a + "g ";
                        pourcentaccomp.Text = tp + "%";
                        barreaccomp.Text = barre;
                        LayoutAccomp1.Children.Add(Avantaccomp);
                        LayoutAccomp1.Children.Add(countaccomp);
                        LayoutAccomp1.Children.Add(soitaccomp);
                        LayoutAccomp1.Children.Add(poidaccomp);
                        LayoutAccomp1.Children.Add(pourcentaccomp);
                        LayoutAccomp1barre.Children.Add(barreaccomp);
                    }
                    else if (i == a)
                    {
                        Accompagnement2 = unAccompagnement.Libelle;
                        idacc2 = unAccompagnement.Id;
                        List<Accompagnement> NBlesAccompagnements = Database.MyCantineSQL.getNBlesAccompagnements(daterequete, idacc2);
                        for (int n = 0; n < NBlesAccompagnements.Count; n++)
                        {
                            Accompagnement NBuneAccompagnement = NBlesAccompagnements[n];
                            a2 = NBuneAccompagnement.Count;
                        }
                        prop2 = unAccompagnement.Gramme;
                        double p = ((double)a2 / TouteslesResistances.Count) * 100;
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
                        Avantaccomp2.Text = Accompagnement2 + ": ";
                        countaccomp2.Text = a2 + "";
                        soitaccomp2.Text = " soit ";
                        poidaccomp2.Text = prop2*a2 + "g ";
                        pourcentaccomp2.Text = tp + "%";
                        barreaccomp2.Text = barre;
                        LayoutAccomp2.Children.Add(Avantaccomp2);
                        LayoutAccomp2.Children.Add(countaccomp2);
                        LayoutAccomp2.Children.Add(soitaccomp2);
                        LayoutAccomp2.Children.Add(poidaccomp2);
                        LayoutAccomp2.Children.Add(pourcentaccomp2);
                        LayoutAccomp2barre.Children.Add(barreaccomp2);
                    }
                    else if (i == a+a2)
                    {
                        Accompagnement3 = unAccompagnement.Libelle;
                        idacc3 = unAccompagnement.Id;
                        List<Accompagnement> NBlesAccompagnements = Database.MyCantineSQL.getNBlesAccompagnements(daterequete, idacc3);
                        for (int n = 0; n < NBlesAccompagnements.Count; n++)
                        {
                            Accompagnement NBuneAccompagnement = NBlesAccompagnements[n];
                            a3 = NBuneAccompagnement.Count;
                        }
                        prop3 = unAccompagnement.Gramme;
                        double p = ((double)a3 / TouteslesResistances.Count) * 100;
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
                        Avantaccomp3.Text = Accompagnement3 + ": ";
                        countaccomp3.Text = a3 + "";
                        soitaccomp3.Text = " soit ";
                        poidaccomp3.Text = prop3*a3 + "g ";
                        pourcentaccomp3.Text = tp + "%";
                        barreaccomp3.Text = barre;
                        LayoutAccomp3.Children.Add(Avantaccomp3);
                        LayoutAccomp3.Children.Add(countaccomp3);
                        LayoutAccomp3.Children.Add(soitaccomp3);
                        LayoutAccomp3.Children.Add(poidaccomp3);
                        LayoutAccomp3.Children.Add(pourcentaccomp3);
                        LayoutAccomp3barre.Children.Add(barreaccomp3);
                    }
                }
                if (ca == "4")
                {
                    if (i == 0)
                    {
                        Accompagnement1 = unAccompagnement.Libelle;
                        idacc = unAccompagnement.Id;
                        List<Accompagnement> NBlesAccompagnements = Database.MyCantineSQL.getNBlesAccompagnements(daterequete, idacc);
                        for (int n = 0; n < NBlesAccompagnements.Count; n++)
                        {
                            Accompagnement NBuneAccompagnement = NBlesAccompagnements[n];
                            a = NBuneAccompagnement.Count;
                        }
                        prop = unAccompagnement.Gramme;
                        double p = ((double)a / TouteslesResistances.Count) * 100;
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
                        Avantaccomp.Text = Accompagnement1 + ": ";
                        countaccomp.Text = a + "";
                        soitaccomp.Text = " soit ";
                        poidaccomp.Text = prop*a + "g ";
                        pourcentaccomp.Text = tp + "%";
                        barreaccomp.Text = barre;
                        LayoutAccomp1.Children.Add(Avantaccomp);
                        LayoutAccomp1.Children.Add(countaccomp);
                        LayoutAccomp1.Children.Add(soitaccomp);
                        LayoutAccomp1.Children.Add(poidaccomp);
                        LayoutAccomp1.Children.Add(pourcentaccomp);
                        LayoutAccomp1barre.Children.Add(barreaccomp);
                    }
                    else if (i == a)
                    {
                        Accompagnement2 = unAccompagnement.Libelle;
                        idacc2 = unAccompagnement.Id;
                        List<Accompagnement> NBlesAccompagnements = Database.MyCantineSQL.getNBlesAccompagnements(daterequete, idacc2);
                        for (int n = 0; n < NBlesAccompagnements.Count; n++)
                        {
                            Accompagnement NBuneAccompagnement = NBlesAccompagnements[n];
                            a2 = NBuneAccompagnement.Count;
                        }
                        prop2 = unAccompagnement.Gramme;
                        double p = ((double)a2 / TouteslesResistances.Count) * 100;
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
                        Avantaccomp2.Text = Accompagnement2 + ": ";
                        countaccomp2.Text = a2 + "";
                        soitaccomp2.Text = " soit ";
                        poidaccomp2.Text = prop2*a2 + "g ";
                        pourcentaccomp2.Text = tp + "%";
                        barreaccomp2.Text = barre;
                        LayoutAccomp2.Children.Add(Avantaccomp2);
                        LayoutAccomp2.Children.Add(countaccomp2);
                        LayoutAccomp2.Children.Add(soitaccomp2);
                        LayoutAccomp2.Children.Add(poidaccomp2);
                        LayoutAccomp2.Children.Add(pourcentaccomp2);
                        LayoutAccomp2barre.Children.Add(barreaccomp2);
                    }
                    else if (i == a + a2)
                    {
                        Accompagnement3 = unAccompagnement.Libelle;
                        idacc3 = unAccompagnement.Id;
                        List<Accompagnement> NBlesAccompagnements = Database.MyCantineSQL.getNBlesAccompagnements(daterequete, idacc3);
                        for (int n = 0; n < NBlesAccompagnements.Count; n++)
                        {
                            Accompagnement NBuneAccompagnement = NBlesAccompagnements[n];
                            a3 = NBuneAccompagnement.Count;
                        }
                        prop3 = unAccompagnement.Gramme;
                        double p = ((double)a3 / TouteslesResistances.Count) * 100;
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
                        Avantaccomp3.Text = Accompagnement3 + ": ";
                        countaccomp3.Text = a3 + "";
                        soitaccomp3.Text = " soit ";
                        poidaccomp3.Text = prop3*a3 + "g ";
                        pourcentaccomp3.Text = tp + "%";
                        barreaccomp3.Text = barre;
                        LayoutAccomp3.Children.Add(Avantaccomp3);
                        LayoutAccomp3.Children.Add(countaccomp3);
                        LayoutAccomp3.Children.Add(soitaccomp3);
                        LayoutAccomp3.Children.Add(poidaccomp3);
                        LayoutAccomp3.Children.Add(pourcentaccomp3);
                        LayoutAccomp3barre.Children.Add(barreaccomp3);
                    }
                    else if (i == a+a2+a3)
                    {
                        Accompagnement4 = unAccompagnement.Libelle;
                        idacc4 = unAccompagnement.Id;
                        List<Accompagnement> NBlesAccompagnements = Database.MyCantineSQL.getNBlesAccompagnements(daterequete, idacc4);
                        for (int n = 0; n < NBlesAccompagnements.Count; n++)
                        {
                            Accompagnement NBuneAccompagnement = NBlesAccompagnements[n];
                            a4 = NBuneAccompagnement.Count;
                        }
                        prop4 = unAccompagnement.Gramme;
                        double p = ((double)a4 / TouteslesResistances.Count) * 100;
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
                        Avantaccomp4.Text = Accompagnement4 + ": ";
                        countaccomp4.Text = a4 + "";
                        soitaccomp4.Text = " soit ";
                        poidaccomp4.Text = prop4*a4 + "g ";
                        pourcentaccomp4.Text = tp + "%";
                        barreaccomp4.Text = barre;
                        LayoutAccomp4.Children.Add(Avantaccomp4);
                        LayoutAccomp4.Children.Add(countaccomp4);
                        LayoutAccomp4.Children.Add(soitaccomp4);
                        LayoutAccomp4.Children.Add(poidaccomp4);
                        LayoutAccomp4.Children.Add(pourcentaccomp4);
                        LayoutAccomp4barre.Children.Add(barreaccomp4);
                    }
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
            LayoutAccomptitle.Children.Add(titleaccomp);
            if (co == "0" && ca == "0")
            {
                this.Content = new StackLayout
                {
                    Children =
                {
                    barJours,
                    menuStack,
                    LayoutViandetitle,
                    LayoutAccomptitle,
                    Cuisto
                }
                };
            }
            else if (co == "0" && ca == "1")
            {
                this.Content = new StackLayout
                {
                    Children =
                {
                    barJours,
                    menuStack,
                    LayoutViandetitle,
                    LayoutAccomptitle,
                    LayoutAccomp1,
                    LayoutAccomp1barre,
                    Cuisto
                }
                };
            }
            else if (co == "0" && ca == "2")
            {
                this.Content = new StackLayout
                {
                    Children =
                {
                    barJours,
                    menuStack,
                    LayoutViandetitle,
                    LayoutAccomptitle,
                    LayoutAccomp1,
                    LayoutAccomp1barre,
                    LayoutAccomp2,
                    LayoutAccomp2barre,
                    Cuisto
                }
                };
            }
            else if (co == "0" && ca == "3")
            {
                this.Content = new StackLayout
                {
                    Children =
                {
                    barJours,
                    menuStack,
                    LayoutViandetitle,
                    LayoutAccomptitle,
                    LayoutAccomp1,
                    LayoutAccomp1barre,
                    LayoutAccomp2,
                    LayoutAccomp2barre,
                    LayoutAccomp3,
                    LayoutAccomp3barre,
                    Cuisto
                }
                };
            }
            else if (co == "0" && ca == "4")
            {
                this.Content = new StackLayout
                {
                    Children =
                {
                    barJours,
                    menuStack,
                    LayoutViandetitle,
                    LayoutAccomptitle,
                    LayoutAccomp1,
                    LayoutAccomp1barre,
                    LayoutAccomp2,
                    LayoutAccomp2barre,
                    LayoutAccomp3,
                    LayoutAccomp3barre,
                    LayoutAccomp4,
                    LayoutAccomp4barre,
                    Cuisto
                }
                };
            }
            else if (co == "1" && ca == "0")
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
                    LayoutAccomptitle,
                    Cuisto

                }
                };
            }
            else if (co == "1" && ca == "1")
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
                    LayoutAccomptitle,
                    LayoutAccomp1,
                    LayoutAccomp1barre,
                    Cuisto

                }
                };
            }
            else if (co == "1" && ca == "2")
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
                    LayoutAccomptitle,
                    LayoutAccomp1,
                    LayoutAccomp1barre,
                    LayoutAccomp2,
                    LayoutAccomp2barre,
                    Cuisto

                }
                };
            }
            else if (co == "1" && ca == "3")
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
                    LayoutAccomptitle,
                    LayoutAccomp1,
                    LayoutAccomp1barre,
                    LayoutAccomp2,
                    LayoutAccomp2barre,
                    LayoutAccomp3,
                    LayoutAccomp3barre,
                    Cuisto

                }
                };
            }
            else if (co == "1" && ca == "4")
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
                    LayoutAccomptitle,
                    LayoutAccomp1,
                    LayoutAccomp1barre,
                    LayoutAccomp2,
                    LayoutAccomp2barre,
                    LayoutAccomp3,
                    LayoutAccomp3barre,
                    LayoutAccomp4,
                    LayoutAccomp4barre,
                    Cuisto

                }
                };
            }
            else if (co == "2" && ca == "0")
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
                    LayoutAccomptitle,
                    Cuisto

                }
                };
            }
            else if (co == "2" && ca == "1")
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
                    LayoutAccomptitle,
                    LayoutAccomp1,
                    LayoutAccomp1barre,
                    Cuisto

                }
                };
            }
            else if (co == "2" && ca == "2")
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
                    LayoutAccomptitle,
                    LayoutAccomp1,
                    LayoutAccomp1barre,
                    LayoutAccomp2,
                    LayoutAccomp2barre,
                    Cuisto

                }
                };
            }
            else if (co == "2" && ca == "3")
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
                    LayoutAccomptitle,
                    LayoutAccomp1,
                    LayoutAccomp1barre,
                    LayoutAccomp2,
                    LayoutAccomp2barre,
                    LayoutAccomp3,
                    LayoutAccomp3barre,
                    Cuisto

                }
                };
            }
            else if (co == "2" && ca == "4")
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
                    LayoutAccomptitle,
                    LayoutAccomp1,
                    LayoutAccomp1barre,
                    LayoutAccomp2,
                    LayoutAccomp2barre,
                    LayoutAccomp3,
                    LayoutAccomp3barre,
                    LayoutAccomp4,
                    LayoutAccomp4barre,
                    Cuisto

                }
                };
            }
            else if (co == "3" && ca == "0")
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
                    LayoutAccomptitle,                    
                    Cuisto

                }
                };
            }
            else if (co == "3" && ca == "1")
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
                    LayoutAccomptitle,
                    LayoutAccomp1,
                    LayoutAccomp1barre,
                    Cuisto

                }
                };
            }
            else if (co == "3" && ca == "2")
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
                    LayoutAccomptitle,
                    LayoutAccomp1,
                    LayoutAccomp1barre,
                    LayoutAccomp2,
                    LayoutAccomp2barre,
                    Cuisto

                }
                };
            }
            else if (co == "3" && ca == "3")
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
                    LayoutAccomptitle,
                    LayoutAccomp1,
                    LayoutAccomp1barre,
                    LayoutAccomp2,
                    LayoutAccomp2barre,
                    LayoutAccomp3,
                    LayoutAccomp3barre,
                    Cuisto

                }
                };
            }
            else if (co == "3" && ca == "4")
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
                    LayoutAccomptitle,
                    LayoutAccomp1,
                    LayoutAccomp1barre,
                    LayoutAccomp2,
                    LayoutAccomp2barre,
                    LayoutAccomp3,
                    LayoutAccomp3barre,
                    LayoutAccomp4,
                    LayoutAccomp4barre,
                    Cuisto

                }
                };
            }
            else if (co == "4" && ca == "0")
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
                    LayoutViande4,
                    LayoutViande4barre,
                    LayoutAccomptitle,
                    Cuisto

                }
                };
            }
            else if (co == "4" && ca == "1")
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
                    LayoutViande4,
                    LayoutViande4barre,
                    LayoutAccomptitle,
                    LayoutAccomp1,
                    LayoutAccomp1barre,
                    Cuisto

                }
                };
            }
            else if (co == "4" && ca == "2")
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
                    LayoutViande4,
                    LayoutViande4barre,
                    LayoutAccomptitle,
                    LayoutAccomp1,
                    LayoutAccomp1barre,
                    LayoutAccomp2,
                    LayoutAccomp2barre,
                    Cuisto

                }
                };
            }
            else if (co == "4" && ca == "3")
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
                    LayoutViande4,
                    LayoutViande4barre,
                    LayoutAccomptitle,
                    LayoutAccomp1,
                    LayoutAccomp1barre,
                    LayoutAccomp2,
                    LayoutAccomp2barre,
                    LayoutAccomp3,
                    LayoutAccomp3barre,
                    Cuisto

                }
                };
            }
            else if (co == "4" && ca == "4") 
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
                    LayoutViande4,
                    LayoutViande4barre,
                    LayoutAccomptitle,
                    LayoutAccomp1,
                    LayoutAccomp1barre,
                    LayoutAccomp2,
                    LayoutAccomp2barre,
                    LayoutAccomp3,
                    LayoutAccomp3barre,
                    LayoutAccomp4,
                    LayoutAccomp4barre,
                    Cuisto

                }
            };
            }

        }
        ///////////////////////////////////////////////////////////////////Fin des Algorithmes//////////////////////////////////////////////////
    }
}