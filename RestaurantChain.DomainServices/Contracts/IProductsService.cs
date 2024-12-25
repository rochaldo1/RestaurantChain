using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;

namespace RestaurantChain.DomainServices.Contracts;

/// <summary>
/// Сервис для работы с продуктами на складе
/// </summary>
public interface IProductsService
{
    /// <summary>
    /// Получить одну запись
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Products Get(int id);
    
    /// <summary>
    /// Создать
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    int Create(Products product);
    
    /// <summary>
    /// Обновить
    /// </summary>
    /// <param name="product"></param>
    void Update(Products product);
    
    /// <summary>
    /// Удалить
    /// </summary>
    /// <param name="id"></param>
    void Delete(int id);
    /// <summary>
    /// Получить список
    /// </summary>
    /// <returns></returns>
    IReadOnlyCollection<ProductsView> List();
    
    /// <summary>
    /// Расчитать и обновить количество продуктов на складе
    /// </summary>
    /// <param name="productId"></param>
    void CalculateAndUpdateQuantity(int productId);
}