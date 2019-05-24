using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentsApp.Models;

namespace StudentsApp.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            Student Edu = new Student();
            Edu.FirstName = "Eduardo";
            Edu.LastName = "Fernandez";

            Student Yani = new Student();
            Yani.FirstName = "Yaniel";
            Yani.LastName = "Fernandez";

            Student Tia = new Student();
            Tia.FirstName = "Consuelo";
            Tia.LastName = "Fernandez";

            List <Student> students = new List<Student>();
            students.Add(Edu);
            students.Add(Yani);
            students.Add(Tia);

            return View(students);
        }
    }
}