using RestaurantChain.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.DomainServices.Contracts
{
    public interface IBanksService
    {
        Banks Get(int id);
        int Create(Banks bank);
        void Update(Banks bank);
        void Delete(int id);
        IReadOnlyCollection<Banks> List();
    }
}
