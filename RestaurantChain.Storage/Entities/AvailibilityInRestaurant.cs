using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Storage.Entities
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
