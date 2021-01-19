using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Escola.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public decimal Salario { get; set; }
        public string Formacao { get; set; }        
        public virtual Pessoa Pessoa { get; set; }

        [Required]
        public int Ativo { get; set; }

        public IEnumerable<Pessoa> ListaPessoas { get; set; }
        public IEnumerable<ProfessorDisciplina> ProfessorDisciplinas { get; set; }
    }
}
