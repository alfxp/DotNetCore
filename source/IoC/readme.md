# DotNetCore.IoC

The package provides **static classes** with **extensions methods** for **inversion of control**.

## ServiceCollectionExtensions

```cs
public static class ServiceCollectionExtensions
{
    public static void AddClassesMatchingInterfaces(this IServiceCollection services, params Assembly[] assemblies) { }
}
```
