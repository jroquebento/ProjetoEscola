using Escola.Models;
using System.Collections.Generic;

namespace Escola.Repositorio
{
    public interface IAlunoRepositorio
    {
        IEnumerable<Aluno> RetornaTodos();
        IEnumerable<Pessoa> RetornaPessoas();
        void Create(Aluno aluno);
        Aluno RetornaPorId(int? id);
        void Edit(Aluno aluno);

        IEnumerable<Aluno> BuscaPorNome(string nome);
        IEnumerable<Aluno> BuscarPorCPF(string CPF);
        IEnumerable<Aluno> BuscarPorCurso(string curso);
    }
}