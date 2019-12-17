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

        public ArrayList Repas { get; set; }
        public ArrayList Utilisateur { get; set; }

        public Accompagnement(int id, string libelle, string description, ArrayList repas, ArrayList utilisateur)
        {
            this.Id = id;
            this.Libelle = libelle;
            this.Description = description;
            Repas = repas;
            Utilisateur = utilisateur;
        }

        public Accompagnement()
        {
        }
    }
}
