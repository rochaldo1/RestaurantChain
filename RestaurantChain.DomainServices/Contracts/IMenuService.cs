using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;

namespace RestaurantChain.DomainServices.Contracts;

/// <summary>
/// Сервис для работы с меню пользователя
/// </summary>
public interface IMenuService
{
    /// <summary>
    /// Получить список прав
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public IReadOnlyCollection<UserRoleRight> List(int userId);
    
    /// <summary>
    /// Получить список
    /// </summary>
    /// <returns></returns>
    public IReadOnlyCollection<Menu> List();
}