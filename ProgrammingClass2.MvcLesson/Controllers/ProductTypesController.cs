﻿using Microsoft.AspNetCore.Mvc;
using ProgrammingClass2.MvcLesson.Data;
using ProgrammingClass2.MvcLesson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.MvcLesson.Controllers
{
    public class ProductTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var productTypes = _context.ProductTypes.ToList();

            return View(productTypes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductType productType)
        {
            if (ModelState.IsValid)
            {
                _context.ProductTypes.Add(productType);
                _context.SaveChanges();

                return RedirectToAction(nameof(ProductTypesController.Index));
            }

            return BadRequest(ModelState);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var productType = _context.ProductTypes.Find(id);

            if (productType != null)
            {
                return View(productType);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(ProductType productType)
        {
            if (this.ModelState.IsValid)
            {
                _context.ProductTypes.Update(productType);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(productType);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var productType = _context.ProductTypes.Find(id);

            if (productType != null)
            {
                return View(productType);
            }    
            
            return NotFound();
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var productType = _context.ProductTypes.Find(id);

            if (productType != null)
            {
                _context.ProductTypes.Remove(productType);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }
    }
}
