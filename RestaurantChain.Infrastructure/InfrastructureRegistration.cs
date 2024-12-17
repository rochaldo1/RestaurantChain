using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.Repository;

namespace RestaurantChain.Infrastructure
{
    public static class InfrastructureRegistration
    {
        public static void UseStorage(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton<IUnitOfWork, UnitOfWork>(_ => new UnitOfWork(connectionString));
        }
    }
}
