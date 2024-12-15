using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Storage.Entities
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
