namespace RestaurantChain.Infrastructure.Entities
{
    /// <summary>
    /// Класс меню приложения.
    /// </summary>
    internal sealed class MenuDb : IdentityBaseDb
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
