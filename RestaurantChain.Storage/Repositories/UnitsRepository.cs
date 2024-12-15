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
