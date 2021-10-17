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
    public class ProductCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // /ProductCategories/45
        [HttpGet]
        public IActionResult Index(int productId)
        {
            var product = _context.Products.Find(productId);

            if (product != null)
            {
                var productCategories = _context
                    .ProductCategories
                    .Include(model => model.Category)
                    .Where(model => model.ProductId == productId)
                    .ToList();

                var vm = new ProductCategoryVm
                {
                    Product = product,
                    ProductCategories = productCategories
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
                var categories = _context.Categories.ToList();

                var vm = new CreateProductCategoryVm
                {
                    Product = product,
                    Categories = categories
                };

                return View(vm);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Create(CreateProductCategoryVm vm)
        {
            if (ModelState.IsValid)
            {
                _context.ProductCategories.Add(new ProductCategory
                {
                    ProductId = vm.Product.Id,
                    CategoryId = vm.SelectedCategoryId
                });

                _context.SaveChanges();

                return RedirectToAction(nameof(ProductCategoriesController.Index), new { productId = vm.Product.Id });
            }

            vm.Categories = _context.Categories.ToList();

            return View(vm);
        }

        [HttpGet]
        public IActionResult Delete(int productId, int categoryId)
        {
            var productCategory = _context
                .ProductCategories
                .Include(productCategory => productCategory.Product)
                .Include(productCategory => productCategory.Category)
                .SingleOrDefault(productCategory => productCategory.ProductId == productId && productCategory.CategoryId == categoryId);

            if (productCategory != null)
            {
                return View(productCategory);
            }

            return NotFound();
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int productId, int categoryId)
        {
            var productCategory = _context
               .ProductCategories
               .SingleOrDefault(productCategory => productCategory.ProductId == productId && productCategory.CategoryId == categoryId);

            if (productCategory != null)
            {
                _context.ProductCategories.Remove(productCategory);
                _context.SaveChanges();

                return RedirectToAction(nameof(ProductCategoriesController.Index), new { productId = productId });
            }

            return NotFound();
        }
    }
}
