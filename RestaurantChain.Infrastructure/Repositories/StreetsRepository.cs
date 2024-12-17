using Npgsql;
using RestaurantChain.Domain.Models;
using RestaurantChain.Repository.Repositories;

namespace RestaurantChain.Infrastructure.Repositories
{
    internal sealed class StreetsRepository : RepositoryBase, IStreetsRepository
    {
        public StreetsRepository(NpgsqlConnection connection) : base(connection)
        {
        }

        public int Create(Streets entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Streets Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Streets entity)
        {
            throw new NotImplementedException();
        }
    }
}
