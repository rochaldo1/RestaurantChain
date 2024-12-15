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
    internal sealed class ApplicationsForDistribuitonRepository : RepositoryBase, IApplicationsForDistributionRepository
    {
        public ApplicationsForDistribuitonRepository(NpgsqlConnection connection) : base(connection)
        {
        }

        public int Create(ApplicationsForDistribution entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ApplicationsForDistribution Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ApplicationsForDistribution entity)
        {
            throw new NotImplementedException();
        }
    }
}
