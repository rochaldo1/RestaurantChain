using Npgsql;
using RestaurantChain.Domain.Models;
using RestaurantChain.Repository.Repositories;

namespace RestaurantChain.Infrastructure.Repositories
{
    internal sealed class SalesRepository : RepositoryBase, ISalesRepository
    {
        public SalesRepository(NpgsqlConnection connection) : base(connection)
        {
        }

        public int Create(Sales entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Sales Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Sales entity)
        {
            throw new NotImplementedException();
        }
    }
}
