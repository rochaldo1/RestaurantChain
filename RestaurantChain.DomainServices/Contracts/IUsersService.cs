using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;

namespace RestaurantChain.DomainServices.Contracts;

/// <summary>
/// Сервис для работы с пользователями
/// </summary>
public interface IUsersService
{
    /// <summary>
    /// Получить одну запись
    /// </summary>
    /// <param name="login"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    Users Get(string login, string password);
    
    /// <summary>
    /// Получить одну запись
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Users Get(int id);
    
    /// <summary>
    /// Создать
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    int Registration(Users user);
    
    /// <summary>
    /// Обновить пароль и пользователя
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    bool ChangePassword (Users user);
    
    /// <summary>
    /// Получить список
    /// </summary>
    /// <returns></returns>
    IReadOnlyCollection<UsersView> List();
    
    /// <summary>
    /// Удалить
    /// </summary>
    /// <param name="id"></param>
    void Delete(int id);
}