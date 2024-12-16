using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Domain.Models
{
    /// <summary>
    /// Класс справочника банков.
    /// </summary>
    public sealed class BanksDomain : IdentityBaseDomain
    {
        /// <summary>
        /// Название банка.
        /// </summary>
        public string BankName { get; set; }
    }
}
