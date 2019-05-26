using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
 
namespace StudentsApp.Models
{
    public class SchoolContext : DbContext
    {
        //Here we specify the class we want to make a table out of
        // enabling at the same time CRUD functionality
        public DbSet<Student> Students { get; set; }
    }
}