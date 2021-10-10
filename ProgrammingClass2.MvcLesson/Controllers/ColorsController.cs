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
            var createViewModel = new ColorVm();

            return View(createViewModel);
        }

        [HttpPost]
        public IActionResult Create(ColorVm colorVm)
        {
            if (this.ModelState.IsValid)
            {
                _context.Colors.Add(colorVm.Color);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(colorVm);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var color = _context.Colors.Find(id);

            if (color != null)
            {
                var colorVm = new ColorVm
                {
                    Color = color,
                };

                return View(colorVm);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(ColorVm colorVm)
        {
            if (this.ModelState.IsValid)
            {
                _context.Colors.Update(colorVm.Color);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(colorVm);
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
