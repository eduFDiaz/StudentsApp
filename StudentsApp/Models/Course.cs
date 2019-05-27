using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsApp.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int TotalCredits { get; set; }
        // Every course will have a collection of Enrollments
        // Specifies One to Many relation to Enrollment model
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}