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
    public class DisciplinaRepositorio : IDisciplinaRepositorio
    {
        private EscolaDataContext db = new EscolaDataContext();

        IMapper mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddMaps(typeof(Escola.Mappers.EscolaProfile));
        }).CreateMapper();

        public IEnumerable<Disciplina> RetornaTodos() 
        {
            var disciplinas = db.Disciplinas.Where(p => p.Ativo.Equals(1)).ToList();
            var listaDisciplinas = mapper.Map<IEnumerable<Entidades.Disciplina>, IEnumerable<Disciplina>>(disciplinas);
            
            return listaDisciplinas;
        }

        public void Create(Disciplina disciplina) 
        {
            var disciplinas = mapper.Map<Disciplina, Entidades.Disciplina>(disciplina);
            db.Disciplinas.Add(disciplinas);
            db.SaveChanges();
        }

        public Disciplina RetornaPorId(int? id) 
        {
            var disciplina = db.Disciplinas.Find(id);
            var disciplinas = mapper.Map<Entidades.Disciplina, Disciplina>(disciplina);

            return disciplinas;
        }

        public void Edit(Disciplina disciplina) 
        {
            var disciplinas = mapper.Map<Disciplina, Entidades.Disciplina>(disciplina);
            db.Entry(disciplinas).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
