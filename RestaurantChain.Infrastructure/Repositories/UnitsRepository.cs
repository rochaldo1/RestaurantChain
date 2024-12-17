using Npgsql;
using RestaurantChain.Domain.Models;
using RestaurantChain.Repository.Repositories;

namespace RestaurantChain.Infrastructure.Repositories
{
    internal sealed class UnitsRepository : RepositoryBase, IUnitsRepository
    {
        public UnitsRepository(NpgsqlConnection connection) : base(connection)
        {
        }

        public int Create(Units entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Units Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Units entity)
        {
            throw new NotImplementedException();
        }
    }
}
