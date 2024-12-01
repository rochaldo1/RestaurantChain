using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Model.Users
{
    /// <summary>
    /// Класс пользователя.
    /// </summary>
    public class User : IUser
    {
        private string _login; 
        private string _password;

        /// <summary>
        /// Логин пользователя.
        /// </summary>
        public string Login
        {
            get { return _login; } 
            set { _login = value; }
        }

        /// <summary>
        /// Пароль пользователя.
        /// </summary>
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public User(string login, string password)
        {
            _login = login;
            _password = password;
        }
    }
}
