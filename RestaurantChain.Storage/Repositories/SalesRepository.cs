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
