using RestaurantChain.Domain.Conventors;
using RestaurantChain.Domain.Models;
using RestaurantChain.Storage;
using RestaurantChain.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Domain.Services
{
    public interface IUsersService
    {
        UsersDomain Get(string login, string password);
    }
}
