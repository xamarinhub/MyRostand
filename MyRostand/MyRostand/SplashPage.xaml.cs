using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyRostand
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashPage : ContentPage
    {
        Image splashImage;
        public SplashPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            BackgroundImageSource = "woow.jpg";
            /*var sub = new StackLayout
            {
                BackgroundColor = Color.FromHex("#429de3")
            };

            splashImage = new Image
            {
                Source = "car.png",
                WidthRequest = 100,
                HeightRequest = 100
            };
            sub.Children.Add(splashImage);
            
            this.Content = sub;*/
        }
    }
}