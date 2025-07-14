using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    /// <summary>
    /// По-сути норма для мужчин, женщин и детей разная, но реализовать решила как одну, а так бы вынесла отдельный справочник норму
    /// </summary>
    public class Vitamin
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        public double Value { get; set; }
    }
}
