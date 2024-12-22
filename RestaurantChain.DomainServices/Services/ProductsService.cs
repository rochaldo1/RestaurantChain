using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Repository;

namespace RestaurantChain.DomainServices.Services;

internal class ProductsService : IProductsService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductsService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public int Create(Products product)
    {
        Products? existProduct = _unitOfWork.ProductsRepository.Get(product.ProductName);

        if (existProduct != null)
        {
            return 0;
        }
        return _unitOfWork.ProductsRepository.Create(product);
    }

    public void Delete(int id)
    {
        _unitOfWork.ProductsRepository.Delete(id);
    }

    public Products Get(int id)
    {
        return _unitOfWork.ProductsRepository.Get(id);
    }

    public IReadOnlyCollection<ProductsView> List()
    {
        return _unitOfWork.ProductsRepository.List();
    }

    public void Update(Products product)
    {
        Products? existProduct = _unitOfWork.ProductsRepository.Get(product.Id);

        if (existProduct == null)
        {
            throw new Exception($"Продукта с Id {product.Id} не найдено");
        }

        _unitOfWork.ProductsRepository.Update(product);
    }

    public void CalculateAndUpdateQuantity(int productId)
    {
        var suppliesCount = _unitOfWork.SuppliesRepository.CountByProduct(productId);
        var applicationsForDistributionCount = _unitOfWork.ApplicationsForDistributionRepository.CountByProduct(productId);
        var count = suppliesCount - applicationsForDistributionCount;
        _unitOfWork.ProductsRepository.UpdateQuantity(productId, count);
    }
}