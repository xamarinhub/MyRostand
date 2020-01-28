using System;
using System.Collections.Generic;
using System.Text;

namespace MyRostand.Models
{
    class Present
    {

        public int Id { get; set; }
        public int Repas { get; set; }
        public int Uti { get; set; }
        public string Description { get; internal set; }

        public Present(int id, int repas, int uti)
        {
            this.Id = id;
            this.Repas = repas;
            this.Uti = uti;
        }
        public Present()
        {
        }
    }
}
