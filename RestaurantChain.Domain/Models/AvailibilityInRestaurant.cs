using RestaurantChain.Domain.Models.Base;

namespace RestaurantChain.Domain.Models
{
    /// <summary>
    /// Класс доступности продуктов в определённом ресторане (их остаток).
    /// </summary>
    public sealed class AvailibilityInRestaurant : IdentityBase
    {
        /// <summary>
        /// Идентификатор ресторана, который подал заявку на распределение.
        /// </summary>
        public int RestaurantId { get; set; }

        /// <summary>
        /// Идентификатор продукта.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Идентификатор единицы измерения.
        /// </summary>
        public int UnitId { get; set; }

        /// <summary>
        /// Оставшееся количество продуктов в ресторане.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Стоимость оставшихся продуктов.
        /// </summary>
        public decimal Price { get; set; }
    }
}
