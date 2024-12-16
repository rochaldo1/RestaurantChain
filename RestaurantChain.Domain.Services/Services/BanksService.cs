using RestaurantChain.Domain.Models;
using RestaurantChain.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Domain.Services.Services
{
    internal sealed class BanksService : ServiceBase, IBanksService
    {
        public BanksService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public BanksDomain Get()
        {
            throw new NotImplementedException();
        }
    }
}
