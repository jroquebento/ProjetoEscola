using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escola.Entidades
{
    [Table(nameof(Boletim))]
    public class Boletim
    {
        [Key]
        public int Id { get; set; }
        public virtual Aluno Aluno { get; set; }
        public virtual ProfessorDisciplina ProfessorDisciplina { get; set; }
        public virtual Bimestre Bimestre { get; set; }
        public double Nota { get; set; }

        public int Ano { get; set; }

        [Required]
        public int Ativo { get; set; }
    }
}
