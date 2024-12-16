using RestaurantChain.Domain.Models;
using RestaurantChain.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Domain.Services.Services
{
    internal sealed class ProductsService : ServiceBase, IProductsService
    {
        public ProductsService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public ProductsDomain Get()
        {
            throw new NotImplementedException();
        }
    }
}
