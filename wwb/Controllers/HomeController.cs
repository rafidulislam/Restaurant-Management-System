using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wwb.Data.Interface;
using wwb.Models;

namespace wwb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMenuRepository _menuRepository;

        public HomeController (IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        
    }
}
