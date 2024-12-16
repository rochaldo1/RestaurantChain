using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Domain.Models
{
    /// <summary>
    /// Базовый класс для идентификаторов.
    /// </summary>
    public abstract class IdentityBaseDomain
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }
    }
}
