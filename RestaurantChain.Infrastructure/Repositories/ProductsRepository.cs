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
    internal sealed class ProductsRepository : RepositoryBase, IProductsRepository
    {
        public ProductsRepository(NpgsqlConnection connection) : base(connection)
        {
        }

        public int Create(Products entity)
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

        public Products Get(int id)
        {
            const string query = "select * from  where id = @id";
            var entityDb = Connection.QueryFirstOrDefault<ProductsDb>(query, new
            {
                Id = id
            });

            return entityDb?.ToDomain();
        }

        public void Update(Products entity)
        {
            const string query = "update  set  where Id = @Id;";
            var entityDb = entity.ToStorage();
            Connection.ExecuteScalar(query, entityDb);
        }
        
        public Products Get(string name)
        {
            const string query = "select * from  where  = @name";
            var entityDb = Connection.QueryFirstOrDefault<ProductsDb>(query, new
            {
                Name = name
            });

            return entityDb?.ToDomain();
        }

        public IReadOnlyCollection<ProductsView> List()
        {
            const string query = "select * from ";
            IEnumerable<ProductsDbView> entities = Connection.Query<ProductsDbView>(query);

            return entities.Select(x => x.ToDomain()).ToArray();
        }
    }
}
