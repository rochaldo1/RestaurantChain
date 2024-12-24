using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;

namespace RestaurantChain.DomainServices.Contracts;

/// <summary>
/// Сервис для работы с ролями
/// </summary>
public interface IRolesService
{
    int Create(Roles role);
    void Delete(int id);
    Roles Get(int id);
    IReadOnlyCollection<Roles> List();
    void Update(Roles role);

    int CreateRight(RolesRights role);
    void DeleteRight(int id);
    RolesRights GetRight(int id);
    IReadOnlyCollection<RolesRightsView> ListRights(int roleId);
    void UpdateRight(RolesRights role);
}