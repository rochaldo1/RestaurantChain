using RestaurantChain.Domain.Models;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Repository;
using RestaurantChain.Domain.Models.View;

namespace RestaurantChain.DomainServices.Services;

internal class SuppliersService : ISuppliersService
{
    private readonly IUnitOfWork _unitOfWork;

    public SuppliersService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public int Create(Suppliers supplier)
    {
        Suppliers? existSupplier = _unitOfWork.SuppliersRepository.Get(supplier.SupplierName);

        if (existSupplier != null)
        {
            return 0;
        }

        return _unitOfWork.SuppliersRepository.Create(supplier);
    }

    public void Delete(int id)
    {
        _unitOfWork.SuppliersRepository.Delete(id);
    }

    public Suppliers Get(int id)
    {
        return _unitOfWork.SuppliersRepository.Get(id);
    }

    public IReadOnlyCollection<SuppliersView> List()
    {
        return _unitOfWork.SuppliersRepository.List();
    }

    public void Update(Suppliers supplier)
    {
        Suppliers? existSupplier = _unitOfWork.SuppliersRepository.Get(supplier.Id);
            
        if (existSupplier == null)
        {
            throw new Exception($"Поставщика с Id {supplier.Id} не найдено");
        }

        _unitOfWork.SuppliersRepository.Update(supplier);
    }
}