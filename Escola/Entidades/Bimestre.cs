using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escola.Entidades
{
    [Table(nameof(Bimestre))]
    public class Bimestre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Nome { get; set; }

        [Required]
        public int Ativo { get; set; }
    }
}
