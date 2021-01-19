using Escola.Models;
using System.Collections.Generic;

namespace Escola.Repositorio
{
    public interface IPessoaRepositorio
    {
        IEnumerable<Pessoa> RetornaTodos();
        void Create(Pessoa pessoa);
        Pessoa RetornaPorId(int? id);
        void Edit(Pessoa pessoa);
        IEnumerable<Pessoa> BuscarPorNome(string pessoa);
        IEnumerable<Pessoa> BuscarPorCpf(string cpf);
        IEnumerable<Pessoa> BuscarPorRG(string rg);

    }
}