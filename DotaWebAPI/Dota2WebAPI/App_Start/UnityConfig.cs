using System.Data.Entity;
using System.Web.Http;
using DatabaseEntities.Entities;
using DataRepo;
using DataRepositories;
using DataRepositories.Repositories;
using DataServices;
using DataServices.Services;
using Dota2WebAPI.Controllers;
using Microsoft.Practices.Unity;
using Unity.WebApi;

namespace Dota2WebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            //container.RegisterType<IUnitOfWork, Dota2DbContext>(new HierarchicalLifetimeManager(),
             //  new InjectionConstructor(@"name=DotaConnectionString"));
            //@"name=DotaConnectionString"
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<DbContext, Dota2DbContext>(new HierarchicalLifetimeManager(), new InjectionConstructor());
            container.RegisterType<IGenericRepository<Hero>, HeroesRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IHeroesService, HeroesService>(new HierarchicalLifetimeManager());
            container.RegisterType<DotaController>(new HierarchicalLifetimeManager());
           // container.RegisterType<DotaController>(new InjectionConstructor());
            //container.RegisterType<IHeroRepository, HeroesRepository>();
            //GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

        }
    }
}