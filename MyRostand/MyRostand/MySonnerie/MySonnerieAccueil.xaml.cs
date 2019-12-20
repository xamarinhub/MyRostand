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

namespace MyRostand.MySonnerie
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MySonnerieAccueil : ContentPage
    {
        public MySonnerieAccueil()
        {
            InitializeComponent();

            Sondage unSondage = Database.MySonnerie.getUnSondage(51);
            titreSondage.Text = unSondage.titre;
            LabelMusique1.Text = unSondage.musique1;
            LabelMusique2.Text = unSondage.musique2;
            LabelMusique3.Text = unSondage.musique3;
            LabelMusique4.Text = unSondage.musique4;
        }

        bool modifEtat = false;





        public void OnCheckBoxCheckedChanged1(object sender, CheckedChangedEventArgs e)
        {

            // Perform required operation after examining e.Value
            modifEtat = true;
            if (modifEtat == true && BoxMusique1.IsChecked == true)
            {
                BoxMusique2.IsChecked = false;
                BoxMusique3.IsChecked = false;
                BoxMusique4.IsChecked = false;
            }
        }

        public void OnCheckBoxCheckedChanged2(object sender, CheckedChangedEventArgs e)
        {
            // Perform required operation after examining e.Value
            modifEtat = true;
            if (modifEtat == true && BoxMusique2.IsChecked == true)
            {
                BoxMusique1.IsChecked = false;
                BoxMusique3.IsChecked = false;
                BoxMusique4.IsChecked = false;
            }
        }


        public void OnCheckBoxCheckedChanged3(object sender, CheckedChangedEventArgs e)
        {
            // Perform required operation after examining e.Value
            modifEtat = true;
            if (modifEtat == true && BoxMusique3.IsChecked == true)
            {
                BoxMusique1.IsChecked = false;
                BoxMusique2.IsChecked = false;
                BoxMusique4.IsChecked = false;
            }
        }


        public void OnCheckBoxCheckedChanged4(object sender, CheckedChangedEventArgs e)
        {
            // Perform required operation after examining e.Value
            modifEtat = true;
            if (modifEtat == true && BoxMusique4.IsChecked == true)
            {
                BoxMusique1.IsChecked = false;
                BoxMusique2.IsChecked = false;
                BoxMusique3.IsChecked = false;
            }
        }

        public void OnClickValide(object sender, EventArgs e)
        {
            if (modifEtat == true && BoxMusique1.IsChecked == true)
            {
                Database.MySonnerie.suppUnVote();
                Database.MySonnerie.addUnVote(LabelMusique1.Text);
                BoxMusique1.IsChecked = false;
                modifEtat = false;
            }
            else if (modifEtat == true && BoxMusique2.IsChecked == true)
            {
                Database.MySonnerie.suppUnVote();
                Database.MySonnerie.addUnVote(LabelMusique2.Text);
                BoxMusique2.IsChecked = false;
                modifEtat = false;
            }
            else if (modifEtat == true && BoxMusique3.IsChecked == true)
            {
                Database.MySonnerie.suppUnVote();
                Database.MySonnerie.addUnVote(LabelMusique3.Text);
                BoxMusique3.IsChecked = false;
                modifEtat = false;
            }
            else if (modifEtat == true && BoxMusique4.IsChecked == true)
            {
                Database.MySonnerie.suppUnVote();
                Database.MySonnerie.addUnVote(LabelMusique4.Text);
                BoxMusique4.IsChecked = false;
                modifEtat = false;
            }
            else
            {
                //ERROR : Aucune musique sélectionnée
            }
        }

    }
}