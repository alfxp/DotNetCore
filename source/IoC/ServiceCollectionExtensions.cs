using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using System.Reflection;

namespace DotNetCore.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static void AddClassesMatchingInterfaces(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.Scan(scan => scan
                .FromAssemblies(assemblies)
                .AddClasses()
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsMatchingInterface()
                .WithScopedLifetime());
        }
    }
}
