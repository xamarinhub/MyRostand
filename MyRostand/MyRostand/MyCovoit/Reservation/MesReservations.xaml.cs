using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyRostand.Models;
using MyRostand.Database;

namespace MyRostand.MyCovoit.Reservation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MesReservations : ContentPage
    {
        internal static Models.Reservation detailReservation;
        public MesReservations()
        {
             
        InitializeComponent();
            Title = "MES RESERVATIONS";
            List<Models.Reservation> lesReservations = new List<Models.Reservation>();
            lesReservations = Database.MyCovoit.getLesReservations();


            ScrollView scroll = new ScrollView();

            StackLayout stackLayout = new StackLayout();

            for (int i = 0; i < lesReservations.Count; i++)
            {
                Models.Reservation uneReservation = lesReservations[i];
                StackLayout stackCard = new StackLayout();

                Frame Card = new Frame
                {
                    Margin = new Thickness(40,20,40,0),
                    BackgroundColor = Color.FromHex("#27ae60"),
                    CornerRadius = 10,
                    HasShadow = true
                };

                StackLayout stakLabel = new StackLayout
                {
                    Padding = new Thickness(15, 0, 15,0),
                };

                Label labelTest = new Label
                {
                    TextColor = Color.White,
                    Text = "🚘 Montée : " + uneReservation.getMonte().ToString() + "\n" +
                    "🚩 Descente : " + uneReservation.getDescente() + "\n" +
                    "💰 Prix : " + uneReservation.getPrix().ToString() + "€"+"\n"+
                    "🧑 Conducteur : "+uneReservation.getConducteur().getPrenom()+" "+uneReservation.getConducteur().getNom(),
                    FontSize = 20
                };

                // Your label tap event
                var tapInfos = new TapGestureRecognizer();
                tapInfos.Tapped += (s, e) =>
                {
                    //ACTION A EFFECTUER QUAND ON CLIQUE SUR LES INFOS DU TRAJET
                    detailReservation = uneReservation;
                    Navigation.PushAsync(new DetailReservation());
                };
                labelTest.GestureRecognizers.Add(tapInfos);

                stakLabel.Children.Add(labelTest);

                stackCard.Children.Add(stakLabel);
                //stackCard.Children.Add(boutonStakLayout);

                Card.Content = stackCard;

                stackLayout.Children.Add(Card);

            }

            scroll.Content = stackLayout;
            Content = scroll;
        }



    }
}