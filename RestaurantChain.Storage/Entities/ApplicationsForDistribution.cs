﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Storage.Entities
{
    /// <summary>
    /// Класс заявок на распределение продуктов.
    /// </summary>
    public sealed class ApplicationsForDistribution : IdentityBase
    {
        /// <summary>
        /// Идентификатор ресторана, который подал заявку на распределение.
        /// </summary>
        public int RestaurantId { get; set; }

        /// <summary>
        /// Идентификатор продукта.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Идентификатор единицы измерения.
        /// </summary>
        public int UnitId { get; set; }

        /// <summary>
        /// Дата оформления заявки в формате DD.MM.YYYY.
        /// </summary>
        public DateTime ApplicationDate { get; set; }

        /// <summary>
        /// Количество продуктов в заявке.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Стоимость продуктов в заявке (2 знака после запятой).В
        /// </summary>
        public decimal Price { get; set; }
    }
}