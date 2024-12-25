using RestaurantChain.Domain.Models.View;
using RestaurantChain.Domain.Models;

namespace RestaurantChain.DomainServices.Contracts;

/// <summary>
/// Сервис для работы с меню ресторана
/// </summary>
public interface INomenclatureService
{
    /// <summary>
    /// Получить одну запись
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Nomenclature Get(int id);
    
    /// <summary>
    /// Создать
    /// </summary>
    /// <param name="nomenclature"></param>
    /// <returns></returns>
    int Create(Nomenclature nomenclature);
    
    /// <summary>
    /// Обновить
    /// </summary>
    /// <param name="nomenclature"></param>
    void Update(Nomenclature nomenclature);
    
    /// <summary>
    /// Удалить
    /// </summary>
    /// <param name="id"></param>
    void Delete(int id);
    
    /// <summary>
    /// Получить список
    /// </summary>
    /// <param name="restaurantId"></param>
    /// <returns></returns>
    IReadOnlyCollection<NomenclatureView> List(int restaurantId);
}