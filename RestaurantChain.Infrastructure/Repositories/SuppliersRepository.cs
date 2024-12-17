using Npgsql;
using RestaurantChain.Domain.Models;
using RestaurantChain.Repository.Repositories;

namespace RestaurantChain.Infrastructure.Repositories
{
    internal sealed class SuppliersRepository : RepositoryBase, ISuppliersRepository
    {
        public SuppliersRepository(NpgsqlConnection connection) : base(connection)
        {
        }

        public int Create(Suppliers entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Suppliers Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Suppliers entity)
        {
            throw new NotImplementedException();
        }
    }
}
