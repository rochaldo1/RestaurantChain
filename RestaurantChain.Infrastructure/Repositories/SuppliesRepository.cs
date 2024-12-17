using Npgsql;
using RestaurantChain.Domain.Models;
using RestaurantChain.Repository.Repositories;

namespace RestaurantChain.Infrastructure.Repositories
{
    internal sealed class SuppliesRepository : RepositoryBase, ISuppliesRepository
    {
        public SuppliesRepository(NpgsqlConnection connection) : base(connection)
        {
        }

        public int Create(Supplies entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Supplies Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Supplies entity)
        {
            throw new NotImplementedException();
        }
    }
}
