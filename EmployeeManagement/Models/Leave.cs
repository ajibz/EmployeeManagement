using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace EmployeeManagement.Models
{
    public class Leave
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int EmployeeName { get; set; }
        public bool Approved { get; set; }
        public string Reason { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}

