using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;

namespace RestaurantChain.Repository.Repositories;

/// <summary>
/// Пользователи
/// </summary>
public interface IUsersRepository : IRepositoryBase<Users>
{
    /// <summary>
    /// Получение пользователя по логин паролю для авторизации
    /// </summary>
    /// <param name="login"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    Users Get(string login, string password);
    
    /// <summary>
    /// Получить по логину
    /// </summary>
    /// <param name="login"></param>
    /// <returns></returns>
    Users Get(string login);
    
    /// <summary>
    /// Список пользователей
    /// </summary>
    /// <returns></returns>
    IReadOnlyCollection<UsersView> List();
}