using RestaurantChain.Domain.Models.View;
using RestaurantChain.Domain.Models;

namespace RestaurantChain.DomainServices.Contracts;

public interface IApplicationsForDistributionService
{
    IReadOnlyCollection<ApplicationsForDistributionView> List(int? restaurantId, DateTime? from, DateTime? to);
    int Create(ApplicationsForDistribution applicationsForDistribution);
    void Update(ApplicationsForDistribution applicationsForDistribution);
    void Delete(int id);
    ApplicationsForDistributionView Get(int id);
}