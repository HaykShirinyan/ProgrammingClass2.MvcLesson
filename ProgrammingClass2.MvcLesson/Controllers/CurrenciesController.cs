using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProgrammingClass2.MvcLesson.Models;
using ProgrammingClass2.MvcLesson.Data;



namespace ProgrammingClass2.MvcLesson.Controllers
{
    public class CurrenciesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CurrenciesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var currencies = _context.Currencies.ToList();
            return View(currencies);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Currency currency)
        {
            if (ModelState.IsValid)
            {
                _context.Currencies.Add(currency);
                _context.SaveChanges();

                return RedirectToAction(nameof(CurrenciesController.Index));
            }

            return BadRequest(ModelState);
        }
    }
}

