namespace RestaurantChain.DomainServices.Contracts;

/// <summary>
/// Сервис для работы с отчетами
/// </summary>
public interface IReportsService
{
    string GetDishesSumByPeriod(DateTime startDate, DateTime endDate);
    string GetRestaurantSumByPeriods(DateTime startDate, DateTime endDate);
}