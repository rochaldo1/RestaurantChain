using RestaurantChain.Domain.Models;

namespace RestaurantChain.Repository.Repositories;

public interface IUsersRepository : IRepositoryBase<Users>
{
    Users Get(string login, string password);
    Users Get(string login);
}