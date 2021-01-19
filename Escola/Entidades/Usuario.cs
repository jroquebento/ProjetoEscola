using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escola.Entidades
{
    [Table(nameof(Usuario))]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar")]
        [Required, StringLength(30) ]
        public string Login { get; set; }

        [Required]
        public int Senha { get; set; }

        public virtual Pessoa Pessoa { get; set; }

        [Required]
        public int Ativo { get; set; }
    }
}
