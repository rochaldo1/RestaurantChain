using RestaurantChain.Domain.Models.Base;

namespace RestaurantChain.Domain.Models
{
    /// <summary>
    /// Класс справочника банков.
    /// </summary>
    public sealed class Banks : IdentityBase
    {
        /// <summary>
        /// Название банка.
        /// </summary>
        public string BankName { get; set; }
    }
}
