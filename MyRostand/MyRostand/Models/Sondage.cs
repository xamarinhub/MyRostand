using System;
using System.Collections.Generic;
using System.Text;
using MyRostand;

namespace MyRostand.Models
{
    class Sondage
    {
        public Sondage() { }

        public int id { get; set; }
        public string titre { get; set; }
        public string musique1 { get; set; }
        public string musique2 { get; set; }
        public string musique3 { get; set; }
        public string musique4 { get; set; }
        public int semaine { get; set; }
    }
}
