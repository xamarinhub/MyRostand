using System;
using System.Collections.Generic;
using System.Text;

namespace MyRostand.Models
{
    class User
    {
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public String Mail { get; set; }
        public String Telephone { get; set; }
        public String Rue { get; set; }
        public String Ville { get; set; }
        public String CodePostal { get; set; }
        public String MDP { get; set; }
        public string Description { get; internal set; }
        public String Bio { get; set; }
       public int Role { get; set; }
        public String Rolelibelle { get; set; }

        public String Classe { get; set; }
        public User(string nom, string prenom, DateTime datenaissance, string mail, string telephone, string rue, string ville, string codepostal, string mdp, string bio, int role, string rolelibelle, string classe)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.DateNaissance = datenaissance;
            this.Mail = mail;
            this.Telephone = telephone;
            this.Rue = rue;
            this.Ville = ville;
            this.CodePostal = codepostal;
            this.MDP = mdp;
            this.Bio = bio;
            this.Role = role;
            this.Rolelibelle = rolelibelle;
            this.Classe = classe;
        }

        public User()
        {
        }
    }
}
