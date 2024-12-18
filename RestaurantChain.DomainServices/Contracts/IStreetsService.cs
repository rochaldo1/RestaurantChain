using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantChain.Domain.Models;

namespace RestaurantChain.DomainServices.Contracts
{
    public interface IStreetsService
    {
        Streets Get(int id);
        int Create(Streets street);
        void Update(Streets street);
    }
}
