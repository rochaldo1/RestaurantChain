using Dapper;

using Npgsql;

using RestaurantChain.Domain.Models;
using RestaurantChain.Infrastructure.Converters;
using RestaurantChain.Infrastructure.Entities;
using RestaurantChain.Repository.Repositories;

namespace RestaurantChain.Infrastructure.Repositories;

internal sealed class MenuRepository : RepositoryBase, IMenuRepository
{
    public MenuRepository(NpgsqlConnection connection) : base(connection)
    {
    }

    public int Create(Menu entity)
    {
        const string query = @"
INSERT INTO menu 
(
    parent_id, 
    item_name, 
    dll_name, 
    method_name, 
    order_num
) 
VALUES
(
    @ParentId, 
    @ItemName, 
    @DLLName,
    @MethodName, 
    @OrderNum
);
 returning Id;";
        MenuDb entityDb = entity.ToStorage();

        return Connection.ExecuteScalar<int>(query, entityDb);
    }

    public void Delete(int id)
    {
        const string query = "delete from menu where Id = @Id;";
        Connection.ExecuteScalar(
            query,
            new
            {
                Id = id
            });
    }

    public Menu Get(int id)
    {
        const string query = @"
SELECT 
	m.id            AS Id, 
	m.parent_id     as ParentId, 
	m.item_name     as ItemName, 
	m.dll_name      as DLLName, 
	m.method_name   as MethodName, 
	m.order_num     as OrderNum,
	m.is_main       as IsMain
FROM menu m
WHERE
    s.Id = @Id;
    ";
        var entityDb = Connection.QueryFirstOrDefault<MenuDb>(
            query,
            new
            {
                Id = id
            });

        return entityDb?.ToDomain();
    }

    public void Update(Menu entity)
    {
        const string query = @"
UPDATE menu SET 
    parent_id   = @ParentId, 
    item_name   = @ItemName, 
    dll_name    = @DLLName, 
    method_name = @MethodName, 
    order_num   = @OrderNum
WHERE 
    id=@Id
";
        MenuDb entityDb = entity.ToStorage();
        Connection.ExecuteScalar(query, entityDb);
    }

    public IReadOnlyCollection<Menu> List()
    {
        const string query = @"
SELECT 
	m.id            AS Id, 
	m.parent_id     as ParentId, 
	m.item_name     as ItemName, 
	m.dll_name      as DLLName, 
	m.method_name   as MethodName, 
	m.order_num     as OrderNum,
	m.is_main       as IsMain
FROM menu m
order by
    m.order_num
";

        IEnumerable<MenuDb> entities = Connection.Query<MenuDb>(query);

        return entities.Select(x => x.ToDomain())
            .OrderBy(x => x.ItemName)
            .ToArray();
    }
}