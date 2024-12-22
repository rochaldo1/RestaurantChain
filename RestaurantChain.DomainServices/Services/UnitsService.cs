using RestaurantChain.Domain.Models;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Repository;

namespace RestaurantChain.DomainServices.Services;

internal class UnitsService : IUnitsService
{
    private readonly IUnitOfWork _unitOfWork;

    public UnitsService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public int Create(Units unit)
    {
        Units? existUnit = _unitOfWork.UnitsRepository.Get(unit.UnitName);

        if (existUnit != null)
        {
            return 0;
        }

        return _unitOfWork.UnitsRepository.Create(unit);
    }

    public void Delete(int id)
    {
        _unitOfWork.UnitsRepository.Delete(id);
    }

    public Units Get(int id)
    {
        return _unitOfWork.UnitsRepository.Get(id);
    }

    public IReadOnlyCollection<Units> List()
    {
        return _unitOfWork.UnitsRepository.List();
    }

    public void Update(Units unit)
    {
        Units? existUnit = _unitOfWork.UnitsRepository.Get(unit.Id);

        if (existUnit == null)
        {
            throw new Exception($"Единицы измерения с Id {unit.Id} не найдено");
        }

        _unitOfWork.UnitsRepository.Update(unit);
    }
}