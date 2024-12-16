using RestaurantChain.Domain.Models;
using RestaurantChain.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Domain.Services.Conventors
{
    internal static class BanksConvetor
    {
        public static BanksDomain ToDomain(Banks bank)
        {
            return new BanksDomain
            {
                Id = bank.Id,
                BankName = bank.BankName
            };
        }

        public static Banks ToStorage(BanksDomain bank)
        {
            return new Banks
            {
                Id = bank.Id,
                BankName = bank.BankName
            };
        }
    }
}
