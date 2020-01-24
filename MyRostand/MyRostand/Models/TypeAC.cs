using System;
using System.Collections.Generic;
using System.Text;

namespace MyRostand.Models
{
    class TypeAC
    {

        public int Id { get; set; }
        public String Libelle { get; set; }
        public int Gramme { get; set; }
        public string Description { get; internal set; }

        public TypeAC(int id,string libelle, int gramme)
        {
            this.Id = id;
            this.Libelle = libelle;
            this.Gramme = gramme;
        }
        public TypeAC()
        {
        }
    }
}
