using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace DotNetCore.EntityFrameworkCore
{
    public static class EntityFrameworkCoreExtensions
    {
        public static void ApplyConfigurationsFromAssembly(this ModelBuilder modelBuilder)
        {
            static bool Expression(Type type) => type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>);

            var types = Assembly.GetCallingAssembly().GetTypes().Where(type => type.GetInterfaces().Any(Expression)).ToList();

            foreach (var configuration in types.Select(Activator.CreateInstance))
            {
                modelBuilder.ApplyConfiguration((dynamic)configuration);
            }
        }

        public static DbSet<T> CommandSet<T>(this DbContext context) where T : class
        {
            return context.DetectChangesLazyLoading(true).Set<T>();
        }

        public static DbContext DetectChangesLazyLoading(this DbContext context, bool enabled)
        {
            context.ChangeTracker.AutoDetectChangesEnabled = enabled;
            context.ChangeTracker.LazyLoadingEnabled = enabled;
            context.ChangeTracker.QueryTrackingBehavior = enabled ? QueryTrackingBehavior.TrackAll : QueryTrackingBehavior.NoTracking;

            return context;
        }

        public static IQueryable<T> QuerySet<T>(this DbContext context) where T : class
        {
            return context.DetectChangesLazyLoading(false).Set<T>().AsNoTracking();
        }
    }
}
