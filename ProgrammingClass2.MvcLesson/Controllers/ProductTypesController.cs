﻿using Microsoft.AspNetCore.Mvc;
using ProgrammingClass2.MvcLesson.Data;
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
    }
}
