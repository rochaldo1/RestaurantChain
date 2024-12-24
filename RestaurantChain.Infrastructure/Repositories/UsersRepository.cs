using System.Security.Cryptography;
using System.Text;

using Dapper;

using Npgsql;

using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.Infrastructure.Converters;
using RestaurantChain.Infrastructure.Entities;
using RestaurantChain.Infrastructure.Entities.Views;
using RestaurantChain.Repository.Repositories;

namespace RestaurantChain.Infrastructure.Repositories;

internal sealed class UsersRepository : RepositoryBase, IUsersRepository
{
    public UsersRepository(NpgsqlConnection connection) : base(connection)
    {
    }

    public void Delete(int id)
    {
        const string query = "delete from users where Id = @Id;";
        Connection.ExecuteScalar(
            query,
            new
            {
                Id = id
            });
    }

    public Users Get(int id)
    {
        const string query = @"
select
    id            AS Id,
    login         AS Login, 
    password      AS Password,
    role_id       AS RoleId,
    first_name    AS FirstName,
    last_name     AS LastName,
    middle_name   AS MiddleName,
    job_title     AS JobTitle
from users
where id = @id;";
        var user = Connection.QueryFirstOrDefault<UsersDb>(query, new { Id = id });

        return user?.ToDomain();
    }

    public void Update(Users entity)
    {
        const string query = @"
    update users set 
        password    = COALESCE(@password, password),
        login       = @Login,
        last_name   = @LastName,
        first_name  = @FirstName,
        middle_name = @MiddleName,
        role_id     = @RoleId
    where id = @id;
    ";
        string? hashPassword = string.IsNullOrWhiteSpace(entity.Password) ? null : GetPasswordHash(entity.Password);
        Connection.ExecuteScalar(
            query,
            new
            {
                entity.Id,
                Password = hashPassword,
                login = entity.Login,
                entity.LastName,
                entity.FirstName,
                entity.MiddleName,
                entity.RoleId
            });
    }

    public int Create(Users entity)
    {
        const string query = @"
    insert into users(
                        login, 
                        password,
                        role_id,
                        first_name,
                        last_name,
                        middle_name,
                        job_title
                     ) 
                values(
                        @login, 
                        @password,
                        @RoleId,
                        @FirstName,
                        @LastName,
                        @MiddleName,
                        @JobTitle
                      ) 
    returning Id;
    ";
        string hashPassword = GetPasswordHash(entity.Password);
        var id = Connection.ExecuteScalar<int>(
            query,
            new
            {
                entity.Login,
                Password = hashPassword,
                entity.LastName,
                entity.FirstName,
                entity.MiddleName,
                entity.RoleId,
                entity.JobTitle
            });

        return id;
    }

    public Users Get(string login, string password)
    {
        const string query = @"
select
    id            AS Id,
    login         AS Login, 
    password      AS Password,
    role_id       AS RoleId,
    first_name    AS FirstName,
    last_name     AS LastName,
    middle_name   AS MiddleName,
    job_title     AS JobTitle
from users
where login = @login and password = @password;";
        string hashPassword = GetPasswordHash(password);
        var user = Connection.QueryFirstOrDefault<UsersDb>(
            query,
            new
            {
                Login = login,
                Password = hashPassword
            });

        return user?.ToDomain();
    }

    public Users Get(string login)
    {
        const string query = @"
select
    id            AS Id,
    login         AS Login, 
    password      AS Password,
    role_id       AS RoleId,
    first_name    AS FirstName,
    last_name     AS LastName,
    middle_name   AS MiddleName,
    job_title     AS JobTitle
from users where login = @login;";
        var user = Connection.QueryFirstOrDefault<UsersDb>(
            query,
            new
            {
                Login = login
            });

        return user?.ToDomain();
    }

    public IReadOnlyCollection<UsersView> List()
    {
        const string query = @"
select 
    u.id            AS Id,
    u.login         AS Login, 
    u.password      AS Password,
    u.role_id       AS RoleId,
    u.first_name    AS FirstName,
    u.last_name     AS LastName,
    u.middle_name   AS MiddleName,
    u.job_title     AS JobTitle,
    r.name          AS RoleName
from users u
    inner join roles r on u.role_id = r.Id
order by
    u.login,
    u.last_name,
    u.first_name;
";
        IEnumerable<UsersDbView> users = Connection.Query<UsersDbView>(query);

        return users.Select(x => x.ToDomain()).ToArray();
    }

    /// <summary>
    ///     Метод конвертирования пароля в хэш код.
    /// </summary>
    /// <param name="value">Пароль.</param>
    /// <returns>Хэшированный пароль.</returns>
    private static string GetPasswordHash(string value)
    {
        byte[] messageBytes = Encoding.UTF8.GetBytes(value);
        byte[] hashValue = MD5.HashData(messageBytes);

        return Convert.ToHexString(hashValue);
    }
}