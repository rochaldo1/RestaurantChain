using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;

namespace RestaurantChain.DomainServices.Contracts;

/// <summary>
/// Сервис для работы с меню пользователя
/// </summary>
public interface IMenuService
{
    public IReadOnlyCollection<UserRoleRight> List(int userId);
    public IReadOnlyCollection<Menu> List();
}