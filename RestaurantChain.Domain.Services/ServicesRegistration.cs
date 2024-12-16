using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.Domain.Services.Services;
using RestaurantChain.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Domain.Services
{
    public static class ServicesRegistration
    {
        public static void UseServices(this IServiceCollection services)
        {
            services.AddSingleton<IApplicationsForDistributionService, ApplicationsForDistributionService>();
            services.AddSingleton<IAvailibilityInRestaurantService, AvailibilityInRestaurantService>();
            services.AddSingleton<IBanksService, BanksService>();
            services.AddSingleton<IDishesService, DishesService>();
            services.AddSingleton<IGroupsOfDishesService, GroupsOfDishesService>();
            services.AddSingleton<IMenuService, MenuService>();
            services.AddSingleton<INomenclarureService, NomenclatureService>();
            services.AddSingleton<IProductsService, ProductsService>();
            services.AddSingleton<IRestaurantsService, RestaurantsService>();
            services.AddSingleton<ISalesService, SalesService>();
            services.AddSingleton<IStreetsService, StreetsService>();
            services.AddSingleton<ISuppliersService, SuppliersService>();
            services.AddSingleton<ISuppliesService, SuppliesService>();
            services.AddSingleton<IUnitsService, UnitsService>();
            services.AddSingleton<IUserRightsService, UserRightsService>();
            services.AddSingleton<IUsersService, UsersService>();
        }
    }
}
