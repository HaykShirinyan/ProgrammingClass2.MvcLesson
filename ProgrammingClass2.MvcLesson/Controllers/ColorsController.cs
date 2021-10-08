using Microsoft.AspNetCore.Mvc;
using ProgrammingClass2.MvcLesson.Data;
using ProgrammingClass2.MvcLesson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.MvcLesson.Controllers
{
    public class ColorsController : Controller
    {
        private ApplicationDbContext _context;

        public ColorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Color> colors = _context.Colors.ToList();

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
            if (this.ModelState.IsValid)
            {
                _context.Colors.Add(color);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(color);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var color = _context.Colors.Find(id);

            if (color != null)
            {
                return View(color);
            }

            return null;
        }

        [HttpPost]
        public IActionResult Edit(Color color)
        {
            if (this.ModelState.IsValid)
            {
                _context.Colors.Update(color);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(color);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var color = _context.Colors.Find(id);

            if (color != null)
            {
                return View(color);
            }

            return NotFound();
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var color = _context.Colors.Find(id);

            if (color != null)
            {
                _context.Colors.Remove(color);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }
    }
 
} 

