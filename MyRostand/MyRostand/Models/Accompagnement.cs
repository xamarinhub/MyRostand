using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace MyRostand.Models
{
    class Accompagnement
    {
        public int Id { get; set; }
        public String Libelle { get; set; }
        public String Description { get; set; }
        public int Gramme { get; set; }
        public ArrayList Repas { get; set; }
        public ArrayList Utilisateur { get; set; }

        public Accompagnement(int id, string libelle, string description, int pGramme, ArrayList repas, ArrayList utilisateur)
        {
            this.Id = id;
            this.Libelle = libelle;
            this.Description = description;
            this.Gramme = pGramme;
            Repas = repas;
            Utilisateur = utilisateur;
        }

        public Accompagnement()
        {
        }
    }
}
