using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;

namespace RestaurantChain.Repository.Repositories;

/// <summary>
/// Заявки
/// </summary>
public interface IApplicationsForDistributionRepository : IRepositoryBase<ApplicationsForDistribution>
{
    /// <summary>
    /// Список заявок
    /// </summary>
    /// <param name="restaurantId">По ресторану</param>
    /// <param name="from">С даты</param>
    /// <param name="to">По дату</param>
    /// <returns></returns>
    IReadOnlyCollection<ApplicationsForDistributionView> List(int? restaurantId, DateTime? from, DateTime? to);
    
    /// <summary>
    /// Получить запись заявки
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    ApplicationsForDistributionView GetView(int id);
    
    /// <summary>
    /// Количество в заявке по продукту
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    int CountByProduct(int productId);
}