using Microsoft.AspNetCore.Mvc;
using ProgrammingClass2.MvcLesson.Data;
using ProgrammingClass2.MvcLesson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.MvcLesson.Controllers
{
    public class UnitOfMeasuresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UnitOfMeasuresController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var unitOfMeasures = _context.UnitOfMeasures.ToList();
            return View(unitOfMeasures);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UnitOfMeasure unitOfMeasure)
        {
            if (ModelState.IsValid)
            {
                _context.UnitOfMeasures.Add(unitOfMeasure);
                _context.SaveChanges();

                return RedirectToAction(nameof(UnitOfMeasuresController.Index));
            }

            return BadRequest(ModelState);
        }
    }
}
