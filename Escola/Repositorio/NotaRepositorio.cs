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
    public class NotaRepositorio : INotaRepositorio
    {
        private EscolaDataContext db = new EscolaDataContext();

        IMapper mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddMaps(typeof(Escola.Mappers.EscolaProfile));
        }).CreateMapper();

        public IEnumerable<Nota> RetornaTodos() 
        {
            var nota = db.Notas.Where(p => p.Ativo.Equals(1)).ToList();
            var listaNotas = mapper.Map<IEnumerable<Entidades.Nota>, IEnumerable<Nota>>(nota);
            return listaNotas;
        }

        public IEnumerable<Aluno> RetornaAlunos()
        {
            var listaAlunos = db.Alunos.Where(p => p.Ativo.Equals(1)).ToList();
            return mapper.Map<IEnumerable<Entidades.Aluno>,IEnumerable<Aluno>>(listaAlunos);
        }

        public List<Tuple<int,string>> RetornaProfDisciplinas()
        {
            var professorDisciplina = db.ProfessorDisciplinas.Where(p => p.Ativo.Equals(1)).ToList();
            var listaProfessorDisciplina = mapper.Map<IEnumerable<Entidades.ProfessorDisciplina>, IEnumerable<ProfessorDisciplina>>(professorDisciplina);

            var listaNomeDisciplina = new List<Tuple<int, string>>();

            foreach (var item in listaProfessorDisciplina)
            {
                listaNomeDisciplina.Add(Tuple.Create(item.Id, item.Professor.Pessoa.Nome + "-" + item.Disciplina.Nome));
            }
            return listaNomeDisciplina;
        }

        public IEnumerable<Bimestre> RetornaBimestres() 
        {
            var listaBimestres = db.Bimestres.Where(p => p.Ativo.Equals(1)).ToList();
            return mapper.Map<IEnumerable<Entidades.Bimestre>, IEnumerable<Bimestre>>(listaBimestres);
        }

        public List<Tuple<int, string>> RetornaAno() 
        {
            var listaAno = new List<Tuple<int, string>>();
            listaAno.Add(Tuple.Create(2020, "2020"));
            listaAno.Add(Tuple.Create(2021, "2021"));
            return listaAno;
        }

        public void Create(Nota nota) 
        {
            var aluno = db.Alunos.Find(nota.Aluno.Id);
            var bimestre = db.Bimestres.Find(nota.Bimestre.Id);

            var professorDisciplina =
                db.ProfessorDisciplinas.Find(nota.ProfessorDisciplina.Id);

            var notas = mapper.Map<Nota, Entidades.Nota>(nota);

            if (aluno != null)
            {
                notas.Aluno = aluno;
            }

            if (bimestre != null)
            {
                notas.Bimestre = bimestre;
            }

            if (professorDisciplina != null)
            {
                notas.ProfessorDisciplina = professorDisciplina;
            }

            db.Notas.Add(notas);
            db.SaveChanges();
        }

        public Nota RetornaPorId(int? id) 
        {
            var nota = db.Notas.Find(id);
            var listaNotas = mapper.Map<Entidades.Nota, Nota>(nota);
            return listaNotas;
        }

        public void Edit(Nota nota)
        {
            Entidades.Aluno aluno =
                db.Alunos.Find(nota.Aluno.Id);

            Entidades.ProfessorDisciplina professorDisciplina =
                db.ProfessorDisciplinas.Find(nota.ProfessorDisciplina.Id);

            Entidades.Bimestre bimestre =
               db.Bimestres.Find(nota.Bimestre.Id);

            var notas
                = mapper.Map<Nota, Entidades.Nota>(nota);

            if (aluno != null)
            {
                notas.Aluno = aluno;
            }

            if (bimestre != null)
            {
                notas.Bimestre = bimestre;
            }

            if (professorDisciplina != null)
            {
                notas.ProfessorDisciplina = professorDisciplina;
            }

            db.Entry(notas).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
