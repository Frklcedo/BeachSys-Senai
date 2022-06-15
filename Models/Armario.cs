using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeachSys.Models
{
    public class Armario
    {
        [Key]
        public int ArmarioId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public double X { get; set; }
        [Required]
        public double Y { get; set; }
        public ICollection<Compartimento> Compartimentos { get; set; }
    }
}