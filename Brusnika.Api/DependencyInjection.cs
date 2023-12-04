using Brusnika.Api.Common.Mapping;

namespace Brusnika.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddMappings();

        return services;
    }
}