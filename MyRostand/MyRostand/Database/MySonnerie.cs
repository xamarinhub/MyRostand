using System;
using System.Collections.Generic;
using System.Text;
using MyRostand.Models;
using MySql.Data.MySqlClient;


namespace MyRostand.Database
{
    class MySonnerie
    {
        public static Sondage getUnSondage(int semaine)
        {

            Sondage unSondage = new Sondage();

            try
            {
                MySqlConnection cnx = MySQL.getCnx();
                cnx.Ping();
                string requete = "SELECT SON_ID,SON_titre, SON_MUSIQUEUN,SON_MUSIQUEDEUX,SON_MUSIQUETROIS,SON_MUSIQUEQUATRE FROM sondage WHERE SON_DATE='" + semaine + "'";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    unSondage.id = reader.GetInt32(0);
                    unSondage.titre = reader.GetString(1);
                    unSondage.musique1 = reader.GetString(2);
                    unSondage.musique2 = reader.GetString(3);
                    unSondage.musique3 = reader.GetString(4);
                    unSondage.musique4 = reader.GetString(5);

                }
                cnx.Close();
                return unSondage;
            }
            catch (MySqlException ex)
            {
                unSondage.titre = ex.ToString();
                return unSondage;
            }
        }
        
        public static void addUnVote(string musique , int idutilisateur , int sondageId)
        {
            try
            {
                MySqlConnection cnx = MySQL.getCnx();
                cnx.Ping();
                string requete = "INSERT INTO voter(VOT_UTILISATEUR, VOT_SONDAGE, VOT_MUSIQUE) VALUES(@iduti, @idsond, @musique)";
                using (MySqlCommand cmd = new MySqlCommand(requete, cnx))
                {

                    cmd.Parameters.AddWithValue("@iduti", idutilisateur);
                    cmd.Parameters.AddWithValue("@idsond", sondageId);
                    cmd.Parameters.AddWithValue("@musique", musique);

                    int recordsAffected = cmd.ExecuteNonQuery();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
        }

        public static int NbVoteParMusique(string musique, int sondageId)
        {
            int nbvotes = 0;
            try
            {
                MySqlConnection cnx = MySQL.getCnx();
                cnx.Ping();
                string requete = "SELECT COUNT(VOT_UTILISATEUR) FROM voter WHERE VOT_SONDAGE ='" + sondageId + "' AND VOT_MUSIQUE ='" + musique + "'";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                }
                cnx.Close();
                return nbvotes;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex);
                Console.WriteLine(ex.StackTrace);
                return nbvotes;
            }
        }

        public static int GetSiVoter(string musique, int sondageId, int idutilisateur)
        {
            int voteOuNon = 0;
            try
            {
                MySqlConnection cnx = MySQL.getCnx();
                cnx.Ping();
                string requete = "SELECT COUNT(VOT_UTILISATEUR) FROM voter WHERE VOT_SONDAGE ='" + sondageId + "' AND VOT_MUSIQUE ='" + musique + "' AND VOT_UTILISATEUR='" + idutilisateur +"'";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                }
                cnx.Close();
                return voteOuNon;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex);
                Console.WriteLine(ex.StackTrace);
                return voteOuNon;
            }
        }

        public static void suppUnVote(int idutilisateur, int sondageId)
        {
            try
            {
                MySqlConnection cnx = MySQL.getCnx();
                cnx.Ping();
                string requete = "DELETE FROM voter WHERE VOT_UTILISATEUR = @iduti AND VOT_SONDAGE = @idsond";
                using (MySqlCommand cmd = new MySqlCommand(requete, cnx))
                {

                    cmd.Parameters.AddWithValue("@iduti", idutilisateur);
                    cmd.Parameters.AddWithValue("@idsond", sondageId);

                    int recordsAffected = cmd.ExecuteNonQuery();
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
