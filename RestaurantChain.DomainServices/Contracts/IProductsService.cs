using RestaurantChain.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.DomainServices.Contracts
{
    public interface IProductsService
    {
        Products Get(int id);
        int Create(Products product);
        void Update(Products product);
        void Delete(int id);
        IReadOnlyCollection<Products> List();
    }
}
