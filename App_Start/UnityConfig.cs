using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using RepositoryPattern.Models.CoreLayer;
using RepositoryPattern.Models.PersistenceLayer;
using RepositoryPattern.Controllers;
using Unity.Injection;

namespace RepositoryPattern
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            //container.RegisterType<StudentsController>(new InjectionConstructor());
            container.RegisterType<IStudentRepository, StudentRepository>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}