using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyRostand.Database;

namespace MyRostand.MyCovoit
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyCovoitDemandeTrajet : ContentPage
    {
        public MyCovoitDemandeTrajet()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DateTime date = DateChoisie.Date;
            var heure = HeureChoisie.Time;

            Database.MyCovoit.DemanderTrajet(Depart.Text, Arriver.Text, date.ToString(), ListeFrequence.SelectedItem.ToString(), heure.ToString());

        }

        async void bopbopliste(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MyCovoitAffichageDemandeTrajet());
        }


    }
}