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
