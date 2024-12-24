using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;

namespace RestaurantChain.Repository.Repositories;

public interface IUsersRepository : IRepositoryBase<Users>
{
    Users Get(string login, string password);
    Users Get(string login);
    IReadOnlyCollection<UsersView> List();
}