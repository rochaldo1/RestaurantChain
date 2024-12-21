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
            const string query = @"
    insert into products (
                            unit_id,
                            product_name,
                            quantity,
                            price
                         )
                values(
                            @UnitId,
                            @ProductName,
                            @Quantity,
                            @Price
                      )
    returning Id;
    ";
            var entityDb = entity.ToStorage();
            var entityId = Connection.ExecuteScalar<int>(query, entityDb);

            return entityId;
        }

        public void Delete(int id)
        {
            const string query = @"
    delete
    from products
    where Id = @Id
    ";
            Connection.ExecuteScalar(query, new
            {
                Id = id,
            });
        }

        public Products Get(int id)
        {
            const string query = @"
    select  Id,
            unit_id         as UnitId,
            product_name    as ProductName,
            quantity        as Quantity,
            price           as Price
    from products
    where id = @id
    ";
            var entityDb = Connection.QueryFirstOrDefault<ProductsDb>(query, new
            {
                Id = id
            });

            return entityDb?.ToDomain();
        }

        public void Update(Products entity)
        {
            const string query = @"
    update products set 
            unit_id         = @UnitId,
            product_name    = @ProductName,
            quantity        = @Quantity,
            price           = @Price
    where Id = @Id;
    ";
            var entityDb = entity.ToStorage();
            Connection.ExecuteScalar(query, entityDb);
        }
        
        public Products Get(string name)
        {
            const string query = @"
    select  Id,
            unit_id         as UnitId,
            product_name    as ProductName,
            quantity        as Quantity,
            price           as Price
    from products 
    where product_name = @name;
    ";
            var entityDb = Connection.QueryFirstOrDefault<ProductsDb>(query, new
            {
                Name = name
            });

            return entityDb?.ToDomain();
        }

        public IReadOnlyCollection<ProductsView> List()
        {
            const string query = @"
    select  p.id            as id,
		    p.unit_id       as UnitId,
		    p.product_name  as ProductName,
		    p.quantity      as Quantity,
		    p.price         as Price,
		    u.unit_name     as UnitName
    from public.products p
    join public.units u on p.unit_id = u.id
    order by product_name;
    ";
            IEnumerable<ProductsDbView> entities = Connection.Query<ProductsDbView>(query);

            return entities.Select(x => x.ToDomain()).ToArray();
        }
    }
}
