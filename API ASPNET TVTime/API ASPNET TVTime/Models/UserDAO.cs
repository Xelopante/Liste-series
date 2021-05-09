using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace API_ASPNET_TVTime.Models
{
    public class UserDAO
    {
        private MySqlConnection connexion;
        public UserDAO()
        {
            //Connexion BDD
            connexion = new MySql.Data.MySqlClient.MySqlConnection("server=localhost;uid=root;pwd=;database=TVTime;");
            connexion.Open();
        }

        //Compte le nombre de ligne qui correspondent au login & mdp pourla connexion
        public int connexionUser(string login, string mdp)
        {
            int count = 0;

            string requete = "SELECT COUNT(*) FROM user WHERE loginUser = " + login + " AND mdpUser = " + mdp + ";";
            MySqlCommand cmd = new MySqlCommand(requete, connexion);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while(rdr.Read())
            {
                count = Convert.ToInt32(rdr[0]);
            }
            rdr.Close();
            connexion.Close();

            return count;
        }
    }
}