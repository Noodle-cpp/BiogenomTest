using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class DietarySupplement
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }
    }
}
