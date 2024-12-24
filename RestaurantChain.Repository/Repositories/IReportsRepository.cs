using RestaurantChain.Domain.Models.Reports;

namespace RestaurantChain.Repository.Repositories;

/// <summary>
/// Отчеты
/// </summary>
public interface IReportsRepository
{
    /// <summary>
    /// Продажи блюд по группам
    /// </summary>
    /// <param name="startDate">Период с</param>
    /// <param name="endDate">Период по</param>
    /// <returns></returns>
    IReadOnlyCollection<DishesSumByPeriod> GetDishesSumByPeriod(DateTime startDate, DateTime endDate);
    
    /// <summary>
    /// Продажи по ресторанам
    /// </summary>
    /// <param name="startDate">Период с</param>
    /// <param name="endDate">Период по</param>
    /// <returns></returns>
    IReadOnlyCollection<RestaurantSumByPeriod> GetRestaurantSumByPeriods(DateTime startDate, DateTime endDate);
}