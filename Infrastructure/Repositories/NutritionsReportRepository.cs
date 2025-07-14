using Application.Interfaces;
using Infrastructure.DbContexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace Infrastructure.Repositories
{
    public class NutritionsReportRepository : INutritionsReportRepository
    {
        private readonly BiogenomDbContext _dbContext;

        public NutritionsReportRepository(BiogenomDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Domain.Models.NutritionsReport?> GetNutritionsReportAsync()
        {
            var report = await _dbContext.NutritionsReports
                                            .Include(x => x.NutritionsReportAttributes)
                                            .ThenInclude(x => x.Vitamin)
                                            .FirstOrDefaultAsync();

            if (report is null) return null;

            return new Domain.Models.NutritionsReport()
            {
                Id = report.Id,
                CreatedAt = report.CreatedAt,
                NutritionsReportAttributes = report.NutritionsReportAttributes.Select(x => new Domain.Models.NutritionsReportAttribute()
                {
                    Id = x.Id,
                    NutritionsReportId = report.Id,
                    Value = x.Value,
                    VitaminId = x.VitaminId,
                    Vitamin = new Domain.Models.Vitamin()
                    {
                        Id = x.VitaminId,
                        Title = x.Vitamin.Title,
                        Value = x.Vitamin.Value
                    }
                }).ToList()
            };
        }
    }
}
