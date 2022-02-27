using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsityChatProject.IoC
{
    public static class DependencyResolver
    {
        public static void ResolveRepositoryScopedDependencies(this IServiceCollection services)
        {
            RegisterRepositories(services);
        }

        public static void ResolveServicesScopedDependencies(this IServiceCollection services)
        {
            RegisterServices(services);
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            var applicationInterfaces = TypesHandler.GetRepositoryInterfaces();
            var applicationClasses = TypesHandler.GetRepositories();

            foreach (var @interface in applicationInterfaces)
            {
                var type = TypesHandler.FindType(@interface, applicationClasses);

                if (type != null)
                    services.AddScoped(@interface, type);
            }
        }

        private static void RegisterServices(IServiceCollection services)
        {
            var applicationInterfaces = TypesHandler.GetServicesInterfaces();
            var applicationClasses = TypesHandler.GetServices();

            foreach (var @interface in applicationInterfaces)
            {
                var type = TypesHandler.FindType(@interface, applicationClasses);

                if (type != null)
                    services.AddScoped(@interface, type);
            }
        }
    }
}
