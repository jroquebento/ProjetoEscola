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
    public class ProfessorDisciplinaRepositorio : IProfessorDisciplinaRepositorio
    {
        private EscolaDataContext db = new EscolaDataContext();

        IMapper mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddMaps(typeof(Escola.Mappers.EscolaProfile));
        }).CreateMapper();
        public IEnumerable<ProfessorDisciplina> RetornaTodos() 
        {
            var professorDisciplina = db.ProfessorDisciplinas.Where(p => p.Ativo.Equals(1)).ToList();
            var professorDisciplinas = mapper.Map<IEnumerable<Entidades.ProfessorDisciplina>, IEnumerable<ProfessorDisciplina>>(professorDisciplina);
            return professorDisciplinas;
        }

        public IEnumerable<Professor> RetornaProfessores() 
        {
            var listaProfessores = db.Professores.Where(p => p.Ativo.Equals(1)).ToList();
            return mapper.Map<IEnumerable<Entidades.Professor>, IEnumerable<Professor>>(listaProfessores);
        }

        public IEnumerable<Disciplina> RetornaDisciplinas() 
        {
            var listaDisciplinas = db.Disciplinas.Where(p => p.Ativo.Equals(1)).ToList();
            return mapper.Map<IEnumerable<Entidades.Disciplina>, IEnumerable<Disciplina>>(listaDisciplinas);
        }

        public void Create(ProfessorDisciplina professorDisciplina) 
        {
            Entidades.Disciplina disciplina = db.Disciplinas.Find(professorDisciplina.Disciplina.Id);
            Entidades.Professor professor = db.Professores.Find(professorDisciplina.Professor.Id);

            var professorDisciplinas = mapper.Map<ProfessorDisciplina, Entidades.ProfessorDisciplina>(professorDisciplina);

            if (disciplina != null)
            {
                professorDisciplinas.Disciplina = disciplina;
            }

            if (professor != null)
            {
                professorDisciplinas.Professor = professor;
            }

            db.ProfessorDisciplinas.Add(professorDisciplinas); ;
            db.SaveChanges();
        }

        public ProfessorDisciplina RetornaPorId(int? id) 
        {
            var professorDisciplina = db.ProfessorDisciplinas.Find(id);
            var professorDisciplinas = mapper.Map<Entidades.ProfessorDisciplina, ProfessorDisciplina>(professorDisciplina);
            return professorDisciplinas;
        }

        public void Edit(ProfessorDisciplina professorDisciplina)
        {
            Entidades.Professor professor = db.Professores.Find(professorDisciplina.Professor.Id);
            Entidades.Disciplina disciplina = db.Disciplinas.Find(professorDisciplina.Disciplina.Id);
            var professorDisciplinas = mapper.Map<ProfessorDisciplina, Entidades.ProfessorDisciplina>(professorDisciplina);

            if (professor != null)
            {
                professorDisciplinas.Professor = professor;
            }

            if (disciplina != null)
            {
                professorDisciplinas.Disciplina = disciplina;
            }

            db.Entry(professorDisciplinas).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
