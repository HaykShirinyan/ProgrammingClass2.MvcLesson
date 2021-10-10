using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass2.MvcLesson.Data;
using ProgrammingClass2.MvcLesson.Models;
using ProgrammingClass2.MvcLesson.ViewModels;
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
                .Include(product => product.ProductType)
                .Include(product => product.Currency)
                .ToList();

            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var createViewModel = new ProductVm
            {
                UnitOfMeasures = _context.UnitOfMeasures.ToList(),
                ProductTypes = _context.ProductTypes.ToList(),
                Currencies = _context.Currencies.ToList(),
            };

            return View(createViewModel);
        }

        [HttpPost]
        public IActionResult Create(ProductVm productVm)
        {
            if (this.ModelState.IsValid)
            {
                _context.Products.Add(productVm.Product);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            productVm.UnitOfMeasures = _context.UnitOfMeasures.ToList();
            productVm.ProductTypes = _context.ProductTypes.ToList();
            productVm.Currencies = _context.Currencies.ToList();

            return View(productVm);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _context.Products.Find(id);

            if (product != null)
            {
                var productVm = new ProductVm
                {
                    Product = product,
                    UnitOfMeasures = _context.UnitOfMeasures.ToList(),
                    ProductTypes = _context.ProductTypes.ToList(),
                    Currencies = _context.Currencies.ToList(),
                };

                return View(productVm);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(ProductVm productVm)
        {
            if (this.ModelState.IsValid)
            {
                _context.Products.Update(productVm.Product);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            productVm.UnitOfMeasures = _context.UnitOfMeasures.ToList();
            productVm.ProductTypes = _context.ProductTypes.ToList();
            productVm.Currencies = _context.Currencies.ToList();

            return View(productVm);
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
