using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace TaskProject.Models
{
    public static class TaskInitializer
    {
        public static void Initialize(TaskContext context)
        {
            context.Database.EnsureCreated();

            // Look for any instances.
            if (context.Employees.Any())
            {
                return;   // DB has been seeded
            }


            var employees = new List<Employee>
            {
                new Employee{ EmployeeName = "James Dean" },
                new Employee{ EmployeeName = "Linda Berry" }
            };
            foreach (var temp in employees)
            {
                context.Employees.Add(temp);
            }
            context.SaveChanges();

            var statuses = new List<Status>
            {
                new Status{ StatusName = "Open" },
                new Status{ StatusName= "Code Review" }
            };

            foreach (var temp in statuses)
            {
                context.Statuses.Add(temp);
            }
            context.SaveChanges();

            var tasks = new List<TaskDetail>
            {
                new TaskDetail{ TaskName = "Learn C#", TaskDescription = "Begin by video...", AssignedDate = DateTime.Parse("01/02/2014"), EmployeeId = 1, StatusId = 2 },
                new TaskDetail{ TaskName = "Learn MVC", TaskDescription = "Use video...", AssignedDate = DateTime.Parse("02/09/2014"), EmployeeId = 1, StatusId = 1 }
            };

            foreach (var temp in tasks)
            {
                context.TaskDetails.Add(temp);
            }
            context.SaveChanges();

        }
    }
}
