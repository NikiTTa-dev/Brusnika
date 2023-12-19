using System.Reflection;
using Brusnika.Application.Common.Interfaces.Persistence;
using Brusnika.Application.Common.Interfaces.Services;
using Brusnika.Application.Common.Settings;
using Brusnika.Infrastructure.Persistence;
using Brusnika.Infrastructure.Persistence.Configurations.Common;
using Brusnika.Infrastructure.Persistence.Configurations.Registrars;
using Brusnika.Infrastructure.Persistence.Repositories;
using Brusnika.Infrastructure.Services;
using Brusnika.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Brusnika.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services
            .AddPersistence(configuration)
            .AddSingleton<IDateTimeProvider, DateTimeProvider>()
            .AddSettings(configuration);
            
        return services;
    }

    private static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var mongoDbSettings = new MongoDbSettings();
        configuration.Bind(MongoDbSettings.SectionName, mongoDbSettings);
        services.AddSingleton(Options.Create(mongoDbSettings));
        
        ConfigurationRegistrar.RegisterConfigurationsFromAssembly(
            Assembly.GetExecutingAssembly());
        
        services.AddSingleton<IMongoDbContext, BrusnikaMongoDbContext>();
        services.AddScoped<IGroupRepository, GroupRepository>();
        services.AddScoped<IPositionRepository, PositionRepository>();
        
        return services;
    }
    
    private static IServiceCollection AddSettings(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        var validationSettings = new ValidationSettings();
        configuration.Bind(ValidationSettings.SectionName, validationSettings);
        services.AddSingleton(Options.Create(validationSettings));
        
        return services;
    }
}