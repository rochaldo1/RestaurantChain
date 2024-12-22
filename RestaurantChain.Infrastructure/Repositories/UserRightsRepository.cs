using Dapper;
using Npgsql;
using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.Infrastructure.Converters;
using RestaurantChain.Infrastructure.Entities;
using RestaurantChain.Infrastructure.Entities.Views;
using RestaurantChain.Repository.Repositories;

namespace RestaurantChain.Infrastructure.Repositories;

internal sealed class UserRightsRepository : RepositoryBase, IUserRightsRepository
{
    public UserRightsRepository(NpgsqlConnection connection) : base(connection)
    {
    }

    public int Create(UserRights entity)
    {
        const string query = @"
INSERT INTO user_rights 
(
    user_id, 
    item_id, 
    r, 
    w, 
    e, 
    d
) 
VALUES
(
    @UserID, 
    @ItemId, 
    @R, 
    @W, 
    @E, 
    @D
)
returning Id;
    ";
        var entityDb = entity.ToStorage();
        return Connection.ExecuteScalar<int>(query, entityDb);
    }

    public void DeleteByUserId(int userId)
    {
        const string query = "delete from user_rights where user_id = @UserId;";
        Connection.ExecuteScalar(query, new
        {
            UserId = userId,
        });
    }

    public void Delete(int id)
    {
        const string query = "delete from user_rights where Id = @Id;";
        Connection.ExecuteScalar(query, new
        {
            Id = id,
        });
    }

    public UserRights Get(int id)
    {
        const string query = @"
SELECT 
	ur.id       as Id, 
	ur.user_id  as UserID, 
	ur.item_id  as ItemId, 
	ur.r        as R, 
	ur.w        as W, 
	ur.e        as E, 
	ur.d        as D
FROM user_rights ur
WHERE
    id = @id;
    ";
        var entityDb = Connection.QueryFirstOrDefault<UserRightsDb>(query, new
        {
            Id = id
        });

        return entityDb?.ToDomain();
    }

    public void Update(UserRights entity)
    {
        const string query = @"
UPDATE user_rights SET 
    user_id = @UserID,
    item_id = @ItemId,
    r       = @R, 
    w       = @W, 
    e       = @E, 
    d       = @D
WHERE 
    Id = @Id;
    ";
        var entityDb = entity.ToStorage();
        Connection.ExecuteScalar(query, entityDb);
    }

    public IReadOnlyCollection<UserRightsView> List(int userId)
    {
        const string query = @"
SELECT 
	ur.id       as Id, 
	ur.user_id  as UserID, 
	ur.item_id  as ItemId, 
	ur.r        as R, 
	ur.w        as W, 
	ur.e        as E, 
	ur.d        as D,
	u.login     as UserName,
	m.item_name as ItemName
FROM user_rights ur
	inner join users u on u.id = ur.user_id 
	inner join menu m on m.id = ur.item_id
WHERE
    ur.user_id = @UserId
order by 
    u.login,
    m.item_name
";
        IEnumerable<UserRightsDbView> entities = Connection.Query<UserRightsDbView>(query,new
        {
            UserId = userId
        });

        return entities.Select(x => x.ToDomain()).ToArray();
    }

    public UserRightsView GetView(int id)
    {
        const string query = @"
SELECT 
	ur.id       as Id, 
	ur.user_id  as UserID, 
	ur.item_id  as ItemId, 
	ur.r        as R, 
	ur.w        as W, 
	ur.e        as E, 
	ur.d        as D,
	u.login     as UserName,
	m.item_name as ItemName
FROM user_rights ur
	inner join users u on u.id = ur.user_id 
	inner join menu m on m.id = ur.item_id
WHERE
    id = @id;
    ";
        var entityDb = Connection.QueryFirstOrDefault<UserRightsDbView>(query, new
        {
            Id = id
        });

        return entityDb?.ToDomain();
    }

    public void CreateDefaultRights(int userId)
    {
        const string query = @"
INSERT INTO public.user_rights (user_id, item_id, r, w, e, d) 
  values
  (@UserId, 1, true, true, true, true),
  (@UserId, 2, false, false, false, false),
  (@UserId, 3, false, false, false, false),
  (@UserId, 4, false, false, false, false),
  (@UserId, 5, false, false, false, false),
  (@UserId, 6, false, false, false, false),
  (@UserId, 7, false, false, false, false),
  (@UserId, 8, true, true, true, true),
  (@UserId, 9, true, true, true, true),
  (@UserId, 10, false, false, false, false),
  (@UserId, 11, false, false, false, false),
  (@UserId, 12, false, false, false, false),
  (@UserId, 13, false, false, false, false),
  (@UserId, 14, false, false, false, false),
  (@UserId, 15, false, false, false, false),
  (@UserId, 16, false, false, false, false),
  (@UserId, 17, false, false, false, false),
  (@UserId, 18, false, false, false, false),
  (@UserId, 19, false, false, false, false),
  (@UserId, 20, false, false, false, false),
  (@UserId, 21, true, true, true, true),
  (@UserId, 22, true, true, true, true)";
        Connection.ExecuteScalar(query, new
        {
            UserId = userId,
        });
    }
}