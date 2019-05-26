using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentsApp.Models;

namespace StudentsApp.ViewModels
{
    public class Course_Students
    {
        public Course course { get; set; }
        public List<Student> students { get; set; }
    }
}