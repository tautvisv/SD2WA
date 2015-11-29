using System.Data.Entity;
using System.Runtime.Remoting.Messaging;
using System.Web.Http;
using CustomCalculationServiceConnectionLib;
using DataAPIRepositories.Repositories;
using DataCache;
using DataMockServices.Services;
using DataRepositories;
using DataRepositories.Repositories;
using DataRepositoriesInterfaces;
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
            //container.RegisterType<IUnitOfWork, Dota2DbContext>(/*new HierarchicalLifetimeManager()*/,
             //  new InjectionConstructor(@"name=DotaConnectionString"));
            //@"name=DotaConnectionString"
            container.RegisterInstance<ICacheSingleton>(CacheSingleton.Instance, new ExternallyControlledLifetimeManager());//<CacheSingleton>(new ExternallyControlledLifetimeManager(()=> return ; ));
            container.RegisterType<ITaskRepository, TaskRepository>(new PerThreadLifetimeManager());
            container.RegisterType<IRegister, TaskRegister>(new PerThreadLifetimeManager());
            container.RegisterType<DbContext, Dota2DbContext>(new PerThreadLifetimeManager(), new InjectionConstructor());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new PerThreadLifetimeManager());
            container.RegisterType<IServiceConnection, CustomCalculationServiceConnection>(new PerThreadLifetimeManager());
            container.RegisterType<IBridgeDotaCalculation, DotaCalculationBridge>(new PerThreadLifetimeManager());
            container.RegisterType<IHeroRepository, HeroesRepository>(new PerThreadLifetimeManager());
            container.RegisterType<IItemRepository, ItemRepository>(new PerThreadLifetimeManager());
            container.RegisterType<IMatchRepository, MatchRepository>(new PerThreadLifetimeManager());
            container.RegisterType<ISteamRepository, SteamRepository>(new PerThreadLifetimeManager());
            container.RegisterType<IStatisticsService, StatisticsService>(new PerResolveLifetimeManager());
            container.RegisterType<IMiscService, MiscService>(new PerResolveLifetimeManager());
            container.RegisterType<DotaController>();
            container.RegisterType<MiscController>();
           // container.RegisterType<DotaController>(new InjectionConstructor());
            //container.RegisterType<IHeroRepository, HeroesRepository>();
            //GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

        }
    }
}