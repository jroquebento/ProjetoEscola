using System.Collections.Generic;

namespace Escola.Models
{
    public class BuscaPessoaViewModel
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string RG { get; set; }
        public List<Pessoa> ListaPessoas { get; set; }
    }
}
