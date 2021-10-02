using Microsoft.AspNetCore.Mvc;
using ProgrammingClass2.MvcLesson.Data;
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
    }
}
