using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRostand.MySonnerie;
using MyRostand.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyRostand.Database;
using System.Globalization;

namespace MyRostand.MySonnerie
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MySonnerieAccueil : ContentPage
    {
        public MySonnerieAccueil()
        {
            InitializeComponent();
            Frame sonnerieStack = new Frame();
            StackLayout stackCardSonnerie = new StackLayout();
            int semaine = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            Sondage unSondage = Database.MySonnerie.getUnSondage(semaine);
            int sondageId = unSondage.id;
            int idutilisateur = 3;
            int nbVoteMusique1 = 1;//Database.MySonnerie.NbVoteParMusique(unSondage.musique1, sondageId);
            int nbVoteMusique2 = 0;//Database.MySonnerie.NbVoteParMusique(unSondage.musique2, sondageId);
            int nbVoteMusique3 = 3;//Database.MySonnerie.NbVoteParMusique(unSondage.musique3, sondageId);
            int nbVoteMusique4 = 5;//Database.MySonnerie.NbVoteParMusique(unSondage.musique4, sondageId);

            int dejaVoterOuNon = 0;
            bool dejaVoter = false;

            if (dejaVoterOuNon != 0)
            {
                dejaVoter = true;
            }
            else
            {
                dejaVoter = false;
            }

            /////////////////////////////////////////////////////////////////////////

            Label titreSondage = new Label()
            {
                TextColor = Color.Black,
                BackgroundColor = Color.FromHex("#27ae60"),
                FontSize = 22,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                Margin = new Thickness(10, 10, 10, 50)
            };

            /////////////////////////////////////////////////////////////////////////

            Label informationSondage = new Label()
            {
                TextColor = Color.Black,
                BackgroundColor = Color.Beige,
                FontSize = 22,
                Text = "Voter pour la sonnerie qui sera mise pendant la semaine.",
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Margin = new Thickness(20, 10, 20, 30)
            };

            /////////////////////////////////////////////////////////////////////////

            Button LabelMusique1 = new Button()
            {
                TextColor = Color.Black,
                BackgroundColor = Color.LightGray,
                FontSize = 16,
                Margin = new Thickness(80, 20, 80, 30)
            };

            /////////////////////////////////////////////////////////////////////////
            

            Button LabelMusique2 = new Button()
            {
                TextColor = Color.Black,
                BackgroundColor = Color.LightGray,
                FontSize = 16,
                Margin = new Thickness(80, 20, 80, 30)
            };


            /////////////////////////////////////////////////////////////////////////

            Button LabelMusique3 = new Button()
            {
                TextColor = Color.Black,
                BackgroundColor = Color.LightGray,
                FontSize = 16,
                Margin = new Thickness(80, 20, 80, 30)
            };

            /////////////////////////////////////////////////////////////////////////

            Button LabelMusique4 = new Button()
            {
                TextColor = Color.Black,
                BackgroundColor = Color.LightGray,
                FontSize = 16,
                Margin = new Thickness(80, 20, 80, 30)
            };

            /////////////////////////////////////////////////////////////////////////

            Label statSondage = new Label()
            {
                TextColor = Color.Black,
                BackgroundColor = Color.Beige,
                FontSize = 22,
                Text = "Voici le nombre de vote par musique :",
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Margin = new Thickness(20, 10, 20, 30)
            };

            Button statMusique1 = new Button()
            {
                TextColor = Color.Black,
                BackgroundColor = Color.LightGray,
                FontSize = 16,
                Margin = new Thickness(80, 20, 80, 30)
            };

            Button statMusique2 = new Button()
            {
                TextColor = Color.Black,
                BackgroundColor = Color.LightGray,
                FontSize = 16,
                Margin = new Thickness(80, 20, 80, 30)
            };

            Button statMusique3 = new Button()
            {
                TextColor = Color.Black,
                BackgroundColor = Color.LightGray,
                FontSize = 16,
                Margin = new Thickness(80, 20, 80, 30)
            };

            Button statMusique4 = new Button()
            {
                TextColor = Color.Black,
                BackgroundColor = Color.LightGray,
                FontSize = 16,
                Margin = new Thickness(80, 20, 80, 30)
            };



            /////////////////////////////////////////////////////////////////////////
            LabelMusique1.Clicked += LabelMusique1_Click;

            async void LabelMusique1_Click(object senders, EventArgs ex)
            {
                if (LabelMusique1.BackgroundColor == Color.LightGray)
                {
                    LabelMusique1.BackgroundColor = Color.LightGreen;
                    LabelMusique2.BackgroundColor = Color.LightGray;
                    LabelMusique3.BackgroundColor = Color.LightGray;
                    LabelMusique4.BackgroundColor = Color.LightGray;
                    Database.MySonnerie.suppUnVote(idutilisateur, sondageId);
                    Database.MySonnerie.addUnVote(LabelMusique1.Text, idutilisateur, sondageId);
                }
            }

            /////////////////////////////////////////////////////////////////////////

            LabelMusique2.Clicked += LabelMusique2_Click;

            async void LabelMusique2_Click(object senders, EventArgs ex)
            {
                if (LabelMusique2.BackgroundColor == Color.LightGray)
                {
                    LabelMusique1.BackgroundColor = Color.LightGray;
                    LabelMusique2.BackgroundColor = Color.LightGreen;
                    LabelMusique3.BackgroundColor = Color.LightGray;
                    LabelMusique4.BackgroundColor = Color.LightGray;
                    Database.MySonnerie.suppUnVote(idutilisateur, sondageId);
                    Database.MySonnerie.addUnVote(LabelMusique2.Text, idutilisateur, sondageId);
                }
            }

            /////////////////////////////////////////////////////////////////////////

            LabelMusique3.Clicked += LabelMusique3_Click;

            async void LabelMusique3_Click(object senders, EventArgs ex)
            {
                if (LabelMusique3.BackgroundColor == Color.LightGray)
                {
                    LabelMusique1.BackgroundColor = Color.LightGray;
                    LabelMusique2.BackgroundColor = Color.LightGray;
                    LabelMusique3.BackgroundColor = Color.LightGreen;
                    LabelMusique4.BackgroundColor = Color.LightGray;
                    Database.MySonnerie.suppUnVote(idutilisateur, sondageId);
                    Database.MySonnerie.addUnVote(LabelMusique3.Text, idutilisateur, sondageId);
                }
            }

            /////////////////////////////////////////////////////////////////////////

            LabelMusique4.Clicked += LabelMusique4_Click;

            async void LabelMusique4_Click(object senders, EventArgs ex)
            {
                if (LabelMusique4.BackgroundColor == Color.LightGray)
                {
                    LabelMusique1.BackgroundColor = Color.LightGray;
                    LabelMusique2.BackgroundColor = Color.LightGray;
                    LabelMusique3.BackgroundColor = Color.LightGray;
                    LabelMusique4.BackgroundColor = Color.LightGreen;
                    Database.MySonnerie.suppUnVote(idutilisateur, sondageId);
                    Database.MySonnerie.addUnVote(LabelMusique4.Text, idutilisateur, sondageId);
                }
            }

            /////////////////////////////////////////////////////////////////////////

            titreSondage.Text = unSondage.titre;
            LabelMusique1.Text = unSondage.musique1;
            LabelMusique2.Text = unSondage.musique2;
            LabelMusique3.Text = unSondage.musique3;
            LabelMusique4.Text = unSondage.musique4;
            statMusique1.Text = unSondage.musique1 + " : " + nbVoteMusique1 + " votes. ";
            statMusique2.Text = unSondage.musique2 + " : " + nbVoteMusique2 + " votes. ";
            statMusique3.Text = unSondage.musique3 + " : " + nbVoteMusique3 + " votes. ";
            statMusique4.Text = unSondage.musique4 + " : " + nbVoteMusique4 + " votes. ";

            /////////////////////////////////////////////////////////////////////////

            stackCardSonnerie.Children.Add(titreSondage);
            stackCardSonnerie.Children.Add(informationSondage);
            stackCardSonnerie.Children.Add(LabelMusique1);
            stackCardSonnerie.Children.Add(LabelMusique2);
            stackCardSonnerie.Children.Add(LabelMusique3);
            stackCardSonnerie.Children.Add(LabelMusique4);
            stackCardSonnerie.Children.Add(statSondage);
            stackCardSonnerie.Children.Add(statMusique1);
            stackCardSonnerie.Children.Add(statMusique2);
            stackCardSonnerie.Children.Add(statMusique3);
            stackCardSonnerie.Children.Add(statMusique4);

            /////////////////////////////////////////////////////////////////////////

            sonnerieStack.Content = stackCardSonnerie;
            Content = sonnerieStack;

 

                /////////////////////////////////////////////////////////////////////////
            }
    }
}