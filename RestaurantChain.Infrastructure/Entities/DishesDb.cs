namespace RestaurantChain.Infrastructure.Entities
{
    /// <summary>
    /// Класс блюд.
    /// </summary>
    internal sealed class DishesDb : IdentityBaseDb
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
