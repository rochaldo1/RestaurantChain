using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Storage.Entities
{
    /// <summary>
    /// Класс блюд.
    /// </summary>
    public sealed class Dishes : IdentityBase
    {
        /// <summary>
        /// Идентификатор группы блюда.
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// Название блюда.
        /// </summary>
        public string DishName { get; set; }

        /// <summary>
        /// Стоимость блюда.
        /// </summary>
        public decimal Price { get; set; }
    }
}
