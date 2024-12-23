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
        var availibility = _unitOfWork.AvailibilityInRestaurantRepository.Get(availibilityInRestaurant.ProductId, availibilityInRestaurant.RestaurantId, availibilityInRestaurant.Price);

        if (availibility is null)
        {
            return _unitOfWork.AvailibilityInRestaurantRepository.Create(availibilityInRestaurant);
        }

        availibility.Quantity += availibilityInRestaurant.Quantity;
        _unitOfWork.AvailibilityInRestaurantRepository.Update(availibility);
        return availibility.Id;
    }

    public void Update(AvailibilityInRestaurant availibilityInRestaurant)
    {
        _unitOfWork.AvailibilityInRestaurantRepository.Update(availibilityInRestaurant);
    }

    public void UpdateCount(AvailibilityInRestaurant availibilityInRestaurant)
    {
        var availibility = _unitOfWork.AvailibilityInRestaurantRepository.Get(availibilityInRestaurant.ProductId, availibilityInRestaurant.RestaurantId, availibilityInRestaurant.Price);
        if(availibility is null)
        {
            return;
        }

        availibility.Quantity -= availibilityInRestaurant.Quantity;

        _unitOfWork.AvailibilityInRestaurantRepository.Update(availibility);
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