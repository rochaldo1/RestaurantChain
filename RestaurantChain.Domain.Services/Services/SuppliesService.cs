using RestaurantChain.Domain.Models;
using RestaurantChain.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Domain.Services.Services
{
    internal sealed class SuppliesService : ServiceBase, ISuppliesService
    {
        public SuppliesService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public SuppliesDomain Get()
        {
            throw new NotImplementedException();
        }
    }
}
