using Npgsql;
using RestaurantChain.Storage.Entities;
using RestaurantChain.Storage.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Storage.Repositories
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
