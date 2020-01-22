using System;
using System.Collections.Generic;
using System.Text;

namespace MyRostand.Models
{
    class Proportion
    {
        public int Id;
        public int Gramme;

        public string Description { get; internal set; }

        public Proportion(int id, int gramme)
        {
            this.Id = id;
            this.Gramme = gramme;
        }
        public Proportion()
        {
        }
    }
}
