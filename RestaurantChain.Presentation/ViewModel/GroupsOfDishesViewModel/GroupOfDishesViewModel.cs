using RestaurantChain.Domain.Models;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RestaurantChain.Presentation.ViewModel.GroupsOfDishesViewModel
{
    internal class GroupOfDishesViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private string _groupName;
        private readonly IGroupsOfDishesService _groupsOfDishesService;
        private readonly int? _currentGroupId;

        public Action OnSaveSuccess;

        public ICommand EnterCommand { get; set; }

        public string GroupName
        {
            get => _groupName;
            set
            {
                _groupName = value;
                OnPropertyChanged("GroupName");
            }
        }

        public GroupOfDishesViewModel(IGroupsOfDishesService groupsOfDishes, int? currentGroupId)
        {
            _groupsOfDishesService = groupsOfDishes;
            _currentGroupId = currentGroupId;
            EnterCommand = new RelayCommand(Enter);
        }

        private void Enter(object sender)
        {
            if (string.IsNullOrWhiteSpace(_groupName))
            {
                MessageBox.Show("Введите название группы!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var result = _currentGroupId.HasValue ? Update() : Create();
            if (result)
                OnSaveSuccess?.Invoke();
        }

        private bool Update()
        {
            var group = new GroupsOfDishes
            {
                Id = _currentGroupId.Value,
                GroupName = _groupName
            };
            try
            {
                _groupsOfDishesService.Update(group);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private bool Create()
        {
            var group = new GroupsOfDishes
            {
                GroupName = _groupName
            };
            
            var id = _groupsOfDishesService.Create(group);
            if(id == 0)
            {
                MessageBox.Show("Такая группа уже существует!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
    }
}
