using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Departments
    {
        [Key]
        public int Id { get; set; }
        public string Marketing { get; set; }
        public string IT { get; set; }
        public string Finance { get; set; }
        public string Catering { get; set; }
        public int EmployeeId { get; set; }

    }
}
