using Dapper;
using Npgsql;
using RestaurantChain.Domain.Models;
using RestaurantChain.Infrastructure.Converters;
using RestaurantChain.Infrastructure.Entities;
using RestaurantChain.Repository.Repositories;

namespace RestaurantChain.Infrastructure.Repositories;

internal sealed class BanksRepository : RepositoryBase, IBanksRepository
{
    public BanksRepository(NpgsqlConnection connection) : base(connection)
    {
    }

    public int Create(Banks entity)
    {
        const string query = @"
    insert into banks (
                        bank_name
                      ) 
                values(
                        @BankName
                      ) 
    returning Id;
    ";
        var entityDb = entity.ToStorage();
        var bankId = Connection.ExecuteScalar<int>(query, entityDb);

        return bankId;
    }

    public void Delete(int id)
    {
        const string query = @"
    delete 
    from banks 
    where Id = @id;
    ";
        Connection.ExecuteScalar<int>(query, new
        {
            Id = id
        });
    }

    public Banks Get(int id)
    {
        const string query = @"
    select  Id, 
            bank_name as BankName 
    from banks 
    where id = @id;
    ";
        var banksDb = Connection.QueryFirstOrDefault<BanksDb>(query, new
        {
            Id = id
        });

        return banksDb?.ToDomain();
    }

    public Banks Get(string bankName)
    {
        const string query = @"
    select  Id, 
            bank_name as BankName 
    from banks 
    where bank_name = @name;
    ";
        var banksDb = Connection.QueryFirstOrDefault<BanksDb>(query, new
        {
            Name = bankName
        });

        return banksDb?.ToDomain();
    }

    public IReadOnlyCollection<Banks> List()
    {
        const string query = @"
    select  Id, 
            bank_name as BankName 
    from banks 
    order by bank_name;
    ";
        IEnumerable<BanksDb> entities = Connection.Query<BanksDb>(query);

        return entities.Select(x => x.ToDomain()).ToArray();
    }

    public void Update(Banks entity)
    {
        const string query = @"
    update banks 
        set bank_name = @BankName 
    where Id = @id;
    ";
        var entityDb = entity.ToStorage();
        Connection.ExecuteScalar(query, entityDb);
    }
}