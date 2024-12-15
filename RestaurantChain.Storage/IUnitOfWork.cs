using RestaurantChain.Storage.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Storage
{
    public interface IUnitOfWork
    {
        IApplicationsForDistributionRepository ApplicationsForDistributionRepository { get; }
        IAvailibilityInRestaurantRepository AvailibilityInRestaurantRepository { get; }
        IBanksRepository BanksRepository { get; }
        IDishesRepository DishesRepository { get; }
        IGroupsOfDishesRepository GroupsOfDishesRepository { get; }
        IMenuRepository MenuRepository { get; }
        INomenclatureRepository NomenclatureRepository { get; }
        IProductsRepository ProductsRepository { get; }
        IRestaurantsRepository RestaurantsRepository { get; }
        ISalesRepository SalesRepository { get; }
        IStreetsRepository StreetsRepository { get; }
        ISuppliersRepository SuppliersRepository { get; }
        ISuppliesRepository SuppliesRepository { get; }
        IUnitsRepository UnitsRepository { get; }
        IUserRightsRepository UserRightsRepository { get; }
        IUsersRepository UsersRepository { get; }
    }
}
