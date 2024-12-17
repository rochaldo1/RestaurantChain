using RestaurantChain.Repository.Repositories;

namespace RestaurantChain.Repository
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
