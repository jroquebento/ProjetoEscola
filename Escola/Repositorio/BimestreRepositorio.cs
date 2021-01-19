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
    public class BimestreRepositorio : IBimestreRepositorio
    {
        private EscolaDataContext db = new EscolaDataContext();

        IMapper mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddMaps(typeof(Escola.Mappers.EscolaProfile));
        }).CreateMapper();

        public IEnumerable<Bimestre> RetornaTodos() 
        {
            var bimestres = db.Bimestres.Where(p => p.Ativo.Equals(1)).ToList();
            var listaBimestres = mapper.Map<IEnumerable<Entidades.Bimestre>, IEnumerable<Bimestre>>(bimestres);

            return listaBimestres;
        }

        public Bimestre RetornaPorId(int? id)
        {
            var bimestre = db.Bimestres.Find(id);
            var bimestres = mapper.Map<Entidades.Bimestre, Bimestre>(bimestre);

            return bimestres;
        }

        public void Create(Bimestre bimestre) 
        {
            var bimestres = mapper.Map<Bimestre, Entidades.Bimestre>(bimestre);
            db.Bimestres.Add(bimestres);
            db.SaveChanges();
        }

        public void Edit(Bimestre bimestre)
        {
            var bimestres = mapper.Map<Bimestre, Entidades.Bimestre>(bimestre);
            db.Entry(bimestres).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
