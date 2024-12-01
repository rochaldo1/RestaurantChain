using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Model.Convertors
{
    /// <summary>
    /// Класс Hash-конвентора.
    /// </summary>
    public class HashCodeConventor : IConvertor<string, string>
    {
        /// <summary>
        /// Конвертирование строки в Hash-код.
        /// </summary>
        /// <param name="value">Конвертируемая строка.</param>
        /// <returns>Конвертированная в хэш-код строка.</returns>
        public string Convert(string value)
        {
            byte[] messageBytes = Encoding.UTF8.GetBytes(value);
            byte[] hashValue = MD5.HashData(messageBytes); // TODO: как разберусь с БД, выбрать нормальный тип шифрования.
            return System.Convert.ToHexString(hashValue);
        }
    }
}
