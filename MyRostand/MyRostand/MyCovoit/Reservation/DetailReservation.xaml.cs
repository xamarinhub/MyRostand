using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyRostand.Models;


namespace MyRostand.MyCovoit.Reservation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailReservation : ContentPage
    {
        internal static Models.Reservation laReservation = MyCovoit.Reservation.MesReservations.detailReservation;
        
        public DetailReservation()
        {
            InitializeComponent();
            Trajet leTrajet = laReservation.getTrajet();
            var dateTrajet = leTrajet.getDate().Date.ToString("dd/MM/yyyy");
            Title = "Détail de la réservation";

            StackLayout stackPrincipal = new StackLayout()
            {
                Margin = new Thickness(30,20,30,0)
            };
            ScrollView scroll = new ScrollView();
            Label reservationSelectionne = new Label()
            {
                Text = "Lieu de départ : " + laReservation.getMonte() + "\n" +
                       "  "+"\n"+
                       "Lieu d'arrivée : " + laReservation.getDescente() + "\n" +
                       "  " + "\n" +
                       "Prix : " + laReservation.getPrix() + "€" + "\n",
                FontSize = 20
            };

            StackLayout stackCardTrajet = new StackLayout();
            Frame frameTrajet = new Frame()
            {
                CornerRadius = 10,
                BorderColor = Color.FromHex("#27ae60"),
                Padding = new Thickness(0,0,0,0)
            };
            StackLayout titreTrajet = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.Fill,
                BackgroundColor = Color.FromHex("#27ae60"),
                HeightRequest = 50,
                Padding = new Thickness(0,15,0,0)
            };
            Label titre = new Label()
            {
                HorizontalTextAlignment = TextAlignment.Center,
                Text = "Trajet",
                FontSize = 20,
                TextColor = Color.White
            };

            StackLayout descTrajet = new StackLayout()
            {
                Padding = new Thickness(10, 0, 10, 20)
            };
            Label description = new Label()
            {
                Text = "Description : " + leTrajet.getDescTrajet() + "\n" +
                       "  " + "\n" +
                       "Lieu de départ : " + leTrajet.getLieuDepart().getLibelle() + "\n" +
                       "  " + "\n" +
                       "Lieu d'arrivée : " + leTrajet.getLieuArrive().getLibelle() + "\n" +
                       "  " + "\n" +
                       "Date : " + dateTrajet + " de " + leTrajet.getHeureDepart() +" à "+ leTrajet.getHeureArrive() +"\n"+
                       "  " + "\n" +
                       "Nombre de places disponibles : " +leTrajet.getNbPlaces(),
                FontSize = 20
            };

            StackLayout stackCardConducteur = new StackLayout();
            Frame frameConducteur = new Frame()
            {
                CornerRadius = 10,
                BorderColor = Color.FromHex("#27ae60"),
                Padding = new Thickness(0, 0, 0, 0),
                Margin = new Thickness(0, 20, 0, 20)
            };

            StackLayout titreConducteur = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.Fill,
                BackgroundColor = Color.FromHex("#27ae60"),
                HeightRequest = 50,
                Padding = new Thickness(0, 15, 0, 0)
            };
            Label titreConducteurr = new Label()
            {
                HorizontalTextAlignment = TextAlignment.Center,
                Text = "Conducteur",
                FontSize = 20,
                TextColor = Color.White
            };

            

            StackLayout descConducteur = new StackLayout()
            {
                Padding = new Thickness(10, 0, 10, 20)
            };

            Label descriptionConducteur = new Label()
            {
                Text = "Nom : " + leTrajet.getConducteur().getNom() + "\n" +
                       "Prénom : " + leTrajet.getConducteur().getPrenom() + "\n" +
                       " " + "\n" +
                       "Date de naissance : " + leTrajet.getConducteur().getDateNaissance().ToString("dd/MM/yyyy") +
                       " " + "\n" + 
                       "Contacter " + leTrajet.getConducteur().getPrenom(),
                FontSize = 20
            };

            titreConducteur.Children.Add(titreConducteurr);
            stackCardConducteur.Children.Add(titreConducteur);
            descConducteur.Children.Add(descriptionConducteur);
            stackCardConducteur.Children.Add(descConducteur);
            frameConducteur.Content = stackCardConducteur;

            StackLayout boutonStakLayout = new StackLayout()
            {
                Margin = new Thickness(0,0,0,20)
            };

            Button boutonAnnuler = new Button
            {
                WidthRequest = 20,
                HeightRequest = 40,
                BackgroundColor = Color.FromHex("#27ae60"),
                CornerRadius = 10,
                Text = "Annuler",
                FontSize = 18,
                TextColor = Color.White
            };

            boutonAnnuler.Clicked += annulerReservation;

            boutonStakLayout.Children.Add(boutonAnnuler);

            descTrajet.Children.Add(description);
            titreTrajet.Children.Add(titre);
            stackCardTrajet.Children.Add(titreTrajet);
            stackCardTrajet.Children.Add(descTrajet);
            frameTrajet.Content = stackCardTrajet;

            stackPrincipal.Children.Add(reservationSelectionne);
            stackPrincipal.Children.Add(frameTrajet);
            stackPrincipal.Children.Add(frameConducteur);
            stackPrincipal.Children.Add(boutonStakLayout);
            scroll.Content = stackPrincipal;
            Content = scroll;
        }

        private void annulerReservation(object sender, EventArgs e)
        {
            Navigation.PushAsync(new annulerReservation());
        }
    }

}