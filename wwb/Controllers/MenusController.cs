using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using wwb.Models;

namespace wwb.Controllers
{
    public class MenusController : Controller
    {
        private readonly DataContext _context;

        public MenusController(DataContext context)
        {
            _context = context;
        }

        public  IActionResult Index()
        {
            return View( _context.menus.ToList());
        }
        public IActionResult MenuConfig()
        {
            return View(_context.menus.ToList());
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = _context.menus.FirstOrDefault(m => m.Id == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Price")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menu);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(menu);
        }
        public ViewResult Details(int MenuId)
        {
            var menu = _context.menus.Find(MenuId);
            if (menu == null)
            {
                
            }
            return View(menu);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = _context.menus.Find(id);
            if (menu == null)
            {
                return NotFound();
            }
            return View(menu);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Price")] Menu menu)
        {
            if (id != menu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menu);
                    _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuExists(menu.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(menu);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = _context.menus
                .FirstOrDefault(m => m.Id == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmedAsync(int id)
        {
            var menu =  _context.menus.Find(id);
            _context.menus.Remove(menu);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuExists(int id)
        {
            return _context.menus.Any(e => e.Id == id);
        }
    }
}
