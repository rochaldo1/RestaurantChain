using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Domain.Models
{
    /// <summary>
    /// Класс меню приложения.
    /// </summary>
    public sealed class MenuDomain : IdentityBaseDomain
    {
        /// <summary>
        /// Идентификатор родительского пункта.
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// Имя пункта/подпункта.
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// Имя DLL.
        /// </summary>
        public string DLLName { get; set; }

        /// <summary>
        /// Имя функции (метода).
        /// </summary>
        public string MethodName { get; set; }

        /// <summary>
        /// Порядок.
        /// </summary>
        public int OrderNum { get; set; }
    }
}
