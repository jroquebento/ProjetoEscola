using AutoMapper;
using Escola.Data;
using Escola.Models;
using Escola.Repositorio;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Escola.Controllers
{
    public class ProfessorController : Controller
    {
        private EscolaDataContext db = new EscolaDataContext();

        IMapper mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddMaps(typeof(Escola.Mappers.EscolaProfile));
        }).CreateMapper();

        private readonly IProfessorRepositorio _professorRepositorio;

        public ProfessorController(IProfessorRepositorio professorRepositorio)
        {
            _professorRepositorio = professorRepositorio;
        }

        public ActionResult Index()
        {
            return View(_professorRepositorio.RetornaTodos());
        }

        public ActionResult Create()
        {
            Professor professor = new Professor();
            professor.ListaPessoas = _professorRepositorio.RetornaPessoas();
            professor.Ativo = 1;
            return View(professor);
        }

        [HttpPost]
        public ActionResult Create(Professor professor)
        {
            _professorRepositorio.Create(professor);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            Professor professor = _professorRepositorio.RetornaPorId(id);
            professor.ListaPessoas = _professorRepositorio.RetornaPessoas();
            return View(professor);
        }

        [HttpPost]
        public ActionResult Edit(Professor professor)
        {
            _professorRepositorio.Edit(professor);
            return RedirectToAction("Index");
        }
    }
}