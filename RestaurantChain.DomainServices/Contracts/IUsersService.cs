using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;

namespace RestaurantChain.DomainServices.Contracts;

/// <summary>
/// Сервис для работы с пользователями
/// </summary>
public interface IUsersService
{
    Users Get(string login, string password);
    Users Get(int id);
    int Registration(Users user);
    bool ChangePassword (Users user);
    IReadOnlyCollection<UsersView> List();
    void Delete(int id);
}