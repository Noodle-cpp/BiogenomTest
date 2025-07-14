using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class NutritionsReport
    {
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public IEnumerable<NutritionsReportAttribute> NutritionsReportAttributes { get; set; }
    }
}
