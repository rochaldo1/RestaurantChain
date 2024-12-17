namespace RestaurantChain.Infrastructure.Entities
{
    /// <summary>
    /// Базовый класс для идентификаторов.
    /// </summary>
    internal abstract class IdentityBaseDb
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id {  get; set; }
    }
}
