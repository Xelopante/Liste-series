using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API_ASPNET_TVTime.Models;

namespace API_ASPNET_TVTime.Controllers
{
    public class UserController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage AddUser([FromBody] User u)
        {
            if (u != null)
                return Request.CreateResponse(HttpStatusCode.Created, u);
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, u);
        }
        [HttpGet]
        public User GetById(long id)
        {
            UserDAO dao = new UserDAO();
            List<User> lesUsers = new List<User>();
            return lesUsers.ElementAt(0);
        }
        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            UserDAO dao = new UserDAO();
            List<User> lesUsers = new List<User>();
            return lesUsers.ToList();
        }
        [HttpDelete]
        public string DeleteUser(string id)
        {
            return "Utilisateur supprimé id " + id;
        }
        [HttpPut]
        public string UpdateUser(string Name, String Id)
        {
            return "Mise à jour de l'utilisateur avec le nom " + Name + " and Id " + Id;
        }
    }
}
