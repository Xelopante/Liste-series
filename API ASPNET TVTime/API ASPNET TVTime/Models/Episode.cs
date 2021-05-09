using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_ASPNET_TVTime.Models
{
    public class Episode
    {
        private int idEpisode;
        private string titreEpisode;

        public Episode()
        {

        }

        public Episode(int idE, string titre)
        {
            this.idEpisode = idE;
            this.titreEpisode = titre;
        }

        public int IdEpisode { get => idEpisode; set => idEpisode = value; }
        public string TitreEpisode { get => titreEpisode; set => titreEpisode = value; }
    }
}