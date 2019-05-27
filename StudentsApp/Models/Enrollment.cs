using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsApp.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        //Has a question mark to set to null as default and not 0
        public decimal? Grade { get; set; }
        // Every Enrollment has access to an Student and a Course
        // this is called navigation properties
        // declare it virtual so .net will fetch it from the db
        public virtual Student student { get; set; }
        public virtual Course  course   { get; set; }
    }
}