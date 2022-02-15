using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Data
{
     public interface IManagement
    {
        Task AddEmployee(Employees employees);
        Task<List<Employees>> GetAllEmployees();
        Task<Employees>GetSingleEmployee(int id);
        Task DeleteEmployee(int id);
        Task UpdateEmployee(Employees employees, int id);
        Task AddAttendance(Attendance attendance);
        Task AddProject(Project project);
        Task<Project> GetSingleProject(int id);
        Task UpdateProject(Project project, int id);
        Task DeleteProject(int id);
        Task<List<Project>> GetAllProjects();
        Task AddLeave(Leave leave);
        Task<List<Leave>> GetAllLeave();
        Task<Leave> GetSingleLeave(int id);
        Task LeaveApproved(Leave leave,int id);
        Task LeaveDisApproved(int id);
        Task RegisterUser(RegisterModel registerModel);
        Task LoginUser(LoginModel loginModel);
        Task LogOutUser();
    }
}
