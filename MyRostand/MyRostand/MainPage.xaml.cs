﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MyRostand.Database;
using MyRostand.MySonnerie;
using MyRostand.MyCantine;
using MyRostand.Models;

namespace MyRostand
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        Frame menuStack = new Frame();



        public MainPage()
        {
            Frame frameboutton = new Frame();
            StackLayout stackButton = new StackLayout();
            InitializeComponent();
            Title = "MyRostand - Accueil";
            var value = Application.Current.Properties["AppUser"];
            String id = value.ToString();
            int iduser = 0;
            List<User> LUser = Database.MyProfil.UnUser(id);
            for (int i = 0; i < LUser.Count; i++)
            {
                User UnUser = LUser[i];
                iduser = UnUser.Id;
            }
            Application.Current.Properties["IdUser"] = iduser;


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
                //ACTION A EFFECTUER QUAND ON CLIQUE SUR MYCANTINE (Ouvre la vue mycantine)
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
            /*==========================MON PROFIL =============================*/
            /*==================================================================*/

            Frame framePROFIL = new Frame()
            {
                Margin = new Thickness(40, 20, 40, 0),
                BackgroundColor = Color.FromHex("#FF8B00"),
                CornerRadius = 10,
                HasShadow = true
            };
            var tapPROFIL = new TapGestureRecognizer();
            tapPROFIL.Tapped += (s, e) =>
            {
                Navigation.PushAsync(new UserProfil());
            };
            framePROFIL.GestureRecognizers.Add(tapPROFIL);

            StackLayout blocPROFIL = new StackLayout()
            {
                Padding = new Thickness(15, 15, 15, 15)
            };
            StackLayout stackTitrePROFIL = new StackLayout()
            {
                Padding = new Thickness(30, 0, 30, 0)
            };
            StackLayout stackImagePROFIL = new StackLayout();
            Label titrePROFIL = new Label()
            {
                Text = "MyPROFIL",
                FontSize = 20
            };
            Image imagePROFIL = new Image()
            {
                Source = "profil.png"
            };
            stackImagePROFIL.Children.Add(imagePROFIL);
            stackTitrePROFIL.Children.Add(titrePROFIL);
            blocPROFIL.Children.Add(stackImagePROFIL);
            blocPROFIL.Children.Add(stackTitrePROFIL);
            framePROFIL.Content = blocPROFIL;
            /*==================================================================*/
            /*==========================MON RGPD =============================*/
            /*==================================================================*/

            Frame frameRGPD = new Frame()
            {
                Margin = new Thickness(40, 20, 40, 0),
                BackgroundColor = Color.FromHex("#388332"),
                CornerRadius = 10,
                HasShadow = true
            };
            var tapRGPD = new TapGestureRecognizer();
            tapRGPD.Tapped += (s, e) =>
            {
                Navigation.PushAsync(new RGPDPAGE());
            };
            frameRGPD.GestureRecognizers.Add(tapRGPD);

            StackLayout blocRGPD = new StackLayout()
            {
                Padding = new Thickness(15, 15, 15, 15)
            };
            StackLayout stackTitreRGPD = new StackLayout()
            {
                Padding = new Thickness(30, 0, 30, 0)
            };
            StackLayout stackImageRGPD = new StackLayout();
            Label titreRGPD = new Label()
            {
                Text = "RGPD",
                FontSize = 20
            };
            Image imageRGPD = new Image()
            {
                Source = "profil.png"
            };

            stackImageRGPD.Children.Add(imageRGPD);
            stackTitreRGPD.Children.Add(titreRGPD);
            blocRGPD.Children.Add(stackImageRGPD);
            blocRGPD.Children.Add(stackTitreRGPD);
            frameRGPD.Content = blocRGPD;

            Button Deconnexion = new Button()
            {
                BackgroundColor = Color.Red,
                Margin = new Thickness(30, 20, 30, 20),
                Padding = new Thickness(0, 1, 0, 1),
                Text = "Se Deconnecter",
                FontSize = 25,
                TextColor = Color.White
            };
            Deconnexion.Clicked += Cuisto_Clicked;
            async void Cuisto_Clicked(object sender, EventArgs e)
            {
                await Navigation.PushAsync(new login());
            }

            ScrollView VerticalScroll = new ScrollView()
            {
                Orientation = ScrollOrientation.Vertical,
                HeightRequest = 1800,
            };
            /*==================================================================*/
            /*============================CONTENT===============================*/
            /*==================================================================*/
            stackButton.Children.Add(frameCantine);
            stackButton.Children.Add(frameCovoit);
            stackButton.Children.Add(frameSonnerie);
            stackButton.Children.Add(framePROFIL);



            stackPrincipal.Children.Add(LogoAccueil);

            List<User> LeUser = Database.MyProfil.UnUser(id);
            for (int i = 0; i < LeUser.Count; i++)
            {
                User UnUser = LeUser[i];
                if (UnUser.Role == 3)
                {
                    stackButton.Children.Add(frameCUISINE);
                }
                else
                {

                }
            }
            stackButton.Children.Add(frameRGPD);
            stackButton.Children.Add(Deconnexion);           
            frameboutton.Content = stackButton;
            menuStack.Content = frameboutton;
            VerticalScroll.Content = menuStack;

            stackPrincipal.Children.Add(VerticalScroll);
            Content = stackPrincipal;

        }
    }
}
