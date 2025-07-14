using Application.Interfaces;
using Domain.Models;
using Infrastructure.DbContexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class SupplementVitaminRepository : ISupplementVitaminRepository
    {
        private readonly BiogenomDbContext _dbContext;

        public SupplementVitaminRepository(BiogenomDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Domain.Models.DietarySupplement>> GetDietarySupplementByVitaminListAsync(List<Guid> vitaminIds)
        {
            var supplementVitamins = await _dbContext.SupplementVitamins
                                                        .Include(x => x.DietarySupplement)
                                                        .Include(x => x.Vitamin)
                                                        .Where(x => vitaminIds.Contains(x.VitaminId))
                                                        .ToListAsync().ConfigureAwait(false);

            return supplementVitamins.Select(x => new Domain.Models.DietarySupplement()
            {
                Id = x.DietarySupplement.Id,
                Title = x.DietarySupplement.Title,
                VitaminBalances = new Dictionary<string, double>()
                {
                    { x.Vitamin.Title, x.SuppsValue }
                }
            }).ToList();
        }
    }
}
