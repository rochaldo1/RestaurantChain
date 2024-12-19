using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.Infrastructure.Entities;
using RestaurantChain.Infrastructure.Entities.Views;

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
        
        public static SuppliersView ToDomain(this SuppliersDbView supplier)
        {
            return new SuppliersView()
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
                TIN = supplier.TIN,
                BankName = supplier.BankName,
                StreetName = supplier.StreetName,
            };
        }
    }
}
