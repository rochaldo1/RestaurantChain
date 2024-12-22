using Microsoft.Extensions.DependencyInjection;

using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.DomainServices.Services;

namespace RestaurantChain.DomainServices;

public static class DomainServicesRegistration
{
    public static void UseDomainServices(this IServiceCollection services)
    {
        services.AddSingleton<IUsersService, UsersService>();
        services.AddSingleton<IStreetsService, StreetsService>();
        services.AddSingleton<IBanksService, BanksService>();
        services.AddSingleton<IGroupsOfDishesService, GroupsOfDishesService>();
        services.AddSingleton<IUnitsService, UnitsService>();
        services.AddSingleton<ISuppliersService, SuppliersService>();
        services.AddSingleton<IProductsService, ProductsService>();
        services.AddSingleton<IQueryService, QueryService>();
        services.AddSingleton<ISuppliesService, SuppliesService>();
        services.AddSingleton<IDishesService, DishesService>();
        services.AddSingleton<IApplicationsForDistributionService, ApplicationsForDistributionService>();
        services.AddSingleton<IRestaurantsService, RestaurantsService>();
        services.AddSingleton<IAvailibilityInRestaurantService, AvailibilityInRestaurantService>();
        services.AddSingleton<INomenclatureService, NomenclatureService>();
        services.AddSingleton<ISalesService, SalesService>();
        services.AddSingleton<IReportsService, ReportsService>();
        services.AddSingleton<IMenuService, MenuService>();
    }
}