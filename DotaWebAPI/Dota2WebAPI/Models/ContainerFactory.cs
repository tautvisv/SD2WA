using System;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Integration.Mvc;
using DataRepo;
using DataRepositories;
using DataRepositories.Repositories;
using Dota2WebAPI.Commands;
using ICommand = ServiceStack.Commands.ICommand;

namespace Dota2WebAPI.Models
{
    public class ContainerFactory
    {
        public static IContainer Initialize(params Assembly[] webAssemblies)
        {
            var factory = new ContainerFactory();

            return factory.CreateContainer(webAssemblies);
        }

        public IContainer CreateContainer(params Assembly[] webAssemblies)
        {
            var builder = new ContainerBuilder();

            if (webAssemblies != null)
            {
                foreach (var webAssembly in webAssemblies)
                {
                    builder.RegisterControllers(webAssembly).InstancePerDependency().PropertiesAutowired();
                }
            }

            // Singletons
            // builder.RegisterType<ConfigurationLoaderService>().As<IConfigurationLoaderService>().SingleInstance();
            builder.RegisterType<Dota2DbContext>().SingleInstance();

            // Per request
            // builder.RegisterType<Repository>().As<IRepository>().InstancePerRequest();
            builder.RegisterType<HeroesRepository>().As<IHeroRepository>().InstancePerRequest();
            builder.RegisterType<TestCommand>().As<Dota2WebAPI.Commands.ICommand>().InstancePerRequest();

            RegisterCommands(GetType().Assembly, builder);

            return builder.Build();
        }

        /// <summary>
        /// Registers the module command types.
        /// </summary>
        private void RegisterCommands(Assembly assembly, ContainerBuilder containerBuilder)
        {
            var commandTypes = new[]
                {
                    typeof(ICommand)
                };

            containerBuilder
                .RegisterAssemblyTypes(assembly)
                .Where(scan => commandTypes.Any(commandType => IsAssignableToGenericType(scan, commandType)))
                .AsImplementedInterfaces()
                .AsSelf()
                .PropertiesAutowired()
                .InstancePerHttpRequest();
        }

        /// <summary>
        /// Determines whether given type is assignable to generic type.
        /// </summary>
        /// <param name="givenType">A given type.</param>
        /// <param name="genericType">A generic type.</param>
        /// <returns>
        ///   <c>true</c> if given type is assignable to generic type; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsAssignableToGenericType(Type givenType, Type genericType)
        {
            if (genericType.IsAssignableFrom(givenType))
            {
                return true;
            }

            var interfaceTypes = givenType.GetInterfaces();

            if (interfaceTypes.Any(it => it.IsGenericType && it.GetGenericTypeDefinition() == genericType))
            {
                return true;
            }

            Type baseType = givenType.BaseType;
            if (baseType == null)
            {
                return false;
            }

            return (baseType.IsGenericType && baseType.GetGenericTypeDefinition() == genericType) || IsAssignableToGenericType(baseType, genericType);
        }
    }
}