using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BeachSys.Models
{
    public class Compartimento
    {
        [Key]
        public int CompartimentoId { get; set; }    
        [Required]
        public int numero { get; set; }
        [Required]
        public double Altura { get; set; }
        [Required]
        public double Largura { get; set; }
        [Required]
        public bool IsDisponivel { get; set; }
        [Required]
        [ForeignKey("Armario")]
        public int ArmarioId { get; set; }
        public Armario Armario { get; set; }
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}