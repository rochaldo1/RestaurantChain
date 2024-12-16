using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Domain.Models
{
    /// <summary>
    /// Класс справочника единиц измерения.
    /// </summary>
    public sealed class UnitsDomain : IdentityBaseDomain
    {
        /// <summary>
        /// Единица измерения.
        /// </summary>
        public string UnitName { get; set; }
    }
}
