using RestaurantChain.Domain.Models.Reports;

namespace RestaurantChain.Repository.Repositories;

public interface IReportsRepository
{
    IReadOnlyCollection<DishesSumByPeriod> GetDishesSumByPeriod(DateTime startDate, DateTime endDate);
    IReadOnlyCollection<RestaurantSumByPeriod> GetRestaurantSumByPeriods(DateTime startDate, DateTime endDate);
}