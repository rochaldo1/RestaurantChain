using Dapper;
using Npgsql;
using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.Infrastructure.Converters;
using RestaurantChain.Infrastructure.Entities;
using RestaurantChain.Infrastructure.Entities.Views;
using RestaurantChain.Repository.Repositories;

namespace RestaurantChain.Infrastructure.Repositories;

internal sealed class ApplicationsForDistribuitonRepository : RepositoryBase, IApplicationsForDistributionRepository
{
    public ApplicationsForDistribuitonRepository(NpgsqlConnection connection) : base(connection)
    {
    }

    public int Create(ApplicationsForDistribution entity)
    {
        const string query = @"
INSERT INTO public.applications_for_distribution 
(
    restaurant_id, 
    product_id, 
    unit_id, 
    application_date, 
    quantity, 
    price
) VALUES
(
    @RestaurantId, 
    @ProductId,
    @UnitId, 
    @ApplicationDate, 
    @Quantity,
    @Price
) returning Id;";
        var entityDb = entity.ToStorage();
        var entityId = Connection.ExecuteScalar<int>(query, entityDb);

        return entityId;
    }

    public void Delete(int id)
    {
        const string query = "delete from applications_for_distribution where Id = @Id;";
        Connection.ExecuteScalar(query, new
        {
            Id = id,
        });
    }

    public ApplicationsForDistribution Get(int id)
    {
        const string query = @"
SELECT 
	s.id, 
	s.restaurant_id     as RestaurantId, 
	s.product_id        as ProductId, 
	s.unit_id           as UnitId, 
	s.application_date  as ApplicationDate, 
	s.quantity          as Quantity, 
	s.price             as Price
FROM applications_for_distribution s
WHERE
    s.Id = @Id;
    ";
        var entityDb = Connection.QueryFirstOrDefault<ApplicationsForDistributionDb>(query, new
        {
            Id = id
        });

        return entityDb?.ToDomain();
    }

    public void Update(ApplicationsForDistribution entity)
    {
        const string query = @"
UPDATE public.applications_for_distribution SET
    restaurant_id = @RestaurantId,  
    product_id  = @ProductId,
    unit_id     = @UnitId, 
    application_date = @ApplicationDate, 
    quantity    = @Quantity, 
    price       = @Price
where Id = @Id;";
        var entityDb = entity.ToStorage();
        Connection.ExecuteScalar(query, entityDb);
    }

    public IReadOnlyCollection<ApplicationsForDistributionView> List(int? restaurantId, DateTime? from, DateTime? to)
    {
        const string query = @"
SELECT 
	s.id, 
	s.restaurant_id     as RestaurantId, 
	s.product_id        as ProductId, 
	s.unit_id           as UnitId, 
	s.application_date  as ApplicationDate, 
	s.quantity          as Quantity, 
	s.price             as Price,
	p.product_name      as ProductName,
	r.restaurant_name   as RestaurantName,
	u.unit_name         as UnitName,
    s.price * s.quantity as SumPrice
FROM applications_for_distribution s
	inner join restaurants r on r.id = s.restaurant_id 
	inner join units u on u.id = s.unit_id 
	inner join products p on p.id = s.product_id 
WHERE
    s.restaurant_id = @RestaurantId 
    AND (@From is null OR s.application_date >= @From)
    AND (@To is null OR s.application_date <= @To);
    ";
        IEnumerable<ApplicationsForDistributionDbView> entities = Connection.Query<ApplicationsForDistributionDbView>(query,
            new
            {
                RestaurantId = restaurantId,
                From = from,
                To = to
            });

        return entities.Select(x => x.ToDomain()).ToArray();

    }

    public ApplicationsForDistributionView GetView(int id)
    {
        const string query = @"
SELECT 
	s.id, 
	s.restaurant_id     as RestaurantId, 
	s.product_id        as ProductId, 
	s.unit_id           as UnitId, 
	s.application_date  as ApplicationDate, 
	s.quantity          as Quantity, 
	s.price             as Price,
	p.product_name      as ProductName,
	r.restaurant_name    as RestaurantName,
	u.unit_name         as UnitName,
    s.price * s.quantity as SumPrice
FROM applications_for_distribution s
	inner join restaurants r on r.id = s.restaurant_id 
	inner join units u on u.id = s.unit_id 
	inner join products p on p.id = s.product_id 
WHERE
    s.Id = @Id;
    ";
        var entityDb = Connection.QueryFirstOrDefault<ApplicationsForDistributionDbView>(query, new
        {
            Id = id
        });

        return entityDb?.ToDomain();
    }

    public int CountByProduct(int productId)
    {
        const string query = @"
select 
    SUM(quantity) 
from applications_for_distribution 
where 
    product_id = @id";
        return Connection.ExecuteScalar<int>(query, new
        {
            Id = productId
        });
    }
}