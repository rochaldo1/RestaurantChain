using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;

namespace RestaurantChain.Repository.Repositories;

/// <summary>
/// Справочник продуктов (склад)
/// </summary>
public interface IProductsRepository : IRepositoryBase<Products>
{
    /// <summary>
    /// Продукт по имени
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    Products Get(string name);
    
    /// <summary>
    /// Список всех продкутов
    /// </summary>
    /// <returns></returns>
    IReadOnlyCollection<ProductsView> List();
    
    /// <summary>
    /// Обновить количество продукта на складе
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="quantity"></param>
    void UpdateQuantity(int productId, int quantity);
}