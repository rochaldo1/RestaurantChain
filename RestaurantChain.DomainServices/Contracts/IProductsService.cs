using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;

namespace RestaurantChain.DomainServices.Contracts;

public interface IProductsService
{
    Products Get(int id);
    int Create(Products product);
    void Update(Products product);
    void Delete(int id);
    IReadOnlyCollection<ProductsView> List();
    void CalculateAndUpdateQuantity(int productId);
}