using RestaurantChain.Domain.Models;
using RestaurantChain.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Domain.Services.Services
{
    internal sealed class ApplicationsForDistributionService : ServiceBase, IApplicationsForDistributionService
    {
        public ApplicationsForDistributionService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public ApplicationsForDistributionDomain Get()
        {
            throw new NotImplementedException();
        }
    }
}
