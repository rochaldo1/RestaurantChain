using RestaurantChain.Domain.Models;

namespace RestaurantChain.Repository.Repositories;

/// <summary>
/// Роли
/// </summary>
public interface IRolesRepository : IRepositoryBase<Roles>
{
    /// <summary>
    /// Список всех ролей
    /// </summary>
    /// <returns></returns>
    IReadOnlyCollection<Roles> List();
}