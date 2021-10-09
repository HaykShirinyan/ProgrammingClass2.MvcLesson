using Microsoft.AspNetCore.Mvc;
using ProgrammingClass2.MvcLesson.Data;
using ProgrammingClass2.MvcLesson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.MvcLesson.Controllers
{
    public class CurrenciesController : Controller
    {
        private ApplicationDbContext _context;

        public CurrenciesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Currency> currencies = _context.Currencies.ToList();

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
            if (this.ModelState.IsValid)
            {
                _context.Currencies.Add(currency);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(currency);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var currency = _context.Currencies.Find(id);

            if (currency != null)
            {
                return View(currency);
            }

            return null;
        }

        [HttpPost]
        public IActionResult Edit(Currency currency)
        {
            if (this.ModelState.IsValid)
            {
                _context.Currencies.Update(currency);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(currency);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var currency = _context.Currencies.Find(id);

            if (currency != null)
            {
                return View(currency);
            }

            return NotFound();
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var currency = _context.Currencies.Find(id);

            if (currency != null)
            {
                _context.Currencies.Remove(currency);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }
    }

} 


