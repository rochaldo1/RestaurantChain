using Npgsql;
using RestaurantChain.Domain.Models;
using RestaurantChain.Repository.Repositories;

namespace RestaurantChain.Infrastructure.Repositories
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
