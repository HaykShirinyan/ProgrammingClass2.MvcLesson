using ProgrammingClass2.MvcLesson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.MvcLesson.ViewModels
{
    public class ProductColorVm
    {
        public Product Product { get; set; }
        public List<ProductColor> ProductColors { get; set; }
    }

    public class CreateProductColorVm
    {
        public Product Product { get; set; }
        public int SelectedColorId { get; set; }

        public List<Color> Colors { get; set; }
    }

}
