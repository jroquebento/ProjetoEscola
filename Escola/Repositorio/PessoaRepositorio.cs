using AutoMapper;
using Escola.Data;
using Escola.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Repositorio
{
    public class PessoaRepositorio : IPessoaRepositorio
    {
        private EscolaDataContext db = new EscolaDataContext();

        IMapper mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddMaps(typeof(Escola.Mappers.EscolaProfile));
        }).CreateMapper();

        public IEnumerable<Pessoa> RetornaTodos() 
        {
            var pessoas = db.Pessoas.Where(p => p.Ativo.Equals(1)).ToList();
            var listaPessoas = mapper.Map<IEnumerable<Entidades.Pessoa>, IEnumerable<Pessoa>>(pessoas);
            return listaPessoas;
        }

        public void Create(Pessoa pessoa)
        {
            var pessoas = mapper.Map<Pessoa, Entidades.Pessoa>(pessoa);
            db.Entry(pessoas).State = EntityState.Added;
            db.SaveChanges();
        }

        public Pessoa RetornaPorId(int? id) 
        {
            var pessoa = db.Pessoas.Find(id);
            var pessoas = mapper.Map<Entidades.Pessoa, Pessoa>(pessoa);
            return pessoas;
        }

        public void Edit(Pessoa pessoa)
        {
            var pessoas = mapper.Map<Pessoa, Entidades.Pessoa>(pessoa);
            db.Entry(pessoas).State = EntityState.Modified;
            db.SaveChanges();
        }

        public IEnumerable<Pessoa> BuscarPorNome(string pessoa)
        {
            var listaPessoas = db.Pessoas.Where(p => p.Nome.Contains(pessoa) && p.Ativo.Equals(1));
            var pessoas = mapper.Map<IEnumerable<Entidades.Pessoa>, IEnumerable<Pessoa>>(listaPessoas);
            return pessoas;
        }

        public IEnumerable<Pessoa> BuscarPorCpf(string pessoa)
        {
            var listaPessoas = db.Pessoas.Where(p => p.CPF.Contains(pessoa) && p.Ativo.Equals(1));
            var pessoas = mapper.Map<IEnumerable<Entidades.Pessoa>, IEnumerable<Pessoa>>(listaPessoas);
            return pessoas;
        }
        public IEnumerable<Pessoa> BuscarPorRG(string pessoa)
        {
            var listaPessoas = db.Pessoas.Where(p => p.RG.Contains(pessoa) && p.Ativo.Equals(1));
            var pessoas = mapper.Map<IEnumerable<Entidades.Pessoa>, IEnumerable<Pessoa>>(listaPessoas);
            return pessoas;
        }
    }
}
