using Escola.Models;
using System.Collections.Generic;

namespace Escola.Repositorio
{
    public interface IUsuarioRepositorio
    {
        IEnumerable<Usuario> RetornaTodos();
        IEnumerable<Pessoa> RetornaPessoas();
        void Create(Usuario usuario);
        Usuario RetornaPorId(int? id);
        void Edit(Usuario usuario);
    }
}