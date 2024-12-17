namespace RestaurantChain.Infrastructure.Entities
{
    /// <summary>
    /// Класс справочника улиц.
    /// </summary>
    internal sealed class StreetsDb : IdentityBaseDb
    {
        /// <summary>
        /// Название улицы.
        /// </summary>
        public string StreetName { get; set; }
    }
}
