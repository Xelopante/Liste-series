using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace API_ASPNET_TVTime.Models
{
    public class SerieDAO
    {
        private MySqlConnection connexion;
        public SerieDAO()
        {
            //Connexion BDD
            connexion = new MySql.Data.MySqlClient.MySqlConnection("server=localhost;uid=root;pwd=;database=TVTime;");
            connexion.Open();
        }

        //EN COURS (manque le blob)
        //Retourne une liste contenant toutes les séries
        public List<Serie> getAllSeries()
        {
            List<Serie> lesSeries = new List<Serie>();

            string requete = "SELECT * FROM serie";
            MySqlCommand cmd = new MySqlCommand(requete, connexion);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Serie s = new Serie();

                s.IdSerie = Convert.ToInt32(rdr[0]);
                s.NomSerie = rdr[1].ToString();
                lesSeries.Add(s);
            }
            rdr.Close();
            connexion.Close();

            foreach(Serie serie in lesSeries)
            {
                List<Saison> lesSaisons = new SaisonDAO().getAllSaisonsBySerie(serie.IdSerie);
                serie.LesSaisons = lesSaisons;
            }

            return lesSeries;
        }

        //EN COURS
        //Retourne une série par son Id
        public Serie getSeriebyId(string id)
        {
            Serie serie = new Serie();

            string requete = "SELECT * FROM serie WHERE id = " + id + ";";
            MySqlCommand cmd = new MySqlCommand(requete, connexion);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                serie.IdSerie = Convert.ToInt32(rdr[0]);
                serie.NomSerie = rdr[1].ToString();
            }

            rdr.Close();
            connexion.Close();

            return serie;
        }

        //Supprime une série avec d'abord les épisodes de chacune de ses saisons
        public void deleteSerie(int id)
        {
            string requete = "DELETE FROM serie WHERE id = " + id + ";";
            MySqlCommand cmd = new MySqlCommand(requete, connexion);
            cmd.ExecuteNonQuery();
            connexion.Close();
        }

        //Ajoute une série
        public void ajouterSerie(Serie serie)
        {
            string requete = "INSERT INTO serie (nom) VALUES ('" + serie.NomSerie + "');";
            MySqlCommand cmd = new MySqlCommand(requete, connexion);
            cmd.ExecuteNonQuery();
            connexion.Close();
        }

        //Met à jour une série
        public void updateSerie(Serie serie)
        {
            string requete = "UPDATE serie SET nom = '" + serie.NomSerie + "' WHERE id = " + serie.IdSerie + ";";
            MySqlCommand cmd = new MySqlCommand(requete, connexion);
            cmd.ExecuteNonQuery();
            connexion.Close();
        }
    }
}