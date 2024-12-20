﻿using RestaurantChain.Domain.Models;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RestaurantChain.Presentation.ViewModel.DishesViewModel
{
    internal class DishViewModel : EditViewModelBase
    {
        private readonly IDishesService _dishesService;
        private readonly IGroupsOfDishesService _groupsOfDishesService;

        private string _dishName;
        private IReadOnlyCollection<GroupsOfDishes> _groupsList;
        private int _selectedGroupId;
        private decimal _price;

        public string DishName
        {
            get => _dishName;
            set
            {
                _dishName = value;
                OnPropertyChanged();
            }
        }

        public IReadOnlyCollection<GroupsOfDishes> GroupsList
        {
            get => _groupsList;
            set
            {
                _groupsList = value;
                OnPropertyChanged();
            }
        }

        public int SelectedGroupId
        {
            get => _selectedGroupId;
            set
            {
                _selectedGroupId = value;
                OnPropertyChanged();
            }
        }

        public decimal Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged();
            }
        }

        public DishViewModel(IDishesService dishesService, IGroupsOfDishesService groupsOfDishesService, int? currentId) : base(currentId)
        {
            _dishesService = dishesService;
            _groupsOfDishesService = groupsOfDishesService;

            if (!Validate())
            {
                OnCancel.Invoke();
            }

            EnterCommand = new RelayCommand(Enter);
        }

        private void Enter(object sender)
        {
            Dishes dish = ValidateAndGetModelOnSave();
            
            if (dish == null)
            {
                return;
            }

            bool result = CurrentId.HasValue ? Update(dish) : Create(dish);

            if (result)
            {
                OnSaveSuccess?.Invoke();
            }
        }

        private bool Update(Dishes dish)
        {
            try
            {
                _dishesService.Update(dish);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }

            return true;
        }

        private bool Create(Dishes dish)
        {
            int id = _dishesService.Create(dish);

            if (id == 0)
            {
                MessageBox.Show("Такое блюдо уже существует!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }

            return true;
        }

        private Dishes ValidateAndGetModelOnSave()
        {
            var dish = new Dishes
            {
                Id = CurrentId ?? 0,
                DishName = _dishName,
                GroupId = _selectedGroupId,
                Price = _price
            };

            var errors = new List<string>();

            if (string.IsNullOrEmpty(dish.DishName))
            {
                errors.Add("Название");
            }

            if (dish.GroupId == 0)
            {
                errors.Add("Группа блюда");
            }

            if (dish.Price <= 0)
            {
                errors.Add("Стоимость");
            }

            if (errors.Count > 0)
            {
                MessageBox.Show($"Поля не заполнены: {string.Join(",", errors)}", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

                return null;
            }

            return dish;
        }

        public override bool Validate()
        {
            if (CurrentId.HasValue)
            {
                Dishes? dish = _dishesService.Get(CurrentId.Value);

                if (dish == null)
                {
                    MessageBox.Show("Такого блюда не существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                    return false;
                }

                DishName = dish.DishName;
                GroupsList = _groupsOfDishesService.List();
                SelectedGroupId = GroupsList.First(x => x.Id == dish.GroupId).Id;
                Price = dish.Price;

                return true;
            }

            GroupsList = _groupsOfDishesService.List();
            return true;
        }
    }
}
