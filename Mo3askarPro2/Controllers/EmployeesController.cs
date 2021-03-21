using Microsoft.AspNetCore.Mvc;
using Mo3askarPro2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mo3askarPro2.Controllers
{
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db;
        public EmployeesController(ApplicationDbContext _db)
        {
            db = _db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(db.Employees);
        }

        [HttpPost]
        public IActionResult Index(string term)
        {
            var data = db.Employees.Where(x => x.EmployeeName.Contains(term));
            return View(data);
        }
        public IActionResult Details(int id)
        {
            var employee = db.Employees.Find(id);
            return View(employee);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = db.Employees.Find(id);
            return View(employee);
        }
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Update(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var employee = db.Employees.Find(id);
            return View(employee);
        }
        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                var lgn = db.Users.Where(x => x.UserName.Equals(user.UserName) && x.Password.Equals(user.Password));

                if (lgn.Any())
                {
                    if (lgn.SingleOrDefault().IsActive == true)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewData["err"] = "Your account is locked.... please contact admin";
                        return View(user);

                    }


                }
                else
                {
                    ViewData["err"] = "Invalid user name / password";
                    return View(user);
                }
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(user);
        }
    }
}
