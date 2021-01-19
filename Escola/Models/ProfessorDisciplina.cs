using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Escola.Models
{
    public class ProfessorDisciplina
    {
        public int Id { get; set; }         
        public virtual Professor Professor { get; set; }
        public virtual Disciplina Disciplina { get; set; }

        [Required]
        public int Ativo { get; set; }

        public IEnumerable<Professor> ListaProfessores { get; set; }
        public IEnumerable<Disciplina> ListaDisciplinas { get; set; }
    }
}
