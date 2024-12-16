﻿using RestaurantChain.Domain.Models;
using RestaurantChain.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Domain.Services.Services
{
    internal class UserRightsService : ServiceBase, IUserRightsService
    {
        public UserRightsService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public UserRightsDomain Get()
        {
            throw new NotImplementedException();
        }
    }
}
