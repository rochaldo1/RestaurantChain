using RestaurantChain.Domain.Models;
using RestaurantChain.Infrastructure.Entities;

namespace RestaurantChain.Infrastructure.Converters
{
    internal static class UsersConventer
    {
        public static Users ToDomain(this UsersDb user)
        {
            return new Users
            {
                Id = user.Id,
                Login = user.Login,
                Password = user.Password,
            };
        }

        public static UsersDb ToStorage(this Users user)
        {
            return new UsersDb
            {
                Id = user.Id,
                Login = user.Login,
                Password = user.Password,
            };
        }
    }
}
