namespace RestaurantChain.DomainServices.Contracts;

/// <summary>
/// Сервис для работы с отчетами
/// </summary>
public interface IReportsService
{
    /// <summary>
    /// Отчет по блдам за период
    /// </summary>
    /// <param name="startDate"></param>
    /// <param name="endDate"></param>
    /// <returns></returns>
    string GetDishesSumByPeriod(DateTime startDate, DateTime endDate);
    
    /// <summary>
    /// Отчет по ресторанам за период
    /// </summary>
    /// <param name="startDate"></param>
    /// <param name="endDate"></param>
    /// <returns></returns>
    string GetRestaurantSumByPeriods(DateTime startDate, DateTime endDate);
}