namespace RestaurantChain.Infrastructure.Entities
{
    /// <summary>
    /// Класс справочника единиц измерения.
    /// </summary>
    internal sealed class UnitsDb : IdentityBaseDb
    {
        /// <summary>
        /// Единица измерения.
        /// </summary>
        public string UnitName { get; set; }
    }
}
