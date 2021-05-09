using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_ASPNET_TVTime.Models
{
    public class Saison
    {
        private int idSaison;
        private int partieSaison;
        private List<Episode> lesEpisodes;

        public Saison()
        {

        }
        public Saison(int idSa, int date, List<Episode> episodes)
        {
            this.idSaison = idSa;
            this.partieSaison = date;
            this.lesEpisodes = episodes;
        }

        public Saison(int idSa, int date)
        {
            this.idSaison = idSa;
            this.partieSaison = date;
        }

        public int IdSaison { get => idSaison; set => idSaison = value; }
        public int PartieSaison { get => partieSaison; set => partieSaison = value; }
        public List<Episode> LesEpisodes { get => lesEpisodes; set => lesEpisodes = value; }
    }
}