using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsApp.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        // Every student will have a collection of Enrollments
        // Specifies One to Many relation to Enrollment model
        // we declare Enrollments as virtual so .net framework 
        // will fetch the enrollments from the database
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}