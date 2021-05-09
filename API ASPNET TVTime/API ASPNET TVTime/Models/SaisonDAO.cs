using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace API_ASPNET_TVTime.Models
{
    public class SaisonDAO
    {
        private MySqlConnection connexion;
        public SaisonDAO()
        {
            //Connexion BDD
            connexion = new MySql.Data.MySqlClient.MySqlConnection("server=localhost;uid=root;pwd=;database=TVTime;");
            connexion.Open();
        }

        //Retourne une liste contenant toutes les saisons d'une série en fonction de son ID
        public List<Saison> getAllSaisonsBySerie(int idSerie)
        {
            List<Saison> lesSaisons = new List<Saison>();

            string requete = "SELECT * FROM saison WHERE id_Serie = " + idSerie + ";";
            MySqlCommand cmd = new MySqlCommand(requete, connexion);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Saison saison = new Saison();
                saison.IdSaison = Convert.ToInt32(rdr[0]);
                saison.PartieSaison = Convert.ToInt32(rdr[1]);
                lesSaisons.Add(saison);
            }
            rdr.Close();
            connexion.Close();

            foreach(Saison saison in lesSaisons)
            {
                List<Episode> lesEpisodes = new EpisodeDAO().getAllEpisodesBySaison(saison.IdSaison);
                saison.LesEpisodes = lesEpisodes;
            }

            return lesSaisons;
        }

        //Supprime tout les épisodes d'une saison avant de la supprimer elle-même
        public void deleteSaison(int idSaison)
        {
            string requete = "DELETE FROM episode WHERE id_Saison = " + idSaison + "; DELETE FROM saison WHERE id = " + idSaison + ";";
            MySqlCommand cmd = new MySqlCommand(requete, connexion);
            cmd.ExecuteNonQuery();
            connexion.Close();
        }

        //Supprime les episode d'une saison puis la saison elle-même (appelée seulement pour SerieDAO)
        public void deleteSaisonBySerie(string idSerie)
        {
            List<string> idSaisons = new List<string>();

            string requete1 = "SELECT * FROM saison WHERE id_Serie = " + idSerie + ";";
            MySqlCommand cmd1 = new MySqlCommand(requete1, connexion);
            MySqlDataReader rdr = cmd1.ExecuteReader();
            while(rdr.Read())
            {
                string idSaison = rdr[0].ToString();
                idSaisons.Add(idSaison);
            }

            EpisodeDAO epdao = new EpisodeDAO();

            foreach(string id in idSaisons)
            {
                epdao.deleteEpisodeBySaison(id);
            }

            string requete2 = "DELETE FROM saison WHERE id_Serie = " + idSerie + ";";
            MySqlCommand cmd2 = new MySqlCommand(requete2, connexion);
            cmd2.ExecuteNonQuery();
            connexion.Close();
        }

        //Ajoute une saison avec l'ID de la série asociée
        public void ajouterSaison(Saison saison, int idSerie)
        {
            string requete = "INSERT INTO saison (id, partie, id_Serie) VALUES (" + saison.IdSaison + ", " + saison.PartieSaison + ", " + idSerie + ");";
            MySqlCommand cmd = new MySqlCommand(requete, connexion);
            cmd.ExecuteNonQuery();
            connexion.Close();
        }

        //Met à jour une saison
        public void updateSaison(Saison saison)
        {
            string requete = "UPDATE saison SET partie = " + saison.PartieSaison + " WHERE id = " + saison.IdSaison + ";";
            MySqlCommand cmd = new MySqlCommand(requete, connexion);
            cmd.ExecuteNonQuery();
            connexion.Close();
        }
    }
}