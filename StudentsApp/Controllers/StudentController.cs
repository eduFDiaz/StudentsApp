using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentsApp.Models;
using StudentsApp.ViewModels;
using System.Data;

namespace StudentsApp.Controllers
{
    public class StudentController : Controller
    {
        // GET: Context for databse Students
        private SchoolContext db = new SchoolContext();

        public ActionResult Index()
        {
            var students = db.Students.ToList();
            return View(students);

            //Course math = new Course();
            //math.CourseName = "math 101";
            //math.TotalCredits = 4;

            //Course_Students obj = new Course_Students();
            //obj.course = math;
            //obj.students = students;

            //return View(obj);
        }
    }
}