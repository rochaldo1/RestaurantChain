using Dapper;

using Npgsql;
using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.Infrastructure.Converters;
using RestaurantChain.Infrastructure.Entities;
using RestaurantChain.Infrastructure.Entities.Views;
using RestaurantChain.Repository.Repositories;

namespace RestaurantChain.Infrastructure.Repositories;

internal sealed class SuppliersRepository : RepositoryBase, ISuppliersRepository
{
    public SuppliersRepository(NpgsqlConnection connection) : base(connection)
    {
    }

    public int Create(Suppliers entity)
    {
        const string query = @"
    insert into suppliers (
                            street_id,
                            bank_id,
                            supervisor_name,
                            supervisor_last_name,
                            supervisor_surname,
                            supplier_name,
                            phone_number,
                            current_account,
                            tin
                          ) 
                values(
                            @StreetId,
                            @BankId,
                            @SupervisorName,
                            @SupervisorLastName,
                            @SupervisorSurname,
                            @SupplierName,
                            @PhoneNumber,
                            @CurrentAccount,
                            @TIN
                      ) 
    returning Id;
    ";
        var entityDb = entity.ToStorage();
        var entityId = Connection.ExecuteScalar<int>(query, entityDb);

        return entityId;
    }

    public void Delete(int id)
    {
        const string query = @"
    delete
    from suppliers
    where Id = @Id;
    ";
        Connection.ExecuteScalar(query, new
        {
            Id = id,
        });
    }

    public Suppliers Get(int id)
    {
        const string query = @"
    select  Id,
            street_id               as StreetId,
            bank_id                 as BankId,
            supervisor_name         as SupervisorName,
            supervisor_last_name    as SupervisorLastName,
            supervisor_surname      as SupervisorSurname,
            supplier_name           as SupplierName,
            phone_number            as PhoneNumber,
            current_account         as CurrentAccount, 
            tin                     as TIN 
    from suppliers 
    where id = @id;
    ";
        var entityDb = Connection.QueryFirstOrDefault<SuppliersDb>(query, new
        {
            Id = id
        });

        return entityDb?.ToDomain();
    }

    public void Update(Suppliers entity)
    {
        const string query = @"
    update suppliers set 
            street_id               = @StreetId,
            bank_id                 = @BankId,
            supervisor_name         = @SupervisorName,
            supervisor_last_name    = @SupervisorLastName,
            supervisor_surname      = @SupervisorSurname,
            supplier_name           = @SupplierName,
            phone_number            = @PhoneNumber,
            current_account         = @CurrentAccount,
            tin                     = @TIN
    where Id = @Id;
    ";
        var entityDb = entity.ToStorage();
        Connection.ExecuteScalar(query, entityDb);
    }

    public Suppliers Get(string name)
    {
        const string query = @"
    select  Id,
            street_id               as StreetId,
            bank_id                 as BankId,
            supervisor_name         as SupervisorName,
            supervisor_last_name    as SupervisorLastName,
            supervisor_surname      as SupervisorSurname,
            supplier_name           as SupplierName,
            phone_number            as PhoneNumber,
            current_account         as CurrentAccount,
            tin                     as TIN 
    from suppliers 
    where 
    supplier_name = @name;
    ";
        var entityDb = Connection.QueryFirstOrDefault<SuppliersDb>(query, new
        {
            Name = name
        });

        return entityDb?.ToDomain();
    }

    public IReadOnlyCollection<SuppliersView> List()
    {
        const string query = @"
    select  sp.id                       as id,
            sp.street_id                as StreetId,
            sp.bank_id                  as BankId,
            sp.phone_number             as PhoneNumber,
            sp.supervisor_name          as SupervisorName,
            sp.supervisor_last_name     as SupervisorLastName,
            sp.supervisor_surname       as SupervisorSurname,
            sp.supplier_name            as SupplierName,
            sp.current_account          as CurrentAccount,
            sp.tin                      as TIN,
            b.bank_name                 as BankName,
            s.street_name               as StreetName
    from public.suppliers sp 
        inner join public.banks b on sp.bank_id = b.id
        inner join public.streets s on sp.street_id = s.id
    order by supplier_name;
    ";
        IEnumerable<SuppliersDbView> entities = Connection.Query<SuppliersDbView>(query);

        return entities.Select(x => x.ToDomain()).ToArray();
    }
}