using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Attendance
    {
        [Key]
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeId { get; set; }
        public int Attend { get; set; }
    }
}
