using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.Repository;

namespace RestaurantChain.DomainServices.Services;

internal class NomenclatureService : INomenclatureService
{
    private readonly IUnitOfWork _unitOfWork;

    public NomenclatureService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Nomenclature Get(int id)
    {
        return _unitOfWork.NomenclatureRepository.Get(id);
    }

    public int Create(Nomenclature nomenclature)
    {
        return _unitOfWork.NomenclatureRepository.Create(nomenclature);
    }

    public void Update(Nomenclature nomenclature)
    {
        _unitOfWork.NomenclatureRepository.Update(nomenclature);
    }

    public void Delete(int id)
    {
        _unitOfWork.NomenclatureRepository.Delete(id);
    }

    public IReadOnlyCollection<NomenclatureView> List(int restaurantId)
    {
        if (restaurantId <= 0)
        {
            return Array.Empty<NomenclatureView>();
        }

        return _unitOfWork.NomenclatureRepository.List(restaurantId);
    }
}