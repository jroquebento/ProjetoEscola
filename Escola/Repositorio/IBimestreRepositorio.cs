using Escola.Models;
using System.Collections.Generic;

namespace Escola.Repositorio
{
    public interface IBimestreRepositorio
    {
        IEnumerable<Bimestre> RetornaTodos();
        Bimestre RetornaPorId(int? id);
        void Create(Bimestre bimestre);
        void Edit(Bimestre bimestre);
    }
}