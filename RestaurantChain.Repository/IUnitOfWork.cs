using RestaurantChain.Repository.Repositories;

namespace RestaurantChain.Repository;

/// <summary>
/// UnitOfWork patter - доступ к репозиториям через UoW
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Заявки на рапределение
    /// </summary>
    IApplicationsForDistributionRepository ApplicationsForDistributionRepository { get; }
    
    /// <summary>
    /// Доступность продуктов в ресторане
    /// </summary>
    IAvailibilityInRestaurantRepository AvailibilityInRestaurantRepository { get; }
    
    /// <summary>
    /// Справочник. Банки
    /// </summary>
    IBanksRepository BanksRepository { get; }
    
    /// <summary>
    /// Справочник. Блюда
    /// </summary>
    IDishesRepository DishesRepository { get; }
    
    /// <summary>
    /// Справочник. Группы блюд
    /// </summary>
    IGroupsOfDishesRepository GroupsOfDishesRepository { get; }
    
    /// <summary>
    /// Меню
    /// </summary>
    IMenuRepository MenuRepository { get; }
    
    /// <summary>
    /// Меню ресторана
    /// </summary>
    INomenclatureRepository NomenclatureRepository { get; }
    
    /// <summary>
    /// Продукты (склад)
    /// </summary>
    IProductsRepository ProductsRepository { get; }
    
    /// <summary>
    /// Рестораны
    /// </summary>
    IRestaurantsRepository RestaurantsRepository { get; }
    
    /// <summary>
    /// Продажи
    /// </summary>
    ISalesRepository SalesRepository { get; }
    
    /// <summary>
    /// Справочник. Улицы
    /// </summary>
    IStreetsRepository StreetsRepository { get; }
    
    /// <summary>
    /// Поставщики
    /// </summary>
    ISuppliersRepository SuppliersRepository { get; }
    
    /// <summary>
    /// Поставки
    /// </summary>
    ISuppliesRepository SuppliesRepository { get; }
    
    /// <summary>
    /// Справочник. Единицы измерения
    /// </summary>
    IUnitsRepository UnitsRepository { get; }
    
    /// <summary>
    /// Пользователи
    /// </summary>
    IUsersRepository UsersRepository { get; }
    
    /// <summary>
    /// Свободный запросы
    /// </summary>
    IQueryRepository QueryRepository { get; }
    
    /// <summary>
    /// Отчеты
    /// </summary>
    IReportsRepository ReportsRepository { get; }
    
    /// <summary>
    /// Роли
    /// </summary>
    IRolesRepository RolesRepository { get; }
    
    /// <summary>
    /// Права ролей
    /// </summary>
    IRolesRightsRepository RolesRightsRepository { get; }
}