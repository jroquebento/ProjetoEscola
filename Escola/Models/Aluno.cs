using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Escola.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Curso { get; set; }
        public int Serie { get; set; }

        [Required]
        public int Ativo { get; set; }
        public virtual Pessoa Pessoa { get; set; }

        public IEnumerable<Pessoa> ListaPessoas { get; set; }

        //public Aluno()
        //{
        //    Pessoa pessoa = new Pessoa { };
        //}

        //public int Idade { get; set; }
        
        //public int RetornaIdade()
        //{            
        //    return DateTime.Now.Year - Pessoa.DataNascimento.Year;
        //}
    }
}
