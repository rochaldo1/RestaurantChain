using RestaurantChain.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.DataBase.Entity.User
{
    public class UserData : IUserData
    {
        public uint Id { get; set; }
        public IUser User { get; set; }

        public UserData(uint id, string login, string password)
        {
            Id = id;
            User = new Model.Users.User(login, password);
        }

        public UserData(string login, string password)
        {
            User = new Model.Users.User(login,password);
        }
    }
}
