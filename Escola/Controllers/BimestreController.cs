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
    public class BimestreController : Controller
    {
        private EscolaDataContext db = new EscolaDataContext();

        IMapper mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddMaps(typeof(Escola.Mappers.EscolaProfile));
        }).CreateMapper();

        private readonly IBimestreRepositorio _bimestreRepositorio;

        public BimestreController(IBimestreRepositorio bimestreRepositorio)
        {
            _bimestreRepositorio = bimestreRepositorio;
        }

        public ActionResult Index()
        {
            return View(_bimestreRepositorio.RetornaTodos());
        }

        public ActionResult Create()
        {
            Bimestre bimestre = new Bimestre();
            bimestre.Ativo = 1;
            return View(bimestre);
        }

        [HttpPost]
        public ActionResult Create(Bimestre bimestre)
        {
            _bimestreRepositorio.Create(bimestre);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            return View(_bimestreRepositorio.RetornaPorId(id));
        }

        [HttpPost]
        public ActionResult Edit(Bimestre bimestre)
        {
            _bimestreRepositorio.Edit(bimestre);
            return RedirectToAction("Index");
        }
    }
}