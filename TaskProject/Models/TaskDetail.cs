using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskProject.Models
{
    public class TaskDetail
    {
        public int TaskDetailId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime AssignedDate { get; set; }
        public int EmployeeId { get; set; }
        public int StatusId { get; set; }
        public virtual Status status { get; set; }
        public virtual Employee employee { get; set; }
    }
}
