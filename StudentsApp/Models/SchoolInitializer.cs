using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace StudentsApp.Models
{
    public class SchoolInitializer : DropCreateDatabaseIfModelChanges<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            var students = new List<Student>
            {
                new Student{ FirstName = "Eduardo", LastName = "Fernandez"},
                new Student{ FirstName = "Yaniel", LastName = "Daniel"},
                new Student{ FirstName = "Consuelo", LastName = "Fernandez"},
            };
            foreach (var temp in students)
            {
                context.Students.Add(temp);
            }
            context.SaveChanges();
            //base.Seed(context);
        }
    }
}