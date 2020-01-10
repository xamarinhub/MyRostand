using System;
using System.Collections.Generic;
using System.Text;

namespace MyRostand.Models
{
    class Proportion
    {
        private int Id;
        private int Gramme;

        public Proportion(int pId, int pGramme)
        {
            this.Id = pId;
            this.Gramme = pGramme;
        }
        public Proportion()
        {
        }
    }
}
