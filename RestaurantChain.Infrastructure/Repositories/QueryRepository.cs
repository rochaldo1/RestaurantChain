using RestaurantChain.Repository.Repositories;
using System.Data;
using Npgsql;

namespace RestaurantChain.Infrastructure.Repositories;

internal class QueryRepository : RepositoryBase, IQueryRepository
{
    public QueryRepository(NpgsqlConnection connection) : base(connection)
    {
    }

    public DataView GetResult(string query)
    {
        if (Connection.State != ConnectionState.Open)
        {
            Connection.Open();
        }

        using var cmd = new NpgsqlCommand(query, Connection);
        cmd.Prepare();

        var da = new NpgsqlDataAdapter(cmd);
        var ds = new DataSet();
            
        da.Fill(ds);
            
        return ds.Tables[0].DefaultView;
    }
}