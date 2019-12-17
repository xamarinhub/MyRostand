using MyRostand.MyCantine;
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
    public partial class MyCantineAccueil : ContentPage
    {
        public MyCantineAccueil()
        {
            InitializeComponent();
        }

        async void GoJoursSemaineAct(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new JoursSemaineAct());
        }
    }
}