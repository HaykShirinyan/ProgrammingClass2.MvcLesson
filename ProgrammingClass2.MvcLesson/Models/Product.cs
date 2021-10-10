using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.MvcLesson.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(300)]
        public string Description { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public int? UnitOfMeasureId { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }

        public int? ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }

        public int? CurrencyId { get; set; }
        public Currency Currency { get; set; }

        public int? ColorId { get; set; }
        public Color Color { get; set; }
    }
}
