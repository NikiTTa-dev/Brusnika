﻿using Microsoft.Extensions.DependencyInjection;

namespace Brusnika.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config =>
            config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

        return services;
    }
}