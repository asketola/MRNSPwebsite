using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace TestApp_2.Models
{
    public class BloggingContext
    {
        public string ConnectionString { get; set; }  
  
        public BloggingContext(string connectionString)  
        {  
            this.ConnectionString = connectionString;  
        }  
  
        private MySqlConnection GetConnection()  
        {  
            return new MySqlConnection(ConnectionString);  
        }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }

        public List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }

    public class Member
    {
        public string FirstName { get; set; }
    }
}