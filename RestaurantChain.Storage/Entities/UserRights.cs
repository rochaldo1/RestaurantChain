﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Storage.Entities
{
    /// <summary>
    /// Класс прав пользователей.
    /// </summary>
    public sealed class UserRights : IdentityBase
    {
        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Идентификатор пункта / подпункта меню.
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        /// Право на чтение записей.
        /// </summary>
        public bool R { get; set; }

        /// <summary>
        /// Право на добавление новых записей.
        /// </summary>
        public bool W { get; set; }

        /// <summary>
        /// Право на изменение записей.
        /// </summary>
        public bool E { get; set; }

        /// <summary>
        /// Право на удаление записей.
        /// </summary>
        public bool D { get; set; }
    }
}
