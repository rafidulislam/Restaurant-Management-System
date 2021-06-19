using FizzWare.NBuilder.Dates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wwb.Models;

namespace wwb.Controllers
{
    public class ReportControllar : Controller
    {
        private readonly DataContext _context;
        public ReportControllar(DataContext context)
        {
            _context = context;
        }

        public IActionResult ViewReport()
        {
            //DateTime thismonth = ;
            var a = _context.metarials.Where(s => s.Date.Month == DateTime.Now.Month).ToList();
            var b = _context.Orders.ToList();
            return View(a);
        }
    }
}
