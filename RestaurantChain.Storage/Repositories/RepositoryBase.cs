using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Storage.Repositories
{
    internal abstract class RepositoryBase
    {
        protected NpgsqlConnection Connection { get; }

        protected RepositoryBase(NpgsqlConnection connection)
        {
            Connection = connection;
        }
    }
}
