using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRostand.Database;
using MyRostand.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyRostand.MyCantine
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class JoursSemaineAct : ContentPage
    {
        public JoursSemaineAct()
        {
            InitializeComponent();
        }

        void OnItemJours(object sender, EventArgs e)
        {
            ToolbarItem item = (ToolbarItem)sender;

            jourSelectionne.Text = $"Le menu de\"{item.Text}\" est : ";

            jourEntree.Text = $" Entrées :";

            List<Entree> lesEntrees = Database.MyCantineSQL.getLesEntrees();

            for (int i = 0; i < lesEntrees.Count; i++)
            {
                Entree uneEntree = lesEntrees[i];
                jourEntree.Text += uneEntree.Libelle + ", ";
            }


            jourViande.Text = $" Viandes :";

            List<Resistance> lesResistances = Database.MyCantineSQL.getlesResistances();
            for (int i = 0; i < lesResistances.Count; i++)
            {
                Resistance uneResistance = lesResistances[i];
                jourViande.Text += uneResistance.Libelle + ", ";
            }

            jourAccompagnement.Text = $" Accompagnement :";
            List<Accompagnement> lesAccompagnements = Database.MyCantineSQL.getlesAccompagnements();
            for (int i = 0; i < lesAccompagnements.Count; i++)
            {
                Accompagnement unAccompagnement = lesAccompagnements[i];
                jourAccompagnement.Text += unAccompagnement.Libelle + ", ";
            }

            jourLaitage.Text = $" Laitage :";
            jourDesserts.Text = $" Desserts :";
        }
    }
}