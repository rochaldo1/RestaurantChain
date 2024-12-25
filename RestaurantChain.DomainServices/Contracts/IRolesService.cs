using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;

namespace RestaurantChain.DomainServices.Contracts;

/// <summary>
/// Сервис для работы с ролями
/// </summary>
public interface IRolesService
{
    /// <summary>
    /// Создать
    /// </summary>
    /// <param name="role"></param>
    /// <returns></returns>
    int Create(Roles role);
    
    /// <summary>
    /// Удалить
    /// </summary>
    /// <param name="id"></param>
    void Delete(int id);
    
    /// <summary>
    /// Получить одну запись роли
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Roles Get(int id);
    
    /// <summary>
    /// Получить список
    /// </summary>
    /// <returns></returns>
    IReadOnlyCollection<Roles> List();
    
    /// <summary>
    /// Обновить
    /// </summary>
    /// <param name="role"></param>
    void Update(Roles role);

    /// <summary>
    /// Создать запись
    /// </summary>
    /// <param name="role"></param>
    /// <returns></returns>
    int CreateRight(RolesRights role);
    
    /// <summary>
    /// Удалить права
    /// </summary>
    /// <param name="id"></param>
    void DeleteRight(int id);
    
    /// <summary>
    /// Получить одну запись прав
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    RolesRights GetRight(int id);
    
    /// <summary>
    /// Получить список прав
    /// </summary>
    /// <param name="roleId"></param>
    /// <returns></returns>
    IReadOnlyCollection<RolesRightsView> ListRights(int roleId);
    
    /// <summary>
    /// Обновить
    /// </summary>
    /// <param name="role"></param>
    void UpdateRight(RolesRights role);
}