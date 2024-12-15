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
    internal sealed class MenuRepository : RepositoryBase, IMenuRepository
    {
        public MenuRepository(NpgsqlConnection connection) : base(connection)
        {
        }

        public int Create(Menu entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Menu Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Menu entity)
        {
            throw new NotImplementedException();
        }
    }
}
