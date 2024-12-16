using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Domain.Models
{
    /// <summary>
    /// Класс справочника групп блюд (их типов).
    /// </summary>
    public sealed class GroupsOfDishesDomain : IdentityBaseDomain
    {
        /// <summary>
        /// Название группы блюд.
        /// </summary>
        public string GroupName { get; set; }
    }
}
