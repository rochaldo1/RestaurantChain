using Npgsql;
using RestaurantChain.Storage.Entities;
using RestaurantChain.Storage.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Storage.Repositories
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
