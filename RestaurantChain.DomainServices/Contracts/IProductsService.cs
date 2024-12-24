using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;

namespace RestaurantChain.DomainServices.Contracts;

/// <summary>
/// Сервис для работы с продуктами на складе
/// </summary>
public interface IProductsService
{
    Products Get(int id);
    int Create(Products product);
    void Update(Products product);
    void Delete(int id);
    IReadOnlyCollection<ProductsView> List();
    void CalculateAndUpdateQuantity(int productId);
}