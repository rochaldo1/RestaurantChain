using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.DataBase.Repositories
{
    /// <summary>
    /// Интерфейс с CRUD-ом для работы с таблицами в БД.
    /// </summary>
    /// <typeparam name="T">Класс.</typeparam>
    public interface IRepository<T> where T : class
    {
        void Create(T entity);
        IList<T> Read();
        void Update(T entity);
        void Delete(T entity);
    }
}
