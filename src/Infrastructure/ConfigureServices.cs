using PrepayPower.Application.Common.Interfaces;
using PrepayPower.Infrastructure.Files;
using PrepayPower.Infrastructure.Persistence;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddTransient<IVegetablesFileReader, VegetablesCsvReader>();
        services.AddTransient<IPurchaseElementsFileReader, PurchaseElementsCsvReader>();
        services.AddSingleton<IPersistenceContext, SimplePersistenceContext>();
        return services;
    }
}
