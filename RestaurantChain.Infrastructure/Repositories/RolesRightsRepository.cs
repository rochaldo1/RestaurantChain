using Dapper;

using Npgsql;

using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.Infrastructure.Converters;
using RestaurantChain.Infrastructure.Entities;
using RestaurantChain.Infrastructure.Entities.Views;
using RestaurantChain.Repository.Repositories;

namespace RestaurantChain.Infrastructure.Repositories;

internal sealed class RolesRightsRepository : RepositoryBase, IRolesRightsRepository
{
    public RolesRightsRepository(NpgsqlConnection connection) : base(connection)
    {
    }

    public int Create(RolesRights entity)
    {
        const string query = @"insert into role_rights (role_id, menu_id, w, r, e, d)
values
(
    @RoleId,
    @MenuId,
    @W,
    @R,
    @E,
    @D
);
    returning Id;
    ";

        return Connection.ExecuteScalar<int>(query, entity.ToStorage());
    }

    public void Delete(int id)
    {
        const string query = @"delete from role_rights where Id = @Id;";
        Connection.ExecuteScalar<int>(
            query,
            new
            {
                Id = id
            });
    }

    public RolesRights Get(int id)
    {
        const string query = @"
    select  Id, 
            role_id as RoleId,
            menu_id as MenuId,
            r as R,
            d as D,
            e as E,
            w as W
    from role_rights 
    where id = @id;
    ";
        var entity = Connection.QueryFirstOrDefault<RolesRightsDb>(
            query,
            new
            {
                Id = id
            });

        return entity?.ToDomain();
    }

    public void Update(RolesRights entity)
    {
        const string query = @"
    update role_rights set
        role_id = @RoleId,
        menu_id = @MenuId,
        w = @W,
        r = @R,
        e = @E,
        d = @D
    where Id = @Id;
    ";
        RolesRightsDb entityDb = entity.ToStorage();
        Connection.ExecuteScalar(query, entityDb);
    }

    public IReadOnlyCollection<RolesRightsView> List(int roleId)
    {
        const string query = @"
    select  rr.Id,
            rr.role_id as RoleId,
            rr.menu_id as MenuId,
            rr.r as R,
            rr.d as D,
            rr.e as E,
            rr.w as W,
            r.name as RoleName,
            m.item_name as MenuName
    from role_rights rr
        inner join roles r on r.id = rr.role_id
        inner join menu m on m.id = rr.menu_id
    where
        rr.role_id = @RoleId
    ";
        IEnumerable<RolesRightsDbView> entities = Connection.Query<RolesRightsDbView>(query, new { RoleId = roleId });

        return entities.Select(x => x.ToDomain()).ToArray();
    }

    public IReadOnlyCollection<UserRoleRight> ListUserRoleRights(int userId)
    {
        const string query = @"
select
   rr.w  AS W,
   rr.r  AS R,
   rr.e  AS E,
   rr.d  AS D,
   rr.menu_id as Id,
   m.dll_name as DllName,
   m.item_name as ItemName,
   m.parent_id as ParentId,
   m.is_main as IsMain,
   m.method_name as MethodName,
   m.order_num as OrderNum
from role_rights rr
   inner join public.menu m on m.id = rr.menu_id
   inner join public.roles r on r.id = rr.role_id
   inner join public.users u on r.id = u.role_id
where
   u.id = @Id and
   rr.r = True
order by
   m.parent_id desc,
   m.order_num asc
    ";
        IEnumerable<UserRoleRightDb> entities = Connection.Query<UserRoleRightDb>(query, new { Id = userId });
        UserRoleRight[] menu = entities.Select(x => x.ToDomain()).ToArray();

        return GetTree(menu, parentId: null)
            .OrderBy(x => x.OrderNum)
            .ToArray();
    }

    private static UserRoleRight[] GetTree(IReadOnlyCollection<UserRoleRight> menu, int? parentId)
    {
        var result = new List<UserRoleRight>();

        UserRoleRight[] childs = menu.Where(x => x.ParentId == parentId).ToArray();

        foreach (UserRoleRight child in childs)
        {
            child.Childrens = GetTree(menu, child.Id);
            result.Add(child);
        }

        return result
            .OrderBy(x => x.OrderNum)
            .ToArray();
    }
}