using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ProgrammingClass2.MvcLesson.Models;

namespace ProgrammingClass2.MvcLesson.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        // Sa 2rd qayln e. Menq aystex nshum enq, vor mer database-um petq e mi table lini, vori anune klini Products
        // u aync kunena Product model-i property-nere.

        // 3rd qayln ayn e, vor petq e migration avelacnenq.
        // Migration avelacnelu hamar bacum enq cmd (Command Line), ev gnum enq mer proekti folderi mej.
        // Heto grum eq hetevyal hramane` dotnet ef migrations add Products
        // Ays depqum "Products" mase mere migration-i anunn e. Migration-nere karox anvanel inch uzum eq.

        // 4rd qayln ayn e, vor stugum enq migration file meji code, vorpeszi hamozvenq, vor amen inch chisht e avelacrel.

        // 5rd qayln ayn e, vor ogtagorcum enq 4rd qaylum stexcvac migratione database update anelu hamar. Cmd Line-i mej grum enq hetevyale`
        // dotnet ef database update.
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
