using RestaurantChain.Domain.Models;
using RestaurantChain.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Domain.Services.Conventors
{
    internal static class SuppliersConvertor
    {
        public static SuppliersDomain ToDomain(this Suppliers supplier)
        {
            return new SuppliersDomain
            {
                Id = supplier.Id,
                BankId = supplier.BankId,
                StreetId = supplier.StreetId,
                SupplierName = supplier.SupplierName,
                PhoneNumber = supplier.PhoneNumber,
                SupervisorName = supplier.SupervisorName,
                SupervisorLastName = supplier.SupervisorLastName,
                SupervisorSurname = supplier.SupervisorSurname,
                CurrentAccount = supplier.CurrentAccount,
                TIN = supplier.TIN
            };
        }

        public static Suppliers ToStorage(this SuppliersDomain supplier)
        {
            return new Suppliers
            {
                Id = supplier.Id,
                BankId = supplier.BankId,
                StreetId = supplier.StreetId,
                SupplierName = supplier.SupplierName,
                PhoneNumber = supplier.PhoneNumber,
                SupervisorName = supplier.SupervisorName,
                SupervisorLastName = supplier.SupervisorLastName,
                SupervisorSurname = supplier.SupervisorSurname,
                CurrentAccount = supplier.CurrentAccount,
                TIN = supplier.TIN
            };
        }
    }
}
