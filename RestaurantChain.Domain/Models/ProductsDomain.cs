using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Domain.Models
{
    /// <summary>
    /// Класс продуктов.
    /// </summary>
    public sealed class ProductsDomain : IdentityBaseDomain
    {
        /// <summary>
        /// Идентификатор единицы измерения.
        /// </summary>
        public int UnitId { get; set; }

        /// <summary>
        /// Название продукта.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Количество продукта на складе.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Стоимость 1-ой единицы продукта.
        /// </summary>
        public decimal Price { get; set; }
    }
}
