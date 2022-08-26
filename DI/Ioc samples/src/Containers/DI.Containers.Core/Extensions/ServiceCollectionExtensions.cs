using DI.Core.Classes;
using DI.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DI.Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCommerce(this IServiceCollection services)
    {
        services.AddScoped<IBillingProcessor, BillingProcessor>();
        services.AddTransient<ICustomer, Customer>();
        services.AddTransient<ILogger, Logger>();
        services.AddTransient<INotifier, Notifier>();
        services.AddTransient<Commerce>();

        return services;
    }
}