namespace RestaurantChain.Infrastructure.Entities
{
    /// <summary>
    /// Класс справочника банков.
    /// </summary>
    internal sealed class BanksDb : IdentityBaseDb
    {
        /// <summary>
        /// Название банка.
        /// </summary>
        public string BankName { get; set; }
    }
}
