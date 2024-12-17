using RestaurantChain.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Presentation.Classes
{
    public static class CurrentState
    {
        public static Users CurrentUser { get; set; }
    }
}
