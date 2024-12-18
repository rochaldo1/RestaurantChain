using Dapper;
using Npgsql;
using RestaurantChain.Domain.Models;
using RestaurantChain.Infrastructure.Converters;
using RestaurantChain.Infrastructure.Entities;
using RestaurantChain.Repository.Repositories;

namespace RestaurantChain.Infrastructure.Repositories
{
    internal sealed class UnitsRepository : RepositoryBase, IUnitsRepository
    {
        public UnitsRepository(NpgsqlConnection connection) : base(connection)
        {
        }

        public int Create(Units entity)
        {
            const string query = "insert into units (unit_name) values(@UnitName) returning Id";
            var entityDb = entity.ToStorage();
            var unitId = Connection.ExecuteScalar<int>(query, entityDb);

            return unitId;
        }

        public void Delete(int id)
        {
            const string query = "delete from units where Id = @Id";
            Connection.ExecuteScalar<int>(query, new
            {
                Id = id
            });
        }

        public Units Get(int id)
        {
            const string query = "select * from units where id = @id";
            var unitsDb = Connection.QueryFirstOrDefault<UnitsDb>(query, new
            {
                Id = id
            });

            return unitsDb?.ToDomain();
        }

        public Units Get(string unitName)
        {
            const string query = "select * from untis where unit_name = @name";
            var unitsDb = Connection.QueryFirstOrDefault<UnitsDb>(query, new
            {
                Name = unitName
            });

            return unitsDb?.ToDomain();
        }

        public void Update(Units entity)
        {
            const string query = "update units set unit_name = @UnitName where Id = @Id";
            var entityDb = entity.ToStorage();
            Connection.ExecuteScalar(query, entityDb);
        }
    }
}
