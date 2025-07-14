using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Vitamin
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        
        public double Value { get; set; }
    }
}
