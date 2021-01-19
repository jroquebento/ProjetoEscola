using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escola.Entidades
{
    [Table(nameof(ProfessorDisciplina))]
    public class ProfessorDisciplina
    {
        [Key]
        public int Id { get; set; }         
        public virtual Professor Professor { get; set; }
        public virtual Disciplina Disciplina { get; set; }

        [Required]
        public int Ativo { get; set; }
    }
}
