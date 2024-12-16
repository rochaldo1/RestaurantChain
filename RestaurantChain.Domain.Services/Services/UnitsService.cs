using RestaurantChain.Domain.Models;
using RestaurantChain.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Domain.Services.Services
{
    internal sealed class UnitsService : ServiceBase, IUnitsService
    {
        public UnitsService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public UnitsDomain Get()
        {
            throw new NotImplementedException();
        }
    }
}
