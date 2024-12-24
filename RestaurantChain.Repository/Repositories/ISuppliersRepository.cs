using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;

namespace RestaurantChain.Repository.Repositories;

/// <summary>
/// Поставщики
/// </summary>
public interface ISuppliersRepository : IRepositoryBase<Suppliers>
{
    /// <summary>
    /// Поставщик по имени
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    Suppliers Get(string name);
    
    /// <summary>
    /// Список всех поставщиков
    /// </summary>
    /// <returns></returns>
    IReadOnlyCollection<SuppliersView> List();
}