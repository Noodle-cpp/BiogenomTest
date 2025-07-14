using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class DietarySupplement
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public Dictionary<string, double> VitaminBalances { get; set; }
    }
}
