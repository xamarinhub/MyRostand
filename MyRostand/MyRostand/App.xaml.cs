using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace MyRostand
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            chargement();
        }

        protected async void chargement()
        {
            MainPage = new NavigationPage(new SplashPage());
            await Task.Delay(3000);
            MainPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.Green,
                BarTextColor = Color.White,
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public Xamarin.Forms.Color BarBackgroundColor { get; set; }
        public Xamarin.Forms.Color BarTextColor { get; set; }
    }
}
