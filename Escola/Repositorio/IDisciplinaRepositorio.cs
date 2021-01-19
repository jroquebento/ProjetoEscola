using Escola.Models;
using System.Collections.Generic;

namespace Escola.Repositorio
{
    public interface IDisciplinaRepositorio
    {
        IEnumerable<Disciplina> RetornaTodos();
        void Create(Disciplina disciplina);
        Disciplina RetornaPorId(int? id);
        void Edit(Disciplina disciplina);
    }
}