using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace API_ASPNET_TVTime.Models
{
    public class EpisodeDAO
    {
        private MySqlConnection connexion;
        public EpisodeDAO()
        {
            //Connexion BDD
            connexion = new MySql.Data.MySqlClient.MySqlConnection("server=localhost;uid=root;pwd=;database=TVTime;");
            connexion.Open();
        }

        //Récupère tout les épisodes d'une saison par son ID
        public List<Episode> getAllEpisodesBySaison(int id)
        {
            List<Episode> lesEpisodes = new List<Episode>();

            string requete = "SELECT * FROM episode WHERE id_Saison = " + id +";";
            MySqlCommand cmd = new MySqlCommand(requete, connexion);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Episode e = new Episode();
                e.IdEpisode = Convert.ToInt32(rdr[2]);
                e.TitreEpisode = rdr[3].ToString();
                lesEpisodes.Add(e);
            }
            rdr.Close();
            connexion.Close();

            return lesEpisodes;
        }

        //Supprime un épisode
        public void deleteEpisode(string id)
        {
            string requete = "SELECT * FROM episode WHERE id = " + id + ";";
            MySqlCommand cmd = new MySqlCommand(requete, connexion);
            cmd.ExecuteNonQuery();
            connexion.Close();
        }

        public void deleteEpisodeBySaison(string idSaison)
        {
            string requete = "SELECT * FROM episode WHERE id_Saison = " + idSaison + ";";
            MySqlCommand cmd = new MySqlCommand(requete, connexion);
            cmd.ExecuteNonQuery();
            connexion.Close();
        }

        //Ajoute un épisode à une saison
        public void ajouterEpisode(Episode episode, int idSaison, int idSerie)
        {
            string requete = "INSERT INTO episode (titre, id_Saison, id_Serie, id) VALUES ('" + episode.TitreEpisode + "', " + idSaison + ", " + idSerie + ", " + episode.IdEpisode + ")";
            MySqlCommand cmd = new MySqlCommand(requete, connexion);
            cmd.ExecuteNonQuery();
            connexion.Close();
        }

        //Met à jour un épisode
        public void updateEpisode(Episode episode)
        {
            string requete = "UPDATE episode SET titre = '" + episode.TitreEpisode + "' WHERE id = " + episode.IdEpisode + ";";
            MySqlCommand cmd = new MySqlCommand(requete, connexion);
            cmd.ExecuteNonQuery();
            connexion.Close();
        }
    }
}