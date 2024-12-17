namespace RestaurantChain.Infrastructure.Entities
{
    /// <summary>
    /// Класс пользователя.
    /// </summary>
    internal class UsersDb : IdentityBaseDb
    {
        /// <summary>
        /// Логин пользователя.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль пользователя.
        /// </summary>
        public string Password { get; set; }
    }
}
