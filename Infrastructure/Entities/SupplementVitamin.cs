using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class SupplementVitamin
    {
        public Guid VitaminId { get; set; }
        public Vitamin Vitamin { get; set; }

        public Guid DietarySupplementId { get; set; }
        public DietarySupplement DietarySupplement { get; set; }

        public double SuppsValue { get; set; }
    }
}
