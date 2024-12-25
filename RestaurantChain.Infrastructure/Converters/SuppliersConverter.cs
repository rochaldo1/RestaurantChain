using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.Infrastructure.Entities;
using RestaurantChain.Infrastructure.Entities.Views;

namespace RestaurantChain.Infrastructure.Converters;

/// <summary>
/// Конвертер моделей для поставщиков
/// </summary>
internal static class SuppliersConverter
{
    /// <summary>
    /// Преобразовать сущность БД в доменную модель
    /// </summary>
    /// <returns>Доменная модель</returns>
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

    /// <summary>
    /// Преобразовать доменную модель в сущность БД
    /// </summary>
    /// <returns>Сущность БД</returns>
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
    
    /// <summary>
    /// Преобразовать сущность БД в доменную модель
    /// </summary>
    /// <returns>Доменная модель</returns>
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