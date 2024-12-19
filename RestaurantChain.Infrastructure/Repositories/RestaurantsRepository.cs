using Dapper;

using Npgsql;
using RestaurantChain.Domain.Models;
using RestaurantChain.Infrastructure.Converters;
using RestaurantChain.Infrastructure.Entities;
using RestaurantChain.Repository.Repositories;

namespace RestaurantChain.Infrastructure.Repositories
{
    internal sealed class RestaurantsRepository : RepositoryBase, IRestaurantsRepository
    {
        public RestaurantsRepository(NpgsqlConnection connection) : base(connection)
        {
        }

        public int Create(Restaurants entity)
        {
            const string query = "insert into  () values() returning Id;";
            var entityDb = entity.ToStorage();
            var entityId = Connection.ExecuteScalar<int>(query, entityDb);

            return entityId;
        }

        public void Delete(int id)
        {
            const string query = "delete from  where Id = @Id;";
            Connection.ExecuteScalar(query, new
            {
                Id = id,
            });
        }

        public Restaurants Get(int id)
        {
            const string query = "select * from  where id = @id";
            var entityDb = Connection.QueryFirstOrDefault<RestaurantsDb>(query, new
            {
                Id = id
            });

            return entityDb?.ToDomain();
        }

        public void Update(Restaurants entity)
        {
            const string query = "update  set  where Id = @Id;";
            var entityDb = entity.ToStorage();
            Connection.ExecuteScalar(query, entityDb);
        }

        public Restaurants Get(string name)
        {
            const string query = "select * from  where  = @name";
            var entityDb = Connection.QueryFirstOrDefault<RestaurantsDb>(query, new
            {
                Name = name
            });

            return entityDb?.ToDomain();
        }

        public IReadOnlyCollection<Restaurants> List()
        {
            const string query = "select * from ";
            IEnumerable<RestaurantsDb> entities = Connection.Query<RestaurantsDb>(query);

            return entities.Select(x => x.ToDomain()).ToArray();
        }
    }
}
