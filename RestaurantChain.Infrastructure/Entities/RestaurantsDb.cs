namespace RestaurantChain.Infrastructure.Entities
{
    /// <summary>
    /// Класс ресторанов.
    /// </summary>
    internal sealed class RestaurantsDb : IdentityBaseDb
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
