using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Domain.Models
{
    /// <summary>
    /// Класс справочника улиц.
    /// </summary>
    public sealed class StreetsDomain : IdentityBaseDomain
    {
        /// <summary>
        /// Название улицы.
        /// </summary>
        public string StreetName { get; set; }
    }
}
