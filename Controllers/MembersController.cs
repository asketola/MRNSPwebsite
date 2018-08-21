using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestApp_2.Controllers
{
	public class MembersController : Controller
    {
        // https://localhost:5001/Members
        // https://localhost:5001/Members/Index
		public IActionResult Index()
        {
            return Content("Maybe login should go here, or some other page... not sure yet");
        }

        // https://localhost:5001/Members/List
        // Shows a list of current members.
        public IActionResult List()
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString = "server=127.0.0.1;uid=root;pwd=defaultdefault;database=Test";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                return View(ex.Message);
            }

            MySqlCommand cmd = new MySqlCommand("select * from Members", conn);

            List<Member> members = new List<Member>();

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    members.Add(new Member()
                    {
                        firstName = reader["firstname"].ToString(),
                        lastName = reader["lastname"].ToString()
                    });
                }
            }

            return View("Members", members);
        }

        // GET https://localhost:5001/Members/Add
        [HttpGet]
        public IActionResult Add()
        {
            return View("MembersAdd");
        }

        // POST for data to https://localhost:5001/Members/Add
        [HttpPost]
        public IActionResult Add(Member model)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString = "server=127.0.0.1;uid=root;pwd=defaultdefault;database=Test";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                return View(ex.Message);
            }

            string insrt = "INSERT INTO Members ( firstName, lastName ) " +
                "VALUES ( '" + model.firstName + "', '" + model.lastName + "');";

            MySqlCommand cmd = new MySqlCommand(insrt, conn);

            cmd.ExecuteNonQuery();
            return Content("user was added");
        }
    }
}
