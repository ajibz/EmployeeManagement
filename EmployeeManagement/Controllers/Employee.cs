using EmployeeManagement.Data;
using EmployeeManagement.Models;
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

        public Employee(IManagement management)
        {
            this._management = management;
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
            ProjectViewModel projectViewModel = new ProjectViewModel();
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
            ProjectViewModel projectViewModel = new ProjectViewModel();
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


    }
}
