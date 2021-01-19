using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Escola.Models
{
    public class Boletim
    {
        public int Id { get; set; }
        public virtual Aluno Aluno { get; set; }
        public virtual ProfessorDisciplina ProfessorDisciplina { get; set; }
        public virtual Bimestre Bimestre { get; set; }
        public double Nota { get; set; }

        public int Ano { get; set; }

        [Required]
        public int Ativo { get; set; }

        public IEnumerable<Aluno> ListaAlunos { get; set; }
        public List<Tuple<int, string>> ListaProfessorDisciplinas { get; set; }
        public IEnumerable<Bimestre> ListaBimestres { get; set; }
        public List<Tuple<int, string>> ListaAnos { get; set; }

    }
}
