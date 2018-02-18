using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityAssistProject.Models
{
    public class LoginClass
    {
        public LoginClass() { }
        public LoginClass(string user, string password)
        {
            UserName = user;
            Password = password;
        }
        public string UserName { set; get; }
        public string Password { set; get; }
    }
}