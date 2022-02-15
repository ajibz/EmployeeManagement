using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Data
{
    public class ApplicationUser:IdentityUser
    {
    

        public string Surname { get; set; }
        public string Firstname { get; set; }
        public int Age { get; set; }
    }
}
