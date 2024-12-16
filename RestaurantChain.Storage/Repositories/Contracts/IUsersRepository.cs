using RestaurantChain.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace RestaurantChain.Storage.Repositories.Contracts
{
    public interface IUsersRepository : IRepositoryBase<Users>
    {
        Users Get(string login, string password);
    }
}
