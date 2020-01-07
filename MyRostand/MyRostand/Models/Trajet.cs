using System;
using System.Collections.Generic;
using System.Text;

namespace MyRostand.Models
{
    class Trajet
    {
        private int Id;
        private Lieu LieuDeDepart;
        private Lieu LieuArrive;
        private Utilisateur Conducteur;
        private DateTime Date;
        private string HeureDepart;
        private string HeureArrive;
        private int NbPlaces;
        private string DescTrajet;

        public Trajet()
        {

        }

        public Trajet(int pId, Lieu pLieuDepart, Lieu pLieuArrive, Utilisateur pConducteur, DateTime pDate, string pHeureDepart, string pHeureArrive, int pNbPlaces, string pDescTrajet)
        {
            this.Id = pId;
            this.LieuDeDepart = pLieuDepart;
            this.LieuArrive = pLieuArrive;
            this.Conducteur = pConducteur;
            this.Date = pDate;
            this.HeureDepart = pHeureDepart;
            this.HeureArrive = pHeureArrive;
            this.NbPlaces = pNbPlaces;
            this.DescTrajet = pDescTrajet;
        }

        public int getId()
        {
            return this.Id;
        }

        public Lieu getLieuDepart()
        {
            return this.LieuDeDepart;
        }

        public Lieu getLieuArrive()
        {
            return this.LieuArrive;
        }

        public Utilisateur getConducteur()
        {
            return this.Conducteur;
        }

        public DateTime getDate()
        {
            return this.Date;
        }

        public string getHeureDepart()
        {
            return this.HeureDepart;
        }

        public string getHeureArrive()
        {
            return this.HeureArrive;
        }

        public int getNbPlaces()
        {
            return this.NbPlaces;
        }

        public string getDescTrajet()
        {
            return this.DescTrajet;
        }

        public void setId(int pId)
        {
            this.Id = pId;
        }

        public void setLieuDepart(Lieu pLieuDepart)
        {
            this.LieuDeDepart = pLieuDepart;
        }

        public void setLieuArrive(Lieu pLieuArrive)
        {
            this.LieuArrive = pLieuArrive;
        }

        public void setConducteur(Utilisateur pConducteur)
        {
            this.Conducteur = pConducteur;
        }

        public void setDate(DateTime pDate)
        {
            this.Date = pDate;
        }

        public void setHeureDepart(string pHeureDepart)
        {
            this.HeureDepart = pHeureDepart;
        }

        public void setHeureArrive(string pHeureArrive)
        {
            this.HeureArrive = pHeureArrive;
        }

        public void setNbPlaces(int pNbPlaces)
        {
            this.NbPlaces = pNbPlaces;
        }

        public void setDescTrajet(string pDescTrajet)
        {
            this.DescTrajet = pDescTrajet;
        }

    }
}
