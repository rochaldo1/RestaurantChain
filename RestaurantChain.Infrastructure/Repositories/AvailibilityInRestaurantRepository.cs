using Dapper;
using Npgsql;
using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.Infrastructure.Converters;
using RestaurantChain.Infrastructure.Entities;
using RestaurantChain.Infrastructure.Entities.Views;
using RestaurantChain.Repository.Repositories;

namespace RestaurantChain.Infrastructure.Repositories;

internal sealed class AvailibilityInRestaurantRepository : RepositoryBase, IAvailibilityInRestaurantRepository
{
    public AvailibilityInRestaurantRepository(NpgsqlConnection connection) : base(connection)
    {
    }

    public int Create(AvailibilityInRestaurant entity)
    {
        const string query = @"
INSERT INTO public.availibility_in_restaurant 
(
    restaurant_id, 
    product_id, 
    unit_id, 
    quantity, 
    price
) VALUES
(
    @RestaurantId, 
    @ProductId,
    @UnitId, 
    @Quantity,
    @Price
) returning Id;";
        var entityDb = entity.ToStorage();
        var entityId = Connection.ExecuteScalar<int>(query, entityDb);

        return entityId;
    }

    public void Delete(int id)
    {
        const string query = "delete from availibility_in_restaurant where Id = @Id;";
        Connection.ExecuteScalar(query, new
        {
            Id = id,
        });
    }

    public AvailibilityInRestaurant Get(int id)
    {
        const string query = @"
SELECT 
	s.id, 
	s.restaurant_id     as RestaurantId, 
	s.product_id        as ProductId, 
	s.unit_id           as UnitId, 
	s.quantity          as Quantity, 
	s.price             as Price
FROM availibility_in_restaurant s
WHERE
    s.Id = @Id;
    ";
        var entityDb = Connection.QueryFirstOrDefault<AvailibilityInRestaurantDb>(query, new
        {
            Id = id
        });

        return entityDb?.ToDomain();
    }

    public void Update(AvailibilityInRestaurant entity)
    {
        const string query = @"
UPDATE availibility_in_restaurant SET
    restaurant_id   = @RestaurantId,  
    product_id      = @ProductId,
    unit_id         = @UnitId, 
    quantity        = @Quantity, 
    price           = @Price
where Id = @Id;";
        var entityDb = entity.ToStorage();
        Connection.ExecuteScalar(query, entityDb);
    }

    public IReadOnlyCollection<AvailibilityInRestaurantView> List(int? restaurantId)
    {
        const string query = @"
SELECT 
	s.id, 
	s.restaurant_id     as RestaurantId, 
	s.product_id        as ProductId, 
	s.unit_id           as UnitId, 
	s.quantity          as Quantity, 
	s.price             as Price,
	p.product_name      as ProductName,
	r.restaurant_name   as RestaurantName,
	u.unit_name         as UnitName
FROM applications_for_distribution s
	inner join restaurants r on r.id = s.restaurant_id 
	inner join units u on u.id = s.unit_id 
	inner join products p on p.id = s.product_id 
WHERE
    s.restaurant_id = @RestaurantId 
    ";
        IEnumerable<AvailibilityInRestaurantDbView> entities = Connection.Query<AvailibilityInRestaurantDbView>(query,
            new
            {
                RestaurantId = restaurantId
            });

        return entities.Select(x => x.ToDomain()).ToArray();
    }

    public AvailibilityInRestaurantView GetView(int id)
    {
        const string query = @"
SELECT 
	s.id, 
	s.restaurant_id     as RestaurantId, 
	s.product_id        as ProductId, 
	s.unit_id           as UnitId, 
	s.quantity          as Quantity, 
	s.price             as Price,
	p.product_name      as ProductName,
	r.restaurant_name   as RestaurantName,
	u.unit_name         as UnitName
FROM applications_for_distribution s
	inner join restaurants r on r.id = s.restaurant_id 
	inner join units u on u.id = s.unit_id 
	inner join products p on p.id = s.product_id 
WHERE
    s.id = @Id
    ";
        var entityDb = Connection.QueryFirstOrDefault<AvailibilityInRestaurantDbView>(query, new
        {
            Id = id
        });

        return entityDb?.ToDomain();
    }

    public AvailibilityInRestaurant Get(int productId, int restaurantId, decimal price)
    {
        const string query = @"
SELECT 
	s.id, 
	s.restaurant_id     as RestaurantId, 
	s.product_id        as ProductId, 
	s.unit_id           as UnitId, 
	s.quantity          as Quantity, 
	s.price             as Price
FROM availibility_in_restaurant s
WHERE
    s.restaurant_id = @RestaurantId and
    s.product_id = @ProductId and
    s.price = @Price;
    ";
        var entityDb = Connection.QueryFirstOrDefault<AvailibilityInRestaurantDb>(query, new
        {
            RestaurantId = restaurantId,
            Price = price,
            ProductId = productId
        });

        return entityDb?.ToDomain();
    }
}