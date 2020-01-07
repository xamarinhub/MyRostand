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
        Label jourChoisi = new Label() { FontSize = 20 };
        Label jourEntree = new Label() { FontSize = 20 };
        Label jourViande = new Label() { FontSize = 20 };
        Label jourAccompagnement = new Label() { FontSize = 20 };
        Label jourLaitage = new Label() { FontSize = 20 };
        Label jourDesserts = new Label() { FontSize = 20 };
        public MyCantineAccueil()
        {
            InitializeComponent();

            Title = "Menu de la semaine";
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

            string numjour;
            string nomjour;
            string nummois;
            string nommois="";
            numjour = $"{ DateTime.Today.Day}";
            nummois = $"{DateTime.Today.Month}";
            nomjour = $"{ DateTime.Today.DayOfWeek }";

            for (int i = 1; i <= 365; i++)
            {

                if (nomjour == "Tuesday")
                {
                    nomjour = "Mardi";
                }
                else if (nomjour == "Wednesday ")
                {
                    nomjour = "Mercredi";
                }
                else if (nomjour == "Monday")
                {
                    nomjour = "Lundi";
                }
                else if (nomjour == "Thursday")
                {
                    nomjour = "Jeudi";
                }
                else if (nomjour == "Friday")
                {
                    nomjour = "Vendredi";
                }
                else if (nomjour == "Saturday")
                {
                    nomjour = "Samedi";
                }
                else if (nomjour == "Sunday")
                {
                    nomjour = "Dimanche";
                }
                else if (nummois == "1")
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
                else if (nummois == "12")
                {
                    nommois = "Décembre";
                }


                string jourcomplet = nomjour +"\n"+numjour+"\n" + nommois;
                Button bouton = new Button()
                {
                    Margin = new Thickness(1, 1, 1, 1),
                    BackgroundColor = Color.FromHex("#27ae60"),
                    BorderColor = Color.GhostWhite,
                    BorderWidth = 2,
                    CornerRadius = 10,
                    Text = jourcomplet,
                    TextColor = Color.White,

                };

                bouton.Clicked += Bouton_Clicked; //QUAND ON CLIQUE, ON AFFICHE LE MENU

                jourScroll.Children.Add(bouton);

            }

            StackLayout stackCard = new StackLayout()
            {
                HeightRequest = 60
            };

            Frame Card = new Frame
            {
                Margin = new Thickness(40, 20, 40, 0),
                BackgroundColor = Color.White,
                BorderColor = Color.FromHex("#27ae60"),
                CornerRadius = 10,
                HasShadow = true
            };

            StackLayout stakLabel = new StackLayout
            {
                Padding = new Thickness(15, 0, 15, 0),
            };

            Label labelTest = new Label
            {
                TextColor = Color.White,
                FontSize = 20
            };

            // Your label tap event
            var tapInfos = new TapGestureRecognizer();
            tapInfos.Tapped += (s, e) =>
            {
                //ACTION A EFFECTUER QUAND ON CLIQUE SUR LES INFOS DU TRAJET
                /*detailReservation = uneReservation;
                Navigation.PushAsync(new DetailReservation());*/
            };
            labelTest.GestureRecognizers.Add(tapInfos);

            stakLabel.Children.Add(labelTest);

            stackCard.Children.Add(stakLabel);
            //stackCard.Children.Add(boutonStakLayout);

            Card.Content = stackCard;

            

            horizontalScroll.Content = jourScroll;
            barJours.Children.Add(horizontalScroll);

            /*==================================================*/
            /*=============AFFICHAGE DU MENU====================*/
            /*==================================================*/

            StackLayout menuStack = new StackLayout();

            menuStack.Children.Add(jourChoisi);
            menuStack.Children.Add(jourEntree);
            menuStack.Children.Add(jourViande);
            menuStack.Children.Add(jourAccompagnement);
            menuStack.Children.Add(jourLaitage);
            menuStack.Children.Add(jourDesserts);

            /*==================================================*/
            /*==================================================*/

            stackPrincipal.Children.Add(barJours);
            stackPrincipal.Children.Add(menuStack);
            stackPrincipal.Children.Add(Card);
            Content = stackPrincipal;

    }

        private void Bouton_Clicked(object sender, EventArgs e)
        {
            //cette variable sert à récupérer le jour en question, et afficher les menus correspondants (a vous de le faire)
            string jourcomplet = ((Button)sender).Text;
            
            jourChoisi.Text = "Jour choisi : "+jourcomplet;


            jourEntree.Text = $" Entrées :";

            List<Entree> lesEntrees = Database.MyCantineSQL.getLesEntrees();

            for (int i = 0; i < lesEntrees.Count; i++)
            {
                Entree uneEntree = lesEntrees[i];
                jourEntree.Text += uneEntree.Libelle + ", ";
            }


            jourViande.Text = $" Viandes :";

            List<Resistance> lesResistances = Database.MyCantineSQL.getlesResistances();
            for (int i = 0; i < lesResistances.Count; i++)
            {
                Resistance uneResistance = lesResistances[i];
                jourViande.Text += uneResistance.Libelle + ", ";
            }

            jourAccompagnement.Text = $" Accompagnement :";
            List<Accompagnement> lesAccompagnements = Database.MyCantineSQL.getlesAccompagnements();
            for (int i = 0; i < lesAccompagnements.Count; i++)
            {
                Accompagnement unAccompagnement = lesAccompagnements[i];
                jourAccompagnement.Text += unAccompagnement.Libelle + ", ";
            }

            jourLaitage.Text = $" Laitage :";
            jourDesserts.Text = $" Desserts :";           
        }
       
    }
}