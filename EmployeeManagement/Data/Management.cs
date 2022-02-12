using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Data
{
    public class Management : IManagement
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public Management(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }

        public async Task AddAttendance(Attendance attendance)
        {
            await _applicationDbContext.attendances.AddAsync(attendance);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task AddEmployee(Employees employees)
        {
           
            await _applicationDbContext.employees.AddAsync(employees);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task AddLeave(Leave leave)
        {
            await _applicationDbContext.leaves.AddAsync(leave);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task AddProject(Project project)
        {
            await _applicationDbContext.projects.AddAsync(project);
            await _applicationDbContext.SaveChangesAsync();
        }

     

        public async Task DeleteEmployee(int id)
        {
           
             _applicationDbContext.employees.Remove(_applicationDbContext.employees.FirstOrDefault(m => m.EmployeeId == id));
             await _applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteProject(int id)
        {
            _applicationDbContext.projects.Remove(_applicationDbContext.projects.FirstOrDefault(m => m.Id == id));
            await _applicationDbContext.SaveChangesAsync();
        }

        public Task<List<Employees>> GetAllEmployees()
        {
           return  _applicationDbContext.employees.ToListAsync();
        }

        public Task<List<Project>> GetAllProjects()
        {
            return _applicationDbContext.projects.ToListAsync();
        }

        public async Task<Employees> GetSingleEmployee(int id)
        {
             return  await _applicationDbContext.employees.FirstOrDefaultAsync(m => m.EmployeeId == id);
        }

        public async  Task<Project> GetSingleProject(int id)
        {
           return await _applicationDbContext.projects.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task UpdateEmployee(Employees employees, int id)
        {
            Employees employees1 = new Employees
            {
                EmployeeId = id,
                Age = employees.Age,
                EmployeeName = employees.EmployeeName,
                Sex = employees.Sex,
                MaritalStatus = employees.MaritalStatus,
                Department = employees.Department
            };
            await _applicationDbContext.SaveChangesAsync();
        
        }

        public async Task UpdateProject(Project project, int id)
        {
            Project project1 = new Project
            {
                 Id = id,
                 ProjectTitle = project.ProjectTitle,
                 EmployeeName = project.EmployeeName,
                 ExpiringDate = project.ExpiringDate,
                 submitted = project.submitted
            };
            _applicationDbContext.projects.Update(project1);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
