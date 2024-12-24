using RestaurantChain.Domain.Models;

namespace RestaurantChain.Repository.Repositories;

/// <summary>
/// Меню пользователя
/// </summary>
public interface IMenuRepository : IRepositoryBase<Menu>
{
    /// <summary>
    /// Получить весь список меню
    /// </summary>
    /// <returns></returns>
    IReadOnlyCollection<Menu> List();
}