﻿using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Employees> employees { get; set; }
        public DbSet<Attendance> attendances { get; set; }
        public DbSet<Leave> leaves { get; set; }
        public DbSet<Project> projects { get; set; }
    }
}
