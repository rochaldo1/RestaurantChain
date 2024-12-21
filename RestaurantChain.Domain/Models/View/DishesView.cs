using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Domain.Models.View
{
    public sealed class DishesView : Dishes
    {
        public string GroupName { get; set; }
    }
}
