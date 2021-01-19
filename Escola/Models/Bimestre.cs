using System.ComponentModel.DataAnnotations;

namespace Escola.Models
{
    public class Bimestre
    {
        public int Id { get; set; }
        public int Nome { get; set; }

        [Required]
        public int Ativo { get; set; }
    }
}
