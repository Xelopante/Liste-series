using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API_ASPNET_TVTime.Models;
using Newtonsoft.Json.Linq;

namespace API_ASPNET_TVTime.Controllers
{
    public class EpisodeController : ApiController
    {
        //FONCTIONNEL
        [HttpPost]
        public HttpResponseMessage AddEpisode([FromBody] JObject json)
        {
            Episode episode = json["episode"].ToObject<Episode>();
            Saison saison = json["saison"].ToObject<Saison>();
            Serie serie = json["serie"].ToObject<Serie>();

            EpisodeDAO dao = new EpisodeDAO();
            dao.ajouterEpisode(episode, saison.IdSaison, serie.IdSerie);

            if (episode != null)
                return Request.CreateResponse(HttpStatusCode.Created, episode);
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, episode);
        }

        [HttpGet]
        public IEnumerable<Episode> GetAll([FromBody] JObject json)
        {
            Saison saison = json["saison"].ToObject<Saison>();

            EpisodeDAO dao = new EpisodeDAO();
            List<Episode> lesEpisodes = new List<Episode>();
            return lesEpisodes.ToList();
        }


        [HttpDelete]
        public string DeleteEpisode(string id)
        {
            return "Episode supprimé id " + id;
        }
        [HttpPut]
        public string UpdateEpisode(string Name, String Id)
        {
            return "Mise à jour de l'épisode avec le nom " + Name + " and Id " + Id;
        }
    }
}
