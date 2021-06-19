using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wwb.Models;

namespace wwb.Controllers
{
    public class MetarialsController : Controller
    {
        private readonly DataContext _context;

        public MetarialsController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.metarials.ToList());
        }

        [HttpPost]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var metarials = _context.metarials.FirstOrDefault(m => m.Id == id);
            if (metarials == null)
            {
                return NotFound();
            }
            return View(metarials);
        }

        public IActionResult Detaila()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Metarials metarials)
        {
            if (ModelState.IsValid)
            {
                _context.Add(metarials);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(metarials);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Metarials metarials)
        {
            if (ModelState.IsValid)
            {
                _context.Update(metarials);
                _context.SaveChanges();
                RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult report(DateTime dateTime)
        {
            var a = _context.metarials.Where(i => i.Date.Month == dateTime.Month).ToList();
            double price = 0.0;
            foreach(var item in a)
            {
                price += item.Price;
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var metarials = _context.metarials.FirstOrDefault(m => m.Id == id);
            _context.metarials.Remove(metarials);
            _context.SaveChanges();
            return View();
        }
        
        [HttpPost]
        public IActionResult Delete()
        {
            return View();
        }
    }
}
