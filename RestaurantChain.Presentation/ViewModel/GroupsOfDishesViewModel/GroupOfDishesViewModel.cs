﻿using System.Windows;

using RestaurantChain.Domain.Models;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.ViewModel.Base;

namespace RestaurantChain.Presentation.ViewModel.GroupsOfDishesViewModel;

internal class GroupOfDishesViewModel : EditViewModelBase
{
    private readonly IGroupsOfDishesService _groupsOfDishesService;

    private string _groupName;

    /// <summary>
    /// Модель данных. Имя
    /// </summary>
    public string GroupName
    {
        get => _groupName;
        set
        {
            _groupName = value;
            OnPropertyChanged();
        }
    }

    public GroupOfDishesViewModel(IGroupsOfDishesService groupsOfDishes, int? currentId) : base(currentId)
    {
        _groupsOfDishesService = groupsOfDishes;

        if (!Validate())
        {
            OnCancel?.Invoke();
        }

        EnterCommand = new RelayCommand(Enter);
    }

    /// <summary>
    /// Обработка команды нажатия кнопки сохранения данных
    /// </summary>
    /// <param name="sender"></param>
    public void Enter(object sender)
    {
        if (string.IsNullOrWhiteSpace(_groupName))
        {
            MessageBox.Show("Введите название группы!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

            return;
        }

        bool result = CurrentId.HasValue ? Update() : Create();

        if (result)
        {
            OnSaveSuccess?.Invoke();
        }
    }

    /// <summary>
    ///  Действие обновить.
    /// </summary>
    /// <returns>Успех операции.</returns>
    private bool Update()
    {
        var group = new GroupsOfDishes
        {
            Id = CurrentId.Value,
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

    /// <summary>
    ///  Действие создать.
    /// </summary>
    /// <returns>Успех операции.</returns>
    private bool Create()
    {
        var group = new GroupsOfDishes
        {
            GroupName = _groupName
        };

        int id = _groupsOfDishesService.Create(group);

        if (id == 0)
        {
            MessageBox.Show("Такая группа уже существует!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

            return false;
        }

        return true;
    }

    /// <summary>
    /// Валидация при загрузке и заполнение полей
    /// </summary>
    /// <returns></returns>
    public override bool Validate()
    {
        if (CurrentId.HasValue)
        {
            GroupsOfDishes? group = _groupsOfDishesService.Get(CurrentId.Value);

            if (group == null)
            {
                MessageBox.Show("Такой группы не существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }

            GroupName = group.GroupName;

            return true;
        }

        return true;
    }
}