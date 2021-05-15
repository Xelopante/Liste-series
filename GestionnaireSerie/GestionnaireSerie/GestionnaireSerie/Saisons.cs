using System;
using System.Collections.Generic;
using System.Text;

namespace GestionnaireSerie
{
    class Saisons
    {
        private string nomSaison;
        private int nbEpisodes;

        public Saisons(string nom, int nb)
        {
            this.nomSaison = nom;
            this.nbEpisodes = nb;
        }

        public Saisons(int nb)
        {
            this.nbEpisodes = nb;
        }

        public string getNomSaison()
        {
            return this.nomSaison;
        }

        public int getNbEpisodes()
        {
            return this.nbEpisodes;
        }

        public void setNomSaison(string nom)
        {
            this.nomSaison = nom;
        }

        public void setNbEpisodes(int nb)
        {
            this.nbEpisodes = nb;
        }
    }
}
