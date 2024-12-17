using RestaurantChain.Domain.Models.Base;

namespace RestaurantChain.Domain.Models
{
    /// <summary>
    /// Класс справочника улиц.
    /// </summary>
    public sealed class Streets : IdentityBase
    {
        /// <summary>
        /// Название улицы.
        /// </summary>
        public string StreetName { get; set; }
    }
}
