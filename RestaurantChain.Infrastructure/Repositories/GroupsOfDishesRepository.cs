using Dapper;
using Npgsql;
using RestaurantChain.Domain.Models;
using RestaurantChain.Infrastructure.Converters;
using RestaurantChain.Infrastructure.Entities;
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
            const string query = "insert into groups_of_dishes (group_name) values(@GroupName) returning Id";
            var entityDb = entity.ToStorage();
            var groupId = Connection.ExecuteScalar<int>(query, entityDb);

            return groupId;
        }

        public void Delete(int id)
        {
            const string query = "delete from groups_of_dishes where Id = @Id";
            Connection.ExecuteScalar<int>(query, new
            {
                Id = id
            });
        }

        public GroupsOfDishes Get(int id)
        {
            const string query = "select * from groups_of_dishes where id = @id";
            var groupsDb = Connection.QueryFirstOrDefault<GroupsOfDishesDb>(query, new
            {
                Id = id
            });
            return groupsDb?.ToDomain();
        }

        public GroupsOfDishes Get(string groupName)
        {
            const string query = "select * from groups_of_dishes where bank_name = @name";
            var groupsDb = Connection.QueryFirstOrDefault<GroupsOfDishesDb>(query, new
            {
                Name = groupName
            });
            return groupsDb?.ToDomain();
        }

        public void Update(GroupsOfDishes entity)
        {
            const string query = "update groups_of_dishes set bank_name = @BankName where Id = @Id";
            var entityDb = entity.ToStorage();
            Connection.ExecuteScalar(query, entityDb);
        }
    }
}
