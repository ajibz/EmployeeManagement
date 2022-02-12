using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace EmployeeManagement.Models
{
    public class Employees
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public string MaritalStatus { get; set; }
        public Double Salary { get; set; }
    }
}
