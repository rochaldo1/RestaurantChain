using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Storage.Entities
{
    /// <summary>
    /// Класс справочника банков.
    /// </summary>
    public sealed class Banks : IdentityBase
    {
        /// <summary>
        /// Название банка.
        /// </summary>
        public string Bank { get; set; }
    }
}
