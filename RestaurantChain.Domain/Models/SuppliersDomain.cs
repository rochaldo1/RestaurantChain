using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Domain.Models
{
    /// <summary>
    /// Класс поставщиков.
    /// </summary>
    public sealed class SuppliersDomain : IdentityBaseDomain
    {
        /// <summary>
        /// Идентификатор улицы, на которой находится поставщик.
        /// </summary>
        public int StreetId { get; set; }

        /// <summary>
        /// Идентификатор банка поставщика.
        /// </summary>
        public int BankId { get; set; }

        /// <summary>
        /// Номер телефона руководителя.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Имя руководителя.
        /// </summary>
        public string SupervisorName { get; set; }

        /// <summary>
        /// Фамилия руководителя.
        /// </summary>
        public string SupervisorLastName { get; set; }

        /// <summary>
        /// Отчество руководителя.
        /// </summary>
        public string SupervisorSurname { get; set; }

        /// <summary>
        /// Название поставщика (название компании).
        /// </summary>
        public string SupplierName { get; set; }

        /// <summary>
        /// Расчётный счёт поставщика.
        /// </summary>
        public string CurrentAccount { get; set; }

        /// <summary>
        /// ИНН поставщика.
        /// </summary>
        public string TIN { get; set; }
    }
}
