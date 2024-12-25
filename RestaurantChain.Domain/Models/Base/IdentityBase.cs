namespace RestaurantChain.Domain.Models.Base;

/// <summary>
/// Базовый класс для всех моделей
/// </summary>
public abstract class IdentityBase
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }
}