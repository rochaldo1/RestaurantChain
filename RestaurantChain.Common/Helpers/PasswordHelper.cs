using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Common.Helpers
{
    /// <summary>
    /// Класс для конвертирования пароля в хэш код.
    /// </summary>
    public static class PasswordHelper
    {
        /// <summary>
        /// Метод конвертирования пароля в хэш код.
        /// </summary>
        /// <param name="value">Пароль.</param>
        /// <returns>Хэшированный пароль.</returns>
        public static string GetPasswordHash(string value)
        {
            byte[] messageBytes = Encoding.UTF8.GetBytes(value);
            byte[] hashValue = MD5.HashData(messageBytes);
            return Convert.ToHexString(hashValue);
        }
    }
}
