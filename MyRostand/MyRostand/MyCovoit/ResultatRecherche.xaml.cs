using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyRostand.Models;
using MyRostand.MyCovoit;
using MyRostand.Database;

namespace MyRostand.MyCovoit
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultatRecherche : ContentPage
    {
        internal static List<Trajet> lesTrajetsRecuperes = MyCovoitAccueil.lesTrajets;
        internal static Trajet trajetChoisi;
        public ResultatRecherche()
        {
            InitializeComponent();
            Title = "Résultat de la recherche";
            List<Models.Trajet> lesTrajets = lesTrajetsRecuperes;



            ScrollView scroll = new ScrollView();

            StackLayout stackLayout = new StackLayout();

            for (int i = 0; i < lesTrajets.Count; i++)
            {
                Models.Trajet unTrajet = lesTrajets[i];
                StackLayout stackCard = new StackLayout();

                Frame Card = new Frame
                {
                    Margin = new Thickness(40, 20, 40, 0),
                    BackgroundColor = Color.FromHex("#27ae60"),
                    CornerRadius = 10,
                    HasShadow = true,
                };

                StackLayout stakLabel = new StackLayout
                {
                    Padding = new Thickness(15, 15, 15, -10),
                    HeightRequest = 220,
                    WidthRequest = 100

                };

                Label labelTest = new Label
                {
                    TextColor = Color.White,
                    Text = "Lieu de départ : " + unTrajet.getLieuDepart().getLibelle() + "\n" + "  " + "\n" +
                           "Lieu d'arrivée : " + unTrajet.getLieuArrive().getLibelle() + "\n" + "  " + "\n" +
                           "Heure de départ : " + unTrajet.getHeureDepart() + "\n" + "  " + "\n" +
                           "Conducteur : " + unTrajet.getConducteur().getPrenom() + " " + unTrajet.getConducteur().getNom(),
                    FontSize = 20
                };

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
                    trajetChoisi = unTrajet;
                    Navigation.PushAsync(new Reservation.ReserverTrajet());
                };
                boutonStakLayout.GestureRecognizers.Add(tapInfos);

                boutonStakLayout.Children.Add(bouton);

                stakLabel.Children.Add(labelTest);

                stackCard.Children.Add(stakLabel);
                stackCard.Children.Add(boutonStakLayout);

                Card.Content = stackCard;

                stackLayout.Children.Add(Card);

            }

            scroll.Content = stackLayout;
            this.Content = scroll;
        }
    }
}