using RestaurantChain.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.DomainServices.Contracts
{
    public interface IDishesService
    {
        Dishes Get(int id);
        int Create(Dishes product);
        void Update(Dishes product);
        void Delete(int id);
        IReadOnlyCollection<Dishes> List();
    }
}
