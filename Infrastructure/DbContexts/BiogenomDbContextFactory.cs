using Infrastructure.DbContexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DbContexts
{
    public class BiogenomDbContextFactory : IDesignTimeDbContextFactory<BiogenomDbContext>
    {
        public BiogenomDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BiogenomDbContext>();
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Port=5433;User ID=postgres;Password=postgres;database=biogenom;");

            return new BiogenomDbContext(optionsBuilder.Options);
        }
    }
}
