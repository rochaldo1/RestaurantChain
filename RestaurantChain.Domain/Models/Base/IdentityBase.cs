namespace RestaurantChain.Domain.Models.Base
{
    /// <summary>
    /// Базовый класс для идентификаторов.
    /// </summary>
    public abstract class IdentityBase
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }
    }
}
