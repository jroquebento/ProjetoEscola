using AutoMapper;
using Escola.Data;
using Escola.Models;
using Escola.Repositorio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Escola.Controllers
{
    public class NotaController : Controller
    {
        private EscolaDataContext db = new EscolaDataContext();

        IMapper mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddMaps(typeof(Escola.Mappers.EscolaProfile));
        }).CreateMapper();

        private readonly INotaRepositorio _notaRepositorio;
        public NotaController(INotaRepositorio notaRepositorio)
        {
            _notaRepositorio = notaRepositorio;
        }

        public ActionResult Index() 
        {
            IEnumerable<Nota> nota = _notaRepositorio.RetornaTodos().OrderBy(p => p.Aluno.Pessoa.Nome);
            foreach (var item in nota)
            {
                item.ListaAlunos = _notaRepositorio.RetornaAlunos();
                item.ListaProfessorDisciplinas = _notaRepositorio.RetornaProfDisciplinas();
                item.ListaBimestres = _notaRepositorio.RetornaBimestres();
            } 
            return View(nota);
        }

        public ActionResult Create()
        {
            Nota nota = new Nota();
            nota.ListaAlunos = _notaRepositorio.RetornaAlunos();
            nota.ListaProfessorDisciplinas = _notaRepositorio.RetornaProfDisciplinas();
            nota.ListaBimestres = _notaRepositorio.RetornaBimestres();
            nota.ListaAnos = _notaRepositorio.RetornaAno();
            nota.Ativo = 1;
            return View(nota);
        }

        [HttpPost]
        public ActionResult Create(Nota nota)
        {
            _notaRepositorio.Create(nota);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            Nota nota = _notaRepositorio.RetornaPorId(id);
            nota.ListaAlunos = _notaRepositorio.RetornaAlunos();
            nota.ListaProfessorDisciplinas = _notaRepositorio.RetornaProfDisciplinas();
            nota.ListaBimestres = _notaRepositorio.RetornaBimestres();
            nota.ListaAnos = _notaRepositorio.RetornaAno();
            return View(nota);
        }

        [HttpPost]
        public ActionResult Edit(Nota nota)
        {
            _notaRepositorio.Edit(nota);
            return RedirectToAction("Index");
        }
    }
}
