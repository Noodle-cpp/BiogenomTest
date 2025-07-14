using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class NutritionsReportAttribute
    {
        [Key]
        public Guid Id { get; set; }

        public Guid VitaminId { get; set; }
        public Vitamin Vitamin { get; set; }

        public double Value { get; set; }

        public Guid NutritionsReportId { get; set; }
        public NutritionsReport NutritionsReport { get; set; }
    }
}
