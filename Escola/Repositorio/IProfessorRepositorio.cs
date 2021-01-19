using Escola.Models;
using System.Collections.Generic;

namespace Escola.Repositorio
{
    public interface IProfessorRepositorio
    {
        IEnumerable<Professor> RetornaTodos();
        IEnumerable<Pessoa> RetornaPessoas();
        void Create(Professor professor);
        Professor RetornaPorId(int? id);
        void Edit(Professor professor);
    }
}