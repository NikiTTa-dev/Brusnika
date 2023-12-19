using Brusnika.Api.Common.Errors;
using Brusnika.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Brusnika.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddControllers()
            .AddNewtonsoftJson();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
        services.AddMappings();
        
        services.AddSingleton<ProblemDetailsFactory, CompanyStructureProblemDetailsFactory>();

        return services;
    }
}