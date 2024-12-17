namespace RestaurantChain.Infrastructure.Entities
{
    /// <summary>
    /// Класс номенклатуры в ресторане.
    /// </summary>
    internal sealed class NomenclatureDb : IdentityBaseDb
    {
        /// <summary>
        /// Идентификатор ресторана.
        /// </summary>
        public int RestaurantId { get; set; }

        /// <summary>
        /// Идентификатор блюда.
        /// </summary>
        public int DishId { get; set; }
    }
}
