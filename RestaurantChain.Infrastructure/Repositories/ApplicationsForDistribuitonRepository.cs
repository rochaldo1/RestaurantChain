using Npgsql;
using RestaurantChain.Domain.Models;
using RestaurantChain.Repository.Repositories;

namespace RestaurantChain.Infrastructure.Repositories
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
