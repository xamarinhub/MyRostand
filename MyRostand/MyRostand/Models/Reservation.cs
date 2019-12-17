using System;
using System.Collections.Generic;
using System.Text;

namespace MyRostand.Models
{
    class Reservation
    {
        private int Id;
        private int Prix;
        private string Descente;
        private string Monte;
        private Trajet LeTrajet;
        private Utilisateur Conducteur;

        public Reservation() {
        }

        public Reservation(int pId, int pPrix, string pDescente, string pMonte, Trajet pTrajet, Utilisateur pConducteur)
        {
            this.Id = pId;
            this.Prix = pPrix;
            this.Descente = pDescente;
            this.Monte = pMonte;
            this.LeTrajet = pTrajet;
            this.Conducteur = pConducteur;
        }

        public int getId()
        {
            return this.Id;
        }
        public int getPrix()
        {
            return this.Prix;
        }

        public string getDescente()
        {
            return this.Descente;
        }

        public string getMonte()
        {
            return this.Monte;
        }

        public Trajet getTrajet()
        {
            return this.LeTrajet;
        }

        public Utilisateur getConducteur()
        {
            return this.Conducteur;
        }

        public void setId(int pId)
        {
            this.Id = pId;
        }

        public void setPrix(int pPrix)
        {
            this.Prix = pPrix;
        }

        public void setDescente(string pDescente)
        {
            this.Descente = pDescente;
        }

        public void setMonte(string pMonte)
        {
            this.Monte = pMonte;
        }

        public void setTrajet(Trajet pTrajet)
        {
            this.LeTrajet = pTrajet;
        }

        public void setConducteur(Utilisateur pConducteur)
        {
            this.Conducteur = pConducteur;
        }

    }
}
