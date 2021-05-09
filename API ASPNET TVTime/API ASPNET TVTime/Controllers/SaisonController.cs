using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using System.IO;
using API_ASPNET_TVTime.Models;
using Newtonsoft.Json.Linq;

namespace API_ASPNET_TVTime.Controllers
{
    public class SaisonController : ApiController
    {
        //FONCTIONNEL
        [HttpPost]
        public HttpResponseMessage AddSaison([FromBody] JObject json)
        {
            Saison saison = json["saison"].ToObject<Saison>();
            Serie serie = json["serie"].ToObject<Serie>();

            SaisonDAO dao = new SaisonDAO();
            dao.ajouterSaison(saison, serie.IdSerie);

            if (saison != null)
                return Request.CreateResponse(HttpStatusCode.Created, saison);
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, saison);
        }

        //FONCTIONNEL
        [HttpGet]
        public IEnumerable<Saison> GetAll([FromBody] JObject json)
        {
            Serie serie = json["serie"].ToObject<Serie>();

            SaisonDAO dao = new SaisonDAO();
            List<Saison> lesSaisons = dao.getAllSaisonsBySerie(serie.IdSerie);

            return lesSaisons.ToList();
        }

        //FONCTIONNEL
        [HttpDelete]
        public string DeleteSaison([FromBody] JObject json)
        {
            Saison saison = json["saison"].ToObject<Saison>();

            SaisonDAO dao = new SaisonDAO();
            dao.deleteSaison(saison.IdSaison);
            return "Saison supprimé id " + saison.IdSaison;
        }

        //FONCTIONNEL
        [HttpPut]
        public string UpdateSaison([FromBody] JObject json)
        {
            Saison saison = json["saison"].ToObject<Saison>();

            SaisonDAO dao = new SaisonDAO();
            dao.updateSaison(saison);
            return "Saison n°" + saison.IdSaison + " modifiée sous la partie n° " + saison.PartieSaison + ";";
        }
    }
}
