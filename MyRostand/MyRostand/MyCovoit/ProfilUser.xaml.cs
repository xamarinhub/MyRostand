using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyRostand.Models;
using MyRostand.Database;

namespace MyRostand.MyCovoit
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilUser : ContentPage
    {
        public ProfilUser()
        {
            InitializeComponent();
            Utilisateur unUtilisateur = Database.MyCovoit.getUnConducteur(1);
            nomUser.Text += unUtilisateur.getNom();
            PrenomUser.Text += unUtilisateur.getPrenom();
            DateNaissance.Text += unUtilisateur.getDateNaissance().ToString("dd/MM/yyyy");
            Bio.Text += unUtilisateur.getBio();
            int fumeur = unUtilisateur.getFumeur();
            if (fumeur == 1)
            {
                Fumeur.Text += "Tolère la cigarette";
            }
            else
            {
                Fumeur.Text += "Ne tolère pas la cigarette";
            }
            int paleur = unUtilisateur.getParleur();
            if (paleur == 1)
            {
                Parleur.Text += "Je suis bavard";
            }
            else
            {
                Parleur.Text += "Ne tolère pas la conversation";
            }
            int musique = unUtilisateur.getMusique();
            if (paleur == 1)
            {
                Musique.Text += "J'écoute souvent de la musique en conduisant";
            }
            else
            {
                Musique.Text += "Ne tolère pas la musique";
            }
            int animaux = unUtilisateur.getAnimaux();
            if (animaux == 1)
            {
                Animaux.Text += "Tolère les animaux";
            }
            else
            {
                Animaux.Text += "Ne tolère pas les animaux";
            }
            NbAnnul.Text += unUtilisateur.getNbAnnul();

            Avis unAvis = Database.MyCovoit.getUnAvis(1);
            if (unAvis.getNote() == 1)
            {
                Note.Text += "⭐";
            }
            if (unAvis.getNote() == 2)
            {
                Note.Text += "⭐⭐";
            }
            if (unAvis.getNote() == 3)
            {
                Note.Text += "⭐⭐⭐";
            }
            if (unAvis.getNote() == 4)
            {
                Note.Text += "⭐⭐⭐⭐";
            }
            if (unAvis.getNote() == 5)
            {
                Note.Text += "⭐⭐⭐⭐⭐";
            }
            Commentaire.Text += unAvis.getCommentaire();
        }
    }
}