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
    // 6rd qayln e controller avelacnele. Ete dzer model-i anune Product e, apa dzer controller-i anune piti lini ProductsController

    // localhost/products/index
    public class ProductsController : Controller
    {
        // ApplicationDbContext-ic ogtvelu hamar piti ayn dneq class contructor-i mej,
        // heto el contructor-ic nshanakeq dzer class-i private field _context popoxakanin
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            // nshanakum enq class-i _context private field-in.
            _context = context;
        }

        // Index action-e amen controller-i default actionn e.
        // Mer depqum sa product-neri axyusaki ejn e.

        // 7rd qayln e sarqel ayd model-i axyusaki eje, vortex uxxaki cuyc ktaq dzer table-i meji bolor tvyalnere.
        [HttpGet]
        public IActionResult Index()
        {
            // Aystex product-nere database-ic vercnum enq ev poxancum Product folder-i meji Index view-in.
            List<Product> products = _context.Products
                .Include(product => product.ProductType)
                .Include(product => product.UnitOfMeasure)
                .Include(product => product.Currency)
                .Include(product => product.Color)
                .ToList();           

            // Aystex menq nshum enq, vor menq uzum enq UnitOfMeasure-neri liste miacnel mer product-neri list-in (Join)

            //Include function-i hamar petq e avelacneq using Microsoft.EntityFrameworkCore amena verevum.

            return View(products);            
        }
       

        // 9rd qaylne e sarqel Create HttpGet action-e, vore parzapes Create view-n kveradadzni.

        // /products/create
        [HttpGet]
        public IActionResult Create()
        {
            var createViewModel = new ProductVm
            {
                UnitOfMeasures = _context.UnitOfMeasures.ToList(),
                ProductTypes = _context.ProductTypes.ToList(),
                Currencies = _context.Currencies.ToList(),
                Colors = _context.Colors.ToList(),
            };

            return View(createViewModel);
        }

        // 11rd qayln e sarqel Create HttpPost action-e, vore Create view-i tvyalnerov Product ksarqi mer database-um.
        // /products/create
        [HttpPost]
        public IActionResult Create(ProductVm productVm)
        {
            if (this.ModelState.IsValid)
            {
                _context.Products.Add(productVm.Product);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            // Ete validation-i het kapvac xndirner kan, menq petq e noric UnitOfMeasures list database-ic vercnenq ev het uxarkenq.
            productVm.UnitOfMeasures = _context.UnitOfMeasures.ToList();
            productVm.ProductTypes = _context.ProductTypes.ToList();
            productVm.Currencies = _context.Currencies.ToList();
            productVm.Colors = _context.Colors.ToList();

            return View(productVm);
        }

        // /products/edit/2
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _context.Products.Find(id);

            if (product != null)
            {
                // Ete gtanq mer product-e, ekeq UnitOfMeasures list-n el database-ic vercnenq
                var productVm = new ProductVm
                {
                    Product = product,
                    UnitOfMeasures = _context.UnitOfMeasures.ToList(),
                    ProductTypes = _context.ProductTypes.ToList(),
                    Currencies = _context.Currencies.ToList(),
                    Colors = _context.Colors.ToList(),
                };                

                return View(productVm);
            }

            return NotFound();
        }

        // /products/edit
        [HttpPost]
        public IActionResult Edit(ProductVm productVm)
        {
            if (this.ModelState.IsValid)
            {
                _context.Products.Update(productVm.Product);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            // Ete validation-i het kapvac xndirner kan, menq petq e noric UnitOfMeasures list database-ic vercnenq ev het uxarkenq.
            productVm.UnitOfMeasures = _context.UnitOfMeasures.ToList();
            productVm.ProductTypes = _context.ProductTypes.ToList();
            productVm.Currencies = _context.Currencies.ToList();
            productVm.Colors = _context.Colors.ToList();

            return View(productVm);
        }

        // /products/delete/2
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

        // Qani vor C#-i mej class-e chi karox 2 nuyn anunov ev parametrerov funkcianer unenal,
        // menq stipvac mere HTTP POST Delete action-i funkciayi anune drel enq DeleteConfirmed.
        // Bayc [ActionName("Delete")] attribute-i mijocov menq nshum enq, vor action-i anune amen depqum Delete e.

        // /products/delete/2
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
