using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace MyRostand.Models
{
    class Resistance
    {

        public int Id { get; set; }
        public String Libelle { get; set; }
        public String Description { get; set; }
        public int Poids { get; set; }

        public ArrayList Utilisateur { get; set; }
        public ArrayList Repas { get; set; }

        public Resistance(int id, string libelle, string description,int poids, ArrayList utilisateur, ArrayList repas)
        {
            this.Id = id;
            this.Libelle = libelle;
            this.Description = description;
            this.Poids = poids;
            Utilisateur = utilisateur;
            Repas = repas;
        }

        public Resistance()
        {
        }
    }
}

