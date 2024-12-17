using RestaurantChain.Domain.Models;
using RestaurantChain.Infrastructure.Entities;

namespace RestaurantChain.Infrastructure.Converters
{
    internal static class SuppliersConverter
    {
        public static Suppliers ToDomain(this SuppliersDb supplier)
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

        public static SuppliersDb ToStorage(this Suppliers supplier)
        {
            return new SuppliersDb
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
