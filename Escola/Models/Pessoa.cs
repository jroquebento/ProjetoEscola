using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Escola.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Telefone { get; set; }
        [Required]
        public int Ativo { get; set; }
        public ICollection<Aluno> Alunos { get; set; }
        public ICollection<Professor> Professores { get; set; }
        public IEnumerable<Pessoa> ListaPessoas { get; set; }

    }
}
