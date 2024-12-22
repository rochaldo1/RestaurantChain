using Dapper;

using Npgsql;
using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.Infrastructure.Converters;
using RestaurantChain.Infrastructure.Entities;
using RestaurantChain.Infrastructure.Entities.Views;
using RestaurantChain.Repository.Repositories;

namespace RestaurantChain.Infrastructure.Repositories;

internal sealed class RestaurantsRepository : RepositoryBase, IRestaurantsRepository
{
    public RestaurantsRepository(NpgsqlConnection connection) : base(connection)
    {
    }

    public int Create(Restaurants entity)
    {
        const string query = @"
INSERT INTO public.restaurants 
(
    street_id, 
    phone_number, 
    director_name, 
    director_last_name, 
    director_surname, 
    restaurant_name
) 
VALUES
(
    @StreetId, 
    @PhoneNumber, 
    @DirectorName, 
    @DirectorLastName, 
    @DirectorSurname, 
    @RestaurantName
)
returning Id;
    ";
        var entityDb = entity.ToStorage();
        var entityId = Connection.ExecuteScalar<int>(query, entityDb);

        return entityId;
    }

    public void Delete(int id)
    {
        const string query = "delete from restaurants where Id = @Id;";
        Connection.ExecuteScalar(query, new
        {
            Id = id,
        });
    }

    public Restaurants Get(int id)
    {
        const string query = @"
SELECT 
    id                  AS Id,     
    street_id           AS StreetId, 
    phone_number        AS PhoneNumber, 
    director_name       AS DirectorName, 
    director_last_name  AS DirectorLastName, 
    director_surname    AS DirectorSurname, 
    restaurant_name     AS RestaurantName
FROM restaurants
WHERE
    id = @id;
    ";
        var entityDb = Connection.QueryFirstOrDefault<RestaurantsDb>(query, new
        {
            Id = id
        });

        return entityDb?.ToDomain();
    }

    public void Update(Restaurants entity)
    {
        const string query = @"
UPDATE public.restaurants SET
    street_id           = @StreetId, 
    phone_number        = @PhoneNumber, 
    director_name       = @DirectorName, 
    director_last_name  = @DirectorLastName, 
    director_surname    = @DirectorSurname, 
    restaurant_name     = @RestaurantName
where
    Id = @Id;
    ";
        var entityDb = entity.ToStorage();
        Connection.ExecuteScalar(query, entityDb);
    }

    public Restaurants Get(string name)
    {
        const string query = @"
SELECT 
    id                  AS Id,     
    street_id           AS StreetId, 
    phone_number        AS PhoneNumber, 
    director_name       AS DirectorName, 
    director_last_name  AS DirectorLastName, 
    director_surname    AS DirectorSurname, 
    restaurant_name     AS RestaurantName
FROM restaurants
WHERE
    restaurant_name = @Name;
    ";
        var entityDb = Connection.QueryFirstOrDefault<RestaurantsDb>(query, new
        {
            Name = name
        });

        return entityDb?.ToDomain();
    }

    public IReadOnlyCollection<RestaurantsView> List()
    {
        const string query = @"
SELECT 
    r.id                  AS Id,     
    r.street_id           AS StreetId, 
    r.phone_number        AS PhoneNumber, 
    r.director_name       AS DirectorName, 
    r.director_last_name  AS DirectorLastName, 
    r.director_surname    AS DirectorSurname, 
    r.restaurant_name     AS RestaurantName,
    s.street_name         AS StreetName
FROM restaurants r
   inner join public.streets s on r.street_id = s.id
order by r.restaurant_name;
";
        IEnumerable<RestaurantsDbView> entities = Connection.Query<RestaurantsDbView>(query);

        return entities.Select(x => x.ToDomain()).ToArray();
    }
}