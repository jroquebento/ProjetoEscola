using Escola.Repositorio;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Escola
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            container.RegisterType<IAlunoRepositorio, AlunoRepositorio>();
            container.RegisterType<IProfessorRepositorio, ProfessorRepositorio>();
            container.RegisterType<IPessoaRepositorio, PessoaRepositorio>();
            container.RegisterType<IBimestreRepositorio, BimestreRepositorio>();
            container.RegisterType<IDisciplinaRepositorio, DisciplinaRepositorio>();
            container.RegisterType<IProfessorDisciplinaRepositorio, ProfessorDisciplinaRepositorio>();
            container.RegisterType<INotaRepositorio, NotaRepositorio>();
            container.RegisterType<IBoletimRepositorio, BoletimRepositorio>();
            container.RegisterType<IUsuarioRepositorio, UsuarioRepositorio>();
        }
    }
}