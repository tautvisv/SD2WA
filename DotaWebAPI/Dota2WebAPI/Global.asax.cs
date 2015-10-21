using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Autofac.Integration.Mvc;
using DataRepo;
using DataRepositories.Repositories;
using Dota2WebAPI.Controllers;
using Dota2WebAPI.Models;
using Microsoft.Practices.Unity;
using Unity.WebApi;

namespace Dota2WebAPI
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            //var container = ContainerFactory.Initialize(GetType().Assembly);
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            //BuildUnityContainer(@"name=DotaConnectionString");

            UnityConfig.RegisterComponents();


        }
        //public static IUnityContainer BuildUnityContainer(string connectionString)
        //{
        //    var container = new UnityContainer();
        //    container.RegisterType<IUnitOfWork, Dota2DbContext>(new HierarchicalLifetimeManager(),
        //        new InjectionConstructor(connectionString));
        //    //container.RegisterType(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        //    //container.RegisterType<IMovieService, MovieService>();
        //    container.RegisterType<IHeroRepository, HeroesRepository>();
        //    return container;
        //}
    }

    //public static class Bootstrapper
    //{
    //    public static IUnityContainer InitialiseBADDDDDDDDDDDDDDDDDDD()
    //    {
    //        var container = BuildUnityContainer();
    //        DependencyResolver.SetResolver(new UnityDependencyResolver(container));
    //        return container;
    //    }
    //    private static IUnityContainer BuildUnityContainer()
    //    {
    //        var container = new UnityContainer();
    //        RegisterTypes(container);
    //        return container;
    //    }
    //    public static void RegisterTypes(IUnityContainer container)
    //    {
    //        container.RegisterType<IUnitOfWork, Dota2DbContext>(new HierarchicalLifetimeManager(),
    //            new InjectionConstructor(@"name=DotaConnectionString"));
    //        container.RegisterType<IHeroRepository, HeroesRepository>();
    //    }
    //}
}
