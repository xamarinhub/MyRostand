using System;
using System.Collections.Generic;
using System.Text;

namespace MyRostand.Models
{
    class Lieu
    {
        private int Id;
        private string Libelle;

        public Lieu(){
        
        }

        public Lieu(int pId, string pLibelle)
        {
            this.Id = pId;
            this.Libelle = pLibelle;
        }

        public int getId()
        {
            return this.Id;
        }

        public string getLibelle()
        {
            return this.Libelle;
        }

        public void setId(int pId)
        {
            this.Id = pId;
        }

        public void setLibbelle(string pLibelle)
        {
            this.Libelle = pLibelle;
        }

    }
}
