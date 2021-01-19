using Escola.Models;
using System.Collections.Generic;

namespace Escola.Repositorio
{
    public interface IProfessorDisciplinaRepositorio
    {
        IEnumerable<ProfessorDisciplina> RetornaTodos();
        IEnumerable<Professor> RetornaProfessores();
        IEnumerable<Disciplina> RetornaDisciplinas();
        void Create(ProfessorDisciplina professorDisciplina);
        ProfessorDisciplina RetornaPorId(int? id);
        void Edit(ProfessorDisciplina professorDisciplina);
    }
}