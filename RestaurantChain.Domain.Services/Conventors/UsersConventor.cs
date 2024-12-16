using RestaurantChain.Domain.Models;
using RestaurantChain.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Domain.Services.Conventors
{
    internal static class UsersConventor
    {
        public static UsersDomain ToDomain(this Users user)
        {
            return new UsersDomain
            {
                Id = user.Id,
                Login = user.Login,
                Password = user.Password,
            };
        }

        public static Users ToStorage(this UsersDomain user)
        {
            return new Users
            {
                Id = user.Id,
                Login = user.Login,
                Password = user.Password,
            };
        }
    }
}
