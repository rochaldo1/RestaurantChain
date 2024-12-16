using RestaurantChain.Domain.Models;
using RestaurantChain.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Domain.Services.Services
{
    internal sealed class GroupsOfDishesService : ServiceBase, IGroupsOfDishesService
    {
        public GroupsOfDishesService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public GroupsOfDishesDomain Get()
        {
            throw new NotImplementedException();
        }
    }
}
