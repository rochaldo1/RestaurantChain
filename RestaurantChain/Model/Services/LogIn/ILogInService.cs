using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Model.Services.LogIn
{
    /// <summary>
    /// Интерфейс сервиса входа пользователя.
    /// </summary>
    public interface ILogInService
    {
        /// <summary>
        /// Проверка введённых значений для входа в аккаунт.
        /// </summary>
        /// <param name="login">Введённый логин.</param>
        /// <param name="password">Введённый пароль.</param>
        /// <returns></returns>
        public bool TryLogIn(string login, string password);
    }
}
