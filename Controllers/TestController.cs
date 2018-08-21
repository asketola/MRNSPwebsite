using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestApp_2
{
    public class TestController : Controller
    {
        // Routes: (see Startup.cs)
        // https://localhost:5001/Test/Index
        // https://localhost:5001
        public IActionResult Index()
        {
            // Will render Views/Test/Index.cshtml
            return View();
        }

        [HttpGet]
        public IActionResult LoginPage()
        {
            // View() will render Views/Test/LoginPage.cshtml
            return View();
        }

        // POST for data to https://localhost:5001/Test/LoginPage
        [HttpPost]
        public IActionResult LoginPage(Login model)
        {
            //establish/test sql connection
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

            //create sql query for password firstname lastname from members where email = input
            string sqlQuery = "select firstname, lastname, password from Members where email='" + model.email + "';";
            MySqlCommand query = new MySqlCommand(sqlQuery, conn);

            string firstName;
            string lastName;

            //reader to parse sql reply
            //if correct, show welcome msg
            //if incorrect show error msg
            using (var reader = query.ExecuteReader())
            {
                if (reader.Read())
                {
                    firstName = reader["firstname"].ToString();
                    lastName = reader["lastname"].ToString();
                    string password = reader["password"].ToString();

                    if (password != model.password)
                    {
                        return Content("'" + model.password + "'");

                    }

                }
                else
                {
                    
                    return Content(model.email);
                }

            }

            return Content("Welcome " + firstName + " " + lastName + "! You are now logged in.");
        }
    }
}
