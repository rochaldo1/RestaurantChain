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
