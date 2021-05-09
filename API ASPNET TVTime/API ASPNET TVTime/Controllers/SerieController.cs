using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API_ASPNET_TVTime.Models;
using System.Web.Script.Serialization;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace API_ASPNET_TVTime.Controllers
{
    public class SerieController : ApiController
    {
        // ~ MANQUE IMAGE, SINON FONCTIONNEL
        [HttpPost]
        public HttpResponseMessage AddSerie([FromBody] JObject json)
        {
            Serie serie = json["serie"].ToObject<Serie>();

            SerieDAO dao = new SerieDAO();
            dao.ajouterSerie(serie);

            if (serie != null)
                return Request.CreateResponse(HttpStatusCode.Created, serie);
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, serie);
        }

        // ~ MANQUE IMAGE, SINON FONCTIONNEL
        [HttpGet]
        public IEnumerable<Serie> GetAll()
        {
            SerieDAO dao = new SerieDAO();
            List<Serie> lesSeries = dao.getAllSeries();
            return lesSeries.ToList();
        }

        //FONCTIONNEL
        [HttpDelete]
        public string DeleteSerie([FromBody] JObject json)
        {
            Serie serie = json["serie"].ToObject<Serie>();

            SerieDAO dao = new SerieDAO();
            dao.deleteSerie(serie.IdSerie);

            return "Série supprimée id " + serie.IdSerie;
        }

        // ~ MANQUE IMAGE, SINON FONCTIONNEL
        [HttpPut]
        public string UpdateSerie([FromBody] JObject json)
        {
            Serie serie = json["serie"].ToObject<Serie>();

            SerieDAO dao = new SerieDAO();
            dao.updateSerie(serie);

            return "Série n°" + serie.IdSerie + " modifiée sous le nom de " + serie.NomSerie + ";";
        }
    }
}
