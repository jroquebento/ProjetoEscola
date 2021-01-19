using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Escola.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public int Senha { get; set; }
        public virtual Pessoa Pessoa { get; set; }

        [Required]
        public int Ativo { get; set; }
        public IEnumerable<Pessoa> ListaPessoas { get; set; }
    }
}
