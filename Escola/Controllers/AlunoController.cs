using AutoMapper;
using Escola.Data;
using Escola.Mappers;
using Escola.Models;
using Escola.Repositorio;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Escola.Controllers
{
    public class AlunoController : Controller
    {
        private EscolaDataContext db = new EscolaDataContext();

        //Inicialização das classes que forem precisar
        IMapper mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddMaps(typeof(Escola.Mappers.EscolaProfile));
        }).CreateMapper();

        private readonly IAlunoRepositorio _alunoRepositorio;

        public AlunoController(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }

        public ActionResult Index()
        {
            return View(_alunoRepositorio.RetornaTodos());
        }

        public ActionResult Create()
        {
            Aluno aluno = new Aluno();
            aluno.ListaPessoas = _alunoRepositorio.RetornaPessoas();
            aluno.Ativo = 1;
            return View(aluno);
        }

        [HttpPost]
        public ActionResult Create(Aluno aluno)
        {
            _alunoRepositorio.Create(aluno);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            Aluno aluno = _alunoRepositorio.RetornaPorId(id);
            aluno.ListaPessoas = _alunoRepositorio.RetornaPessoas();
            return View(aluno);
        }

        [HttpPost]
        public ActionResult Edit(Aluno aluno)
        {
            _alunoRepositorio.Edit(aluno);
            return RedirectToAction("Index");
        }

        public ActionResult Buscar() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Buscar(BuscaAlunoViewModel aluno)
        {
            BuscaAlunoViewModel retorno = new BuscaAlunoViewModel();

            if (aluno.Nome != null)
            {
                retorno.ListaAlunos = _alunoRepositorio.BuscaPorNome(aluno.Nome).ToList();
            }
            if (aluno.CPF != null) 
            {
                retorno.ListaAlunos = _alunoRepositorio.BuscarPorCPF(aluno.CPF).ToList();
            }
            if (aluno.Curso != null)
            {
                retorno.ListaAlunos = _alunoRepositorio.BuscarPorCurso(aluno.Curso).ToList();
            }

            return View(retorno);
        }
        public ActionResult Listar(List<Aluno> aluno)
        {
            return View();
        }
    }
}