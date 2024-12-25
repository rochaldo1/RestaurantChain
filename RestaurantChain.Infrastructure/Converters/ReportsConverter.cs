using RestaurantChain.Domain.Models.Reports;
using RestaurantChain.Infrastructure.Entities.Reports;

namespace RestaurantChain.Infrastructure.Converters;

internal static class ReportsConverter
{
    /// <summary>
    /// Преобразовать сущность БД в доменную модель
    /// </summary>
    /// <returns>Доменная модель</returns>
    public static DishesSumByPeriod ToDomain(this DishesSumByPeriodDb db)
    {
        return new DishesSumByPeriod
        {
            SaleCount = db.SaleCount,
            Price = db.Price,
            Date = db.Date,
            GroupName = db.GroupName,
            DishName = db.DishName,
            RestaurantName = db.RestaurantName,
        };
    }

    /// <summary>
    /// Преобразовать сущность БД в доменную модель
    /// </summary>
    /// <returns>Доменная модель</returns>
    public static RestaurantSumByPeriod ToDomain(this RestaurantSumByPeriodDb db)
    {
        return new RestaurantSumByPeriod
        {
            SaleCount = db.SaleCount,
            Price = db.Price,
            Date = db.Date,
            RestaurantName = db.RestaurantName
        };
    }
}