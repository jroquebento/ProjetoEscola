using AutoMapper;
using Escola.Data;
using Escola.Models;
using Escola.Repositorio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Escola.Controllers
{
    public class ProfessorDisciplinaController : Controller
    {
        private EscolaDataContext db = new EscolaDataContext();

        IMapper mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddMaps(typeof(Escola.Mappers.EscolaProfile));
        }).CreateMapper();

        private readonly IProfessorDisciplinaRepositorio _professorDisciplinaRepositorio;

        public ProfessorDisciplinaController(IProfessorDisciplinaRepositorio professorDisciplinaRepositorio)
        {
            _professorDisciplinaRepositorio = professorDisciplinaRepositorio;
        }

        public ActionResult Index()
        {
            return View(_professorDisciplinaRepositorio.RetornaTodos());
        }

        public ActionResult Create()
        {
            ProfessorDisciplina professorDisciplina = new ProfessorDisciplina();
            professorDisciplina.ListaProfessores = _professorDisciplinaRepositorio.RetornaProfessores();
            professorDisciplina.ListaDisciplinas = _professorDisciplinaRepositorio.RetornaDisciplinas();
            professorDisciplina.Ativo = 1;
            return View(professorDisciplina);
        }

        [HttpPost]
        public ActionResult Create(ProfessorDisciplina professorDisciplina)
        {
            _professorDisciplinaRepositorio.Create(professorDisciplina);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            ProfessorDisciplina professorDisciplina = _professorDisciplinaRepositorio.RetornaPorId(id);
            professorDisciplina.ListaProfessores = _professorDisciplinaRepositorio.RetornaProfessores();
            professorDisciplina.ListaDisciplinas = _professorDisciplinaRepositorio.RetornaDisciplinas();     
            return View(professorDisciplina);
        }

        [HttpPost]
        public ActionResult Edit(ProfessorDisciplina professorDisciplina)
        {
            _professorDisciplinaRepositorio.Edit(professorDisciplina);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            //ProfessorDisciplina professorDisciplina = db.ProfessorDisciplinas.Find(id);
            //ViewBag.ListaProfessores = db.Professores.ToList();
            //ViewBag.ListaDisciplinas = db.Disciplinas.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            //ProfessorDisciplina professorDisciplina = db.ProfessorDisciplinas.Find(id);
            //db.ProfessorDisciplinas.Remove(professorDisciplina);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}