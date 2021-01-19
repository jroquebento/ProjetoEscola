using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Models
{
    public class GerarBoletimViewModel
    {
        public int Aluno_Id { get; set; }
        public int ProfessorDisciplina_Id { get; set; }
        public int Bimestre_Id { get; set; }
        public int Ano { get; set; }

        public IEnumerable<Aluno> ListaAlunos { get; set; }
        public List<Tuple<int, string>> ListaProfessorDisciplinas { get; set; }
        public IEnumerable<Bimestre> ListaBimestres { get; set; }
        public List<Tuple<int, string>> ListaAnos { get; set; }

        public List<Nota> ListaNotas { get; set; }
    }
}
