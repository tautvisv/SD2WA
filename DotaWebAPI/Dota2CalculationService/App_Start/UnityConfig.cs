using Microsoft.Practices.Unity;
using System.Web.Http;
using CalculationServices.Services;
using CalculationServicesInterfaces;
using Dota2CalculationService.Controllers;
using Unity.WebApi;
using Validation;

namespace Dota2CalculationService
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IStatisticsCalculationService, StatisticsCalculationService>(new ExternallyControlledLifetimeManager());
            container.RegisterType<IKeyValidation, KeyValidation>(new ExternallyControlledLifetimeManager());
            container.RegisterType<CalculationController>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}