using RestaurantChain.Domain.Conventors;
using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Services.Conventors;
using RestaurantChain.Storage;
using RestaurantChain.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Domain.Services.Services
{
    internal sealed class UsersService : ServiceBase, IUsersService
    {
        public UsersService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public UsersDomain Get(string login, string password)
        {
            var user = _unitOfWork.UsersRepository.Get(login, password);
            return user?.ToDomain();
        }
    }
}
