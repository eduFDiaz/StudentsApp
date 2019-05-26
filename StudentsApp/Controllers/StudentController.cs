using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentsApp.Models;
using StudentsApp.ViewModels;

namespace StudentsApp.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            Course math = new Course();
            math.CourseName = "math 101";
            math.TotalCredits = 4;

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

            Course_Students obj = new Course_Students();
            obj.course = math;
            obj.students = students;

            return View(obj);
        }
    }
}