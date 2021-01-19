using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escola.Entidades
{
    [Table(nameof(Professor))]
    public class Professor
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "money"), Required]
        public decimal Salario { get; set; }

        [Column(TypeName = "varchar")]
        [Required, StringLength(50)]
        public string Formacao { get; set; }        
        public virtual Pessoa Pessoa { get; set; }

        [Required]
        public int Ativo { get; set; }

        public IEnumerable<ProfessorDisciplina> ProfessorDisciplinas { get; set; }
    }
}
