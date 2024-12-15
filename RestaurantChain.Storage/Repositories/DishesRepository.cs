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
    internal sealed class DishesRepository : RepositoryBase, IDishesRepository
    {
        public DishesRepository(NpgsqlConnection connection) : base(connection)
        {
        }

        public int Create(Dishes entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Dishes Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Dishes entity)
        {
            throw new NotImplementedException();
        }
    }
}
