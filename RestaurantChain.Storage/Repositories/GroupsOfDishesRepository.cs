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
    internal sealed class GroupsOfDishesRepository : RepositoryBase, IGroupsOfDishesRepository
    {
        public GroupsOfDishesRepository(NpgsqlConnection connection) : base(connection)
        {
        }

        public int Create(GroupsOfDishes entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public GroupsOfDishes Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(GroupsOfDishes entity)
        {
            throw new NotImplementedException();
        }
    }
}
