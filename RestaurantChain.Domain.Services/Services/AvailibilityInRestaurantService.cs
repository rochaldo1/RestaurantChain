using RestaurantChain.Domain.Models;
using RestaurantChain.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Domain.Services.Services
{
    internal sealed class AvailibilityInRestaurantService : ServiceBase, IAvailibilityInRestaurantService
    {
        public AvailibilityInRestaurantService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public AvailibilityInRestaurantDomain Get()
        {
            throw new NotImplementedException();
        }
    }
}
