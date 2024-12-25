using RestaurantChain.Domain.Models;

namespace RestaurantChain.DomainServices.Contracts;

/// <summary>
/// Сервис для работы с группами блюд
/// </summary>
public interface IGroupsOfDishesService
{
    /// <summary>
    /// Получить одну запись
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    GroupsOfDishes Get(int id);
    
    /// <summary>
    /// Создать
    /// </summary>
    /// <param name="group"></param>
    /// <returns></returns>
    int Create(GroupsOfDishes group);
    
    /// <summary>
    /// Обновить
    /// </summary>
    /// <param name="group"></param>
    void Update(GroupsOfDishes group);
    
    /// <summary>
    /// Удалить
    /// </summary>
    /// <param name="id"></param>
    void Delete(int id);
    /// <summary>
    /// Получить список
    /// </summary>
    /// <returns></returns>
    IReadOnlyCollection<GroupsOfDishes> List();
}