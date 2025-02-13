﻿using System.Windows;

using Microsoft.Extensions.DependencyInjection;

using RestaurantChain.Domain.Models.View;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Classes.Helpers;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.View.RestaurantsViews.AvailibilityInRestaurantViews;
using RestaurantChain.Presentation.ViewModel.Base;

namespace RestaurantChain.Presentation.ViewModel.RestaurantsViewModels.AvailibilityInRestaurantViewModel;

internal class AvailibilityListViewModel : ListViewModelBase<AvailibilityInRestaurantView>
{
    private readonly IAvailibilityInRestaurantService _availibilityInRestaurantService;

    private readonly int _restaurantId;

    public AvailibilityListViewModel(IServiceProvider serviceProvider, int restaurantId) : base(serviceProvider)
    {
        _restaurantId = restaurantId;
        _availibilityInRestaurantService = serviceProvider.GetRequiredService<IAvailibilityInRestaurantService>();
        OnPropertyChanged();
        DataBind();
    }

    /// <summary>
    /// Обновить таблицу
    /// </summary>
    protected override void DataBind()
    {
        IReadOnlyCollection<AvailibilityInRestaurantView> entities = _availibilityInRestaurantService.List(_restaurantId);
        SetEntities(entities);
    }

    /// <summary>
    /// Установить команды CRUD кнопкам
    /// </summary>
    protected override void SetCommands()
    {
        CreateCommand = new RelayCommand(CreateEntity);
        EditCommand = new RelayCommand(EditEntity);
        DeleteCommand = new RelayCommand(DeleteEntity);
    }

    /// <summary>
    /// Вызов команды создания записи из окна таблицы
    /// </summary>
    /// <param name="sender"></param>
    private void CreateEntity(object sender)
    {
        var view = new AvailibilityInRestaurantWindow(ServiceProvider, availibilityId: null, _restaurantId);
        WindowHelper.ShowDialog(view, "Создание записи", width: 500, height: 500);
        DataBind();
    }

    /// <summary>
    /// Вызов команды редактирования выбранной записи из таблицы
    /// </summary>
    /// <param name="sender"></param>
    private void EditEntity(object sender)
    {
        if (!HasSelectedItem())
        {
            return;
        }

        var view = new AvailibilityInRestaurantWindow(ServiceProvider, SelectedItem.Id, _restaurantId);
        WindowHelper.ShowDialog(view, "Редактирование записи", width: 500, height: 500);
        DataBind();
    }

    /// <summary>
    /// Удалить выбранную запись
    /// </summary>
    /// <param name="sender"></param>
    private void DeleteEntity(object sender)
    {
        if (!HasSelectedItem())
        {
            return;
        }

        if (MessageBox.Show("Удалить заявку?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
        {
            _availibilityInRestaurantService.Delete(SelectedItem.Id);
        }
        else
        {
            return;
        }

        DataBind();
    }
}