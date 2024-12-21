using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Infrastructure.Entities.Views
{
    internal sealed class DishesDbView : DishesDb
    {
        public string GroupName { get; set; }
    }
}
