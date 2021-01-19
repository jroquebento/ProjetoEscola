using AutoMapper;
using Escola.Entidades;
using System.Data.Entity;

namespace Escola.Data
{
    public class EscolaDataContext : DbContext
    {
        public EscolaDataContext() : base("EscolaConn")
        {
            Database.SetInitializer(new DbInitializer());            
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<ProfessorDisciplina> ProfessorDisciplinas { get; set; }
        public DbSet<Bimestre> Bimestres { get; set; }
        public DbSet<Nota> Notas { get; set; }

        public DbSet<Boletim> Boletins { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
