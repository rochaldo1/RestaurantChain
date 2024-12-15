using Dapper;
using Npgsql;
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
            throw new NotImplementedException();
        }
    }
}
