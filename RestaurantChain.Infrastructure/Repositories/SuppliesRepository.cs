using Dapper;

using Npgsql;
using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.Infrastructure.Converters;
using RestaurantChain.Infrastructure.Entities;
using RestaurantChain.Infrastructure.Entities.Views;
using RestaurantChain.Repository.Repositories;

namespace RestaurantChain.Infrastructure.Repositories;

internal sealed class SuppliesRepository : RepositoryBase, ISuppliesRepository
{
    public SuppliesRepository(NpgsqlConnection connection) : base(connection)
    {
    }

    public int Create(Supplies entity)
    {
        const string query = @"
INSERT INTO public.supplies 
(
    supplier_id, 
    product_id, 
    unit_id, 
    supply_date, 
    quantity, 
    price
) VALUES
(
    @SupplierId, 
    @ProductId,
    @UnitId, 
    @SupplyDate, 
    @Quantity,
    @Price
) returning Id;";
        var entityDb = entity.ToStorage();
        var entityId = Connection.ExecuteScalar<int>(query, entityDb);

        return entityId;
    }

    public void Delete(int id)
    {
        const string query = "delete from supplies where Id = @Id;";
        Connection.ExecuteScalar(query, new
        {
            Id = id,
        });
    }

    public SuppliesView GetView(int id)
    {
        const string query = @"
SELECT 
	s.id, 
	s.supplier_id       as SupplierId, 
	s.product_id        as ProductId, 
	s.unit_id           as UnitId, 
	s.supply_date       as SupplyDate, 
	s.quantity          as Quantity, 
	s.price             as Price,
	p.product_name      as ProductName,
	sr.supplier_name    as SupplierName,
	u.unit_name         as UnitName,
    s.price * s.quantity as SumPrice
FROM supplies s
	inner join suppliers sr on sr.id = s.supplier_id 
	inner join units u on u.id = s.unit_id 
	inner join products p on p.id = s.product_id 
WHERE
    s.Id = @Id;
    ";
        var entityDb = Connection.QueryFirstOrDefault<SuppliesDbView>(query, new
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
from public.supplies 
where 
    product_id = @id";
        return Connection.ExecuteScalar<int>(query, new
        {
            Id = productId
        });
    }

    public Supplies Get(int id)
    {
        const string query = @"
SELECT 
	s.id, 
	s.supplier_id       as SupplierId, 
	s.product_id        as ProductId, 
	s.unit_id           as UnitId, 
	s.supply_date       as SupplyDate, 
	s.quantity          as Quantity, 
	s.price             as Price
FROM supplies s
WHERE
    s.Id = @Id;
    ";
        var entityDb = Connection.QueryFirstOrDefault<SuppliesDb>(query, new
        {
            Id = id
        });

        return entityDb?.ToDomain();
    }

    public void Update(Supplies entity)
    {
        const string query = @"
UPDATE public.supplies SET
    supplier_id = @SupplierId,  
    product_id  = @ProductId,
    unit_id     = @UnitId, 
    supply_date = @SupplyDate, 
    quantity    = @Quantity, 
    price       = @Price
where Id = @Id;";
        var entityDb = entity.ToStorage();
        Connection.ExecuteScalar(query, entityDb);
    }

    public IReadOnlyCollection<SuppliesView> List(int? supplierId, DateTime? from, DateTime? to)
    {
        const string query = @"
SELECT 
	s.id, 
	s.supplier_id       as SupplierId, 
	s.product_id        as ProductId, 
	s.unit_id           as UnitId, 
	s.supply_date       as SupplyDate, 
	s.quantity          as Quantity, 
	s.price             as Price,
	p.product_name      as ProductName,
	sr.supplier_name    as SupplierName,
	u.unit_name         as UnitName,
    s.price * s.quantity as SumPrice
FROM supplies s
	inner join suppliers sr on sr.id = s.supplier_id 
	inner join units u on u.id = s.unit_id 
	inner join products p on p.id = s.product_id 
WHERE
    s.supplier_id = @SupplierId 
    AND (@From is null OR s.supply_date >= @From)
    AND (@To is null OR s.supply_date <= @To);
    ";
        IEnumerable<SuppliesDbView> entities = Connection.Query<SuppliesDbView>(query,
            new
            {
                SupplierId = supplierId,
                From = from,
                To = to
            });

        return entities.Select(x => x.ToDomain()).ToArray();
    }
}