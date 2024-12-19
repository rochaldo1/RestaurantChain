using RestaurantChain.Domain.Models;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.DomainServices.Services
{
    internal class GroupsOfDishesService : IGroupsOfDishesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GroupsOfDishesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Create(GroupsOfDishes group)
        {
            GroupsOfDishes? existGroup = _unitOfWork.GroupsOfDishesRepository.Get(group.GroupName);

            if(existGroup != null)
            {
                return 0;
            }

            return _unitOfWork.GroupsOfDishesRepository.Create(group);
        }

        public void Delete(int id)
        {
            _unitOfWork.GroupsOfDishesRepository.Delete(id);
        }

        public GroupsOfDishes Get(int id)
        {
            return _unitOfWork.GroupsOfDishesRepository.Get(id);
        }

        public IReadOnlyCollection<GroupsOfDishes> List()
        {
            return _unitOfWork.GroupsOfDishesRepository.List();
        }

        public void Update(GroupsOfDishes group)
        {
            GroupsOfDishes? existGroup = _unitOfWork.GroupsOfDishesRepository.Get(group.Id);

            if (existGroup == null)
            {
                throw new Exception($"Группы блюд с Id {group.Id} не найдено");
            }

            _unitOfWork.GroupsOfDishesRepository.Update(group);
        }
    }
}
