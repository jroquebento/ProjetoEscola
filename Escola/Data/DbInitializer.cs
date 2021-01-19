using Escola.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Data
{
    public class DbInitializer : CreateDatabaseIfNotExists<EscolaDataContext>
    {
        protected override void Seed(EscolaDataContext context)
        {
            // Pessoa
            //var pessoa = new Pessoa()
            //{
            //    Nome = "Roberto da Silva",
            //    Email = "roberto@gmail.com",
            //    RG = "668754029",
            //    CPF = "34485637485",
            //    DataNascimento = DateTime.Parse("12/04/2004"),
            //    Sexo = "M",
            //    Telefone = "937584275"
            //};
            //context.Pessoas.Add(pessoa);
            //context.SaveChanges();


            ////Aluno
            //var aluno = new Aluno()
            //{
            //    Curso = "Química",
            //    Serie = 3,
            //    Pessoa = pessoa
            //};
            //context.Alunos.Add(aluno);
            //context.SaveChanges();

            //// Pessoa 1
            //var pessoa1 = new Pessoa()
            //{
            //    Nome = "Rosa",
            //    Email = "rosa@gmail.com",
            //    RG = "233943843",
            //    CPF = "3848484848",
            //    DataNascimento = DateTime.Parse("28/01/1990"),
            //    Sexo = "F",
            //    Telefone = "928595954"
            //};
            //context.Pessoas.Add(pessoa1);
            //context.SaveChanges();

            ////Professor
            //var professor = new Professor()
            //{
            //    Formacao = "Licenciatura",
            //    Salario = 5000.00M,
            //    Pessoa = pessoa1
            //};
            //context.Professores.Add(professor);
            //context.SaveChanges();

            ////Disciplina
            //var disciplina = new Disciplina()
            //{
            //    Nome = "Geografia"
            //};
            //context.Disciplinas.Add(disciplina);
            //context.SaveChanges();

            //// ProfessorDisciplina
            //var professorDisciplina = new ProfessorDisciplina()
            //{
            //    Disciplina = disciplina,
            //    Professor = professor
            //};
            //context.ProfessorDisciplinas.Add(professorDisciplina);
            //context.SaveChanges();

            ////Bimestre
            //var bimestre = new Bimestre()
            //{
            //    Nome = 2
            //};
            //context.Bimestres.Add(bimestre);
            //context.SaveChanges();

            //// Boletim
            //var boletim = new Boletim()
            //{
            //    Aluno = aluno,
            //    ProfessorDisciplina = professorDisciplina,
            //    Bimestre = bimestre,
            //    Nota = 7
            //};
            //context.Boletins.Add(boletim);
            //context.SaveChanges();

            ////Usuario
            //var usuario = new Usuario()
            //{
            //    Login = "robertosilva",
            //    Senha = 123,
            //    Pessoa = pessoa
            //};
            //context.Usuarios.Add(usuario);
            //context.SaveChanges();
        }
    }
}
