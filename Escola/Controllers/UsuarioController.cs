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
    public class UsuarioController : Controller
    {
        private EscolaDataContext db = new EscolaDataContext();

        IMapper mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddMaps(typeof(Escola.Mappers.EscolaProfile));
        }).CreateMapper();

        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public ActionResult Index()
        {
            return View(_usuarioRepositorio.RetornaTodos());
        }

        public ActionResult Create()
        {
            Usuario usuario = new Usuario();
            usuario.ListaPessoas = _usuarioRepositorio.RetornaPessoas();
            usuario.Ativo = 1;            
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            _usuarioRepositorio.Create(usuario);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            Usuario usuario = _usuarioRepositorio.RetornaPorId(id);
            usuario.ListaPessoas = _usuarioRepositorio.RetornaPessoas();            
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Edit(Usuario usuario)
        {
            _usuarioRepositorio.Edit(usuario);
            return RedirectToAction("Index");
        }
    }
}