using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyRostand.Models;
using MyRostand.Database;

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

                /*==========================*/

                string jourcomplet = libelleJour + "\n" + numjour + "\n" + nommois;
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

                ancienneDate = ancienneDate.AddDays(1);
            }

            horizontalScroll.Content = jourScroll;
            barJours.Children.Add(horizontalScroll);

            /*==================================================*/
            /*=============AFFICHAGE DU MENU====================*/
            /*==================================================*/

            menuStack.IsVisible = false; //SI ON CLIQUE SUR UN JOUR ON PASSE A TRUE (voir la fonction clicked)

            /*------------------------------------------*/

            menuStack.Children.Add(jourChoisi);
            menuStack.Children.Add(toutesresistances);
            menuStack.Children.Add(jourAccompagnement);

            /*==================================================*/
            /*==================================================*/

            stackPrincipal.Children.Add(barJours);
            stackPrincipal.Children.Add(menuStack);
            Content = stackPrincipal;

        }

        private void Bouton_Clicked(object sender, EventArgs e)
        {
            //cette variable sert à récupérer le jour en question, et afficher les menus correspondants
            string jourcomplet = ((Button)sender).Text;

            menuStack.IsVisible = true;

            jourChoisi.Text = "Jour choisi : " + jourcomplet;


            toutesresistances.Text = $" Viandes :";
            String Viande = "";
            List<Resistance> TouteslesResistances = Database.MyCantineSQL.getTouteslesResistances();
            for (int i = 0; i < TouteslesResistances.Count; i++)
            {
                Resistance uneResistance = TouteslesResistances[i];
                Viande = uneResistance.Libelle;
                toutesresistances.Text += uneResistance.Libelle + ", ";
            }

            jourAccompagnement.Text = $" Accompagnement :";
            List<Accompagnement> lesAccompagnements = Database.MyCantineSQL.getlesAccompagnements();
            for (int i = 0; i < lesAccompagnements.Count; i++)
            {
                Accompagnement unAccompagnement = lesAccompagnements[i];
                jourAccompagnement.Text += unAccompagnement.Libelle + ", ";
            }
        }
    }
}