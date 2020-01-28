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
                string requete = "SELECT ACC_ID, ACC_LIBELLE, ACC_DESCRIPTION, AT_POIDS FROM accompagnement, repasaccompagnement, repas, accompagnementtype WHERE ACC_ID=RA_ACCOMPAGNEMENT AND RA_REPAS=REP_ID AND AT_ID=ACC_TYPE AND REP_DATE= '" + daterequete + "' ";
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
                string requete = "SELECT RES_LIBELLE, RES_DESCRIPTION FROM resistance, reservationmenu, repas WHERE resistance.RES_ID = res_plat AND res_repas = REP_ID AND REP_DATE = '" + daterequete + "'";
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
                string requete = "SELECT ACC_LIBELLE, AT_POIDS FROM repas, reservationmenu, concerner, accompagnement, accompagnementtype WHERE REP_ID=res_repas AND res_id=con_res_id AND con_accompagnement=ACC_ID AND ACC_TYPE=AT_ID AND REP_DATE= '" + daterequete + "'";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Accompagnement unAccompagnement = new Accompagnement();
                    unAccompagnement.Libelle = reader.GetString(0);
                    unAccompagnement.Gramme = reader.GetInt32(1);
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
                string requete = "SELECT ACC_ID, ACC_LIBELLE, ACC_DESCRIPTION, AT_POIDS FROM accompagnement, accompagnementtype WHERE AT_ID=ACC_TYPE";
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
        //////////////////////////////////////////////////////////////////REQUÊTE AFIN DE RECUPERER UN TYPE////////////////////////////
        public static List<TypeAC> getType()
        {
            List<TypeAC> UnType = new List<TypeAC>();

            try
            {
                MySqlConnection cnx = MySQL.getCnx();
                cnx.Ping();
                string requete = "SELECT AT_LIBELLE, AT_POIDS FROM accompagnementtype ";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TypeAC LeGrammage = new TypeAC();
                    LeGrammage.Libelle = reader.GetString(0);
                    LeGrammage.Gramme = reader.GetInt32(1);
                    UnType.Add(LeGrammage);
                }
                cnx.Close();
                return UnType;
            }
            catch (MySqlException ex)
            {
                TypeAC erreurSQL = new TypeAC();
                erreurSQL.Description = (ex.ToString());
                UnType.Add(erreurSQL);
                return UnType;
            }

        }
        //////////////////////////////////////////////////////////////////REQUÊTE AFIN DE RECUPERER UN GRAMMAGE D'UN TYPE////////////////////////////
        public static List<TypeAC> getUnGrammage(string typeaccomp)
        {
            List<TypeAC> UnGrammage = new List<TypeAC>();

            try
            {
                MySqlConnection cnx = MySQL.getCnx();
                cnx.Ping();
                string requete = "SELECT AT_POIDS FROM accompagnementtype WHERE AT_LIBELLE = '" + typeaccomp + "' ";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TypeAC LeGrammage = new TypeAC();
                    LeGrammage.Gramme = reader.GetInt32(0);
                    UnGrammage.Add(LeGrammage);
                }
                cnx.Close();
                return UnGrammage;
            }
            catch (MySqlException ex)
            {
                TypeAC erreurSQL = new TypeAC();
                erreurSQL.Description = (ex.ToString());
                UnGrammage.Add(erreurSQL);
                return UnGrammage;
            }

        }
        //////////////////////////////////////////////////////////////////REQUÊTE AFIN DE UPDATE UN GRAMMAGE D'UN TYPE////////////////////////////
        public static List<TypeAC> setUnGrammage(string poidtype, string typeaccomp)
        {
            List<TypeAC> NewGrammage = new List<TypeAC>();

            try
            {
                MySqlConnection cnx = MySQL.getCnx();
                cnx.Ping();
                string requete = "UPDATE accompagnementtype SET AT_POIDS = '" + poidtype + "'  WHERE AT_LIBELLE='" + typeaccomp + "'";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TypeAC LeGrammage = new TypeAC();
                    LeGrammage.Gramme = reader.GetInt32(0);
                    NewGrammage.Add(LeGrammage);
                }
                cnx.Close();
                return NewGrammage;
            }
            catch (MySqlException ex)
            {
                TypeAC erreurSQL = new TypeAC();
                erreurSQL.Description = (ex.ToString());
                NewGrammage.Add(erreurSQL);
                return NewGrammage;
            }

        }
        public static int getIdRepas(string daterequete)
        {
            int idRepas = 0;

            MySqlConnection cnx = MySQL.getCnx();
            cnx.Ping();
            string requete = "SELECT REP_ID FROM repas WHERE REP_DATE= '" + daterequete + "' ";
            MySqlCommand cmd = new MySqlCommand(requete, cnx);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                idRepas = reader.GetInt32(0);
            }
            cnx.Close();
            return idRepas;

        }

        public static bool getStatutReserver(string daterequete, int idUtilisateur)
        {
            bool reserve = false;
            int cpt = 0;

            try
            {
                MySqlConnection cnx = MySQL.getCnx();
                cnx.Ping();
                string requete = "SELECT COUNT(res_id) FROM reservationmenu WHERE res_repas = " + getIdRepas(daterequete) + " and res_uti = " + idUtilisateur + ";";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cpt = reader.GetInt32(0);
                }
                cnx.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex);
                Console.WriteLine(ex.StackTrace);
            }

            //DEJA RESERVE
            if (cpt > 0)
            {
                reserve = true;
                return reserve;
            }
            else
            {
                return reserve;
            }
        }

        public static int getIdReservationMenu(int idrepas)
        {
            int idReservationMenu = 0;

            MySqlConnection cnx = MySQL.getCnx();
            cnx.Ping();
            string requete = "SELECT RES_ID FROM reservationmenu WHERE RES_REPAS= '" + idrepas + "' ";
            MySqlCommand cmd = new MySqlCommand(requete, cnx);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                idReservationMenu = reader.GetInt32(0);
            }
            cnx.Close();
            return idReservationMenu;

        }

        public static void AjouterReservationMenu(int idrepas, int idutilisateur)
        {
            try
            {
                MySqlConnection cnx = MySQL.getCnx();
                cnx.Ping();
                string requete = "INSERT INTO reservationmenu VALUES (@RES_ID,@RES_REPAS,@RES_PLAT,@RES_UTI)";
                using (MySqlCommand cmd = new MySqlCommand(requete, cnx))
                {
                    cmd.Parameters.AddWithValue("RES_ID", null);
                    cmd.Parameters.AddWithValue("@RES_REPAS", idrepas);
                    cmd.Parameters.AddWithValue("@RES_PLAT", null);
                    cmd.Parameters.AddWithValue("@RES_UTI", idutilisateur);
                    cmd.ExecuteNonQuery();
                }

            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
        }

        public static void AnnulerReservationMenu(int idrepas, int idReservationMenu, int idutilisateur)
        {
            try
            {
                MySqlConnection cnx = MySQL.getCnx();
                cnx.Ping();
                string requete = "DELETE FROM reservationmenu WHERE res_id = idMenuReservation AND res_repas = idrepas AND res_uti = idutilisateur";
                using (MySqlCommand cmd = new MySqlCommand(requete, cnx))
                {
                    cmd.ExecuteNonQuery();
                }

            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
        }
        //////////////////////////
        public static void AjouterResistance(int idrepas, int idReservationMenu, int idresistance, int idutilisateur)
        {
            try
            {
                MySqlConnection cnx = MySQL.getCnx();
                cnx.Ping();
                string requete = "UPDATE reservationmenu SET res_plat=@RES_PLAT where res_id=@RES_ID and res_repas=@RES_REPAS AND res_uti=@RES_UTI";
                using (MySqlCommand cmd = new MySqlCommand(requete, cnx))
                {
                    cmd.Parameters.AddWithValue("@RES_ID", idReservationMenu);
                    cmd.Parameters.AddWithValue("@RES_REPAS", idrepas);
                    cmd.Parameters.AddWithValue("@RES_PLAT", idresistance);
                    cmd.Parameters.AddWithValue("@RES_UTI", idutilisateur);
                    cmd.ExecuteNonQuery();
                }

            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
        }

        //////////////////////////

        public static void SupprimerResistance(int idrepas, int idReservationMenu, int idutilisateur)
        {
            try
            {
                MySqlConnection cnx = MySQL.getCnx();
                cnx.Ping();
                string requete = "UPDATE reservationmenu SET res_plat = NULL WHERE res_id = idReservationMenu AND res_repas = idrepas  AND res_uti = idutilisateur";
                using (MySqlCommand cmd = new MySqlCommand(requete, cnx))
                {
                    cmd.ExecuteNonQuery();
                }

            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
        }



        //////////////////////////
        public static void AjouterAccompagnement(int idReservationMenu, int idaccompagnement)
        {
            try
            {
                MySqlConnection cnx = MySQL.getCnx();
                cnx.Ping();
                string requete = "INSERT INTO concerner VALUES (@con_res_id,@con_accompagnement)";
                using (MySqlCommand cmd = new MySqlCommand(requete, cnx))
                {
                    cmd.Parameters.AddWithValue("@con_res_id", idReservationMenu);
                    cmd.Parameters.AddWithValue("@con_accompagnement", idaccompagnement);
                    cmd.ExecuteNonQuery();
                }

            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
        }

        public static void SupprimerAccompagnement(int idReservationMenu, int idaccompagnement)
        {
            try
            {
                MySqlConnection cnx = MySQL.getCnx();
                cnx.Ping();
                string requete = "DELETE FROM concerner VALUES (@con_res_id,@con_accompagnement) WHERE @con_res_id=idReservationMenu AND @con_accompagnement=idaccompagnement";
                using (MySqlCommand cmd = new MySqlCommand(requete, cnx))
                {
                    cmd.Parameters.AddWithValue("@con_res_id", idReservationMenu);
                    cmd.Parameters.AddWithValue("@con_accompagnement", idaccompagnement);
                    cmd.ExecuteNonQuery();
                }

            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
        }
  //////////////////////////////////////////////////////////////////REQUÊTE AFIN DE UPDATE UN ELEVE NON PRESENT////////////////////////////
        public static List<Present> getToutEleveS(string daterequete)
        {
            List<Present> ToutEleveS = new List<Present>();

            try
            {
                MySqlConnection cnx = MySQL.getCnx();
                cnx.Ping();
                string requete = "SELECT COUNT(rpr_id) FROM repaspresence, repas WHERE rpr_repas = REP_ID AND REP_DATE = '" + daterequete + "'";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Present LeEleve = new Present();
                    LeEleve.Uti = reader.GetInt32(0);
                    ToutEleveS.Add(LeEleve);
                }
                cnx.Close();
                return ToutEleveS;
            }
            catch (MySqlException ex)
            {
                Present erreurSQL = new Present();
                erreurSQL.Description = (ex.ToString());
                ToutEleveS.Add(erreurSQL);
                return ToutEleveS;
            }

        }
        ////////////////////REQUETE POUR QUE L'ELEVE INDIQUE QU'IL NE SERA PAS PRESENT///////////////////
        
        public static void NonPresent(int idrepas, int idutilisateur)
        {
            try
            {
                MySqlConnection cnx = MySQL.getCnx();
                cnx.Ping();
                string requete = "INSERT INTO repaspresence VALUES (@rpr_id,@rpr_repas,@rpr_uti)";
                using (MySqlCommand cmd = new MySqlCommand(requete, cnx))
                {
                    cmd.Parameters.AddWithValue("@rpr_id", "id");
                    cmd.Parameters.AddWithValue("@rpr_repas", idrepas);
                    cmd.Parameters.AddWithValue("@rpr_uti", idutilisateur);
                    cmd.ExecuteNonQuery();
                }

            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
        }

        ////////////////////REQUETE QUI INDIQUE QUE L'ELEVE SERA FINALEMENT PRESENT///////////////////

        public static void Present(int idrepas, int idutilisateur)
        {
            try
            {
                MySqlConnection cnx = MySQL.getCnx();
                cnx.Ping();
                string requete = "DELETE FROM repaspresence WHERE rpr_repas=@rpr_repas AND rpr_uti=@rpr_uti";
                using (MySqlCommand cmd = new MySqlCommand(requete, cnx))
                {
                    cmd.Parameters.AddWithValue("@rpr_repas", idrepas);
                    cmd.Parameters.AddWithValue("@rpr_uti", idutilisateur);
                    cmd.ExecuteNonQuery();
                }

            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}



