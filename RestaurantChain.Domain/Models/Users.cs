using RestaurantChain.Domain.Models.Base;

namespace RestaurantChain.Domain.Models;

/// <summary>
/// Класс пользователя.
/// </summary>
public class Users : IdentityBase
{
    /// <summary>
    /// Логин пользователя.
    /// </summary>
    public string Login { get; set; }

    /// <summary>
    /// Пароль пользователя.
    /// </summary>
    public string Password { get; set; }
    
    /// <summary>
    ///     Фамилия
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    ///     Имя
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    ///     Отчество
    /// </summary>
    public string MiddleName { get; set; }
    
    /// <summary>
    ///     Должность
    /// </summary>
    public string JobTitle { get; set; }

    /// <summary>
    ///     Роль
    /// </summary>
    public int RoleId { get; set; }
}