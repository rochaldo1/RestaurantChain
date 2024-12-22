using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Repository;

namespace RestaurantChain.DomainServices.Services;

internal class RestaurantsService : IRestaurantsService
{
    private readonly IUnitOfWork _unitOfWork;

    public RestaurantsService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Restaurants Get(int id)
    {
        return _unitOfWork.RestaurantsRepository.Get(id);
    }

    public int Create(Restaurants restaurant)
    {
        Restaurants? existRestaurant = _unitOfWork.RestaurantsRepository.Get(restaurant.RestaurantName);

        if (existRestaurant != null)
        {
            return 0;
        }

        return _unitOfWork.RestaurantsRepository.Create(restaurant);
    }

    public void Update(Restaurants restaurant)
    {
        Restaurants? existRestaurant = _unitOfWork.RestaurantsRepository.Get(restaurant.Id);

        if (existRestaurant == null)
        {
            throw new Exception($"Ресторна с Id {restaurant.Id} не найдено");
        }

        _unitOfWork.RestaurantsRepository.Update(restaurant);
    }

    public void Delete(int id)
    {
        _unitOfWork.RestaurantsRepository.Delete(id);
    }

    public IReadOnlyCollection<RestaurantsView> List()
    {
        return _unitOfWork.RestaurantsRepository.List();
    }
}