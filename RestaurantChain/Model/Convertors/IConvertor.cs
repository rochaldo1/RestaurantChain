using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Model.Convertors
{
    /// <summary>
    /// Интерфейс конвентора.
    /// </summary>
    /// <typeparam name="R">Возвращаемый тип.</typeparam>
    /// <typeparam name="V">Передаваемый тип.</typeparam>
    public interface IConvertor<R,V> where R: notnull where V : notnull
    {
        public R Convert(V value);
    }
}
