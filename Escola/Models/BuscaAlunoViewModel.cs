using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Models
{
    public class BuscaAlunoViewModel
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Curso { get; set; }
        public List<Aluno> ListaAlunos { get; set; }
    }
}
