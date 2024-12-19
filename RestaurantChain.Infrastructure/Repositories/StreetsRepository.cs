using Dapper;
using Npgsql;
using RestaurantChain.Domain.Models;
using RestaurantChain.Infrastructure.Converters;
using RestaurantChain.Infrastructure.Entities;
using RestaurantChain.Repository.Repositories;

namespace RestaurantChain.Infrastructure.Repositories
{
    internal sealed class StreetsRepository : RepositoryBase, IStreetsRepository
    {
        public StreetsRepository(NpgsqlConnection connection) : base(connection)
        {
        }

        public int Create(Streets entity)
        {
            const string query = "insert into streets (street_name) values(@StreetName) returning Id;";
            var entityDb = entity.ToStorage();
            var streetId = Connection.ExecuteScalar<int>(query, entityDb);

            return streetId;
        }

        public void Delete(int id)
        {
            const string query = "delete from streets where Id = @Id;";
            Connection.ExecuteScalar(query, new
            {
                Id = id,
            });
        }

        public Streets Get(int id)
        {
            const string query = "select Id, street_name as StreetName from streets where id = @id";
            var streetsDb = Connection.QueryFirstOrDefault<StreetsDb>(query, new
            {
                Id = id
            });

            return streetsDb?.ToDomain();
        }

        public void Update(Streets entity)
        {
            const string query = "update streets set street_name = @StreetName where Id = @Id;";
            var entityDb = entity.ToStorage();
            Connection.ExecuteScalar(query, entityDb);
        }

        public Streets Get(string streetName)
        {
            const string query = "select Id, street_name as StreetName from streets where street_name = @name";
            var streetsDb = Connection.QueryFirstOrDefault<StreetsDb>(query, new
            {
                Name = streetName
            });

            return streetsDb?.ToDomain();
        }

        public IReadOnlyCollection<Streets> List()
        {
            const string query = "select Id, street_name as StreetName from streets order by street_name";
            IEnumerable<StreetsDb> entities = Connection.Query<StreetsDb>(query);

            return entities.Select(x => x.ToDomain()).ToArray();
        }
    }
}
