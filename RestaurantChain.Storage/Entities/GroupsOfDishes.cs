using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Storage.Entities
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
