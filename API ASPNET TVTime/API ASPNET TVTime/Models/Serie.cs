using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_ASPNET_TVTime.Models
{
    public class Serie
    {
        private int idSerie;
        private string nomSerie;
        private List<Saison> lesSaisons;

        public Serie()
        {

        }

        public Serie(int id, string nom, List<Saison> saisons)
        {
            this.idSerie = id;
            this.nomSerie = nom;
            this.lesSaisons = saisons;
        }

        public int IdSerie { get => idSerie; set => idSerie = value; }
        public string NomSerie { get => nomSerie; set => nomSerie = value; }
        public List<Saison> LesSaisons { get => lesSaisons; set => lesSaisons = value; }
    }
}