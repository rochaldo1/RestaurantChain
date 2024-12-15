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
    internal sealed class AvailibilityInRestaurantRepository : RepositoryBase, IAvailibilityInRestaurantRepository
    {
        public AvailibilityInRestaurantRepository(NpgsqlConnection connection) : base(connection)
        {
        }

        public int Create(AvailibilityInRestaurant entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public AvailibilityInRestaurant Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(AvailibilityInRestaurant entity)
        {
            throw new NotImplementedException();
        }
    }
}
