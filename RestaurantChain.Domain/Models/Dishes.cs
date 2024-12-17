using RestaurantChain.Domain.Models.Base;

namespace RestaurantChain.Domain.Models
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
