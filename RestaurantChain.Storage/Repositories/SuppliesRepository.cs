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
