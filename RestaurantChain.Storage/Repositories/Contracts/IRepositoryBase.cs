using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Storage.Repositories.Contracts
{
    /// <summary>
    /// Интерфейс с CRUD-ом для работы с таблицами в БД.
    /// </summary>
    /// <typeparam name="TEntity">Класс сущности.</typeparam>
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        int Create(TEntity entity);
        TEntity Get(int id);
        //IList<TEntity> Read();
        void Update(TEntity entity);
        void Delete(int id);
    }
}
