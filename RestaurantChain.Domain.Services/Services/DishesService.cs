using RestaurantChain.Domain.Models;
using RestaurantChain.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Domain.Services.Services
{
    internal sealed class DishesService : ServiceBase, IDishesService
    {
        public DishesService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public DishesDomain Get()
        {
            throw new NotImplementedException();
        }
    }
}
