using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass2.MvcLesson.Data;
using ProgrammingClass2.MvcLesson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.MvcLesson.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Product> products = _context
                .Products
                .Include(product => product.UnitOfMeasure)
                .ToList();

            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.UnitOfMeasures = _context.UnitOfMeasures.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (this.ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.UnitOfMeasures = _context.UnitOfMeasures.ToList();

            return View(product);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _context.Products.Find(id);

            if (product != null)
            {
                ViewBag.UnitOfMeasures = _context.UnitOfMeasures.ToList();
                return View(product);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (this.ModelState.IsValid)
            {
                _context.Products.Update(product);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.UnitOfMeasures = _context.UnitOfMeasures.ToList();

            return View(product);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);

            if (product != null)
            {
                return View(product);
            }

            return NotFound();
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _context.Products.Find(id);

            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }
    }
}
