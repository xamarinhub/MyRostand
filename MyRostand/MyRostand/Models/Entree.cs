using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace MyRostand.Models
{
    class Entree
    {


        public int Id { get; set; }
        public string Libelle { get; set; }
        public string Description { get; set; }

        public ArrayList Repas { get; set; }


        public Entree()
        {
        }

        public Entree(int id, string libelle, string description, ArrayList repas)
        {
            this.Id = id;
            this.Libelle = libelle;
            this.Description = description;
            Repas = repas;
        }
    }
}
