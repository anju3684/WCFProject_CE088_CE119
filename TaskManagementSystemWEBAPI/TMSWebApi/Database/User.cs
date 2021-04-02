using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMSWebApi.Database
{
    public class User
    {
        public int UserId { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}