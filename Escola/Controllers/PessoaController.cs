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
    public class PessoaController : Controller
    {
        private EscolaDataContext db = new EscolaDataContext();
        
        IMapper mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddMaps(typeof(Escola.Mappers.EscolaProfile));
        }).CreateMapper();

        private readonly IPessoaRepositorio _pessoaRepositorio;

        public PessoaController(IPessoaRepositorio pessoaRepositorio)
        {
            _pessoaRepositorio = pessoaRepositorio;
        }

        public ActionResult Index()
        {
            return View(_pessoaRepositorio.RetornaTodos());
        }

        public ActionResult Create()
        {
            Pessoa pessoa = new Pessoa();
            pessoa.Ativo = 1;
            return View(pessoa);
        }

        [HttpPost]
        public ActionResult Create(Pessoa pessoa)
        {
            _pessoaRepositorio.Create(pessoa);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            return View(_pessoaRepositorio.RetornaPorId(id));
        }

        [HttpPost]
        public ActionResult Edit(Pessoa pessoa)
        {
            _pessoaRepositorio.Edit(pessoa);
            return RedirectToAction("Index");
        }

        public ActionResult Buscar()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Buscar(BuscaPessoaViewModel pessoa)
        {
            BuscaPessoaViewModel retorno = new BuscaPessoaViewModel();               

            if (pessoa.Nome != null) {
               retorno.ListaPessoas = _pessoaRepositorio.BuscarPorNome(pessoa.Nome).ToList(); 
            }

            if (pessoa.Cpf != null) 
            {
                retorno.ListaPessoas = _pessoaRepositorio.BuscarPorCpf(pessoa.Cpf).ToList();
            }

            if (pessoa.RG != null) 
            {
                retorno.ListaPessoas = _pessoaRepositorio.BuscarPorRG(pessoa.RG).ToList();
            }

            return View(retorno);
        }

        public ActionResult Listar(List<Pessoa> pessoa) 
        {
            return View();
        }
    }
}