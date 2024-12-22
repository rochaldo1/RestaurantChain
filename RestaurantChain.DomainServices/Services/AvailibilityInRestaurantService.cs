using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Repository;

namespace RestaurantChain.DomainServices.Services;

internal class AvailibilityInRestaurantService : IAvailibilityInRestaurantService
{
    private readonly IUnitOfWork _unitOfWork;

    public AvailibilityInRestaurantService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IReadOnlyCollection<AvailibilityInRestaurantView> List(int? restaurantId)
    {
        if (restaurantId is null or < 0)
        {
            return Array.Empty<AvailibilityInRestaurantView>();
        }

        return _unitOfWork.AvailibilityInRestaurantRepository.List(restaurantId);
    }

    public int Create(AvailibilityInRestaurant availibilityInRestaurant)
    {
        return _unitOfWork.AvailibilityInRestaurantRepository.Create(availibilityInRestaurant);
    }

    public void Update(AvailibilityInRestaurant availibilityInRestaurant)
    {
        _unitOfWork.AvailibilityInRestaurantRepository.Create(availibilityInRestaurant);
    }

    public void Delete(int id)
    {
        _unitOfWork.AvailibilityInRestaurantRepository.Delete(id);
    }

    public AvailibilityInRestaurantView Get(int id)
    {
        return _unitOfWork.AvailibilityInRestaurantRepository.GetView(id);
    }
}