using EmployeeManagement.Models;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public Management(ApplicationDbContext applicationDbContext,UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager,RoleManager<IdentityRole> roleManager)
        {
            this._applicationDbContext = applicationDbContext;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
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

        public Task<List<Leave>> GetAllLeave()
        {
            return _applicationDbContext.leaves.ToListAsync();
        }

        public Task<List<Project>> GetAllProjects()
        {
            return _applicationDbContext.projects.ToListAsync();
        }

        public async Task<Employees> GetSingleEmployee(int id)
        {
             return  await _applicationDbContext.employees.FirstOrDefaultAsync(m => m.EmployeeId == id);
        }

        public async Task<Leave> GetSingleLeave(int id)
        {
            return await _applicationDbContext.leaves.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async  Task<Project> GetSingleProject(int id)
        {
           return await _applicationDbContext.projects.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async  Task LeaveApproved(Leave leave,int id)
        {
           
            _applicationDbContext.Update(leave);

            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task LeaveDisApproved(int id)
        {
            _applicationDbContext.leaves.Remove(_applicationDbContext.leaves.FirstOrDefault(m => m.Id == id));
            await _applicationDbContext.SaveChangesAsync();
        }

        public Task LoginUser(LoginModel loginModel)
        {
            return _signInManager.PasswordSignInAsync(loginModel.Email,loginModel.Password,true,true);
            
        }

        public Task LogOutUser()
        {
            return _signInManager.SignOutAsync();
        }

        public async Task RegisterUser(RegisterModel registerModel)
        {
          

            ApplicationUser applicationUser = new ApplicationUser { Email = registerModel.Email,UserName = registerModel.Email, Surname = registerModel.Surname, Firstname = registerModel.Firstname, Age = registerModel.Age};
            var response = await _userManager.CreateAsync(applicationUser, registerModel.Password);

            if (response.Succeeded) {
                IdentityRole identityRole = new IdentityRole();
                identityRole.Name = "Admin";
                await _roleManager.CreateAsync(identityRole);
                await _userManager.AddToRoleAsync(applicationUser, "Admin");
                await _signInManager.SignInAsync(applicationUser, true, null);
            }
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
            _applicationDbContext.Update(employees);
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
