using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Storage.Entities
{
    /// <summary>
    /// Класс ресторанов.
    /// </summary>
    public sealed class Restaurants : IdentityBase
    {
        /// <summary>
        /// Идентификатор улицы.
        /// </summary>
        public int StreetId { get; set; }

        /// <summary>
        /// Номер телефона ресторана.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Имя директора ресторана.
        /// </summary>
        public string DirectorName { get; set; }
        
        /// <summary>
        /// Фамилия директора ресторана.
        /// </summary>
        public string DirectorLastName { get; set; }

        /// <summary>
        /// Отчество директора ресторана.
        /// </summary>
        public string DirectorSurname { get; set; }

        /// <summary>
        /// Название ресторана.
        /// </summary>
        public string RestaurantName { get; set; }
    }
}
