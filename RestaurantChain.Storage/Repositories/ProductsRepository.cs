using Npgsql;
using RestaurantChain.Storage.Entities;
using RestaurantChain.Storage.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Storage.Repositories
{
    internal sealed class ProductsRepository : RepositoryBase, IProductsRepository
    {
        public ProductsRepository(NpgsqlConnection connection) : base(connection)
        {
        }

        public int Create(Products entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Products Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Products entity)
        {
            throw new NotImplementedException();
        }
    }
}
