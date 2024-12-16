using Dapper;
using Npgsql;
using RestaurantChain.Common.Helpers;
using RestaurantChain.Storage.Entities;
using RestaurantChain.Storage.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Storage.Repositories
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
            var query = "insert into users(login, password) values(@login, @password)";
            var hashPassword = PasswordHelper.GetPasswordHash(entity.Password);
            var id = Connection.ExecuteScalar<int>(query, new
            {
                Login = entity.Login,
                Password = hashPassword
            });
            return id;
        }

        public Users Get(string login, string password)
        {
            var query = "select * from users where login = @login and password = @password";
            var hashPassword = PasswordHelper.GetPasswordHash(password);
            var user = Connection.QueryFirstOrDefault<Users>(query, new
            {
                Login = login,
                Password = hashPassword
            });
            return user;
        }
    }
}
