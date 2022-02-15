using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Areas
{
   
    public class Accounts : Controller
    {
        private readonly IManagement _management;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public Accounts(IManagement management,SignInManager<ApplicationUser> signInManager)
        {
            this._management = management;
            this._signInManager = signInManager;
        }

        [HttpGet("/Account/Login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost("/Account/Login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
             await _management.LoginUser(loginModel);
                if (_signInManager.IsSignedIn(User))
                {
                     return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View();
                }
               
            }
           

            return View();
        }

        [HttpGet("/Account/Register")]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost("/Account/Register")]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {

                await _management.RegisterUser(registerModel);
            }
            return View();
        }

        [HttpPost("/Account/LogOut")]
        public async Task<IActionResult> LogOut()
        {
            await _management.LogOutUser();
            return RedirectToAction("Index","Home");
        }

    }
}
