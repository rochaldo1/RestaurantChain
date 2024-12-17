using Npgsql;
using RestaurantChain.Domain.Models;
using RestaurantChain.Repository.Repositories;

namespace RestaurantChain.Infrastructure.Repositories
{
    internal sealed class DishesRepository : RepositoryBase, IDishesRepository
    {
        public DishesRepository(NpgsqlConnection connection) : base(connection)
        {
        }

        public int Create(Dishes entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Dishes Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Dishes entity)
        {
            throw new NotImplementedException();
        }
    }
}
