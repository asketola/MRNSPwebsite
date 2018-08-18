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
	// Routes: (see Startup.cs)
        // https://localhost:5001/Test/Index
        // https://localhost:5001

	public class MembersController : Controller
    {
		public IActionResult Index()
        {
            // Will render Views/Test/Index.cshtml
            return View();
        }

		// https://localhost:5001/Test/Members
		public IActionResult Members()
		{
			MySql.Data.MySqlClient.MySqlConnection conn;
			string myConnectionString = "server=127.0.0.1;ius=root;pwd=defaultdefault;Database:Test";

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

            MySqlCommand cmd = new MySqlCommand("select * from Blog", conn);

            List<Blog> blogs = new List<Blog>();

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    blogs.Add(new Blog()
                    {
                        BlogId = Convert.ToInt32(reader["BlogId"]),
                        Url = reader["Url"].ToString()
                    });
                }
            }

            // View() will render Views/Test/Members.cshtml
            return View(blogs);
		}

    }
}
