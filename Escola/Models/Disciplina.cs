using System.ComponentModel.DataAnnotations;

namespace Escola.Models
{
    public class Disciplina
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [Required]
        public int Ativo { get; set; }
    }
}
