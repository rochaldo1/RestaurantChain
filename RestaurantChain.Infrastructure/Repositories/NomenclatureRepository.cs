using Dapper;
using Npgsql;
using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.Infrastructure.Converters;
using RestaurantChain.Infrastructure.Entities;
using RestaurantChain.Infrastructure.Entities.Views;
using RestaurantChain.Repository.Repositories;

namespace RestaurantChain.Infrastructure.Repositories;

internal sealed class NomenclatureRepository : RepositoryBase, INomenclatureRepository
{
    public NomenclatureRepository(NpgsqlConnection connection) : base(connection)
    {
    }

    public int Create(Nomenclature entity)
    {
        const string query = @"
INSERT INTO nomenclature 
(
    restaurant_id, 
    dish_id) 
VALUES
(
    @RestaurantId, 
    @DishId
)
    returning Id;
    ";
        var entityDb = entity.ToStorage();
        return Connection.ExecuteScalar<int>(query, entityDb);
    }

    public void Delete(int id)
    {
        const string query = @"
delete from nomenclature 
where 
    Id = @Id;
    ";
        Connection.ExecuteScalar(query, new
        {
            Id = id,
        });
    }

    public Nomenclature Get(int id)
    {
        const string query = @"
SELECT 
    id              AS Id, 
    restaurant_id   AS RestaurantId, 
    dish_id         AS DishId
FROM nomenclature
where 
    id = @id
    ";
        var entityDb = Connection.QueryFirstOrDefault<NomenclatureDb>(query, new
        {
            Id = id
        });

        return entityDb?.ToDomain();
    }

    public void Update(Nomenclature entity)
    {
        const string query = @"
    update nomenclature set 
        restaurant_id = @RestaurantId,
        dish_id = @DishId       
    where Id = @Id;
    ";
        var entityDb = entity.ToStorage();
        Connection.ExecuteScalar(query, entityDb);
    }

    public IReadOnlyCollection<NomenclatureView> List(int restaurantId)
    {
        const string query = @"
SELECT 
    n.id              AS Id, 
    n.restaurant_id   AS RestaurantId, 
    n.dish_id         AS DishId,
    r.restaurant_name as RestaurantName,
    d.dish_name		  as DishName,
    d.group_id 		  as GroupId,
    d.price 		  as Price,
    god.group_name    as GroupName
FROM nomenclature n
	inner join restaurants r on r.id = n.restaurant_id 
	inner join dishes d on d.id = n.dish_id 
	inner join groups_of_dishes god on god.id = d.group_id 
WHERE
    n.restaurant_id = @RestaurantId;
    ";
        IEnumerable<NomenclatureDbView> entities = Connection.Query<NomenclatureDbView>(query,
            new
            {
                RestaurantId = restaurantId
            });

        return entities.Select(x => x.ToDomain()).ToArray();
    }
}