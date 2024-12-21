using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
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
        int Create(Dishes dish);
        void Update(Dishes dish);
        void Delete(int id);
        IReadOnlyCollection<DishesView> List();
    }
}
