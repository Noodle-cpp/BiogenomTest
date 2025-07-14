using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class NutritionsReportAttribute
    {
        public Guid Id { get; set; }
        public Guid VitaminId { get; set; }
        public Vitamin Vitamin { get; set; }
        public double Value { get; set; }
        public Guid NutritionsReportId { get; set; }
    }
}
