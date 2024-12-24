using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;

namespace RestaurantChain.Repository.Repositories;

/// <summary>
/// Продажи
/// </summary>
public interface ISalesRepository : IRepositoryBase<Sales>
{
    /// <summary>
    /// Получить продажи
    /// </summary>
    /// <param name="restaurantId">Ресторан</param>
    /// <param name="from">Период с</param>
    /// <param name="to">Период по</param>
    /// <returns></returns>
    IReadOnlyCollection<SalesView> List(int? restaurantId, DateTime? from, DateTime? to);
    
    /// <summary>
    /// Получить продажу
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    SalesView GetView(int id);
}