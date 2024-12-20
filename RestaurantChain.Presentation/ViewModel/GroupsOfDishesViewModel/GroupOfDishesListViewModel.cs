using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.Domain.Models;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.View.GroupsOfDishesViews;
using RestaurantChain.Presentation.ViewModel.Base;

namespace RestaurantChain.Presentation.ViewModel.GroupsOfDishesViewModel
{
    internal class GroupOfDishesListViewModel : ListViewModelBase<GroupsOfDishes>
    {
        private readonly IGroupsOfDishesService _groupsOfDishesService;
        public GroupOfDishesListViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _groupsOfDishesService = serviceProvider.GetRequiredService<IGroupsOfDishesService>();
            DataBind();
        }

        protected override void DataBind()
        {
            IReadOnlyCollection<GroupsOfDishes> entities = _groupsOfDishesService.List();
            SetEntities(entities);
        }

        protected override void SetCommands()
        {
            CreateCommand = new RelayCommand(CreateEntity);
            EditCommand = new RelayCommand(EditEntity);
            DeleteCommand = new RelayCommand(DeleteEntity);
        }

        private void CreateEntity(object sender)
        {
            var view = new GroupOfDishesWindow(ServiceProvider, groupId: null);
            ShowDialog(view, "Создание записи");
            RefreshData(sender);
        }

        private void EditEntity(object sender)
        {
            if (!HasSelectedItem())
            {
                return;
            }
            
            var view = new GroupOfDishesWindow(ServiceProvider, SelectedItem.Id);
            ShowDialog(view, "Редактирование записи");
            RefreshData(sender);
        }

        private void DeleteEntity(object sender)
        {
            if (!HasSelectedItem())
            {
                return;
            }
            
            GroupsOfDishes group = _groupsOfDishesService.Get(SelectedItem.Id);

            if (MessageBox.Show($"Удалить группу блюд '{group.GroupName}'?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _groupsOfDishesService.Delete(SelectedItem.Id);
            }
            else
            {
                return;
            }

            RefreshData(sender);
        }

        private void RefreshData(object sender)
        {
            DataBind();
        }
    }
}
