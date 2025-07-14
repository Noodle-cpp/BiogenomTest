using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DbContexts
{
    public class BiogenomDbContext : DbContext
    {
        public BiogenomDbContext(DbContextOptions options) : base(options)
        {
        }

        protected BiogenomDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SupplementVitamin>().HasKey(s => new { s.DietarySupplementId, s.VitaminId});
        }

        public DbSet<DietarySupplement> DietarySupplements { get; set; }
        public DbSet<NutritionsReport> NutritionsReports { get; set; }  
        public DbSet<NutritionsReportAttribute> NutritionsReportAttributes { get; set; }
        public DbSet<SupplementVitamin> SupplementVitamins { get; set; }
        public DbSet<Vitamin> Vitamins { get; set; }
    }
}
