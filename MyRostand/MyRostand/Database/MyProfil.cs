using MyRostand.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyRostand.Database
{
    class MyProfil
    {
        //////////////////////////////////////////////////////////////////REQUÊTE DE PROFIL////////////////////////////

        public static List<User> UnUser(string idConducteur)
        {
            List<User> UnUsers = new List<User>();
            try
            {
                MySqlConnection cnx = MySQL.getCnx();
                cnx.Ping();
                string requete = "SELECT UTI_NOM, UTI_PRENOM, UTI_BIO, UTI_TEL, UTI_DATENAISSANCE, UTI_EMAIL,UTI_RUE, UTI_CP, UTI_VILLE, UTI_MDP, UTI_ROLE, ROL_LIBELLE, UTI_ID FROM utilisateur, role WHERE UTI_ROLE = ROL_ID AND UTI_EMAIL = '" + idConducteur + "' ";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    User UnUser = new User();
                    UnUser.Nom = reader.GetString(0);
                    UnUser.Prenom = reader.GetString(1);
                    UnUser.Bio = reader.GetString(2);
                    UnUser.Telephone = reader.GetString(3);
                    UnUser.DateNaissance = reader.GetDateTime(4);
                    UnUser.Mail = reader.GetString(5);
                    UnUser.Rue = reader.GetString(6);
                    UnUser.CodePostal = reader.GetString(7);
                    UnUser.Ville = reader.GetString(8);
                    UnUser.MDP = reader.GetString(9);
                    UnUser.Role = reader.GetInt32(10);
                    UnUser.Rolelibelle = reader.GetString(11);
                    UnUser.Id = reader.GetInt32(12);
                    UnUsers.Add(UnUser);
                }
                cnx.Close();
                return UnUsers;
            }
            catch (MySqlException ex)
            {
                Utilisateur erreurSQL = new Utilisateur();
                erreurSQL.Description = (ex.ToString());
                return UnUsers;
            }

        }
        //////////////////////////////////////////////////////////////////REQUÊTE AFIN DE UPDATE UNE BIO////////////////////////////
        public static List<User> setUnMDP(string mdputi, string mailuti)
        {
            List<User> Newmdp = new List<User>();

            try
            {
                MySqlConnection cnx = MySQL.getCnx();
                cnx.Ping();
                string requete = "UPDATE utilisateur SET UTI_MDP = '" + mdputi + "'  WHERE UTI_EMAIL='" + mailuti + "'";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    User LaBio = new User();
                    LaBio.MDP = reader.GetString(0);
                    Newmdp.Add(LaBio);
                }
                cnx.Close();
                return Newmdp;
            }
            catch (MySqlException ex)
            {
                Utilisateur erreurSQL = new Utilisateur();
                erreurSQL.Description = (ex.ToString());
                return Newmdp;
            }
        }
        //////////////////////////////////////////////////////////////////REQUÊTE AFIN DE UPDATE UN NUMERO DE TELEPHONE////////////////////////////
        public static List<User> setUnTelephone(string teluti, string mailuti)
        {
            List<User> NewTelephone = new List<User>();

            try
            {
                MySqlConnection cnx = MySQL.getCnx();
                cnx.Ping();
                string requete = "UPDATE utilisateur SET UTI_TEL = '" + teluti + "'  WHERE UTI_EMAIL='" + mailuti + "'";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    User LeTel = new User();
                    LeTel.Telephone = reader.GetString(0);
                    NewTelephone.Add(LeTel);
                }
                cnx.Close();
                return NewTelephone;
            }
            catch (MySqlException ex)
            {
                Utilisateur erreurSQL = new Utilisateur();
                erreurSQL.Description = (ex.ToString());
                return NewTelephone;
            }
        }
        //////////////////////////////////////////////////////////////////REQUÊTE AFIN DE UPDATE UNE RUE////////////////////////////
        public static List<User> setUneRue(string rueuti, string mailuti)
        {
            List<User> NewRue = new List<User>();

            try
            {
                MySqlConnection cnx = MySQL.getCnx();
                cnx.Ping();
                string requete = "UPDATE utilisateur SET UTI_RUE = '" + rueuti + "'  WHERE UTI_EMAIL='" + mailuti + "'";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    User LaRue = new User();
                    LaRue.Rue = reader.GetString(0);
                    NewRue.Add(LaRue);
                }
                cnx.Close();
                return NewRue;
            }
            catch (MySqlException ex)
            {
                Utilisateur erreurSQL = new Utilisateur();
                erreurSQL.Description = (ex.ToString());
                return NewRue;
            }
        }
        //////////////////////////////////////////////////////////////////REQUÊTE AFIN DE UPDATE UN CODE POSTAL////////////////////////////
        public static List<User> setUnCodePost(string cputi, string mailuti)
        {
            List<User> NewCodePost = new List<User>();

            try
            {
                MySqlConnection cnx = MySQL.getCnx();
                cnx.Ping();
                string requete = "UPDATE utilisateur SET UTI_CP = '" + cputi + "'  WHERE UTI_EMAIL='" + mailuti + "'";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    User LeCodePost = new User();
                    LeCodePost.CodePostal = reader.GetString(0);
                    NewCodePost.Add(LeCodePost);
                }
                cnx.Close();
                return NewCodePost;
            }
            catch (MySqlException ex)
            {
                Utilisateur erreurSQL = new Utilisateur();
                erreurSQL.Description = (ex.ToString());
                return NewCodePost;
            }
        }
        //////////////////////////////////////////////////////////////////REQUÊTE AFIN DE UPDATE UNE VILLE////////////////////////////
        public static List<User> setUneVille(string villeuti, string mailuti)
        {
            List<User> NewUneVille = new List<User>();

            try
            {
                MySqlConnection cnx = MySQL.getCnx();
                cnx.Ping();
                string requete = "UPDATE utilisateur SET UTI_VILLE = '" + villeuti + "'  WHERE UTI_EMAIL='" + mailuti + "'";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    User LaVille = new User();
                    LaVille.Ville = reader.GetString(0);
                    NewUneVille.Add(LaVille);
                }
                cnx.Close();
                return NewUneVille;
            }
            catch (MySqlException ex)
            {
                Utilisateur erreurSQL = new Utilisateur();
                erreurSQL.Description = (ex.ToString());
                return NewUneVille;
            }
        }
        //////////////////////////////////////////////////////////////////REQUÊTE AFIN DE UPDATE UN EMAIL////////////////////////////
        public static List<User> setUnEmail(string emailuti, string mailuti)
        {
            List<User> NewEmail = new List<User>();

            try
            {
                MySqlConnection cnx = MySQL.getCnx();
                cnx.Ping();
                string requete = "UPDATE utilisateur SET UTI_EMAIL = '" + emailuti + "'  WHERE UTI_EMAIL='" + mailuti + "'";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    User LeEmail = new User();
                    LeEmail.Mail = reader.GetString(0);
                    NewEmail.Add(LeEmail);
                }
                cnx.Close();
                return NewEmail;
            }
            catch (MySqlException ex)
            {
                Utilisateur erreurSQL = new Utilisateur();
                erreurSQL.Description = (ex.ToString());
                return NewEmail;
            }
        }
    }
}
