using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.Repository;

namespace RestaurantChain.Infrastructure;

public static class InfrastructureRegistration
{
    /// <summary>
    /// Регистрация БД
    /// </summary>
    /// <param name="services"></param>
    /// <param name="connectionString"></param>
    public static void UseStorage(this IServiceCollection services, string connectionString)
    {
        services.AddSingleton<IUnitOfWork, UnitOfWork>(_ => new UnitOfWork(connectionString));
    }
}