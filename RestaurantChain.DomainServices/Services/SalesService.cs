using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Repository;

namespace RestaurantChain.DomainServices.Services;

internal class SalesService : ISalesService
{
    private readonly IUnitOfWork _unitOfWork;

    public SalesService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IReadOnlyCollection<SalesView> List(int? restaurantId, DateTime? from, DateTime? to)
    {
        if (restaurantId == null || restaurantId <= 0)
        {
            return Array.Empty<SalesView>();
        }

        return _unitOfWork.SalesRepository.List(restaurantId, from, to);
    }

    public int Create(Sales sales)
    {
        return _unitOfWork.SalesRepository.Create(sales);
    }

    public void Update(Sales sales)
    {
        _unitOfWork.SalesRepository.Update(sales);
    }

    public void Delete(int id)
    {
        _unitOfWork.SalesRepository.Delete(id);
    }

    public Sales Get(int id)
    {
        return _unitOfWork.SalesRepository.Get(id);
    }
}