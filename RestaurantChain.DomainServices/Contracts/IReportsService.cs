namespace RestaurantChain.DomainServices.Contracts;

public interface IReportsService
{
    string GetDishesSumByPeriod(DateTime startDate, DateTime endDate);
    string GetRestaurantSumByPeriods(DateTime startDate, DateTime endDate);
}