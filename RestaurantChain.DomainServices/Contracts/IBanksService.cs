﻿using RestaurantChain.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.DomainServices.Contracts
{
    public interface IBanksService
    {
        int Create(Banks bank);
        void Update(Banks bank);
    }
}
