using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Entidades
{
    public class Nota
    {
        [Key]
        public int Id { get; set; }
        public virtual Aluno Aluno { get; set; }
        public virtual ProfessorDisciplina ProfessorDisciplina { get; set; }
        public virtual Bimestre Bimestre { get; set; }
        
        [Required]
        public double Valor { get; set; }
        public DateTime DataCadastro { get; set; }

        public int Ano { get; set; }

        [Required]
        public int Ativo { get; set; }
    }
}
