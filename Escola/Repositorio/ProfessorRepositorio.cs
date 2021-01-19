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
    public class ProfessorRepositorio : IProfessorRepositorio
    {
        private EscolaDataContext db = new EscolaDataContext();

        IMapper mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddMaps(typeof(Escola.Mappers.EscolaProfile));
        }).CreateMapper();

        public IEnumerable<Professor> RetornaTodos() 
        {
            var professor = db.Professores.Where(p => p.Ativo.Equals(1)).ToList();
            var listaProfessores = mapper.Map<IEnumerable<Entidades.Professor>, IEnumerable<Professor>>(professor);
            return listaProfessores;
        }
        public IEnumerable<Pessoa> RetornaPessoas()
        {
            var pessoa = db.Pessoas.Where(p => p.Ativo.Equals(1)).ToList();
            return mapper.Map<IEnumerable<Entidades.Pessoa>, IEnumerable<Pessoa>>(pessoa);
        }

        public void Create(Professor professor) 
        {
            Entidades.Pessoa pessoa = db.Pessoas.Find(professor.Pessoa.Id);
            var professores = mapper.Map<Professor, Entidades.Professor>(professor);

            if (pessoa != null)
            {
                professores.Pessoa = pessoa;
            }

            db.Professores.Add(professores);
            db.SaveChanges();
        }

        public Professor RetornaPorId(int? id)
        {
            var professor = db.Professores.Find(id);
            var professores = mapper.Map<Entidades.Professor, Professor>(professor);
            return professores;
        }

        public void Edit(Professor professor)
        {
            Entidades.Pessoa pessoa = db.Pessoas.Find(professor.Pessoa.Id);
            var professores = mapper.Map<Professor, Entidades.Professor>(professor);

            if (pessoa != null)
            {
                professores.Pessoa = pessoa;
            }

            db.Entry(professores).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
