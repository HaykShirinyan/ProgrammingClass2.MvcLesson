using ProgrammingClass2.MvcLesson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.MvcLesson.ViewModels
{
    public class ProductCategoryVm
    {
        public Product Product { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
    }

    public class CreateProductCategoryVm
    {
        public Product Product { get; set; }
        public int SelectedCategoryId { get; set; }

        public List<Category> Categories { get; set; }
    }
}
