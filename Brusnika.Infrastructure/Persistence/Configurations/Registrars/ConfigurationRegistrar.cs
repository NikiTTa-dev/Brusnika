using System.Reflection;
using Brusnika.Application.Common.Interfaces.Persistence;

namespace Brusnika.Infrastructure.Persistence.Configurations.Registrars;

public static class ConfigurationRegistrar
{
    public static void RegisterConfigurationsFromAssembly(
        Assembly assembly,
        params object[] services)
    {
        var applyConfigurationMethod = typeof(IMongoDbConfiguration)
            .GetMethods()
            .Single(e =>
                e.Name == nameof(IMongoDbConfiguration.Configure));

        var servicesTypes = services.Select(s => s.GetType()).ToList();

        assembly
            .GetConstructableTypes()
            .Where(ti => ti.GetInterfaces().Any(i => i == typeof(IMongoDbConfiguration)))
            .Select(ti =>
            {
                var serviceConstructor = ti
                    .GetConstructors()
                    .Select(c => c.GetParameters()
                        .Select(p => p.ParameterType).ToList())
                    .FirstOrDefault(c => c.All(p => servicesTypes.Contains(p)));

                var hasEmptyConstructor = ti.GetConstructor(Type.EmptyTypes) != null;

                if (serviceConstructor != null)
                {
                    var parameters = services
                        .Where(s => serviceConstructor.Contains(s.GetType()))
                        .ToArray();
                    return Activator.CreateInstance(ti, parameters);
                }

                return !hasEmptyConstructor ? null : Activator.CreateInstance(ti);
            })
            .OrderBy(obj => ((IMongoDbConfiguration)obj!).Order)
            .ToList()
            .ForEach(obj => applyConfigurationMethod.Invoke(obj, Array.Empty<object>()));
    }

    private static IEnumerable<TypeInfo> GetConstructableTypes(this Assembly assembly)
    {
        return assembly.GetLoadableDefinedTypes().Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition);
    }

    private static IEnumerable<TypeInfo> GetLoadableDefinedTypes(this Assembly assembly)
    {
        try
        {
            return assembly.DefinedTypes;
        }
        catch (ReflectionTypeLoadException ex)
        {
            return ex.Types.Where(t => t != null).Select(IntrospectionExtensions.GetTypeInfo!);
        }
    }
}