using RestaurantChain.Domain.Models;
using RestaurantChain.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Domain.Services.Conventors
{
    internal static class GroupsOfDishesConvertor
    {
        public static GroupsOfDishesDomain ToDomain(this GroupsOfDishes group)
        {
            return new GroupsOfDishesDomain
            {
                Id = group.Id,
                GroupName = group.GroupName
            };
        }

        public static GroupsOfDishes ToStorage(this GroupsOfDishesDomain group)
        {
            return new GroupsOfDishes
            {
                Id = group.Id,
                GroupName = group.GroupName
            };
        }
    }
}
