using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mo3askarPro2.Models;
using Mo3askarPro2.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mo3askarPro2.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;
        private RoleManager<IdentityRole> roleManager;
        public AccountController(UserManager<ApplicationUser> _userManager,
            SignInManager<ApplicationUser> _signInManager,
            RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.EmailAccount, Email = model.EmailAccount, PhoneNumber = model.Phone };

                var r = await userManager.CreateAsync(user, model.Password);

                if (r.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Employees");
                }

                foreach (var err in r.Errors)
                {
                    ModelState.AddModelError(string.Empty, err.Description);
                }

            }
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Employees");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var r = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (r.Succeeded)
                {
                    return RedirectToAction("Index", "Employees");
                }

                ModelState.AddModelError(string.Empty, "Invalid user/password");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {

                IdentityRole identityRole = new IdentityRole { Name = model.RoleName };
                IdentityResult chkData = await roleManager.CreateAsync(identityRole);
                if (chkData.Succeeded)
                {
                    return RedirectToAction("RolesList", "Account");
                }

                foreach (var err in chkData.Errors)
                {
                    ModelState.AddModelError(string.Empty, err.Description);
                }

            }
            return View(model);
        }

        [HttpGet]
        public IActionResult RolesList()
        {
            var r = roleManager.Roles;
            return View(r);
        }

    }
}
