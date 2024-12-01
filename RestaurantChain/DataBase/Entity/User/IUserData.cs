using RestaurantChain.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.DataBase.Entity.User
{
    public interface IUserData
    {
        uint Id { get; set; }
        IUser User { get; set; }
    }
}
