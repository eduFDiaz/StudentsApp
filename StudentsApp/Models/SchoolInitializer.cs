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
                new Student{ FirstName = "Eduardo", LastName = "Fernandez", EnrollmentDate = DateTime.Parse("2014-01-02")},
                new Student{ FirstName = "Yaniel", LastName = "Daniel", EnrollmentDate = DateTime.Parse("2013-01-02")},
                new Student{ FirstName = "Consuelo", LastName = "Fernandez", EnrollmentDate = DateTime.Parse("2011-11-02")},
            };
            foreach (var temp in students)
            {
                context.Students.Add(temp);
            }
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course{CourseName = "Java", TotalCredits = 4},
                new Course{CourseName = "C#", TotalCredits = 4},
                new Course{CourseName = "ASP.net MVC", TotalCredits = 4},
            };
            foreach (var temp in courses)
            {
                context.Courses.Add(temp);
            }
            context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
                new Enrollment{StudentId = 1, CourseId = 1, Grade = 3},
                new Enrollment{StudentId = 1, CourseId = 2, Grade = 4},
                new Enrollment{StudentId = 2, CourseId = 2, Grade = 3},
                new Enrollment{StudentId = 3, CourseId = 1, Grade = null},
            };
            foreach (var temp in enrollments)
            {
                context.Enrollments.Add(temp);
            }
            context.SaveChanges();
            //base.Seed(context);
        }
    }
}