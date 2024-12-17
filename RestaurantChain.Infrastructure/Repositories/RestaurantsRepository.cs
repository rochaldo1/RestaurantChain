using Npgsql;
using RestaurantChain.Domain.Models;
using RestaurantChain.Repository.Repositories;

namespace RestaurantChain.Infrastructure.Repositories
{
    internal sealed class RestaurantsRepository : RepositoryBase, IRestaurantsRepository
    {
        public RestaurantsRepository(NpgsqlConnection connection) : base(connection)
        {
        }

        public int Create(Restaurants entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Restaurants Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Restaurants entity)
        {
            throw new NotImplementedException();
        }
    }
}
