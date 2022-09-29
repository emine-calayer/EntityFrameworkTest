using EntityFrameworkTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkTest.Data
{
    public class ApplicationDbContext : DbContext
    {
      
        public DbSet<Ogrenci> Ogrenciler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
          optionsBuilder.UseSqlServer(@"Server=localhost;Database=OkulDb;Trusted_Connection=True;");
            
        }

    }
}
