using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;

namespace RestaurantChain.Repository.Repositories;

/// <summary>
/// Поставки
/// </summary>
public interface ISuppliesRepository : IRepositoryBase<Supplies>
{
    /// <summary>
    /// Список поставок
    /// </summary>
    /// <param name="supplierId">Поставщик</param>
    /// <param name="from">Период с</param>
    /// <param name="to">Период по</param>
    /// <returns></returns>
    IReadOnlyCollection<SuppliesView> List(int? supplierId, DateTime? from, DateTime? to);
    
    /// <summary>
    /// Получить поставку
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    SuppliesView GetView(int id);
    
    /// <summary>
    /// Количество всех поставок по продукту
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    int CountByProduct(int productId);
}