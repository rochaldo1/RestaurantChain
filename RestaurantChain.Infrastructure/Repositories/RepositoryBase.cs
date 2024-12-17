using Npgsql;

namespace RestaurantChain.Infrastructure.Repositories
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
