using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wwb.Models;

namespace wwb.Controllers
{
    public class AdminController : Controller
    {
        private readonly DataContext _context;

        public AdminController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Admin admin)
        {
            var a = _context.Admin.Where(u => u.Email == admin.Email && u.Password == admin.Password);
            if(a!= null)
            {
                HttpContext.Session.SetString("Email", admin.Email);
                return RedirectToAction("Index", "Menus");
            }
            else
            {
                return RedirectToAction("Login", "Menus");
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Admin");
        }
    }
}
