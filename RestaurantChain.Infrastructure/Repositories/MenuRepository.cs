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
        var entityDb = entity.ToStorage();
        return Connection.ExecuteScalar<int>(query, entityDb);
    }

    public void Delete(int id)
    {
        const string query = "delete from menu where Id = @Id;";
        Connection.ExecuteScalar(query, new
        {
            Id = id,
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
	m.order_num     as OrderNum
FROM menu m
WHERE
    s.Id = @Id;
    ";
        var entityDb = Connection.QueryFirstOrDefault<MenuDb>(query, new
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
        var entityDb = entity.ToStorage();
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
	m.order_num     as OrderNum
FROM menu m
order by
    m.order_num
";

        IEnumerable<MenuDb> entities = Connection.Query<MenuDb>(query);

        var menu = entities.Select(x => x.ToDomain()).ToArray();
        var result = GetTree(menu, null);
        return result
            .OrderBy(x => x.OrderNum)
            .ToArray();
    }

    private static IReadOnlyCollection<Menu> GetTree(IReadOnlyCollection<Menu> menu, int? parentId)
    {
        var result = new List<Menu>();

        var childs = menu.Where(x => x.ParentId == parentId).ToArray();
        foreach (var child in childs)
        {
            child.Childrens = GetTree(menu, child.Id);
            result.Add(child);
        }

        return result
            .OrderBy(x => x.OrderNum)
            .ToArray();
    }
}