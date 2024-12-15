using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Storage.Entities
{
    /// <summary>
    /// Класс номенклатуры в ресторане.
    /// </summary>
    public sealed class Nomenclature : IdentityBase
    {
        /// <summary>
        /// Идентификатор ресторана.
        /// </summary>
        public int RestaurantId { get; set; }

        /// <summary>
        /// Идентификатор блюда.
        /// </summary>
        public int DishId { get; set; }
    }
}
