using RestaurantChain.Domain.Models.Base;

namespace RestaurantChain.Domain.Models
{
    /// <summary>
    /// Класс справочника групп блюд (их типов).
    /// </summary>
    public sealed class GroupsOfDishes : IdentityBase
    {
        /// <summary>
        /// Название группы блюд.
        /// </summary>
        public string GroupName { get; set; }
    }
}
