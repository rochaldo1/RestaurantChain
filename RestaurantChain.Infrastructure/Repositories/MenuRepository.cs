using Dapper;
using Npgsql;
using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.Infrastructure.Converters;
using RestaurantChain.Infrastructure.Entities;
using RestaurantChain.Infrastructure.Entities.Views;
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

    public IReadOnlyCollection<MenuView> List()
    {
        const string query = @"
WITH RECURSIVE rec AS (
  select
  	id, 
  	parent_id,
  	item_name,
  	dll_name,
  	method_name,
  	1 AS level,
  	order_num
  FROM menu
  WHERE parent_id is null -- START
  
  UNION ALL 
  
  SELECT 
  	c.id, 
  	c.parent_id,
  	c.item_name,
  	c.dll_name,
  	c.method_name,
  	p.level+1,
  	c.order_num
  FROM menu 
  	c JOIN rec p ON c.parent_id = p.id
) 

select
	rec.id 	as Id,
	rec.parent_id	as ParentId,
	rec.item_name	as ItemName,
	rec.dll_name 	as DLLName,
	rec.method_name as MethodName,
	rec.level 		as Level,
	rec.order_num 	as OrderNum
FROM rec 
ORDER BY 
	level asc,
	order_num asc;";

        IEnumerable<MenuDbView> entities = Connection.Query<MenuDbView>(query);

        return entities.Select(x => x.ToDomain()).ToArray();
    }
}