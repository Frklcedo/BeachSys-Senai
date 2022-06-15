using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeachSys.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        [Required(ErrorMessage="O nome do usuário é obrigatório",AllowEmptyStrings = false)]
        public string Nome { get; set; }
        [Required(ErrorMessage="O cpf do usuário é obrigatório",AllowEmptyStrings = false)]
        public string Cpf { get; set; }
        [Required(ErrorMessage="O e-mail do usuário é obrigatório",AllowEmptyStrings = false)]
        public string Email { get; set; }
        [Required(ErrorMessage="A senha do usuário é obrigatória",AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        public Compartimento Compartimento { get; set; }
        public bool IsRoot { get; set; }
       
    }
}