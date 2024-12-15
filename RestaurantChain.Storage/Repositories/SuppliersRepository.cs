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
