using RestaurantChain.Domain.Models;
using RestaurantChain.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Domain.Services.Services
{
    internal sealed class RestaurantsService : ServiceBase, IRestaurantsService
    {
        public RestaurantsService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public RestaurantsDomain Get()
        {
            throw new NotImplementedException();
        }
    }
}
