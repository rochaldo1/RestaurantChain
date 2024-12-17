using RestaurantChain.Domain.Models.Base;

namespace RestaurantChain.Domain.Models
{
    /// <summary>
    /// Класс номенклатуры в ресторане.
    /// </summary>
    public sealed class Nomenclature : IdentityBase
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
