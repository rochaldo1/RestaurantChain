﻿using RestaurantChain.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.DomainServices.Contracts
{
    public interface IUnitsService
    {
        int Create(Units unit);
        void Update(Units unit);
    }
}