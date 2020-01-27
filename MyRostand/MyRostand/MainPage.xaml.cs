using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MyRostand.Database;
using MyRostand.MySonnerie;
using MyRostand.MyCantine;

namespace MyRostand
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Title = "MyRostand - Accueil";
            StackLayout stackPrincipal = new StackLayout()
            {
                Padding = new Thickness(0, 40, 0, 0),
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            Image LogoAccueil = new Image()
            {
                Source = "myrostandaccueil.jpg"
            };
        /*==================================================================*/
        /*==========================MY CANTINE==============================*/
        /*==================================================================*/

        Frame frameCantine = new Frame()
            {
                Margin = new Thickness(40, 20, 40, 0),
                BackgroundColor = Color.FromHex("#27ae60"),
                CornerRadius = 10,
                HasShadow = true
            };
            var tapCantine = new TapGestureRecognizer();
            tapCantine.Tapped += (s, e) =>
            {
                //ACTION A EFFECTUER QUAND ON CLIQUE SUR LES INFOS DU TRAJET
                Navigation.PushAsync(new MyCantineAccueil());
            };
            frameCantine.GestureRecognizers.Add(tapCantine);

            StackLayout blocCantine = new StackLayout()
            {
                Padding = new Thickness(15, 15, 15, 15)
            };
            StackLayout stackTitreCantine = new StackLayout()
            {
                Padding = new Thickness(30, 0, 30, 0)
            };
            StackLayout stackImageCantine = new StackLayout();
            Label titreCantine = new Label()
            {
                Text = "MyCantine",
                FontSize = 20
            };
            Image imageCantine = new Image()
            {
                Source = "mycantine.png"
            };

            stackImageCantine.Children.Add(imageCantine);
            stackTitreCantine.Children.Add(titreCantine);
            blocCantine.Children.Add(stackImageCantine);
            blocCantine.Children.Add(stackTitreCantine);
            frameCantine.Content = blocCantine;

            /*==================================================================*/
            /*==========================MY COVOIT===============================*/
            /*==================================================================*/

            Frame frameCovoit = new Frame()
            {
                Margin = new Thickness(40, 20, 40, 0),
                BackgroundColor = Color.FromHex("#f9ca24"),
                CornerRadius = 10,
                HasShadow = true
            };
            var tapCovoit = new TapGestureRecognizer();
            tapCovoit.Tapped += (s, e) =>
            {
                //ACTION A EFFECTUER QUAND ON CLIQUE SUR LES INFOS DU TRAJET

                Navigation.PushAsync(new MyCovoitAccueil());
            };
            frameCovoit.GestureRecognizers.Add(tapCovoit);

            StackLayout blocCovoit = new StackLayout()
            {
                Padding = new Thickness(15, 15, 15, 15)
            };
            StackLayout stackTitreCovoit = new StackLayout()
            {
                Padding = new Thickness(30, 0, 30, 0)
            };
            StackLayout stackImageCovoit = new StackLayout();
            Label titreCovoit = new Label()
            {
                Text = "MyCovoit",
                FontSize = 20
            };
            Image imageCovoit = new Image()
            {
                Source = "mycovoit.png"
            };

            stackImageCovoit.Children.Add(imageCovoit);
            stackTitreCovoit.Children.Add(titreCovoit);
            blocCovoit.Children.Add(stackImageCovoit);
            blocCovoit.Children.Add(stackTitreCovoit);
            frameCovoit.Content = blocCovoit;

            /*==================================================================*/
            /*==========================MY SONNERIE=============================*/
            /*==================================================================*/

            Frame frameSonnerie = new Frame()
            {
                Margin = new Thickness(40, 20, 40, 0),
                BackgroundColor = Color.FromHex("#22a6b3"),
                CornerRadius = 10,
                HasShadow = true
            };
            var tapSonnerie = new TapGestureRecognizer();
            tapSonnerie.Tapped += (s, e) =>
            {
                //ACTION A EFFECTUER QUAND ON CLIQUE SUR LES INFOS DU TRAJET
                Navigation.PushAsync(new MySonnerieAccueil());
            };
            frameSonnerie.GestureRecognizers.Add(tapSonnerie);

            StackLayout blocSonnerie = new StackLayout()
            {
                Padding = new Thickness(15, 15, 15, 15)
            };
            StackLayout stackTitreSonnerie = new StackLayout()
            {
                Padding = new Thickness(30, 0, 30, 0)
            };
            StackLayout stackImageSonnerie = new StackLayout();
            Label titreSonnerie = new Label()
            {
                Text = "MySonnerie",
                FontSize = 20
            };
            Image imageSonnerie = new Image()
            {
                Source = "mysonnerie.png"
            };

            stackImageSonnerie.Children.Add(imageSonnerie);
            stackTitreSonnerie.Children.Add(titreSonnerie);
            blocSonnerie.Children.Add(stackImageSonnerie);
            blocSonnerie.Children.Add(stackTitreSonnerie);
            frameSonnerie.Content = blocSonnerie;


            /*==================================================================*/
            /*==========================ACCES CUISINE=============================*/
            /*==================================================================*/

            Frame frameCUISINE = new Frame()
            {
                Margin = new Thickness(40, 20, 40, 0),
                BackgroundColor = Color.DarkOrchid,
                CornerRadius = 10,
                HasShadow = true
            };
            var tapCUISINE = new TapGestureRecognizer();
            tapCUISINE.Tapped += (s, e) =>
            {
                //ACTION A EFFECTUER QUAND ON CLIQUE SUR LES INFOS DU TRAJET
                Navigation.PushAsync(new ToutMenu());
            };
            frameCUISINE.GestureRecognizers.Add(tapCUISINE);

            StackLayout blocCUISINE = new StackLayout()
            {
                Padding = new Thickness(15, 15, 15, 15)
            };
            StackLayout stackTitreCUISINE = new StackLayout()
            {
                Padding = new Thickness(30, 0, 30, 0)
            };
            StackLayout stackImageCUISINE = new StackLayout();
            Label titreCUISINE = new Label()
            {
                Text = "MyCUISINE",
                FontSize = 20
            };
            Image imageCUISINE = new Image()
            {
                Source = "mycantine.png"
            };

            stackImageCUISINE.Children.Add(imageCUISINE);
            stackTitreCUISINE.Children.Add(titreCUISINE);
            blocCUISINE.Children.Add(stackImageCUISINE);
            blocCUISINE.Children.Add(stackTitreCUISINE);
            frameCUISINE.Content = blocCUISINE;

            /*==================================================================*/
            /*============================CONTENT===============================*/
            /*==================================================================*/
            stackPrincipal.Children.Add(LogoAccueil);
            stackPrincipal.Children.Add(frameCantine);
            stackPrincipal.Children.Add(frameCovoit);
            stackPrincipal.Children.Add(frameSonnerie);
            stackPrincipal.Children.Add(frameCUISINE);
            Content = stackPrincipal;
        }
    }
}
