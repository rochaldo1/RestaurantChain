using RestaurantChain.Domain.Models;
using RestaurantChain.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Domain.Services.Services
{
    internal sealed class SalesService : ServiceBase, ISalesService
    {
        public SalesService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public SalesDomain Get()
        {
            throw new NotImplementedException();
        }
    }
}
