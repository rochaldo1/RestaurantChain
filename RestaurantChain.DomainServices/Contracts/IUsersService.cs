using RestaurantChain.Domain.Models;

namespace RestaurantChain.DomainServices.Contracts;

public interface IUsersService
{
    Users Get(string login, string password);
    int Registration(Users user);
    bool ChangePassword (Users user);
}