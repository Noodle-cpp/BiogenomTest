using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class NutritionsReportViewModel
    {
        public Guid Id { get; set; }
        public int CountInNorm { get; set; }
        public int CountBelow { get; set; }
        public IEnumerable<VitaminAttributeViewModel> VitaminAttributes { get; set; }
        public IEnumerable<VitaminBalanceViewModel> VitaminBalances { get; set; }
        public IEnumerable<DietarySupplement> DietarySupplements { get; set; }
    }
}
