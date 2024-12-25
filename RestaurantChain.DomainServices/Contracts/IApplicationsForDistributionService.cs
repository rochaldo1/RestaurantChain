using RestaurantChain.Domain.Models.View;
using RestaurantChain.Domain.Models;

namespace RestaurantChain.DomainServices.Contracts;

/// <summary>
/// Сервис для работы с заявками на распределение
/// </summary>
public interface IApplicationsForDistributionService
{
    /// <summary>
    /// Получить список
    /// </summary>
    /// <param name="restaurantId"></param>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <returns></returns>
    IReadOnlyCollection<ApplicationsForDistributionView> List(int? restaurantId, DateTime? from, DateTime? to);
    
    /// <summary>
    /// Создать
    /// </summary>
    /// <param name="applicationsForDistribution"></param>
    /// <returns></returns>
    int Create(ApplicationsForDistribution applicationsForDistribution);
    
    /// <summary>
    /// Обновить
    /// </summary>
    /// <param name="applicationsForDistribution"></param>
    void Update(ApplicationsForDistribution applicationsForDistribution);
    
    /// <summary>
    /// Удалить
    /// </summary>
    /// <param name="id"></param>
    void Delete(int id);
    
    /// <summary>
    /// Получить одну запись
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    ApplicationsForDistributionView Get(int id);
}