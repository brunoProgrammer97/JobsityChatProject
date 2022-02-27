using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace JobsityChatProject.IoC
{
    public class TypesHandler
    {
        public static IEnumerable<Type> GetRepositoryInterfaces()
        {
            return Assembly.Load("JobsityChatProject.Core").GetTypes().Where(
                type => type.IsInterface
                && type.Namespace != null
                && type.Namespace.StartsWith("JobsityChatProject.Core.RepositoryInterfaces"));
        }

        public static IEnumerable<Type> GetRepositories()
        {
            return Assembly.Load("JobsityChatProject.Infrastructure").GetTypes().Where(
                type => type.IsClass
                && !type.IsAbstract
                && type.Namespace != null
                && type.Namespace.StartsWith("JobsityChatProject.Infrastructure.Repository")
                && type.GetCustomAttribute<CompilerGeneratedAttribute>() == null);
        }

        public static IEnumerable<Type> GetServicesInterfaces()
        {
            return Assembly.Load("JobsityChatProject.Core").GetTypes().Where(
                type => type.IsInterface
                && type.Namespace != null
                && type.Namespace.StartsWith("JobsityChatProject.Core.ServicesInterfaces"));
        }

        public static IEnumerable<Type> GetServices()
        {
            return Assembly.Load("JobsityChatProject.Core").GetTypes().Where(
                type => type.IsClass
                && !type.IsAbstract
                && type.Namespace != null
                && type.Namespace.StartsWith("JobsityChatProject.Core.Services")
                && type.GetCustomAttribute<CompilerGeneratedAttribute>() == null);
        }

        public static Type FindType(Type @interface, IEnumerable<Type> types)
        {
            foreach (var type in types)
            {
                if (type.GetInterfaces().Contains(@interface))
                {
                    return type;
                }
            }

            return null;
        }
    }
}
