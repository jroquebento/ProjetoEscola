using AutoMapper;
using Escola.Data;
using Escola.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Escola.Repositorio
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private EscolaDataContext db = new EscolaDataContext();

        IMapper mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddMaps(typeof(Escola.Mappers.EscolaProfile));
        }).CreateMapper();

        public IEnumerable<Aluno> RetornaTodos()
        {
            var alunos = db.Alunos.Where(p => p.Ativo.Equals(1)).ToList();
            var listaAluno = mapper.Map<IEnumerable<Entidades.Aluno>, IEnumerable<Aluno>>(alunos);
            return listaAluno;
        }

        public IEnumerable<Pessoa> RetornaPessoas() 
        {
            var pessoas = db.Pessoas.Where(p => p.Ativo.Equals(1)).ToList();
            return mapper.Map<IEnumerable<Entidades.Pessoa>, IEnumerable<Pessoa>>(pessoas);
        }


        public void Create(Aluno aluno) 
        {
            var pessoa = db.Pessoas.Find(aluno.Pessoa.Id);
            var alunos = mapper.Map<Aluno, Entidades.Aluno>(aluno);

            if (pessoa != null)
            {
                alunos.Pessoa = pessoa;
            }

            db.Alunos.Add(alunos);
            db.SaveChanges();
        }

        public Aluno RetornaPorId(int? id) 
        {
            var aluno = db.Alunos.Find(id);
            var alunoModel = mapper.Map<Entidades.Aluno, Aluno>(aluno);
            return alunoModel;
        }

        public void Edit(Aluno aluno)
        {
            Entidades.Pessoa pessoa = db.Pessoas.Find(aluno.Pessoa.Id);
            var alunos = mapper.Map<Aluno, Entidades.Aluno>(aluno);

            if (pessoa != null)
            {
                alunos.Pessoa = pessoa;
            }

            db.Entry(alunos).State = EntityState.Modified;
            db.SaveChanges();
        }

        public IEnumerable<Aluno> BuscaPorNome(string nome)
        {
            var listaAlunos = db.Alunos.Where(p => p.Pessoa.Nome.Contains(nome) && p.Ativo.Equals(1)).ToList();
            var alunos = mapper.Map<IEnumerable<Entidades.Aluno>, IEnumerable<Aluno>>(listaAlunos);
            return alunos;
        }

        public IEnumerable<Aluno> BuscarPorCPF(string CPF)
        {
            var listaAlunos = db.Alunos.Where(p => p.Pessoa.CPF.Contains(CPF) && p.Ativo.Equals(1)).ToList();
            var alunos = mapper.Map<IEnumerable<Entidades.Aluno>, IEnumerable<Aluno>>(listaAlunos);
            return alunos;
        }

        public IEnumerable<Aluno> BuscarPorCurso(string curso)
        {
            var listaAlunos = db.Alunos.Where(p => p.Curso.Contains(curso) && p.Ativo.Equals(1)).ToList();
            var alunos = mapper.Map<IEnumerable<Entidades.Aluno>, IEnumerable<Aluno>>(listaAlunos);
            return alunos;
        }
    }
}
