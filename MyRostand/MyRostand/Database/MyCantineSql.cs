using MyRostand.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyRostand.Database
{
    class MyCantineSQL
    {

        ///////////////////////////////////////////////////////////////REQUÊTE AFIN DE RECUPERER LES ENTREES /////////////////////////////////////////////////////////////
        public static List<Entree> getLesEntrees(string daterequete)
        {
            List<Entree> lesEntrees = new List<Entree>();

            try
            {
                MySqlConnection cnx = MySQL.getCnx();
                cnx.Ping(); 
                string requete = "SELECT ENT_ID, ENT_LIBELLE, ENT_DESCRIPTION FROM entree, repasentree, repas WHERE ENT_ID=RE_ENTREE AND RE_REPAS=REP_ID AND REP_DATE= '"+daterequete+"' ";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Entree uneEntree = new Entree();
                    uneEntree.Id = reader.GetInt32(0);
                    uneEntree.Libelle = reader.GetString(1);
                    uneEntree.Description = reader.GetString(2);
                    lesEntrees.Add(uneEntree);
                }
                cnx.Close();
                return lesEntrees;
            }
            catch (MySqlException ex)
            {
                Entree erreurSQL = new Entree();
                erreurSQL.Description = (ex.ToString());
                lesEntrees.Add(erreurSQL);
                return lesEntrees;
            }
        }
        /////////////////////////////////////////////////////////////REQUÊTE AFIN DE RECUPERER LES DESSERTS ///////////////////////////////////////////////////////////////////////////////////////////////
        public static List<Dessert> getLesDesserts(string daterequete)
        {
            List<Dessert> lesDesserts = new List<Dessert>();

            try
            {
                MySqlConnection cnx = MySQL.getCnx();
                cnx.Ping();
                string requete = "SELECT DES_ID, DES_LIBELLE, DES_DESCRIPTION FROM dessert, repasdessert, repas WHERE DES_ID=RD_DESSERT AND RD_REPAS=REP_ID AND REP_DATE= '" + daterequete + "' ";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Dessert unDessert = new Dessert();
                    unDessert.Id = reader.GetInt32(0);
                    unDessert.Libelle = reader.GetString(1);
                    unDessert.Description = reader.GetString(2);
                    lesDesserts.Add(unDessert);
                }
                cnx.Close();
                return lesDesserts;
            }
            catch (MySqlException ex)
            {
                Dessert erreurSQL = new Dessert();
                erreurSQL.Description = (ex.ToString());
                lesDesserts.Add(erreurSQL);
                return lesDesserts;
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////REQUÊTE AFIN DE RECUPERER LES LAITAGES/////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static List<Laitage> getlesLaitages(string daterequete)
        {
            List<Laitage> lesLaitages = new List<Laitage>();

            try
            {
                MySqlConnection cnx = MySQL.getCnx();
                cnx.Ping();
                string requete = "SELECT LAI_ID, LAI_LIBELLE, LAI_DESCRIPTION FROM laitage, repaslaitage, repas WHERE LAI_ID=RL_LAITAGE AND RL_REPAS=REP_ID AND REP_DATE= '" + daterequete + "' ";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Laitage unLaitage = new Laitage();
                    unLaitage.Id = reader.GetInt32(0);
                    unLaitage.Libelle = reader.GetString(1);
                    unLaitage.Description = reader.GetString(2);
                    lesLaitages.Add(unLaitage);
                }
                cnx.Close();
                return lesLaitages;
            }
            catch (MySqlException ex)
            {
                Laitage erreurSQL = new Laitage();
                erreurSQL.Description = (ex.ToString());
                lesLaitages.Add(erreurSQL);
                return lesLaitages;
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////REQUÊTE AFIN DE RECUPERER LES ACCOMPAGNEMENTS/////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static List<Accompagnement> getlesAccompagnements(string daterequete)
        {
            List<Accompagnement> lesAccompagnements = new List<Accompagnement>();

            try
            {
                MySqlConnection cnx = MySQL.getCnx();
                cnx.Ping();
                string requete = "SELECT ACC_ID, ACC_LIBELLE, ACC_DESCRIPTION, ACC_PROP FROM accompagnement, repasaccompagnement, repas WHERE ACC_ID=RA_ACCOMPAGNEMENT AND RA_REPAS=REP_ID AND REP_DATE= '" + daterequete + "' ";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Accompagnement unAccompagnement = new Accompagnement();
                    unAccompagnement.Id = reader.GetInt32(0);
                    unAccompagnement.Libelle = reader.GetString(1);
                    unAccompagnement.Description = reader.GetString(2);
                    unAccompagnement.Gramme = reader.GetInt32(3);
                    lesAccompagnements.Add(unAccompagnement);
                }
                cnx.Close();
                return lesAccompagnements;
            }
            catch (MySqlException ex)
            {
                Accompagnement erreurSQL = new Accompagnement();
                erreurSQL.Description = (ex.ToString());
                lesAccompagnements.Add(erreurSQL);
                return lesAccompagnements;
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////REQUÊTE AFIN DE RECUPERER LES VIANDES/////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static List<Resistance> getlesResistances(string daterequete)
        {
            List<Resistance> lesResistances = new List<Resistance>();

            try
            {
                MySqlConnection cnx = MySQL.getCnx();
                cnx.Ping();
                string requete = "SELECT RES_ID, RES_LIBELLE, RES_DESCRIPTION FROM resistance, repasresistance, repas WHERE RES_ID=RR_RESISTANCE AND RR_REPAS=REP_ID AND REP_DATE= '" + daterequete + "' ";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Resistance unResistance = new Resistance();
                    unResistance.Id = reader.GetInt32(0);
                    unResistance.Libelle = reader.GetString(1);
                    unResistance.Description = reader.GetString(2);
                    lesResistances.Add(unResistance);
                }
                cnx.Close();
                return lesResistances;
            }
            catch (MySqlException ex)
            {
                Resistance erreurSQL = new Resistance();
                erreurSQL.Description = (ex.ToString());
                lesResistances.Add(erreurSQL);
                return lesResistances;
            }
        }

////////////////////////////////////////////////////////////REQUÊTE AFIN DE RECUPERER TOUTES LES VIANDES//////////////////////////////////////////////

        public static List<Resistance> getTouteslesResistances(string daterequete)
        {
            List<Resistance> TouteslesResistances = new List<Resistance>();

            try
            {
                MySqlConnection cnx = MySQL.getCnx();
                cnx.Ping();
                string requete = "SELECT RES_LIBELLE, RES_DESCRIPTION FROM resistance, repasresistance, repas WHERE RES_ID = RR_RESISTANCE AND RR_REPAS = REP_ID AND REP_DATE = '" + daterequete + "'";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Resistance unResistance = new Resistance();
                    unResistance.Libelle = reader.GetString(0);
                    unResistance.Description = reader.GetString(1);
                    TouteslesResistances.Add(unResistance);
                }
                cnx.Close();
                return TouteslesResistances;
            }
            catch (MySqlException ex)
            {
                Resistance erreurSQL = new Resistance();
                erreurSQL.Description = (ex.ToString());
                TouteslesResistances.Add(erreurSQL);
                return TouteslesResistances;
            }
        }
        //////////////////////////////////////////////////////////////////REQUÊTE AFIN DE RECUPERER TOUT LES ACCOMPAGNEMENTS////////////////////////////
        public static List<Accompagnement> getToutlesAccompagnements(string daterequete)
        {
            List<Accompagnement> ToutlesAccompagnements = new List<Accompagnement>();

            try
            {
                MySqlConnection cnx = MySQL.getCnx();
                cnx.Ping();
                string requete = "SELECT ACC_ID, ACC_LIBELLE, ACC_DESCRIPTION, ACC_PROP FROM accompagnement, repasaccompagnement, repas WHERE ACC_ID=RA_ACCOMPAGNEMENT AND RA_REPAS=REP_ID AND REP_DATE= '" + daterequete + "' ";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Accompagnement unAccompagnement = new Accompagnement();
                    unAccompagnement.Id = reader.GetInt32(0);
                    unAccompagnement.Libelle = reader.GetString(1);
                    unAccompagnement.Description = reader.GetString(2);
                    unAccompagnement.Gramme = reader.GetInt32(3);
                    ToutlesAccompagnements.Add(unAccompagnement);
                }
                cnx.Close();
                return ToutlesAccompagnements;
            }
            catch (MySqlException ex)
            {
                Accompagnement erreurSQL = new Accompagnement();
                erreurSQL.Description = (ex.ToString());
                ToutlesAccompagnements.Add(erreurSQL);
                return ToutlesAccompagnements;
            }
          
        }
        //////////////////////////////////////////////////////////////////REQUÊTE AFIN DE RECUPERER UN ACCOMPAGNEMENTS////////////////////////////
        public static List<Accompagnement> getUnAccompagnements()
        {
            List<Accompagnement> UnAccompagnements = new List<Accompagnement>();

            try
            {
                MySqlConnection cnx = MySQL.getCnx();
                cnx.Ping();
                string requete = "SELECT ACC_ID, ACC_LIBELLE, ACC_DESCRIPTION, ACC_PROP FROM accompagnement";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Accompagnement unAccompagnement = new Accompagnement();
                    unAccompagnement.Id = reader.GetInt32(0);
                    unAccompagnement.Libelle = reader.GetString(1);
                    unAccompagnement.Description = reader.GetString(2);
                    unAccompagnement.Gramme = reader.GetInt32(3);
                    UnAccompagnements.Add(unAccompagnement);
                }
                cnx.Close();
                return UnAccompagnements;
            }
            catch (MySqlException ex)
            {
                Accompagnement erreurSQL = new Accompagnement();
                erreurSQL.Description = (ex.ToString());
                UnAccompagnements.Add(erreurSQL);
                return UnAccompagnements;
            }

        }
        //////////////////////////////////////////////////////////////////REQUÊTE AFIN DE RECUPERER UN GRAMMAGE D'UN ACCOMPAGNEMENTS////////////////////////////
        public static List<Accompagnement> getUnGrammage(string AccompName)
        {
            List<Accompagnement> UnGrammage = new List<Accompagnement>();

            try
            {
                MySqlConnection cnx = MySQL.getCnx();
                cnx.Ping();
                string requete = "SELECT ACC_PROP FROM accompagnement WHERE ACC_LIBELLE='"+ AccompName + "'";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Accompagnement LeGrammage = new Accompagnement();
                    LeGrammage.Gramme = reader.GetInt32(0);
                    UnGrammage.Add(LeGrammage);
                }
                cnx.Close();
                return UnGrammage;
            }
            catch (MySqlException ex)
            {
                Accompagnement erreurSQL = new Accompagnement();
                erreurSQL.Description = (ex.ToString());
                UnGrammage.Add(erreurSQL);
                return UnGrammage;
            }

        }
        //////////////////////////////////////////////////////////////////REQUÊTE AFIN DE UPDATE UN GRAMMAGE D'UN ACCOMPAGNEMENTS////////////////////////////
        public static List<Accompagnement> setUnGrammage(string AccompGrame, string AccompName)
        {
            List<Accompagnement> NewGrammage = new List<Accompagnement>();

            try
            {
                MySqlConnection cnx = MySQL.getCnx();
                cnx.Ping();
                string requete = "UPDATE accompagnement SET ACC_PROP = '" + AccompGrame + "'  WHERE ACC_LIBELLE='" + AccompName + "'";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Accompagnement LeGrammage = new Accompagnement();
                    LeGrammage.Gramme = reader.GetInt32(0);
                    NewGrammage.Add(LeGrammage);
                }
                cnx.Close();
                return NewGrammage;
            }
            catch (MySqlException ex)
            {
                Accompagnement erreurSQL = new Accompagnement();
                erreurSQL.Description = (ex.ToString());
                NewGrammage.Add(erreurSQL);
                return NewGrammage;
            }

        }
    }
}



