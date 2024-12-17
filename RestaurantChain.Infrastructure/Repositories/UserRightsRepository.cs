using Npgsql;
using RestaurantChain.Domain.Models;
using RestaurantChain.Repository.Repositories;

namespace RestaurantChain.Infrastructure.Repositories
{
    internal sealed class UserRightsRepository : RepositoryBase, IUserRightsRepository
    {
        public UserRightsRepository(NpgsqlConnection connection) : base(connection)
        {
        }

        public int Create(UserRights entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public UserRights Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(UserRights entity)
        {
            throw new NotImplementedException();
        }
    }
}
