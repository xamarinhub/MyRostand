using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyRostand.MyCovoit.Reservation;

namespace MyRostand.MyCovoit
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyCovoitNav : ContentView
    {
        public MyCovoitNav()
        {
            InitializeComponent();
        }

        async void GoMesReservations(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MesReservations());
        }

        async void GoMyProfil(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilUser());
        }
    }
}