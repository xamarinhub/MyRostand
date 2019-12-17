using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace MyRostand.Models
{
    class Repas
    {
        public int Id { get; set; }
        public DateTime date { get; set; }

        public ArrayList Utilisateur { get; set; }
        public ArrayList Resistance { get; set; }
        public ArrayList Entree { get; set; }
        public ArrayList Dessert { get; set; }
        public ArrayList Laitage { get; set; }
        public ArrayList Accompagnement { get; set; }

        public Repas()
        {

        }

        public Repas(int id, DateTime date, ArrayList utilisateur, ArrayList resistance, ArrayList entree, ArrayList dessert, ArrayList laitage, ArrayList accompagnement)
        {
            Id = id;
            this.date = date;
            Utilisateur = utilisateur;
            Resistance = resistance;
            Entree = entree;
            Dessert = dessert;
            Laitage = laitage;
            Accompagnement = accompagnement;
        }
    }
}