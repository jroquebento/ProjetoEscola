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
using System.Windows.Documents;

namespace Escola.Controllers
{
    public class BoletimController : Controller
    {
        private EscolaDataContext db = new EscolaDataContext();

        IMapper mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddMaps(typeof(Escola.Mappers.EscolaProfile));
        }).CreateMapper();

        private readonly IBoletimRepositorio _boletimRepositorio;
        public BoletimController(IBoletimRepositorio boletimRepositorio)
        {
            _boletimRepositorio = boletimRepositorio;
        }

        public ActionResult Index()
        {
            return View(_boletimRepositorio.RetornaTodos());
        }

        public ActionResult GerarBoletim()
        {
            GerarBoletimViewModel gerarBoletim = new GerarBoletimViewModel();

            gerarBoletim.ListaAlunos = _boletimRepositorio.RetornaAlunos();
            gerarBoletim.ListaProfessorDisciplinas = _boletimRepositorio.RetornaProfDisciplinas();
            gerarBoletim.ListaBimestres = _boletimRepositorio.RetornaBimestres();
            gerarBoletim.ListaAnos = _boletimRepositorio.RetornaAnos();

            return View(gerarBoletim);
        }

        [HttpPost]
        public ActionResult GerarBoletim(GerarBoletimViewModel gerarBoletim)
        {          
            IEnumerable<Nota> listaNotas = _boletimRepositorio.RetornaBoletim(gerarBoletim);

            gerarBoletim.ListaAlunos = _boletimRepositorio.RetornaAlunos();
            gerarBoletim.ListaProfessorDisciplinas = _boletimRepositorio.RetornaProfDisciplinas();
            gerarBoletim.ListaBimestres = _boletimRepositorio.RetornaBimestres();
            gerarBoletim.ListaAnos = _boletimRepositorio.RetornaAnos();

            gerarBoletim.ListaNotas = listaNotas.ToList();

            return View(gerarBoletim);            
        }

        [HttpPost]
        public ActionResult GravarBoletim(List<Nota> listaNota)
        {
            _boletimRepositorio.Create(listaNota);
            return RedirectToAction("Index");
        }
    }
}