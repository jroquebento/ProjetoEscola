using Escola.Models;
using System;
using System.Collections.Generic;

namespace Escola.Repositorio
{
    public interface INotaRepositorio
    {
        IEnumerable<Nota> RetornaTodos();
        IEnumerable<Aluno> RetornaAlunos();
        List<Tuple<int, string>> RetornaProfDisciplinas();
        IEnumerable<Bimestre> RetornaBimestres();
        List<Tuple<int, string>> RetornaAno();
        void Create(Nota nota);
        Nota RetornaPorId(int? id);
        void Edit(Nota nota);
    }
}