using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MyRostand.Models;
using MyRostand.Database;
using MyRostand.MyCovoit;

namespace MyRostand.MyCovoit.Reservation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class annulerReservation : ContentPage
    {
        internal Models.Reservation laReservation = DetailReservation.laReservation;
        public annulerReservation()
        {
            InitializeComponent();
            StackLayout stackPrincipal = new StackLayout()
            {
                Margin = new Thickness(30,20,30,0)
            };
            Title = "Annuler la réservation";

            StackLayout stackTrajet = new StackLayout();
            Label titreTrajet = new Label()
            {
                Text = "Voulez vous annuler la réservation du trajet suivant ? ",
                FontSize = 25
            };

            Label descTrajet = new Label()
            {
                Text = "🚘 Départ : " + laReservation.getTrajet().getLieuDepart().getLibelle() + "\n" +
                       "🚩 Arrivée : " + laReservation.getTrajet().getLieuArrive().getLibelle() + "\n" + 
                       "💰 Prix : " + laReservation.getPrix() + "€",
                FontSize = 20
            };

            stackTrajet.Children.Add(titreTrajet);
            stackTrajet.Children.Add(descTrajet);

            StackLayout stackBouton = new StackLayout()
            {
                Margin = new Thickness(0,10,0,0)
            };
            Button boutonConfirmer = new Button()
            {
                Text = "Annuler",
                BackgroundColor = Color.FromHex("#27ae60"),
                CornerRadius = 10,
                HeightRequest = 40
            };
            boutonConfirmer.Clicked += confirmerAnnulation;

            stackBouton.Children.Add(boutonConfirmer);

            stackPrincipal.Children.Add(stackTrajet);
            stackPrincipal.Children.Add(stackBouton);
            Content = stackPrincipal;
        }

        private void confirmerAnnulation(object sender, EventArgs e)
        {
            MyRostand.Database.MyCovoit.annulerReservation(laReservation);
            Navigation.PushAsync(new MesReservations());
        }
    }
}