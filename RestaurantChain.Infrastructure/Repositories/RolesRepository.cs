using Dapper;

using Npgsql;

using RestaurantChain.Domain.Models;
using RestaurantChain.Infrastructure.Converters;
using RestaurantChain.Infrastructure.Entities;
using RestaurantChain.Repository.Repositories;

namespace RestaurantChain.Infrastructure.Repositories;

internal sealed class RolesRepository : RepositoryBase, IRolesRepository
{
    public RolesRepository(NpgsqlConnection connection) : base(connection)
    {
    }

    public int Create(Roles entity)
    {
        const string query = @"
    insert into roles (
                        name
                      ) 
                values(
                        @Name
                      ) 
    returning Id;
    ";

        return Connection.ExecuteScalar<int>(query, entity.ToStorage());
    }

    public void Delete(int id)
    {
        const string query = @"delete from roles where Id = @Id;";
        Connection.ExecuteScalar<int>(
            query,
            new
            {
                Id = id
            });
    }

    public Roles Get(int id)
    {
        const string query = @"
    select  Id, 
            name as Name 
    from roles 
    where id = @id;
    ";
        var entity = Connection.QueryFirstOrDefault<RolesDb>(
            query,
            new
            {
                Id = id
            });

        return entity?.ToDomain();
    }

    public void Update(Roles entity)
    {
        const string query = @"
    update roles 
        set name = @Name 
    where Id = @Id;
    ";
        RolesDb entityDb = entity.ToStorage();
        Connection.ExecuteScalar(query, entityDb);
    }

    public IReadOnlyCollection<Roles> List()
    {
        const string query = @"
    select  Id, 
            name as Name 
    from roles 
    order by name;
    ";
        IEnumerable<RolesDb> entities = Connection.Query<RolesDb>(query);

        return entities.Select(x => x.ToDomain()).ToArray();
    }
}