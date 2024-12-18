using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.DomainServices.Services
{
    internal class GroupsOfDishes : IGroupsOfDishesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GroupsOfDishes(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Create(Domain.Models.GroupsOfDishes group)
        {
            var existGroup = _unitOfWork.GroupsOfDishesRepository.Get(group.GroupName);
            if (existGroup != null)
            {
                return 0;
            }
            return _unitOfWork.GroupsOfDishesRepository.Create(group);
        }

        public void Update(Domain.Models.GroupsOfDishes group)
        {
            var existGroup = _unitOfWork.GroupsOfDishesRepository.Get(group.Id);
            if (existGroup == null)
            {
                throw new Exception($"Группы с Id {group.Id} не найдено");
            }
            _unitOfWork.GroupsOfDishesRepository.Update(group);
        }
    }
}
