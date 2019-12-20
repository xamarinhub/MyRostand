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
            Title = "MyRostand";
            StackLayout stackPrincipal = new StackLayout()
            {
                Padding = new Thickness(0, 20, 0, 0),
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            Label titrePrincipal = new Label()
            {
                Text = "MyRostand",
                FontSize = 25
            };

            stackPrincipal.Children.Add(titrePrincipal);


            NavigationPage.SetHasNavigationBar(this, false);
            var sub = new StackLayout
            {
                BackgroundColor = Color.FromHex("#f7f1e3")
            };

            splashImage = new Image
            {
                Source = "slapshscreen.png",
                WidthRequest = 700,
                HeightRequest = 700,
            };
            sub.Children.Add(splashImage);

            this.Content = sub;
        }
    }
}