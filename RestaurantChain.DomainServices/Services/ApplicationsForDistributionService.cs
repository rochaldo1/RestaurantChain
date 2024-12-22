using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Repository;

namespace RestaurantChain.DomainServices.Services;

internal class ApplicationsForDistributionService : IApplicationsForDistributionService
{
    private readonly IUnitOfWork _unitOfWork;

    public ApplicationsForDistributionService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IReadOnlyCollection<ApplicationsForDistributionView> List(int? restaurantId, DateTime? from, DateTime? to)
    {
        if (restaurantId is null or < 0)
        {
            return Array.Empty<ApplicationsForDistributionView>();
        }

        return _unitOfWork.ApplicationsForDistributionRepository.List(restaurantId, from, to);
    }

    public int Create(ApplicationsForDistribution applicationsForDistribution)
    {
        return _unitOfWork.ApplicationsForDistributionRepository.Create(applicationsForDistribution);
    }

    public void Update(ApplicationsForDistribution applicationsForDistribution)
    {
        _unitOfWork.ApplicationsForDistributionRepository.Create(applicationsForDistribution);
    }

    public void Delete(int id)
    {
        _unitOfWork.ApplicationsForDistributionRepository.Delete(id);
    }

    public ApplicationsForDistributionView Get(int id)
    {
        return _unitOfWork.ApplicationsForDistributionRepository.GetView(id);
    }
}