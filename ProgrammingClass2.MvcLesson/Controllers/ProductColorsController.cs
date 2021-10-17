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
    public class ProductColorsController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ProductColorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index(int productId)
        {
            var product = _context.Products.Find(productId);

            if (product != null)
            {
                var productColors = _context
                    .ProductColors
                    .Include(model => model.Color)
                    .Where(model => model.ProductId == productId)
                    .ToList();

                var vm = new ProductColorVm
                {
                    Product = product,
                    ProductColors = productColors
                };

                return View(vm);
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult Create(int productId)
        {
            var product = _context.Products.Find(productId);

            if (product != null)
            {
                var colors = _context.Colors.ToList();

                var vm = new CreateProductColorVm
                {
                    Product = product,
                    Colors = colors
                };

                return View(vm);
            }

            return NotFound();
        } 

        [HttpPost]
        public IActionResult Create(CreateProductColorVm vm)
        {
            if (ModelState.IsValid)
            {
                _context.ProductColors.Add(new ProductColor
                {
                    ProductId = vm.Product.Id,
                    ColorId = vm.SelectedColorId
                });

                _context.SaveChanges();

                return RedirectToAction(nameof(ProductColorsController.Index), new { productId = vm.Product.Id });
            }

            vm.Colors = _context.Colors.ToList();

            return View(vm);
        }

        [HttpGet]
        public IActionResult Delete (int productId, int colorId)
        {
            var productColor = _context
                .ProductColors
                .Include(productColor => productColor.Product)
                .Include(productColor => productColor.Color)
                .SingleOrDefault(productColor => productColor.ProductId == productId && productColor.ColorId == colorId);

            if(productColor != null)
            {
                return View(productColor); 
            }

            return NotFound();
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int productId, int colorId)
        {
            var productColor = _context
                .ProductColors
                .SingleOrDefault(productColor => productColor.ProductId == productId && productColor.ColorId == colorId);

            if (productColor != null)
            {
                _context.ProductColors.Remove(productColor);
                _context.SaveChanges();

                return RedirectToAction(nameof(ProductColorsController.Index), new { productId = productId });
            }

            return NotFound();
        }
    }
}
