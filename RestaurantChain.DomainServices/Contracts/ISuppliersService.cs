using RestaurantChain.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.DomainServices.Contracts
{
    public interface ISuppliersService
    {
        Suppliers Get(int id);
        int Create(Suppliers supplier);
        void Update(Suppliers supplier);
        void Delete(int id);
        IReadOnlyCollection<Suppliers> List();
    }
}
