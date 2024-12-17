using Npgsql;
using RestaurantChain.Domain.Models;
using RestaurantChain.Repository.Repositories;

namespace RestaurantChain.Infrastructure.Repositories
{
    internal sealed class BanksRepository : RepositoryBase, IBanksRepository
    {
        public BanksRepository(NpgsqlConnection connection) : base(connection)
        {
        }

        public int Create(Banks entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Banks Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Banks entity)
        {
            throw new NotImplementedException();
        }
    }
}
