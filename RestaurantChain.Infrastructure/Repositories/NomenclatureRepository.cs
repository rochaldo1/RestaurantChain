using Npgsql;
using RestaurantChain.Domain.Models;
using RestaurantChain.Repository.Repositories;

namespace RestaurantChain.Infrastructure.Repositories
{
    internal sealed class NomenclatureRepository : RepositoryBase, INomenclatureRepository
    {
        public NomenclatureRepository(NpgsqlConnection connection) : base(connection)
        {
        }

        public int Create(Nomenclature entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Nomenclature Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Nomenclature entity)
        {
            throw new NotImplementedException();
        }
    }
}
