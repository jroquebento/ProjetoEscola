using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escola.Entidades
{
    [Table(nameof(Pessoa))]
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar")]
        [Required, StringLength(100)]
        public string Nome { get; set; }

        [Column(TypeName = "varchar")]
        [Required, StringLength(80)]
        public string Email { get; set; }

        [Column(TypeName = "varchar")]
        [Required, StringLength(20)]
        public string RG { get; set; }

        [Column(TypeName = "varchar")]
        [Required, StringLength(11)]
        public string CPF { get; set; }

        public DateTime DataNascimento { get; set; }

        [Column(TypeName = "varchar")]
        [Required, StringLength(1)]
        public string Sexo { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(9)]
        public string Telefone { get; set; }

        [Required]
        public int Ativo { get; set; }
        public ICollection<Aluno> Alunos { get; set; }
        public ICollection<Professor> Professores { get; set; }
    }
}
