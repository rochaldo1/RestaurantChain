using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;

namespace RestaurantChain.Repository.Repositories;

/// <summary>
/// Права ролей
/// </summary>
public interface IRolesRightsRepository : IRepositoryBase<RolesRights>
{
    /// <summary>
    /// Получить все права по роли
    /// </summary>
    /// <param name="roleId"></param>
    /// <returns></returns>
    IReadOnlyCollection<RolesRightsView> List(int roleId);
    
    /// <summary>
    /// Получить все права по юзеру
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    IReadOnlyCollection<UserRoleRight> ListUserRoleRights(int userId);
}