using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class Employee : Controller
    {
        private readonly IManagement _management;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public Employee(IManagement management,UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager)

        {
            this._management = management;
            this._userManager = userManager;
            this._roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEmployee(Employees employee)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = new ApplicationUser { Email = Request.Form["Email"],UserName=Request.Form["Email"]};
                await _userManager.CreateAsync(applicationUser, Request.Form["Password"]);
                await _userManager.AddToRoleAsync(applicationUser, "Employee");

                await _management.AddEmployee(employee);
                return RedirectToAction("Index","Home");

            }

            return View();
        }


        [HttpGet]
        [ActionName("AllEmployees")]
        public async Task<IActionResult> GetAllEmployee()
        {
            List<Employees> employees = await  _management.GetAllEmployees();
            return View(employees);
        }



        [HttpGet]
        public async Task<IActionResult> AssignProject()
        {
            ViewModel projectViewModel = new ViewModel();
            projectViewModel.employees = await _management.GetAllEmployees();


            return View(projectViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AssignProject(Project project)
        {

            if (ModelState.IsValid)
            {
                await _management.AddProject(project);
                return RedirectToAction("AssignProject");
            }

            return View();
        }

        [HttpGet]
        [ActionName("ProjectStatus")]
        public async Task<IActionResult> ProjectStatus()
        {
           List<Project> projects =  await _management.GetAllProjects();


            return View(projects);
        }

        [HttpGet]
        public async Task<IActionResult> EditProject(int id)
        {
            ViewModel projectViewModel = new ViewModel();
            projectViewModel.project = await _management.GetSingleProject(id);
            projectViewModel.employees = await _management.GetAllEmployees();



            return View(projectViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditProject(Project project,int id)
        {
            if (ModelState.IsValid)
            { 
                await _management.UpdateProject(project,id);
                return RedirectToAction("ProjectStatus");

            }

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> DeleteProject( int id)
        {
           
                await _management.DeleteProject(id);
                return RedirectToAction("ProjectStatus");

        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddLeave()
        {
            ViewModel viewModel = new ViewModel();
            viewModel.employees = await _management.GetAllEmployees();

            return View(viewModel);

        }
        [HttpPost]
        public async Task<IActionResult> AddLeave(Leave leave)
        {

            await _management.AddLeave(leave);
            return RedirectToAction("AllLeaves");

        }

        [HttpGet]
        public async Task<IActionResult> AllLeaves()
        {
            ViewModel viewModel = new ViewModel();
            viewModel.GetAllLeave = await _management.GetAllLeave();
            return View(viewModel);

        }

        [HttpPost]
        public async Task<IActionResult> LeaveApproved(int id)
        {
            Leave leave = await _management.GetSingleLeave(id);
            leave.Approved = true;



            await _management.LeaveApproved(leave,id);
            return RedirectToAction("AllLeaves");

        }
        [HttpPost]
        public async Task<IActionResult> LeaveDisApproved(int id)
        {

            await _management.LeaveDisApproved(id);
            return RedirectToAction("AllLeaves");

        }


    }
}
