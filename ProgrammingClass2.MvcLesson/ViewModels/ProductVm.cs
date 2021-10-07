using ProgrammingClass2.MvcLesson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.MvcLesson.ViewModels
{
    public class ProductVm
    {
        public Product Product { get; set; }

        public List<ProductType> ProductTypes { get; set; }
        public List<UnitOfMeasure> UnitOfMeasures { get; set; }
    }
}
