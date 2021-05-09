using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_ASPNET_TVTime.Models
{
    public class User
    {
        private int idUser;
        private string loginUser;
        private string mdpUser;
        private string mailUser;

        public User()
        {

        }

        public User(int id, string login, string mdp, string mail)
        {
            this.idUser = id;
            this.loginUser = login;
            this.mdpUser = mdp;
            this.mailUser = mail;
        }

        public int IdUser { get => idUser; set => idUser = value; }
        public string LoginUser { get => loginUser; set => loginUser = value; }
        public string MdpUser { get => mdpUser; set => mdpUser = value; }
        public string MailUser { get => mailUser; set => mailUser = value; }
    }
}