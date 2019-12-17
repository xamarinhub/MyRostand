using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;


namespace MyRostand.Database
{
    public class MySQL
    {

        public string etatConnexion;
        public MySqlConnection cnx;

        public static string initConnexion()
        {
            List<string> infos = infosSQL.getInfos();


            // Connection String.
            string connString = "server=" + infos[0] + ";database=" + infos[2]
                + ";port=" + 3306 + ";user = " + infos[3] + ";password = " + infos[4];

            return connString;
        }

        public static MySqlConnection getCnx()
        {
            MySqlConnection cnx = new MySqlConnection(initConnexion());
            cnx.Open();
            return cnx;
        }

        public static string EtatConnexion()
        {
            try
            {
                string connString = initConnexion();
                MySqlConnection cnx = new MySqlConnection(connString);
                string etatConnexion = "Connecté !";
                return etatConnexion;

            }catch(MySqlException ex)
            {
                string etatConnexion = ex.ToString();
                return etatConnexion;
            }
        }

        public static string testRequete()
        {
            string resultat="";
            try
            {
                MySqlConnection cnx = getCnx();
                cnx.Ping();
                string requete = "SELECT com_identifiant FROM compteconnexion WHERE com_id = 1";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resultat = reader.GetString(0);
                }
                cnx.Close();
                return resultat;
            }
            catch(MySqlException ex)
            {
                resultat = ex.ToString();
                return resultat;
            }
        }

        public static List<string> testRequeteMultiple()
        {
            List<string> toto = new List<string>();

            try
            {
                MySqlConnection cnx = getCnx();
                cnx.Ping();
                string requete = "SELECT com_identifiant FROM compteconnexion";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    toto.Add(reader.GetString(0));
                }
                cnx.Close();
                return toto;
            }
            catch (MySqlException ex)
            {
                toto.Add(ex.ToString());
                return toto;
            }
        }
    }
}
