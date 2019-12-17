using System;
using System.Collections.Generic;
using System.Text;

namespace MyRostand.Models
{
    class Avis
    {
        private int Id;
        private int Note;
        private String Commentaire;
        public Utilisateur Utilisateur;


        public Avis()
        {
        }

        public Avis(int pId, int pNote, string pCommentaire, Utilisateur pUtilisateur)
        {
            this.Id = pId;
            this.Note = pNote;
            this.Commentaire = pCommentaire;
            this.Utilisateur = pUtilisateur;
        }
        public int getId()
        {
            return this.Id;
        }
        public int getNote()
        {
            return this.Note;
        }
        public String getCommentaire()
        {
            return this.Commentaire;
        }
        public Utilisateur getUtilisateur()
        {
            return Utilisateur;
        }

        public void setId(int pId)
        {
            this.Id = pId;
        }
        public void setNote(int pNote)
        {
            this.Note = pNote;
        }
        public void setCommentaire(String pCommentaire)
        {
            this.Commentaire = pCommentaire;
        }
        public void setUtilisateur(Utilisateur pUtilisateur)
        {
            this.Utilisateur = pUtilisateur;
        }
    }

}
