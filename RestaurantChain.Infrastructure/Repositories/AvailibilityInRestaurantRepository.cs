using Npgsql;
using RestaurantChain.Domain.Models;
using RestaurantChain.Repository.Repositories;

namespace RestaurantChain.Infrastructure.Repositories
{
    internal sealed class AvailibilityInRestaurantRepository : RepositoryBase, IAvailibilityInRestaurantRepository
    {
        public AvailibilityInRestaurantRepository(NpgsqlConnection connection) : base(connection)
        {
        }

        public int Create(AvailibilityInRestaurant entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public AvailibilityInRestaurant Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(AvailibilityInRestaurant entity)
        {
            throw new NotImplementedException();
        }
    }
}
