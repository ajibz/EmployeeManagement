using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace EmployeeManagement.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string ProjectTitle { get; set; }
        public DateTime ExpiringDate { get; set; }
        public bool submitted { get; set; }
    }
}
