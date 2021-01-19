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
    public class DisciplinaController : Controller
    {
        private EscolaDataContext db = new EscolaDataContext();

        IMapper mapper = new MapperConfiguration(cfg =>
       {
           cfg.AddMaps(typeof(Escola.Mappers.EscolaProfile));
       }).CreateMapper();

        private readonly IDisciplinaRepositorio _disciplinaRepositorio;

        public DisciplinaController(IDisciplinaRepositorio disciplinaRepositorio)
        {
            _disciplinaRepositorio = disciplinaRepositorio;
        }

        public ActionResult Index()
        {
            return View(_disciplinaRepositorio.RetornaTodos());
        }

        public ActionResult Create()
        {
            Disciplina disciplina = new Disciplina();
            disciplina.Ativo = 1;
            return View(disciplina);
        }

        [HttpPost]
        public ActionResult Create(Disciplina disciplina)
        {
            _disciplinaRepositorio.Create(disciplina);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            return View(_disciplinaRepositorio.RetornaPorId(id));
        }

        [HttpPost]
        public ActionResult Edit(Disciplina disciplina)
        {
            _disciplinaRepositorio.Edit(disciplina);
            return RedirectToAction("Index");
        }
    }
}