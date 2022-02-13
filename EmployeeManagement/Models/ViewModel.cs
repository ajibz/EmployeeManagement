using EmployeeManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class ViewModel
    {
        public Project project { get; set; }
        public  List<Employees> employees { get; set; }
        public Leave leave { get; set; }
        public List<Leave> GetAllLeave { get; set; }
    }
}
