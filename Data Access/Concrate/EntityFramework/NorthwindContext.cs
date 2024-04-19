using Entities.Concrate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Concrate.EntityFramework
{
    /*Context db tabloları ile proje klasları arasında bağlantı kuruyor*/
    public class NorthwindContext:DbContext
    {
        //Bu metot veri tabanında hangisi ile çalışacağını söylüyorsun 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-PT152PB\SQLEXPRESS;Database=NORTHWND;Trusted_Connection=true;TrustServerCertificate=true");
        }

        public DbSet<Product> Products { get; set; }                          //DBset ile sınıf ve tabloları birbine bağladık
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
