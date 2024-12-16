using RestaurantChain.Domain.Models;
using RestaurantChain.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Domain.Services.Services
{
    internal sealed class StreetsService : ServiceBase, IStreetsService
    {
        public StreetsService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public StreetsDomain Get()
        {
            throw new NotImplementedException();
        }
    }
}
