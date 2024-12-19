using Dapper;

using Npgsql;
using RestaurantChain.Domain.Models;
using RestaurantChain.Infrastructure.Converters;
using RestaurantChain.Infrastructure.Entities;
using RestaurantChain.Repository.Repositories;

namespace RestaurantChain.Infrastructure.Repositories
{
    internal sealed class SuppliesRepository : RepositoryBase, ISuppliesRepository
    {
        public SuppliesRepository(NpgsqlConnection connection) : base(connection)
        {
        }

        public int Create(Supplies entity)
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

        public Supplies Get(int id)
        {
            const string query = "select * from  where id = @id";
            var entityDb = Connection.QueryFirstOrDefault<SuppliesDb>(query, new
            {
                Id = id
            });

            return entityDb?.ToDomain();
        }

        public void Update(Supplies entity)
        {
            const string query = "update  set  where Id = @Id;";
            var entityDb = entity.ToStorage();
            Connection.ExecuteScalar(query, entityDb);
        }
    }
}
