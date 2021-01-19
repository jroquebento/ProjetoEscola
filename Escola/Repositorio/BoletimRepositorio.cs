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
    public class BoletimRepositorio : IBoletimRepositorio
    {
        private EscolaDataContext db = new EscolaDataContext();

        IMapper mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddMaps(typeof(Escola.Mappers.EscolaProfile));
        }).CreateMapper();

        public IEnumerable<Boletim> RetornaTodos() 
        {
            var boletim = db.Boletins.Where(p => p.Ativo.Equals(1)).ToList();
            var listaBoletins = mapper.Map<IEnumerable<Entidades.Boletim>, IEnumerable<Boletim>>(boletim);
            return listaBoletins;
        }

        public IEnumerable<Aluno> RetornaAlunos()
        {
            var listaAlunos = db.Alunos.Where(p => p.Ativo.Equals(1)).ToList();
            return mapper.Map<IEnumerable<Entidades.Aluno>,IEnumerable<Aluno>>(listaAlunos);
        }

        public List<Tuple<int, string>> RetornaProfDisciplinas() 
        {
            var professorDisciplina = db.ProfessorDisciplinas.Where(p => p.Ativo.Equals(1)).ToList();
            var listaProfessorDisciplina =
                mapper.Map<IEnumerable<Entidades.ProfessorDisciplina>,
                IEnumerable<ProfessorDisciplina>>(professorDisciplina);

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
            return mapper.Map<IEnumerable<Entidades.Bimestre>,IEnumerable<Bimestre>>(listaBimestres);
        }

        public void Create(Boletim boletim) 
        {
            var aluno = db.Alunos.Find(boletim.Aluno.Id);
            var bimestre = db.Bimestres.Find(boletim.Bimestre.Id);

            var professorDisciplina =
                db.ProfessorDisciplinas.Find(boletim.ProfessorDisciplina.Id);

            var boletins = mapper.Map<Boletim, Entidades.Boletim>(boletim);

            if (aluno != null)
            {
                boletins.Aluno = aluno;
            }

            if (bimestre != null)
            {
                boletins.Bimestre = bimestre;
            }

            if (professorDisciplina != null)
            {
                boletins.ProfessorDisciplina = professorDisciplina;
            }

            db.Boletins.Add(boletins);
            db.SaveChanges();
        }

        public List<Tuple<int, string>> RetornaAnos() 
        {
            var listaAno = new List<Tuple<int, string>>();
            listaAno.Add(Tuple.Create(2020, "2020"));
            listaAno.Add(Tuple.Create(2021, "2021"));
            return listaAno;
        }

        public IEnumerable<Nota> RetornaBoletim(GerarBoletimViewModel nota) 
        {
            //Fazer busca no entity
            var notas = db.Notas.Where(p => p.Aluno.Id.Equals(nota.Aluno_Id)
                                      && p.ProfessorDisciplina.Id.Equals(nota.ProfessorDisciplina_Id)
                                      && p.Bimestre.Id.Equals(nota.Bimestre_Id) && p.Ativo.Equals(1)
                                      ).ToList();
            var listaNotas = mapper.Map<IEnumerable<Entidades.Nota>, IEnumerable<Nota>>(notas);

            return listaNotas;
        }

        public void Create(List<Nota> listaNota) 
        {
            if (listaNota.Count() > 0)
            {
                var aluno = db.Alunos.Find(listaNota[0].Aluno.Id);
                var bimestre = db.Bimestres.Find(listaNota[0].Bimestre.Id);

                var professorDisciplina =
                    db.ProfessorDisciplinas.Find(listaNota[0].ProfessorDisciplina.Id);

                var boletins = mapper.Map<Boletim, Entidades.Boletim>(new Boletim());

                if (aluno != null)
                {
                    boletins.Aluno = aluno;
                }

                if (bimestre != null)
                {
                    boletins.Bimestre = bimestre;
                }

                if (professorDisciplina != null)
                {
                    boletins.ProfessorDisciplina = professorDisciplina;
                }

                boletins.Nota = listaNota.Sum(p => p.Valor) / listaNota.Count();

                boletins.Ano = listaNota[0].Ano;

                boletins.Ativo = 1;

                int bimestres = listaNota[0].Bimestre.Id;
                int alunos = listaNota[0].Aluno.Id;
                int anos = listaNota[0].Ano;
                int professorDisciplinas = listaNota[0].ProfessorDisciplina.Id;

                var boletim = db.Boletins.Where(p => p.Bimestre.Id == bimestres &&
                p.Aluno.Id == alunos &&
                p.Ano == anos &&
                p.ProfessorDisciplina.Id == professorDisciplinas &&
                p.Ativo.Equals(1)).FirstOrDefault();

                if (boletim != null)
                {
                    boletim.Ativo = 0;
                    db.Entry(boletim).State = EntityState.Modified;
                    db.SaveChanges();
                }

                db.Boletins.Add(boletins);
                db.SaveChanges();
            }
        }
    }
}
