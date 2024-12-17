namespace RestaurantChain.Infrastructure.Entities
{
    /// <summary>
    /// Класс поставок.
    /// </summary>
    internal sealed class SuppliesDb : IdentityBaseDb
    {
        /// <summary>
        /// Идентификатор поставщика.
        /// </summary>
        public int SupplierId { get; set; }

        /// <summary>
        /// Идентификатор поставляемого продукта.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Идентификатор единицы измерения.
        /// </summary>
        public int UnitId { get; set; }

        /// <summary>
        /// Дата поставки.
        /// </summary>
        public DateTime SupplyDate { get; set; }

        /// <summary>
        /// Количество поставяемых продуктов.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Стоимость продуктов в поставке.
        /// </summary>
        public decimal Price { get; set; }
    }
}
