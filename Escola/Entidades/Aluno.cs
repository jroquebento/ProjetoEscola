using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escola.Entidades
{
    [Table(nameof(Aluno))]
    public class Aluno
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar")]
        [Required, StringLength(20)]
        public string Curso { get; set; }

        [Required]
        public int Serie { get; set; }

        [Required]
        public int Ativo { get; set; }
        public virtual Pessoa Pessoa { get; set; }
    }
}
