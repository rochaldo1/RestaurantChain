using Dapper;
using Npgsql;
using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.Infrastructure.Converters;
using RestaurantChain.Infrastructure.Entities;
using RestaurantChain.Infrastructure.Entities.Views;
using RestaurantChain.Repository.Repositories;

namespace RestaurantChain.Infrastructure.Repositories;

internal sealed class DishesRepository : RepositoryBase, IDishesRepository
{
    public DishesRepository(NpgsqlConnection connection) : base(connection)
    {
    }

    public int Create(Dishes entity)
    {
        const string query = @"
    insert into dishes (
                        group_id,
                        dish_name,
                        price
                       )
                values(
                        @GroupId,
                        @DishName,
                        @Price
                      )
    returning Id;
    ";
        var entityDb = entity.ToStorage();
        var entityId = Connection.ExecuteScalar<int>(query, entityDb);

        return entityId;
    }

    public void Delete(int id)
    {
        const string query = @"
    delete
    from dishes
    where Id = @Id;
    ";
        Connection.ExecuteScalar(query, new
        {
            Id = id,
        });
    }

    public Dishes Get(int id)
    {
        const string query = @"
    select  Id,
            group_id    as GroupId,
            dish_name   as DishName,
            price       as Price
    from dishes
    where id = @id;
    ";
        var entityDb = Connection.QueryFirstOrDefault<DishesDb>(query, new
        {
            Id = id
        });

        return entityDb?.ToDomain();
    }

    public Dishes Get(string name)
    {
        const string query = @"
    select  Id,
            group_id    as GroupId,
            dish_name   as DishName,
            price       as Price
    from dishes
    where dish_name = @name;
    ";
        var entityDb = Connection.QueryFirstOrDefault<DishesDb>(query, new
        {
            Name = name
        });

        return entityDb?.ToDomain();
    }

    public IReadOnlyCollection<DishesView> List()
    {
        const string query = @"
    select 	d.id            as id,
		    d.group_id      as GroupId,
		    d.dish_name     as DishName,
		    d.price         as Price,
		    g.group_name    as GroupName
    from public.dishes d
    join public.groups_of_dishes g on d.group_id = g.id;
    ";
        IEnumerable<DishesDbView> entities = Connection.Query<DishesDbView>(query);

        return entities.Select(x => x.ToDomain()).ToArray();
    }

    public void Update(Dishes entity)
    {
        const string query = @"
    update dishes set
            group_id = @GroupId,
            dish_name = @DishName,
            price = @Price
    where Id = @Id;
    ";
        var entityDb = entity.ToStorage();
        Connection.ExecuteScalar(query, entityDb);
    }
}