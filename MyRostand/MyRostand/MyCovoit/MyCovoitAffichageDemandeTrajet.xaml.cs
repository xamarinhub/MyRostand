using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyRostand.MyCovoit
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyCovoitAffichageDemandeTrajet : ContentPage
    {
        public MyCovoitAffichageDemandeTrajet()
        {
            InitializeComponent();
            Title = "Demandes de trajets :";
            List<Models.Reservation> lesReservations = new List<Models.Reservation>();
            lesReservations = Database.MyCovoit.getLesReservations();


            ScrollView scroll = new ScrollView();

            StackLayout stackLayout = new StackLayout();

            for (int i = 0; i < lesReservations.Count; i++)
            {
                Models.Reservation uneReservation = lesReservations[i];

                Frame Card = new Frame
                {
                    Margin = new Thickness(40, 20, 40, 0),
                    BackgroundColor = Color.FromHex("#27ae60"),
                    CornerRadius = 10,
                    HasShadow = true
                };

                StackLayout stackCard = new StackLayout();

                StackLayout stakLabel = new StackLayout
                {
                    Padding = new Thickness(15, 15, 15, -10),
                    HeightRequest = 140,
                    WidthRequest = 100

                };

                Label labelTest = new Label
                {
                    TextColor = Color.White,
                    Text = "Montée : " + uneReservation.getMonte().ToString() + "\n" +
                    "Descente : " + uneReservation.getDescente() + "\n" +
                    "Prix : " + uneReservation.getPrix().ToString() + "€" + "\n" +
                    "Conducteur : " + uneReservation.getConducteur(),
                    FontSize = 25
                };



                scroll.Content = stackLayout;
                Content = scroll;
            }
        }
    }
}