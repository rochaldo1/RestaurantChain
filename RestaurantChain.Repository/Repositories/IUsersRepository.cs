using RestaurantChain.Domain.Models;

namespace RestaurantChain.Repository.Repositories
{
    public interface IUsersRepository
    {
        Users Get(int id);
        Users Get(string login, string password);
        Users Get(string login);
        int Create(Users entity);
        void Update(Users entity);
    }
}
