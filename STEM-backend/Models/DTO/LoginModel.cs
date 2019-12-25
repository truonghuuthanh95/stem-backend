using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STEM_backend.Models.DTO
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }

        public LoginModel(string username, string password, string type)
        {
            Username = username;
            Password = password;
            Type = type;
        }
    }
}