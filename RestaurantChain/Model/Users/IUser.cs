using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Model.Users
{
    /// <summary>
    /// Интерфейс пользователя.
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// Логин пользователя.
        /// </summary>
        [DisplayName("Логин")]
        string Login { get; }

        /// <summary>
        /// Пароль пользователя.
        /// </summary>
        [DisplayName("Пароль")]
        string Password { get; }
    }
}
