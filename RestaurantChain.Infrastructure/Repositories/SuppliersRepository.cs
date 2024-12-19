using Dapper;

using Npgsql;
using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.Infrastructure.Converters;
using RestaurantChain.Infrastructure.Entities;
using RestaurantChain.Infrastructure.Entities.Views;
using RestaurantChain.Repository.Repositories;

namespace RestaurantChain.Infrastructure.Repositories
{
    internal sealed class SuppliersRepository : RepositoryBase, ISuppliersRepository
    {
        public SuppliersRepository(NpgsqlConnection connection) : base(connection)
        {
        }

        public int Create(Suppliers entity)
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

        public Suppliers Get(int id)
        {
            const string query = "select * from  where id = @id";
            var entityDb = Connection.QueryFirstOrDefault<SuppliersDb>(query, new
            {
                Id = id
            });

            return entityDb?.ToDomain();
        }

        public void Update(Suppliers entity)
        {
            const string query = "update  set  where Id = @Id;";
            var entityDb = entity.ToStorage();
            Connection.ExecuteScalar(query, entityDb);
        }

        public Suppliers Get(string name)
        {
            const string query = "select * from  where  = @name";
            var entityDb = Connection.QueryFirstOrDefault<SuppliersDb>(query, new
            {
                Name = name
            });

            return entityDb?.ToDomain();
        }

        public IReadOnlyCollection<SuppliersView> List()
        {
            const string query = "select * from ";
            IEnumerable<SuppliersDbView> entities = Connection.Query<SuppliersDbView>(query);

            return entities.Select(x => x.ToDomain()).ToArray();
        }
    }
}
