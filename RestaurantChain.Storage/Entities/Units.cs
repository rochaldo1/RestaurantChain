using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Storage.Entities
{
    /// <summary>
    /// Класс справочника единиц измерения.
    /// </summary>
    public sealed class Units : IdentityBase
    {
        /// <summary>
        /// Единица измерения.
        /// </summary>
        public string UnitName { get; set; }
    }
}
