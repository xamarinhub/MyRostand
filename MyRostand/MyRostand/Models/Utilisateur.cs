using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyRostand.Models
{
    class Utilisateur
    {
        private int Id;
        private string Nom;
        private string Prenom;
        private DateTime dateNaissance;
        private string Bio;
        private int Telephone;
        private string Mail;
        public string Mdp { get; set; }
        private int Parleur;
        private int Musique;
        private int Animaux;
        private int Fumeur;
        private int NbAnnul;
        private ArrayList Avis { get; set; }
        public string Description { get; internal set; }

        public Utilisateur()
        {

        }

        public Utilisateur(int pId, string pNom, string pPrenom, DateTime pDateNaissance, string pBio, int pTelephone, string pMail, string pMdp, int pParleur, int pMusique, int pAnimaux, int pFumeur, int pNbAnnul, ArrayList Avis)
        {
            this.Id = pId;
            this.Nom = pNom;
            this.Prenom = pPrenom;
            this.dateNaissance = pDateNaissance;
            this.Bio = pBio;
            this.Telephone = pTelephone;
            this.Mail = pMail;
            this.Mdp = pMdp;
            this.Parleur = pParleur;
            this.Musique = pMusique;
            this.Animaux = pAnimaux;
            this.Fumeur = pFumeur;
            this.NbAnnul = pNbAnnul;
            this.Avis = Avis;
        }

        public int getId()
        {
            return this.Id;
        }

        public string getNom()
        {
            return this.Nom;
        }

        public string getPrenom()
        {
            return this.Prenom;
        }

        public DateTime getDateNaissance()
        {
            return this.dateNaissance;
        }
        public string getBio()
        {
            return this.Bio;
        }

        public int getTelephone()
        {
            return this.Telephone;
        }

        public string getMail()
        {
            return this.Mail;
        }
        public int getParleur()
        {
            return this.Parleur;
        }
        public int getMusique()
        {
            return this.Musique;
        }
        public int getAnimaux()
        {
            return this.Animaux;
        }
        public int getFumeur()
        {
            return this.Fumeur;
        }
        public int getNbAnnul()
        {
            return this.NbAnnul;
        }

        public void setId(int pId)
        {
            this.Id = pId;
        }

        public void setNom(string pNom)
        {
            this.Nom = pNom;
        }

        public void setPrenom(string pPrenom)
        {
            this.Prenom = pPrenom;
        }

        public void setDateNaissance(DateTime pDateNaissance)
        {
            this.dateNaissance = pDateNaissance;
        }
        public void setBio(string pBio)
        {
            this.Bio = pBio;
        }
        public void setTelephone(int pTelephone)
        {
            this.Telephone = pTelephone;
        }
        public void setMail(string pMail)
        {
            this.Mail = pMail;
        }
        public void setParleur(int pParleur)
        {
            this.Parleur = pParleur;
        }
        public void setMusique(int pMusique)
        {
            this.Musique = pMusique;
        }
        public void setAnimaux(int pAnimaux)
        {
            this.Animaux = pAnimaux;
        }
        public void setFumeur(int pFumeur)
        {
            this.Fumeur = pFumeur;
        }
        public void setNbAnnul(int pNbAnnul)
        {
            this.NbAnnul = pNbAnnul;
        }


    }
}
