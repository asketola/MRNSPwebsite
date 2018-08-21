using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace TestApp_2.Models
{
    public class Member
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
    }

    public class Login
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}