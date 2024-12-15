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
    internal sealed class RestaurantsRepository : RepositoryBase, IRestaurantsRepository
    {
        public RestaurantsRepository(NpgsqlConnection connection) : base(connection)
        {
        }

        public int Create(Restaurants entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Restaurants Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Restaurants entity)
        {
            throw new NotImplementedException();
        }
    }
}
