﻿using RestaurantChain.Domain.Models.Base;

namespace RestaurantChain.Domain.Models
{
    /// <summary>
    /// Класс справочника единиц измерения.
    /// </summary>
    public class Units : IdentityBase
    {
        /// <summary>
        /// Единица измерения.
        /// </summary>
        public string UnitName { get; set; }
    }
}
