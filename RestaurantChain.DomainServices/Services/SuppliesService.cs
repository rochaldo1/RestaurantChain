using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Repository;

namespace RestaurantChain.DomainServices.Services;

internal class SuppliesService : ISuppliesService
{
    private readonly IUnitOfWork _unitOfWork;

    public SuppliesService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IReadOnlyCollection<SuppliesView> List(int? supplierId, DateTime? from, DateTime? to)
    {
        if (supplierId is null or < 0)
        {
            return Array.Empty<SuppliesView>();
        }

        return _unitOfWork.SuppliesRepository.List(supplierId, from, to);
    }

    public int Create(Supplies supply)
    {
        return _unitOfWork.SuppliesRepository.Create(supply);
    }

    public void Update(Supplies supply)
    {
        _unitOfWork.SuppliesRepository.Update(supply);
    }

    public void Delete(int id)
    {
        _unitOfWork.SuppliesRepository.Delete(id);
    }

    public SuppliesView Get(int id)
    {
        return _unitOfWork.SuppliesRepository.GetView(id);
    }
}