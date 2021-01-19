using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Models
{
    public class Nota
    {
        public int Id { get; set; }
        public virtual Aluno Aluno { get; set; }
        public virtual ProfessorDisciplina ProfessorDisciplina { get; set; }
        public virtual Bimestre Bimestre { get; set; }
        public double Valor { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public int Ano { get; set; } 
        public int Ativo { get; set; }

        public IEnumerable<Aluno> ListaAlunos { get; set; }
        public List<Tuple<int, string>> ListaProfessorDisciplinas { get; set; }
        public IEnumerable<Bimestre> ListaBimestres { get; set; }
        public List<Tuple<int, string>> ListaAnos { get; set; }
    }
}
