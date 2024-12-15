﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Storage.Entities
{
    /// <summary>
    /// Класс продаж в ресторане (чеки).
    /// </summary>
    public sealed class Sales : IdentityBase
    {
        /// <summary>
        /// Идентификатор ресторана.
        /// </summary>
        public int RestaurantId { get; set; }

        /// <summary>
        /// Идентификатор блюда.
        /// </summary>
        public int DishId { get; set; }

        /// <summary>
        /// Стоимость проданных блюд.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Количество проданных блюд.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Дата продажи в формате DD.MM.YYYY.
        /// </summary>
        public DateTime SaleDate { get; set; }
    }
}
