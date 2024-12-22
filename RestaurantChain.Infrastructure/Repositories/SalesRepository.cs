using Dapper;
using Npgsql;
using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.Infrastructure.Converters;
using RestaurantChain.Infrastructure.Entities;
using RestaurantChain.Infrastructure.Entities.Views;
using RestaurantChain.Repository.Repositories;

namespace RestaurantChain.Infrastructure.Repositories;

internal sealed class SalesRepository : RepositoryBase, ISalesRepository
{
    public SalesRepository(NpgsqlConnection connection) : base(connection)
    {
    }

    public int Create(Sales entity)
    {
        const string query = @"
INSERT INTO sales 
(
    restaurant_id, 
    dish_id, 
    price, 
    quantity, 
    sale_date
) 
VALUES
(
    @RestaurantId, 
    @DishId, 
    @Price, 
    @Quantity, 
    CURRENT_DATE
)
returning Id;
";
        var entityDb = entity.ToStorage();
        var entityId = Connection.ExecuteScalar<int>(query, entityDb);

        return entityId;
    }

    public void Delete(int id)
    {
        const string query = "delete from sales where Id = @Id;";
        Connection.ExecuteScalar(query, new
        {
            Id = id,
        });
    }

    public Sales Get(int id)
    {
        const string query = @"
SELECT 
	s.id				as Id, 
	s.restaurant_id 	as RestaurantId , 
	s.dish_id			as DishId, 
	s.price				as Price, 
	s.quantity			as Quantity, 
	s.sale_date			as SaleDate
FROM sales s
WHERE
    s.Id = @Id;
    ";
        var entityDb = Connection.QueryFirstOrDefault<SalesDb>(query, new
        {
            Id = id
        });

        return entityDb?.ToDomain();
    }

    public void Update(Sales entity)
    {
        const string query = @"
UPDATE sales SET 
	restaurant_id   = @RestaurantId, 
	dish_id         = @DishId,
	price           = @Price, 
	quantity        = @Quantity, 
	sale_date       = @SaleDate
WHERE id = @Id;";
        var entityDb = entity.ToStorage();
        Connection.ExecuteScalar(query, entityDb);
    }

    public IReadOnlyCollection<SalesView> List(int? restaurantId, DateTime? from, DateTime? to)
    {
        const string query = @"
SELECT 
	s.id				as Id, 
	s.restaurant_id 	as RestaurantId , 
	s.dish_id			as DishId, 
	s.price				as Price, 
	s.quantity			as Quantity, 
	s.sale_date			as SaleDate,
	r.restaurant_name 	as RestaurantName,
	d.group_id 			as GroupId,
	d.group_id 			as DishName,
	god.group_name		as GroupName,
	s.price * s.quantity as SumPrice
FROM sales s
	inner join restaurants r on r.id = s.restaurant_id 
	inner join dishes d on d.id = s.dish_id
	inner join groups_of_dishes god on god.id = d.group_id
WHERE
    s.restaurant_id = @RestaurantId 
    AND (@From is null OR s.sale_date >= @From)
    AND (@To is null OR s.sale_date <= @To);
    ";
        IEnumerable<SalesDbView> entities = Connection.Query<SalesDbView>(query,
            new
            {
                RestaurantId = restaurantId,
                From = from,
                To = to
            });

        return entities.Select(x => x.ToDomain()).ToArray();
    }

    public SalesView GetView(int id)
    {
        const string query = @"
SELECT 
	s.id				as Id, 
	s.restaurant_id 	as RestaurantId , 
	s.dish_id			as DishId, 
	s.price				as Price, 
	s.quantity			as Quantity, 
	s.sale_date			as SaleDate,
	r.restaurant_name 	as RestaurantName,
	d.group_id 			as GroupId,
	d.group_id 			as DishName,
	god.group_name		as GroupName,
	s.price * s.quantity as SumPrice
FROM sales s
	inner join restaurants r on r.id = s.restaurant_id 
	inner join dishes d on d.id = s.dish_id
	inner join groups_of_dishes god on god.id = d.group_id
WHERE
    s.id = @Id
    ";
        var entityDb = Connection.QueryFirstOrDefault<SalesDbView>(query, new
        {
            Id = id
        });

        return entityDb?.ToDomain();
    }
}