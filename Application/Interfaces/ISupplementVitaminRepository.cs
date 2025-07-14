using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISupplementVitaminRepository
    {
        Task<IEnumerable<Domain.Models.DietarySupplement>> GetDietarySupplementByVitaminListAsync(List<Guid> vitaminIds);
    }
}
