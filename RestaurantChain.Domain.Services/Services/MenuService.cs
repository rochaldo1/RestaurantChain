using RestaurantChain.Domain.Models;
using RestaurantChain.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Domain.Services.Services
{
    internal sealed class MenuService : ServiceBase, IMenuService
    {
        public MenuService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public MenuDomain Get()
        {
            throw new NotImplementedException();
        }
    }
}
