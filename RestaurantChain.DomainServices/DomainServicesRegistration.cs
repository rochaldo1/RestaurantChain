using Microsoft.Extensions.DependencyInjection;

using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.DomainServices.Services;

namespace RestaurantChain.DomainServices
{
    public static class DomainServicesRegistration
    {
        public static void UseDomainServices(this IServiceCollection services)
        {
            services.AddSingleton<IUsersService, UsersService>();
        }
    }
}
