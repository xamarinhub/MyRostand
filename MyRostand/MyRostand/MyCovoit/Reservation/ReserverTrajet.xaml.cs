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
    public partial class ReserverTrajet : ContentPage
    {
        internal Trajet trajetChoisi = ResultatRecherche.trajetChoisi;
        public ReserverTrajet()
        {
            InitializeComponent();
            Title = "Reserver un trajet";
            StackLayout stackPrincipal = new StackLayout()
            {
                Margin = new Thickness(30, 20, 30, 0)
            };

            StackLayout stackTrajet = new StackLayout();

            Label descTrajet = new Label()
            {
                Text = "🚘 Départ : " + trajetChoisi.getLieuDepart().getLibelle() + "\n" +
                       "🚩 Arrivée : " + trajetChoisi.getLieuArrive().getLibelle() + "\n" +
                       "🧑 Conducteur : " + trajetChoisi.getConducteur().getPrenom() + " " + trajetChoisi.getConducteur().getNom(),
                FontSize = 20
            };

            stackTrajet.Children.Add(descTrajet);

            StackLayout stackForm = new StackLayout();
            Picker lieuDepart = new Picker()
            {
                Title = "Choisissez un lieu de départ"
            };
            List<Lieu> lieuxDepart = Database.MyCovoit.getLesLieux();
            for(int i=0; i<lieuxDepart.Count; i++)
            {
                lieuDepart.Items.Add(lieuxDepart[i].getLibelle());
            }

            Picker lieuArrivee = new Picker()
            {
                Title = "Choisissez un lieu d'arrivée"
            };
            List<Lieu> lieuxArrivee = Database.MyCovoit.getLesLieux();
            for (int i = 0; i < lieuxArrivee.Count; i++)
            {
                lieuArrivee.Items.Add(lieuxArrivee[i].getLibelle());
            }

            stackForm.Children.Add(lieuDepart);
            stackForm.Children.Add(lieuArrivee);

            StackLayout boutonStakLayout = new StackLayout()
            {
                HeightRequest = 60
            };
            Frame bouton = new Frame()
            {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
                CornerRadius = 10,
                HeightRequest = 20
            };

            Label Labelbouton = new Label()
            {
                Text = "Réserver",
                HorizontalTextAlignment = TextAlignment.Center,
                BackgroundColor = Color.White,
                FontSize = 18,
                TextColor = Color.FromHex("#27ae60")
            };

            bouton.Content = Labelbouton;

            var tapInfos = new TapGestureRecognizer();
            tapInfos.Tapped += (s, e) =>
            {
                Database.MyCovoit.ajouterReservation(trajetChoisi.getId(), lieuDepart.SelectedItem.ToString(), lieuArrivee.SelectedItem.ToString());
                Navigation.PushAsync(new Reservation.MesReservations());
            };
            boutonStakLayout.GestureRecognizers.Add(tapInfos);

            boutonStakLayout.Children.Add(bouton);

            stackPrincipal.Children.Add(stackTrajet);
            stackPrincipal.Children.Add(stackForm);
            stackPrincipal.Children.Add(boutonStakLayout);


            Content = stackPrincipal;
        }
    }
}