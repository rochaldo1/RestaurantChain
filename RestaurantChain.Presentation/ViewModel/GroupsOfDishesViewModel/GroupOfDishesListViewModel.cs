﻿using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.Domain.Models;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Classes.Helpers;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.View.GroupsOfDishesViews;
using RestaurantChain.Presentation.ViewModel.Base;

namespace RestaurantChain.Presentation.ViewModel.GroupsOfDishesViewModel;

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
        WindowHelper.ShowDialog(view, "Создание записи");
        RefreshData(sender);
    }

    private void EditEntity(object sender)
    {
        if (!HasSelectedItem())
        {
            return;
        }
            
        var view = new GroupOfDishesWindow(ServiceProvider, SelectedItem.Id);
        WindowHelper.ShowDialog(view, "Редактирование записи");
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
            try
            {
                _groupsOfDishesService.Delete(SelectedItem.Id);
            }
            catch (Exception e)
            {
                IsFkError(e);
            }
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