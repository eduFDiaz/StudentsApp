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
                        new Employee{ EmployeeName = "Eduardo" },
                        new Employee{ EmployeeName = "Yani" },
                        new Employee{ EmployeeName = "Consue" },
                    };
            foreach (var temp in employees)
            {
                context.Employees.Add(temp);
            }
            context.SaveChanges();
        }
    }
}
