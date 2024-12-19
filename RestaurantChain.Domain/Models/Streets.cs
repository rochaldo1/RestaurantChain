using RestaurantChain.Domain.Models.Base;

namespace RestaurantChain.Domain.Models
{
    /// <summary>
    /// Класс справочника улиц.
    /// </summary>
    public class Streets : IdentityBase
    {
        /// <summary>
        /// Название улицы.
        /// </summary>
        public string StreetName { get; set; }
    }
}
