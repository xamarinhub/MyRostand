using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using MyRostand.Models;
using System.Threading.Tasks;
using System.Data;

namespace MyRostand.Database
{
    class MyCovoit
    {

        public static List<Reservation> getLesReservations()
        {
            List<Reservation> lesReservations = new List<Reservation>();

            try
            {
                MySqlConnection cnx = MySQL.getCnx();
                cnx.Ping();
                string requete = "SELECT RES_ID, RES_PRIX, RES_MONTER, RES_DECENTE, RES_TRAJET, UTI_PRENOM, UTI_NOM, UTI_ID FROM reserver, trajet, conducteur, utilisateur WHERE RES_TRAJET = TRA_ID AND TRA_CONDUCTEUR = CON_UTILISATEUR AND CON_UTILISATEUR = UTI_ID AND RES_ARCHIVE = 0";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Reservation uneReservation = new Reservation();
                    uneReservation.setId(reader.GetInt32(0));
                    uneReservation.setPrix(reader.GetInt32(1));
                    uneReservation.setMonte(reader.GetString(2));
                    uneReservation.setDescente(reader.GetString(3));
                    uneReservation.setTrajet(getUnTrajet(reader.GetInt32(4)));
                    Utilisateur leConducteur = new Utilisateur();
                    leConducteur.setId(reader.GetInt32(7));
                    leConducteur.setNom(reader.GetString(6));
                    leConducteur.setPrenom(reader.GetString(5));
                    uneReservation.setConducteur(leConducteur);
                    lesReservations.Add(uneReservation);
                }
                cnx.Close();
                return lesReservations;
            }
            catch (MySqlException ex)
            {
                Reservation erreurSQL = new Reservation();
                erreurSQL.setMonte(ex.ToString());
                lesReservations.Add(erreurSQL);
                return lesReservations;
            }
        }

        public static Trajet getUnTrajet(int idTrajet)
        {
            Trajet unTrajet = new Trajet();

            try
            {
                MySqlConnection cnx = MySQL.getCnx();
                cnx.Ping();
                string requete = "SELECT TRA_ID, TRA_LIEU_DEPART, TRA_LIEU_ARRIVER, TRA_CONDUCTEUR, TRA_DATE, TRA_HEUREDEPART, TRA_HEUREARRIVER, TRA_NBRPLACE, TRA_DESCRIPTION FROM trajet WHERE TRA_ID = " + idTrajet;
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                var reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    unTrajet.setId(reader.GetInt32(0));
                    Lieu LieuDepart = getUnLieu(reader.GetInt32(1));
                    unTrajet.setLieuDepart(LieuDepart);
                    Lieu LieuArrive = getUnLieu(reader.GetInt32(2));
                    unTrajet.setLieuArrive(LieuArrive);
                    Utilisateur Conducteur = getUnConducteur(reader.GetInt32(3));
                    unTrajet.setConducteur(Conducteur);
                    unTrajet.setDate(reader.GetDateTime(4));
                    unTrajet.setHeureDepart(reader.GetString(5));
                    unTrajet.setHeureArrive(reader.GetString(6));
                    unTrajet.setNbPlaces(reader.GetInt32(7));
                    unTrajet.setDescTrajet(reader.GetString(8));
                }
                cnx.Close();
                return unTrajet;
            }
            catch (MySqlException ex)
            {
                unTrajet.setDescTrajet(ex.ToString());
                return unTrajet;
            }
        }

        public static List<Trajet> rechercherUnTrajet(string lieuDeDepart, string lieuArrivee)
        {
            List<Trajet> trajetsTrouves = new List<Trajet>();

            try
            {
                MySqlConnection cnx = MySQL.getCnx();
                cnx.Ping();
                string requete = "SELECT DISTINCT TRA_ID FROM trajet, lieux WHERE TRA_LIEU_DEPART = LIE_ID AND LIE_LIBELLE = '"+lieuDeDepart+"' OR LIE_LIBELLE = '"+lieuArrivee+"'";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Trajet unTrajet = getUnTrajet(reader.GetInt32(0));
                    trajetsTrouves.Add(unTrajet);
                }
                cnx.Close();
                return trajetsTrouves;
            }
            catch (MySqlException ex)
            {
                Trajet unTrajet = new Trajet();
                unTrajet.setDescTrajet(ex.ToString());
                trajetsTrouves.Add(unTrajet);
                return trajetsTrouves;
            }
        }

        public static Lieu getUnLieu(int idLieu)
        {
            Lieu unLieu = new Lieu();
            unLieu.setId(idLieu);
            try
            {
                MySqlConnection cnx = MySQL.getCnx();
                cnx.Ping();
                string requete = "SELECT LIE_LIBELLE FROM lieux WHERE LIE_ID = " + idLieu;
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    unLieu.setLibbelle(reader.GetString(0));
                }
                cnx.Close();
                return unLieu;
            }
            catch (MySqlException ex)
            {
                unLieu.setLibbelle(ex.ToString());
                return unLieu;
            }
        }

        public static Lieu getUnLieuParLibelle(string libelle)
        {
            Lieu unLieu = new Lieu();
            unLieu.setLibbelle(libelle);
            try
            {
                MySqlConnection cnx = MySQL.getCnx();
                cnx.Ping();
                string requete = "SELECT LIE_ID FROM lieux WHERE LIE_LIBELLE = '" + libelle+"';";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    unLieu.setId(reader.GetInt32(0));
                }
                cnx.Close();
                return unLieu;
            }
            catch (MySqlException ex)
            {
                unLieu.setLibbelle(ex.ToString());
                return unLieu;
            }
        }

        public static List<Lieu> getLesLieux()
        {
            List<Lieu> lesLieux = new List<Lieu>();

            try
            {
                MySqlConnection cnx = MySQL.getCnx();
                cnx.Ping();
                string requete = "SELECT LIE_ID, LIE_LIBELLE FROM lieux";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Lieu unLieu = new Lieu(reader.GetInt32(0), reader.GetString(1));
                    lesLieux.Add(unLieu);
                }
                cnx.Close();
                return lesLieux;
            }
            catch (MySqlException ex)
            {
                Lieu unLieu = new Lieu();
                unLieu.setLibbelle(ex.ToString());
                lesLieux.Add(unLieu);
                return lesLieux;
            }
        }

        public static Utilisateur getUnConducteur(int idConducteur)
        {
            Utilisateur unUtilisateur = new Utilisateur();
            unUtilisateur.setId(idConducteur);
            try
            {
                MySqlConnection cnx = MySQL.getCnx();
                cnx.Ping();
                string requete = "SELECT UTI_NOM, UTI_PRENOM, UTI_DATENAISSANCE, UTI_BIO, UTI_FUMEUR, UTI_PARLEUR, UTI_MUSIQUE, UTI_ANIMAUX, UTI_NBRANNUL FROM utilisateur WHERE UTI_ID = " + idConducteur;
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    unUtilisateur.setNom(reader.GetString(0));
                    unUtilisateur.setPrenom(reader.GetString(1));
                    unUtilisateur.setDateNaissance(reader.GetDateTime(2));
                    unUtilisateur.setBio(reader.GetString(3));
                    unUtilisateur.setFumeur(reader.GetInt32(4));
                    unUtilisateur.setParleur(reader.GetInt32(5));
                    unUtilisateur.setMusique(reader.GetInt32(6));
                    unUtilisateur.setAnimaux(reader.GetInt32(7));
                    unUtilisateur.setNbAnnul(reader.GetInt32(8));
                }
                cnx.Close();
                return unUtilisateur;
            }
            catch (MySqlException ex)
            {
                unUtilisateur.setNom(ex.ToString());
                return unUtilisateur;
            }
        }
        public static Avis getUnAvis(int idAvis)
        {
            Avis unAvis = new Avis();
            unAvis.setId(idAvis);
            try
            {
                MySqlConnection cnx = MySQL.getCnx();
                cnx.Ping();
                string requete = "SELECT AVI_NOTE, AVI_COMMENTAIRE FROM avis WHERE AVI_ID = " + idAvis;
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    unAvis.setNote(reader.GetInt32(0));
                    unAvis.setCommentaire(reader.GetString(1));
                }
                cnx.Close();
                return unAvis;
            }
            catch (MySqlException ex)
            {
                return unAvis;
            }
        }

        public static void annulerReservation(Reservation uneReservation)
        {
            MySqlConnection cnx = MySQL.getCnx();
            cnx.Ping();
            string requete = "UPDATE reserver SET RES_ARCHIVE = 1 WHERE RES_ID = " + uneReservation.getId();
            MySqlCommand cmd = new MySqlCommand(requete, cnx);
            cmd.ExecuteNonQuery();
        }

        public static int getMaxIdReservation()
        {
            int cpt = 0;
            try
            {
                MySqlConnection cnx = MySQL.getCnx();
                cnx.Ping();
                string requete = "SELECT MAX(RES_ID) FROM reserver";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    cpt = (reader.GetInt32(0))+1;
                }
                cnx.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            return cpt;
        }
        public static void ajouterReservation(int idTrajet, string LieuDepart, string LieuArrivee)
        {
            int idReservation = getMaxIdReservation();
            try
            {
                MySqlConnection cnx = MySQL.getCnx();
                cnx.Ping();
                string requete = "INSERT INTO reserver VALUES(2,@idTrajet,@idReservation,@prix,@depart,@arrivee,0)";
                using (MySqlCommand cmd = new MySqlCommand(requete, cnx))
                {
                    cmd.Parameters.Add("@idTrajet", DbType.Int32).Value = idTrajet;
                    cmd.Parameters.Add("@idReservation", DbType.Int32).Value = idReservation;
                    cmd.Parameters.Add("@prix", DbType.Int32).Value = 350;
                    cmd.Parameters.Add("@depart", DbType.String).Value = LieuDepart;
                    cmd.Parameters.Add("@arrivee", DbType.String).Value = LieuArrivee;
                    cmd.ExecuteNonQuery();
                };
                
            }
            catch(MySqlException e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }

        }

    }
}
