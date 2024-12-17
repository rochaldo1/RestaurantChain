using Dapper;
using Npgsql;
using RestaurantChain.Domain.Models;
using RestaurantChain.Repository.Repositories;
using System.Security.Cryptography;
using System.Text;

namespace RestaurantChain.Infrastructure.Repositories
{
    internal sealed class UsersRepository : RepositoryBase, IUsersRepository
    {
        public UsersRepository(NpgsqlConnection connection) : base(connection)
        {
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Users Get(int id)
        {
            var query = "select * from users where id = @id";
            var user = Connection.QueryFirstOrDefault<Users>(query, new { Id = id });
            return user;
        }

        public void Update(Users entity)
        {
            throw new NotImplementedException();
        }

        public int Create(Users entity)
        {
            const string query = "insert into users(login, password) values(@login, @password)";
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
            const string query = "select * from users where login = @login and password = @password";
            var hashPassword = GetPasswordHash(password);
            var user = Connection.QueryFirstOrDefault<Users>(query, new
            {
                Login = login,
                Password = hashPassword
            });
            return user;
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
    }
}
