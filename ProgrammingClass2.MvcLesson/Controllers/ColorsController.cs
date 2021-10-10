using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProgrammingClass2.MvcLesson.Models;
using ProgrammingClass2.MvcLesson.Data;


namespace ProgrammingClass2.MvcLesson.Controllers
{
    public class ColorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ColorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var colors = _context.Colors.ToList();
            return View(colors);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Color color)
        {
            if (ModelState.IsValid)
            {
                _context.Colors.Add(color);
                _context.SaveChanges();

                return RedirectToAction(nameof(ColorsController.Index));
            }

            return BadRequest(ModelState);
        }
    }
}

