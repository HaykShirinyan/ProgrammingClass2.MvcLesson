using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.MvcLesson.Models
{
    // 1 qayln ayn e, vor petq e Model avelacnenq. Ays depqum modele Product class-n e.
    // C# model-neri property-nerov sarqvum en SQL table-nere.

    // 2 qayln ayn e, vor petq e ays model-ov ApplicationDbContext-i mej property avelacnenq vore hamarjeq klini database-i table-in.
    public class Product
    {
        // Key attribute nshanakum e Id property-n ays model-i primary key e.
        // Primary key-i mijocov heshtutyamb gtnum enq mer uzac toxe.
        [Key]
        public int Id { get; set; }

        // Required attribute nshanakum e chenq karox apranq sarqel aranc anun talu. Apranqi anune partadir e
        // StringLength attribute nshanakum e apranqi anune petq e amena shate 50 tar unena.
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(300)]
        public string Description { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        // Foreign Key.
        // Foreign Key-n mek ayl table-i Primary Key e, vori mijocov karox enq ayd table-i tvyalnere gtnel ev dnel mer axyusaki mej

        // int? nshanakum a ays int property-n hnaravor e null nshanakel. Aranc harcakani int tesaki popoxakannerin hnaravor che null nshanakel.
        public int? UnitOfMeasureId { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }


        public int? ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }


        public int? CurrencyId { get; set; }
        public Currency Currency { get; set; }
    }
}
