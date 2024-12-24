using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;

namespace RestaurantChain.Repository.Repositories;

/// <summary>
/// Меню ресторана
/// </summary>
public interface INomenclatureRepository : IRepositoryBase<Nomenclature>
{
    /// <summary>
    /// Получить меню по ресторану
    /// </summary>
    /// <param name="restaurantId"></param>
    /// <returns></returns>
    IReadOnlyCollection<NomenclatureView> List(int restaurantId);
}