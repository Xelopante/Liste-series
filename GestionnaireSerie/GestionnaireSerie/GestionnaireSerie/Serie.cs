using System;
using System.Collections.Generic;
using System.Text;

namespace GestionnaireSerie
{
    class Serie
    {
        private string nomSerie;
        private List<Saisons> lesSaisons;

        public string NomSerie { get => nomSerie; set => nomSerie = value; }

        public Serie(string nom, List<Saisons> saisons)
        {
            this.NomSerie = nom;
            this.lesSaisons = saisons;
        }

        public Serie(string nom)
        {
            this.NomSerie = nom;
        }

        public string getNomSerie()
        {
            return this.NomSerie;
        }

        public List<Saisons> getLesSaisons()
        {
            return this.lesSaisons;
        }

        public void setNomSerie(string nom)
        {
            this.NomSerie = nom;
        }

        public void setLesSaisons(List<Saisons> saisons)
        {
            this.lesSaisons = saisons;
        }
    }
}
