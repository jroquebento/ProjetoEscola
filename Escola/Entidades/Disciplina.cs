using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escola.Entidades
{
    [Table(nameof(Disciplina))]
    public class Disciplina
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar")]
        [Required, StringLength(50)]
        public string Nome { get; set; }

        [Required]
        public int Ativo { get; set; }
    }
}
