using Android.Content.Res;
using MyRostand.Models;
using MyRostand.MyCovoit;
using MyRostand.MyCovoit.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyRostand
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyCovoitAccueil : ContentPage
    {
        internal static List<Trajet> lesTrajets = new List<Trajet>();
        internal static Models.Trajet trajetReserve;
        public MyCovoitAccueil()
        {
            InitializeComponent();
        }

        async void GoMyProfilUser(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilUser());
        }

        public void rechercherTrajets(object sender, EventArgs e)
        {
            lesTrajets = Database.MyCovoit.rechercherUnTrajet(Depart.Text, Arriver.Text);
            Navigation.PushAsync(new ResultatRecherche());
        }

        async void goReserverTrajet(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ReserverTrajet());
        }

    }


}