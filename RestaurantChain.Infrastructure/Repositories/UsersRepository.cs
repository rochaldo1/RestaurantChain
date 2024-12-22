using Dapper;
using Npgsql;
using RestaurantChain.Domain.Models;
using RestaurantChain.Infrastructure.Converters;
using RestaurantChain.Infrastructure.Entities;
using RestaurantChain.Repository.Repositories;
using System.Security.Cryptography;
using System.Text;

namespace RestaurantChain.Infrastructure.Repositories;

internal sealed class UsersRepository : RepositoryBase, IUsersRepository
{
    public UsersRepository(NpgsqlConnection connection) : base(connection)
    {
    }

    public void Delete(int id)
    {
        const string query = "delete from users where Id = @Id;";
        Connection.ExecuteScalar(query, new
        {
            Id = id,
        });
    }

    public Users Get(int id)
    {
        const string query = @"select * from users where id = @id;
    ";
        var user = Connection.QueryFirstOrDefault<UsersDb>(query, new { Id = id });
        return user?.ToDomain();
    }

    public void Update(Users entity)
    {
        const string query = @"
    update users set 
        password =  COALESCE(@password, password),
        login = @Login
    where id = @id;
    ";
        var hashPassword = string.IsNullOrWhiteSpace(entity.Password) ? null : GetPasswordHash(entity.Password);
        Connection.ExecuteScalar(query, new
        {
            Id = entity.Id,
            Password = hashPassword,
            login = entity.Login,
        });
    }

    public int Create(Users entity)
    {
        const string query = @"
    insert into users(
                        login, 
                        password
                     ) 
                values(
                        @login, 
                        @password
                      ) 
    returning Id;
    ";
        var hashPassword = GetPasswordHash(entity.Password);
        var id = Connection.ExecuteScalar<int>(query, new
        {
            Login = entity.Login,
            Password = hashPassword
        });
        return id;
    }

    public Users Get(string login, string password)
    {
        const string query = @"
    select * 
    from users 
    where login = @login and password = @password;
    ";
        var hashPassword = GetPasswordHash(password);
        var user = Connection.QueryFirstOrDefault<UsersDb>(query, new
        {
            Login = login,
            Password = hashPassword
        });
        return user?.ToDomain();
    }

    public Users Get(string login)
    {
        const string query = @"
    select * 
    from users 
    where login = @login;
    ";
        var user = Connection.QueryFirstOrDefault<UsersDb>(query, new
        {
            Login = login
        });
        return user?.ToDomain();
    }

    /// <summary>
    /// Метод конвертирования пароля в хэш код.
    /// </summary>
    /// <param name="value">Пароль.</param>
    /// <returns>Хэшированный пароль.</returns>
    private static string GetPasswordHash(string value)
    {
        var messageBytes = Encoding.UTF8.GetBytes(value);
        var hashValue = MD5.HashData(messageBytes);
        return Convert.ToHexString(hashValue);
    }

    public IReadOnlyCollection<Users> List()
    {
        var query = "select * from users;";
        var users = Connection.Query<UsersDb>(query);
        return users.Select(x => x.ToDomain()).ToArray();
    }
}