namespace RestaurantChain.Infrastructure.Entities
{
    /// <summary>
    /// Класс справочника групп блюд (их типов).
    /// </summary>
    internal sealed class GroupsOfDishesDb : IdentityBaseDb
    {
        /// <summary>
        /// Название группы блюд.
        /// </summary>
        public string GroupName { get; set; }
    }
}
