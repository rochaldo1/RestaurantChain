using RestaurantChain.Domain.Models;

namespace RestaurantChain.Repository.Repositories
{
    public interface IUsersRepository
    {
        Users Get(string login, string password);
    }
}
