using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;

namespace RestaurantChain.Repository.Repositories;

public interface IApplicationsForDistributionRepository : IRepositoryBase<ApplicationsForDistribution>
{
    IReadOnlyCollection<ApplicationsForDistributionView> List(int? restaurantId, DateTime? from, DateTime? to);
    ApplicationsForDistributionView GetView(int id);
    int CountByProduct(int productId);
}