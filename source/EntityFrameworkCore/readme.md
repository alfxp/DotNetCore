# DotNetCore.EntityFrameworkCore

The package provides classes for **Entity Framework Core**.

## EntityFrameworkCoreExtensions

The **EntityFrameworkCoreExtensions** class provides **extension methods**.

```cs
public static class EntityFrameworkCoreExtensions
{
    public static void ApplyConfigurationsFromAssembly(this ModelBuilder modelBuilder) { }

    public static DbSet<T> CommandSet<T>(this DbContext context) where T : class { }

    public static DbContext DetectChangesLazyLoading(this DbContext context, bool enabled) { }

    public static IQueryable<T> QuerySet<T>(this DbContext context) where T : class { }
}
```

## ServiceCollectionExtensions

```cs
public static class ServiceCollectionExtensions
{
    public static void AddDbContextMemory<T>(this IServiceCollection services) where T : DbContext { }

    public static void AddDbContextMigrate<T>(this IServiceCollection services, Action<DbContextOptionsBuilder> options) where T : DbContext { }
}
```

## Repository

### EntityFrameworkCoreCommandRepository

```cs
public class EntityFrameworkCoreCommandRepository<T> : ICommandRepository<T> where T : class
{
    public EntityFrameworkCoreCommandRepository(DbContext context) { }

    public void Add(T item) { }

    public Task AddAsync(T item) { }

    public void AddRange(IEnumerable<T> items) { }

    public Task AddRangeAsync(IEnumerable<T> items) { }

    public void Delete(object key) { }

    public void Delete(Expression<Func<T, bool>> where) { }

    public Task DeleteAsync(object key) { }

    public Task DeleteAsync(Expression<Func<T, bool>> where) { }

    public void Update(object key, T item) { }

    public Task UpdateAsync(object key, T item) { }

    public void UpdatePartial(object key, object item) { }

    public Task UpdatePartialAsync(object key, object item) { }

    public void UpdateRange(IEnumerable<T> items) { }

    public Task UpdateRangeAsync(IEnumerable<T> items) { }
}
```

### EntityFrameworkCoreQueryRepository

```cs
public class EntityFrameworkCoreQueryRepository<T> : IQueryRepository<T> where T : class
{
    public EntityFrameworkCoreQueryRepository(DbContext context) { }

    public IQueryable<T> Queryable { get; };

    public bool Any() { }

    public bool Any(Expression<Func<T, bool>> where) { }

    public Task<bool> AnyAsync() { }

    public Task<bool> AnyAsync(Expression<Func<T, bool>> where) { }

    public long Count() { }

    public long Count(Expression<Func<T, bool>> where) { }

    public Task<long> CountAsync() { }

    public Task<long> CountAsync(Expression<Func<T, bool>> where) { }

    public T Get(object key) { }

    public Task<T> GetAsync(object key) { }

    public IEnumerable<T> List() { }

    public async Task<IEnumerable<T>> ListAsync() { }

    public IQueryable<T> Specify(ISpecification<T> specification) { }

    public Task<IQueryable<T>> SpecifyAsync(ISpecification<T> specification) { }
}
```

### EntityFrameworkCoreRepository

```cs
public class EntityFrameworkCoreRepository<T> : IRepository<T> where T : class
{
    public EntityFrameworkCoreRepository(DbContext context) { }

    public IQueryable<T> Queryable { get; };

    public void Add(T item) { }

    public Task AddAsync(T item) { }

    public void AddRange(IEnumerable<T> items) { }

    public Task AddRangeAsync(IEnumerable<T> items) { }

    public bool Any() { }

    public bool Any(Expression<Func<T, bool>> where) { }

    public Task<bool> AnyAsync() { }

    public Task<bool> AnyAsync(Expression<Func<T, bool>> where) { }

    public long Count() { }

    public long Count(Expression<Func<T, bool>> where) { }

    public Task<long> CountAsync() { }

    public Task<long> CountAsync(Expression<Func<T, bool>> where) { }

    public void Delete(object key) { }

    public void Delete(Expression<Func<T, bool>> where) { }

    public Task DeleteAsync(object key) { }

    public Task DeleteAsync(Expression<Func<T, bool>> where) { }

    public T Get(object key) { }

    public Task<T> GetAsync(object key) { }

    public IEnumerable<T> List() { }

    public Task<IEnumerable<T>> ListAsync() { }

    public IQueryable<T> Specify(ISpecification<T> specification) { }

    public Task<IQueryable<T>> SpecifyAsync(ISpecification<T> specification) { }

    public void Update(object key, T item) { }

    public Task UpdateAsync(object key, T item) { }

    public void UpdatePartial(object key, object item) { }

    public Task UpdatePartialAsync(object key, object item) { }

    public void UpdateRange(IEnumerable<T> items) { }

    public Task UpdateRangeAsync(IEnumerable<T> items) { }
}
```
