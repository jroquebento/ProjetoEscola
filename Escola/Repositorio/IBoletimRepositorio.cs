using Escola.Models;
using System;
using System.Collections.Generic;

namespace Escola.Repositorio
{
    public interface IBoletimRepositorio
    {
        IEnumerable<Boletim> RetornaTodos();
        IEnumerable<Aluno> RetornaAlunos();
        List<Tuple<int, string>> RetornaProfDisciplinas();
        IEnumerable<Bimestre> RetornaBimestres();
        void Create(Boletim boletim);
        List<Tuple<int, string>> RetornaAnos();
        IEnumerable<Nota> RetornaBoletim(GerarBoletimViewModel gerarBoletim);
        void Create(List<Nota> listaNota);
    }
}