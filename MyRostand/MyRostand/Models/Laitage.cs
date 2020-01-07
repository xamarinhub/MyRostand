using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace MyRostand.Models
{
    class Laitage
    {
        public int Id { get; set; }
        public String Libelle { get; set; }
        public String Description { get; set; }

        public ArrayList Repas { get; set; }

        public Laitage(int id, string libelle, string description, ArrayList repas)
        {
            this.Id = id;
            this.Libelle = libelle;
            this.Description = description;
            Repas = repas;
        }

        public Laitage()
        {
        }

    }
}
